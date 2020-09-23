using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Attributes
{
    /// <summary>
    /// This attribute shows a reason to shouldn't use the attributed object
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DonotUseAttribute : Attribute
    {
        /// <summary>
        /// Why shouldn't be used
        /// </summary>
        public string Reason
        {
            get;set;
        }
    }
}
