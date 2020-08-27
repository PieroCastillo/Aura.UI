using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Attributes
{
    public class InDevelopingAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InDevelopingFeaturesAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
