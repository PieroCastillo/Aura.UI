using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DonotUseAttribute : Attribute
    {
        public string Reason
        {
            get;set;
        }
    }
}
