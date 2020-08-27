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
        public static Window GetParentWindowOfLogical(this ILogical Logical)  
        {
            return Logical.GetParentTOfLogical<Window>();
        }

        public static T GetParentTOfLogical<T>(this ILogical Logical) where T : class
        {
            return Logical.GetSelfAndLogicalAncestors().OfType<T>().FirstOrDefault<T>();
        }
    }
}
