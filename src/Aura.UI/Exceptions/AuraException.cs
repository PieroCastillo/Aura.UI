using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Exceptions
{
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
