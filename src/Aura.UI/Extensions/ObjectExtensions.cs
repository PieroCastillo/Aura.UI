using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.UIExtensions
{
    public static class ObjectExtensions
    {
        public static T CloneElement<T>(this object source) where T : class
        {
            T result = Activator.CreateInstance<T>();
            return result;
        }
    }
}
