using Aura.UI.Exceptions;
using Aura.UI.Mobile.Dialogs;
using Aura.UI.Mobile.Primitives;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Mobile.Material
{
    public class AlertDialog : AlertDialogBase
    {
        public static void Show(Panel container, AlertDialogParameters parameters)
        {
            var dlg = new AlertDialog();
            dlg.ApplyAlertDialogParameters(parameters);
            container.Children.Add(dlg);

            dlg.AgreeButton.Click += (sender, e) =>
            {
                try
                {
                    container.Children.Remove(dlg);
                }
                catch
                {
                    throw new AuraException<AlertDialog>("The Panel does not exist");
                }
            };

            dlg.CancelButton.Click += (sender, e) =>
            {
                try
                {
                    container.Children.Remove(dlg);
                }
                catch
                {
                    throw new AuraException<AlertDialog>("The Panel does not exist");
                }
            };
        }
    }
}
