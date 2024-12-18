using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using System;

namespace Aura.UI.Controls
{
    public partial class Badge : ContentControl
    {
        private ContentPresenter _badgePresenter = new();

        static Badge()
        {
            ClipToBoundsProperty.OverrideDefaultValue<Badge>(false);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this.GetControl(e, "PART_BadgePresenter", out _badgePresenter);

            if(_badgePresenter is null)
                throw new Exception("BadgePresenter not found");
            
            _badgePresenter.GetObservable(ContentProperty).Subscribe(SetBadgeMargin);
            BoundsProperty.Changed.Subscribe(SetBadgeMargin);
        }

        void SetBadgeMargin(object? @object)
        {
            double top = 0, left = 0, right = 0, bottom = 0;

            switch (BadgePosition)
            {
                case BadgePosition.Right:
                    right = -_badgePresenter.Bounds.Width / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Center;
                    BadgeHorizontalAlignment = HorizontalAlignment.Right;
                    break;

                case BadgePosition.Left:
                    left = -_badgePresenter.Bounds.Width / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Center;
                    BadgeHorizontalAlignment = HorizontalAlignment.Left;
                    break;

                case BadgePosition.Top:
                    top = -_badgePresenter.Bounds.Height / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Top;
                    BadgeHorizontalAlignment = HorizontalAlignment.Center;
                    break;

                case BadgePosition.Bottom:
                    bottom = -_badgePresenter.Bounds.Height / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Bottom;
                    BadgeHorizontalAlignment = HorizontalAlignment.Center;
                    break;

                case BadgePosition.RightTop:
                    right = -_badgePresenter.Bounds.Width / 2;
                    top = -_badgePresenter.Bounds.Height / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Top;
                    BadgeHorizontalAlignment = HorizontalAlignment.Right;
                    break;

                case BadgePosition.LeftTop:
                    left = -_badgePresenter.Bounds.Width / 2;
                    top = -_badgePresenter.Bounds.Height / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Top;
                    BadgeHorizontalAlignment = HorizontalAlignment.Left;
                    break;

                case BadgePosition.RightBottom:
                    right = -_badgePresenter.Bounds.Width / 2;
                    bottom = -_badgePresenter.Bounds.Height / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Bottom;
                    BadgeHorizontalAlignment = HorizontalAlignment.Right;
                    break;

                case BadgePosition.LeftBottom:
                    left = -_badgePresenter.Bounds.Width / 2;
                    bottom = -_badgePresenter.Bounds.Height / 2;
                    BadgeVerticalAlignment = VerticalAlignment.Bottom;
                    BadgeHorizontalAlignment = HorizontalAlignment.Left;
                    break;
            }

            BadgeThickness = new(left, top, right, bottom);
        }
    }
}
