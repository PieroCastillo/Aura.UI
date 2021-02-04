using System;

namespace Aura.UI.Attributes
{
    /// <summary>
    /// This attribute is used when the control is a primitive (usually does not have a template)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PrimitiveAttribute : Attribute
    {
    }
}