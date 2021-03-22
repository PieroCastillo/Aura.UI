using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aura.UI.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
