using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Attributes
{
    /// <summary>
    /// This Attribute should be used when the Control has a Parts in its template
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TemplatePartAttribute : Attribute
    {
        public TemplatePartAttribute()
        {

        }
        /// <summary>
        ///     Part name used by the class to indentify required element in the style
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        ///     Type of the element that should be used as a part with name specified in TemplatePartAttribute.Name
        /// </summary>
        public Type Type
        {
            get; set;
        }
    }
}
