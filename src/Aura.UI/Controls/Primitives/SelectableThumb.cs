using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls.Mixins;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public class SelectableThumb<TCustomValue> : Thumb, ISelectableThumb, ICustomValueControl<TCustomValue>
    {
        public SelectableThumb()
        {
            this.DoubleTapped += OnDoubleTapped;
        }

        static SelectableThumb()
        {
            SelectableMixin.Attach<SelectableThumb<TCustomValue>>(IsSelectedProperty);
            PressedMixin.Attach<SelectableThumb<TCustomValue>>();
        }

        #region Funcionalities 
        protected virtual void OnDoubleTapped(object sender, RoutedEventArgs e)
        {
            try
            {
                var sl_base = this.GetParentTOfLogical<SliderBase<TCustomValue>>();
                if(sl_base.CanDeleteThumbs != false)
                {
                    sl_base.SelectableThumbs.Remove(this);
                }
            }
            catch
            {

            }
        }
        #endregion

        #region Properties
        public TCustomValue Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly StyledProperty<TCustomValue> ValueProperty =
            AvaloniaProperty.Register<SelectableThumb<TCustomValue>, TCustomValue>(nameof(Value));

        public bool IsSelected
        {
            get { return GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<SelectableThumb<TCustomValue>, bool>(nameof(IsSelected), false);

        public double RelativePosition
        {
            get { return GetValue(RelativePositionProperty); }
            set { SetValue(RelativePositionProperty, value); }
        }
        public static readonly StyledProperty<double> RelativePositionProperty =
            AvaloniaProperty.Register<SelectableThumb<TCustomValue>, double>(nameof(Value));
        #endregion
    }
}
