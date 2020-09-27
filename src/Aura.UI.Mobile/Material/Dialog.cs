using Aura.UI.Exceptions;
using Aura.UI.Mobile.Dialogs;
using Aura.UI.Mobile.Primitives;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Mobile.Material
{
    public class Dialog : DialogBase
    {
        public static void Show(Panel container, DialogParameters parameters)
        {
            var dlg = new Dialog();
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
                    throw new AuraException<Dialog>("The Panel does not exist");
                }
            };
        }
    }
}
