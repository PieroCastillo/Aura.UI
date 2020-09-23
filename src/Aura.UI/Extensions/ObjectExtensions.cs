using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.UIExtensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Clones an instance of class
        /// </summary>
        /// <typeparam name="T">Type of instanced class</typeparam>
        /// <param name="source">the instance to clone</param>
        /// <returns>the clone of the instance</returns>
        public static T CloneElement<T>(this object source) where T : class
        {
            T result = Activator.CreateInstance<T>();
            return result;
        }
    }
}
