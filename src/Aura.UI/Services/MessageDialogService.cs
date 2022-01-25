using Aura.UI.Controls;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using JetBrains.Annotations;
using System;

namespace Aura.UI.Services
{
    public static class MessageDialogService
    {
        public static void NewMessageDialog(this Control owner,
                                            object title,
                                            object content,
                                            Action<object, RoutedEventArgs>? OnClosing, [CanBeNull] IImage icon = null) => NewMessageDialog<MessageDialog>(owner, title, content, OnClosing, icon);

        public static void NewMessageDialog<TMessageDialog>(this Control owner,
                                            object title,
                                            object content,
                                            Action<object, RoutedEventArgs>? OnClosing, [CanBeNull] IImage icon = null)
            where TMessageDialog : MessageDialog, new()
        {
            var m = new TMessageDialog();
            m.SetOwner(owner);

            m.Content = content;
            m.Title = title;
            if (icon != null)
                m.Icon = icon;

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