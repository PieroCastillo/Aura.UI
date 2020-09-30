using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public class Follower : ContentControl
    {
        public Follower()
        {
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top;
            var win = this.GetParentWindowOfLogical();
            this.Owner = win;
            if(Owner != null)
            {
                Owner.PointerMoved += owner_PointerMoved;
            }
        }

        private void owner_PointerMoved(object sender, PointerEventArgs e)
        {
            if(KeepFollowing != false)
            {
                var x1 = e.GetPosition(this.GetParentWindowOfLogical()).X;
                var y1 = e.GetPosition(this.GetParentWindowOfLogical()).Y;

                X = x1;
                Y = x1;

                this.Margin = new Thickness(x1, y1);
            }
        }

        private void ProcessMargin(double Xtop, double Yleft)
        {
             
        }

        public bool KeepFollowing
        {
            get => GetValue(KeepFollowingProperty);
            set => SetValue(KeepFollowingProperty, value);
        }
        public readonly static StyledProperty<bool> KeepFollowingProperty =
            AvaloniaProperty.Register<Follower, bool>(nameof(KeepFollowing), false, inherits: true);

        public Control Owner
        {
            get => GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }
        public readonly static StyledProperty<Control> OwnerProperty =
            AvaloniaProperty.Register<Follower, Control>(nameof(Owner));

        private double X;
        private double Y;
    }
}
