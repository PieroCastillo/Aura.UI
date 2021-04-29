using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using System;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    [PseudoClasses(":closing")]
    public partial class MessageDialog : ContentDialogBase
    {
        private Button _closebutton;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _closebutton = this.GetControl<Button>(e, "PART_ButtonClose");
            _closebutton.Click += (s, e) =>
            {
                Close();
            };
        }

        /// <summary>
        /// Gets or Sets the title
        /// </summary>
        public object Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Defines <see cref="Title"/> Property
        /// </summary>
        public readonly static StyledProperty<object> TitleProperty =
            AvaloniaProperty.Register<MessageDialog, object>(nameof(Title), "Title");

        /// <summary>
        /// The Icon of the MessageDialog
        /// </summary>
        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Defines <see cref="Icon"/> Property
        /// </summary>
        public readonly static StyledProperty<IImage> IconProperty =
            AuraTabItem.IconProperty.AddOwner<MessageDialog>();
    }
}