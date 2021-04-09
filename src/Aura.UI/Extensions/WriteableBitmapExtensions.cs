using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Aura.UI.Extensions
{
    public static class WriteableBitmapExtensions
    {
        public static void SetPixel(this WriteableBitmap wrbitmap, int row, int column, Color color)
        {
            try
            {
                using (var fb = wrbitmap.Lock())
                {
                    int[] data = new int[fb.Size.Width * fb.Size.Height];
                    Marshal.Copy(source: fb.Address, data, 0, fb.Size.Width * fb.Size.Height);
                    var intcolor = (int)color.ToUint32();
                    data[column * fb.Size.Width + row] = intcolor;
                    Marshal.Copy(data, 0, fb.Address, fb.Size.Width * fb.Size.Height);
                }
            }
            catch
            {

            }
        }

        public static Color GetPixel(this WriteableBitmap wrbitmap, int row, int column)
        {
            try
            {
                using (var fb = wrbitmap.Lock())
                {
                    int[] data = new int[fb.Size.Width * fb.Size.Height];
                    Marshal.Copy(source: fb.Address, data, 0, fb.Size.Width * fb.Size.Height);
                    var intcolor = data[column * fb.Size.Width + row];
                    return Color.FromUInt32((uint)intcolor);
                }
            }
            catch
            {
                return Colors.Black;
            }
        }
    }
}
