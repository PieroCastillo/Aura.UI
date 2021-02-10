using Aura.UI.Controls;
using Aura.UI.Controls.Primitives;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using System.Diagnostics;

#nullable enable
namespace Aura.UI.Services
{
    public static partial class ContentDialogService
    {
        internal static void ShowDialogOn(Control window, Control dialog)
        {
            Dispatcher.UIThread.Post(() =>
            {
                dialog.Width = window.Bounds.Width;
                dialog.Height = window.Bounds.Height;
                window.PropertyChanged += (s, e) =>
                {
                    dialog.Width = window.Bounds.Width;
                    dialog.Height = window.Bounds.Height;
                };
                var layer = OverlayLayer.GetOverlayLayer(window);
                layer.Children.Add(dialog);
            });
        }

        internal static void CloseDialogOn(Control window, Control dialog)
        {
            Dispatcher.UIThread.Post(() =>
            {
                var layer = OverlayLayer.GetOverlayLayer(window);
                if (layer.Children.Contains(dialog))
                {
                    layer.Children.Remove(dialog);
                }
            });
        }

        public static void NewContentDialog(this WindowBase owner,
                                         object content,
                                         Action<object, RoutedEventArgs>? OnOKButtonClick,
                                         Action<object, RoutedEventArgs>? OnCancelButtonClick,
                                         object? OkButtonContent,
                                         object? CancelButtonContent)
            => NewContentDialog<ContentDialog>(
                owner,
                content,
                OnOKButtonClick,
                OnCancelButtonClick,
                OkButtonContent,
                CancelButtonContent);

        /// <summary>
        /// Creates a new ContentDialog, you must set the window owner and the content, the rest parameters are optional, you can set them as null
        /// </summary>
        /// <param name="owner">the window owner</param>
        /// <param name="content">the ContentDialog content</param>
        /// <param name="OnOKButtonClick">This action is invoked when the Ok Button is clicked</param>
        /// <param name="OnCancelButtonClick">This action is invoked when the Cancel Button is clicked</param>
        /// <param name="OkButtonContent">The OkButton content, when is null the default content is "Ok"</param>
        /// <param name="CancelButtonContent">The CancelButton content, when is null the default content is "Cancel"</param>
        public static void NewContentDialog<TContentDialog>(this WindowBase owner,
                                         object content,
                                         Action<object, RoutedEventArgs>? OnOKButtonClick,
                                         Action<object, RoutedEventArgs>? OnCancelButtonClick,
                                         object? OkButtonContent,
                                         object? CancelButtonContent) where TContentDialog : ContentDialog, new()
        {
            var dialog = new TContentDialog();
            dialog.Content = content;
            dialog.SetOwner(owner);

            // returns Ok when OkButton content is false or returns the custom content
            dialog.OkButtonContent = OkButtonContent == null ? "Ok" : OkButtonContent;

            // the same but with CancelButton content
            dialog.CancelButtonContent = CancelButtonContent == null ? "Cancel" : CancelButtonContent;

            // sets the actions and the closing
            dialog.OkButtonClick += (s, e) =>
            {
                if (OnOKButtonClick != null)
                {
                    OnOKButtonClick.Invoke(s, e);
                }
                dialog.Close();
            };
            dialog.CancelButtonClick += (s, e) =>
            {
                if (OnCancelButtonClick != null)
                {
                    OnCancelButtonClick.Invoke(s, e);
                }
                dialog.Close();
            };
            dialog.Show();
        }

        public static void NewCustomContentDialog<TContentDialogBase>(this WindowBase owner,
                                                  object content,
                                                  Action<object, RoutedEventArgs>? OnShowing,
                                                  Action<object, RoutedEventArgs>? OnClosing)
                                                  where TContentDialogBase : ContentDialogBase, new()
        {
            var c = new TContentDialogBase();
            c.SetOwner(owner);
            c.Content = content;

            if (OnShowing != null)
            {
                c.Showing += (s, e) =>
                {
                    OnShowing.Invoke(s, e);
                };
            }

            if (OnClosing != null)
            {
                c.Closing += (s, e) =>
                {
                    OnClosing.Invoke(s, e);
                };
            }

            c.Show();
        }
    }
}