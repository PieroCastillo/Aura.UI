using Aura.UI.Attributes;
using Aura.UI.Collections;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    [Primitive]
    public class SliderBase<TCustomValue> : TemplatedControl
    {
        #region Properties
        public MultiValueTrackBase<TCustomValue> Track
        {
            get { return GetValue(TrackProperty); }
            set { SetValue(TrackProperty, value); }
        }
        public static readonly StyledProperty<MultiValueTrackBase<TCustomValue>> TrackProperty =
            AvaloniaProperty.Register<SliderBase<TCustomValue>, MultiValueTrackBase<TCustomValue>>(nameof(Track));

        public Orientation Orientation
        {
            get { return GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        public readonly static StyledProperty<Orientation> OrientationProperty =
            AvaloniaProperty.Register<SliderBase<TCustomValue>, Orientation>(nameof(Orientation), Orientation.Horizontal);
        public bool CanDeleteThumbs
        {
            get { return GetValue(CanDeleteThumbsProperty); }
            set { SetValue(CanDeleteThumbsProperty, value); }
        }
        public readonly static StyledProperty<bool> CanDeleteThumbsProperty =
            AvaloniaProperty.Register<SliderBase<TCustomValue>, bool>(nameof(CanDeleteThumbs), true);

        public SelectableThumbs<TCustomValue> SelectableThumbs
        {
            get { return GetValue(SelectableThumbsProperty); }
            set { SetValue(SelectableThumbsProperty, value); }
        }
        public static readonly StyledProperty<SelectableThumbs<TCustomValue>> SelectableThumbsProperty =
            AvaloniaProperty.Register<MultiValueTrackBase<TCustomValue>, SelectableThumbs<TCustomValue>>(nameof(SelectableThumbs));

        #endregion

        #region Funcionalities
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            if(e.GetCurrentPoint(this).Properties.IsLeftButtonPressed == true)
            {                
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        SelectableThumbs.Insert((int)e.GetCurrentPoint(this).Position.X,new SelectableThumb<TCustomValue>());
                        break;
                    case Orientation.Vertical:
                        SelectableThumbs.Insert((int)e.GetCurrentPoint(this).Position.Y, new SelectableThumb<TCustomValue>());
                        break;
                }
            }
        }
        #endregion
    }
}
