using Avalonia;
using Avalonia.Controls.Presenters;
using System;

namespace Aura.UI.Controls.Presenters
{
    public class AuraContentPresenter : ContentPresenter
    {
        static AuraContentPresenter()
        {
            ContentProperty.Changed.Subscribe(ContentSuscribe);
        }

        private static void ContentSuscribe(AvaloniaPropertyChangedEventArgs<object> e)
        {
            var acp = e.Sender as AuraContentPresenter;
            if (acp != null)
            {
                if (acp.Content is string)
                {
                    acp.ContentIsString = true;
                }
                else
                {
                    acp.ContentIsString = false;
                }
            }
        }

        private bool _ContentIsString;

        public bool ContentIsString
        {
            get => _ContentIsString;
            private set => SetAndRaise(ContentIsStringProperty, ref _ContentIsString, value);
        }

        public readonly static DirectProperty<AuraContentPresenter, bool> ContentIsStringProperty =
            AvaloniaProperty.RegisterDirect<AuraContentPresenter, bool>(nameof(ContentIsString), o => o.ContentIsString);
    }
}