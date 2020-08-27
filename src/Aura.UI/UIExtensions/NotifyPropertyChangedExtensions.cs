using Aura.UI.Attributes;
using Aura.UI.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Aura.UI.UIExtensions
{
    [Experimental]
    public static class NotifyPropertyChangedExtensions
    {
        public static string NameOfProperty<T, TResult>(Expression<Func<T, TResult>> propertyExpression)
        {
            var member = propertyExpression.Body as MemberExpression;

            if (member == null || member.Member.MemberType != MemberTypes.Property)
                throw new AuraException<Expression>(String.Format("{0} is not a property", propertyExpression)); 

            return member.Member.Name;
        }

        public static bool IsProperty<T, TResult>(this PropertyChangedEventArgs me, Expression<Func<T, TResult>> propertyExpression)
        {
            return me.PropertyName == NameOfProperty(propertyExpression);
        }

        public static void FirePropertyChanged<T, TResult>(this T me, Expression<Func<T, TResult>> propertyExpression) where T : INotifyPropertyChanged
        {
            FirePropertyChanged(NameOfProperty(propertyExpression), me);
        }

        public static void FirePropertyChanged<T>(this T me, [CallerMemberName] string propertyName = null) where T : INotifyPropertyChanged
        {
            FirePropertyChanged(propertyName, me);
        }

        public static void Refresh<T>(this T me) where T : INotifyPropertyChanged
        {
            FirePropertyChanged("", me);
        }

        public static TResult IfNotNull<T, TResult>(this T me, Func<T, TResult> expression)
            where T : class
            where TResult : class
        {
            return me == null ? null : expression(me);
        }



        #region Utility functions

        private static void FirePropertyChanged(string propertyName, INotifyPropertyChanged obj)
        {
            var eventDelagate = (MulticastDelegate)GetPropertyChangedField(obj.GetType()).GetValue(obj);
            if (eventDelagate == null)
                return;

            var delegates = eventDelagate.GetInvocationList();
            foreach (var dlg in delegates)
                try
                {
                    dlg.Method.Invoke(dlg.Target, new object[] { obj, new PropertyChangedEventArgs(propertyName) });
                }
                catch (TargetInvocationException targetInvocationException)
                {
                    throw targetInvocationException.InnerException;
                }
        }

        private static FieldInfo GetPropertyChangedField(Type objType)
        {
            var property = objType.GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null) return property;

            if (objType.BaseType != null && objType.BaseType.GetInterface("INotifyPropertyChanged") != null)
                return GetPropertyChangedField(objType.BaseType);

            throw new AuraException<Type>("PropertyChanged event not implemented");
        }

        #endregion
    }
}
