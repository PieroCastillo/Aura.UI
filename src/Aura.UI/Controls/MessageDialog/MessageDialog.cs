using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Text;

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
                this.Close();
            };
        }

        private object _title = "Title";
        /// <summary>
        /// Gets or Sets the title
        /// </summary>
        public object Title
        {
            get => _title;
            set => SetAndRaise(TitleProperty, ref _title, value);
        }
        /// <summary>
        /// Defines <see cref="Title"/>
        /// </summary>
        public readonly static DirectProperty<MessageDialog, object> TitleProperty =
            AvaloniaProperty.RegisterDirect<MessageDialog, object>(
                nameof(Title),
                o => o.Title,
                (o,v) => o.Title = v);

        public override void Close()
        {
            var t = new DispatcherTimer();
            t.Interval = new TimeSpan(0,0,0,0,500);
            t.Start();
            PseudoClasses.Add(":closing");
            t.Tick += (s, e) =>
            {
                base.Close();
            };
        }
    }
}
