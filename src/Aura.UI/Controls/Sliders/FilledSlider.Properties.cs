using Avalonia;
using Avalonia.Controls.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public  partial class FilledSlider
    {
        /// <summary>
        /// Template for the Thumb of the <see cref="FilledSlider"/>
        /// </summary>
        public IControlTemplate ThumbTemplate
        {
            get { return GetValue(ThumbTemplateProperty); }
            set { SetValue(ThumbTemplateProperty, value); }
        }
        public static readonly StyledProperty<IControlTemplate> ThumbTemplateProperty =
            AvaloniaProperty.Register<FilledSlider, IControlTemplate>(nameof(ThumbTemplate));

        /// <summary>
        /// Shows a content in the right
        /// </summary>
        public object RightContent
        {
            get { return GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }
        public static readonly StyledProperty<object> RightContentProperty =
            AvaloniaProperty.Register<FilledSlider, object>(nameof(RightContent), "Right");

        /// <summary>
        /// Shows a content in the left
        /// </summary>
        public object LeftContent
        {
            get { return GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }
        public static readonly StyledProperty<object> LeftContentProperty =
            AvaloniaProperty.Register<FilledSlider, object>(nameof(LeftContent), "Left");
    }
}
