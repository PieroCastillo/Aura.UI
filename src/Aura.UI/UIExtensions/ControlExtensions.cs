using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.UIExtensions
{
    public static class ControlExtensions
    {
        public static Rect GetAbsolutePlacement(this Control element, bool relativeToScreen = false)
        {
            var absolutePos = element.PointToScreen(new Point(0, 0));
            if (relativeToScreen)
            {
                return new Rect(absolutePos.X, absolutePos.Y, element.Width, element.Height);
            }
            var posMW = (Application.Current.ApplicationLifetime as ClassicDesktopStyleApplicationLifetime).MainWindow.PointToScreen(new Point(0, 0));
            var x_ = absolutePos.X - posMW.X;
            var y_ = absolutePos.Y - posMW.Y;
            absolutePos = new PixelPoint(x_ , y_);
            return new Rect(absolutePos.X, absolutePos.Y, element.Width, element.Height);
        }
    }
}
