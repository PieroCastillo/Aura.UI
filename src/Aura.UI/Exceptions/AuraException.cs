using System;

namespace Aura.UI.Exceptions
{
    /// <summary>
    /// Shows a exception of a control
    /// </summary>
    /// <typeparam name="TControl">Type of control that had the exception</typeparam>
    public class AuraException<TControl> : Exception
    {
        public AuraException()
        {
        }

        public AuraException(string message)
            : base(message)
        {
        }

        public AuraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}