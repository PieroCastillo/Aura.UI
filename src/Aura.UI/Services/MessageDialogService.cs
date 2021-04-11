using Aura.UI.Controls;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Aura.UI.Services
{
    public static class MessageDialogService
    {
        public static void NewMessageDialog(this Control owner,
                                            object title,
                                            object content,
                                            Action<object, RoutedEventArgs>? OnClosing) => NewMessageDialog<MessageDialog>(owner, title, content, OnClosing);

        public static void NewMessageDialog<TMessageDialog>(this Control owner,
                                            object title,
                                            object content,
                                            Action<object, RoutedEventArgs>? OnClosing)
            where TMessageDialog : MessageDialog, new()
        {
            var m = new TMessageDialog();
            m.SetOwner(owner);

            m.Content = content;
            m.Title = title;

            if (OnClosing != null)
            {
                m.Closing += (s, e) =>
                {
                    OnClosing.Invoke(s, e);
                };
            }
            m.Show();
        }
    }
}