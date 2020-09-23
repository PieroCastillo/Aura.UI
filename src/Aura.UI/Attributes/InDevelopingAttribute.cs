using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Attributes
{
    /// <summary>
    /// This atttibute is used when the control is in developing
    /// </summary>
    public class InDevelopingAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    
    /// <summary>
    /// Thiss attribute is used when a feature of the attributed control is in developing
    /// </summary>
    public class InDevelopingFeaturesAttribute : Attribute
    {
        /// <summary>
        /// Name of feature
        /// </summary>
        public string Name { get; set; }
    }
}
