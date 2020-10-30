using Aura.UI.Attributes;
using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Editors
{
    public class LayoutEditor : ContentControl
    {
        Thumb Top;
        Thumb Right;
        Thumb Left;
        Thumb Bottom;

        Thumb TopLeft;
        Thumb TopRight;
        Thumb BottomLeft;
        Thumb BottomRight;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            // defines thumbs
            Top = this.GetControl<Thumb>(e, "PART_Thumb_Top");
            Bottom = this.GetControl<Thumb>(e, "PART_Thumb_Bottom");
            Left = this.GetControl<Thumb>(e, "PART_Thumb_Left");
            Right = this.GetControl<Thumb>(e, "PART_Thumb_Right");

            TopLeft = this.GetControl<Thumb>(e, "PART_Thumb_TopLeft");
            TopRight = this.GetControl<Thumb>(e, "PART_Thumb_TopRight");
            BottomLeft = this.GetControl<Thumb>(e, "PART_Thumb_BottomLeft");
            BottomRight = this.GetControl<Thumb>(e, "PART_Thumb_BottomRight");

            // defines border controllers
            SetThumbFunction(Top, Side.Top);
            SetThumbFunction(Bottom, Side.Bottom);
            SetThumbFunction(Left, Side.Left);
            SetThumbFunction(Right, Side.Right);
            // defines corner controllers
            SetThumbFunction(TopLeft, Corner.TopLeft);
            SetThumbFunction(TopRight, Corner.TopRight);
            SetThumbFunction(BottomLeft, Corner.BottomLeft);
            SetThumbFunction(BottomRight, Corner.BottomRight);
        }

        protected void SetThumbFunction(Thumb t, Side side)
        {
            t.DragDelta += (s, e) =>
            {
                this.NewSizeBySide(e, side);
            };
            t.DragCompleted += (s, e) =>
            {
                this.NewSizeBySide(e, side);
            };
        }
        protected void SetThumbFunction(Thumb t, Corner corner)
        {
            t.DragDelta += (s, e) =>
            {
                this.NewSizeByCorner(e, corner);
            };
            t.DragCompleted += (s, e) =>
            {
                this.NewSizeByCorner(e, corner);
            };
        }


        public EditMode EditMode
        {
            get => GetValue(EditModeProperty);
            set => SetValue(EditModeProperty, value);
        }
        public static readonly StyledProperty<EditMode> EditModeProperty =
            AvaloniaProperty.Register<LayoutEditor, EditMode>(nameof(LayoutEditor), EditMode.Resize);
    }

    public enum EditMode
    {
        Rotate,
        Resize
    }
}
