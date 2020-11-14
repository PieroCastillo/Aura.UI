using Avalonia.Controls;
using Avalonia.LogicalTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.UI.UIExtensions
{
    public static class LogicalExtensions
    {
        /// <summary>
        /// Return a window of the ILogical indicated
        /// </summary>
        /// <param name="Logical">The window to get its parent</param>
        /// <returns>the window of the control</returns>
        public static Window GetParentWindowOfLogical(this ILogical Logical)  
        {
            return Logical.GetParentTOfLogical<Window>();
        }
        /// <summary>
        /// Return a parent of the ILogical indicated
        /// </summary>
        /// <param name="Logical">The control to get its parent</param>
        /// <returns>the parent of the control</returns>
        public static T GetParentTOfLogical<T>(this ILogical logical) where T : class
        {
            return logical.GetSelfAndLogicalAncestors().OfType<T>().FirstOrDefault<T>();
        }
    }
}
