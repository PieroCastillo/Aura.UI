using Aura.UI.Exceptions;
using Aura.UI.Mobile.Dialogs;
using Aura.UI.Mobile.Primitives;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Mobile.Cupertino
{
    public class CupertinoDialog : DialogBase
    {
        public static void Show(Panel container, DialogParameters parameters)
        {
            var dlg = new CupertinoDialog();
            dlg.ApplyDialogParameters(parameters);
            container.Children.Add(dlg);

            dlg.AgreeButton.Click += (sender, e) =>
            {
                try
                {
                    container.Children.Remove(dlg);
                }
                catch
                {
                    throw new AuraException<CupertinoDialog>("The Panel does not exist");
                }
            };

        }
    }
}
