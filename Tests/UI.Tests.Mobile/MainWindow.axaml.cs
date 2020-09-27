using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Aura.UI.Mobile;
using Aura.UI.Mobile.Material;
using Aura.UI.Mobile.Cupertino;
using Aura.UI.Mobile.Dialogs;

namespace UI.Tests.Mobile
{
    public class MainWindow : Window
    {
        Grid container1;
        Button alt_dlg_btn;
        Button alt_dlg_ios_btn;
        Button dlg_btn;
        Button dlg_ios_btn;

        public MainWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            container1 = this.Find<Grid>("container1");
            var dlg_param = new DialogParameters("Hey!", "Are you ready?", "Yes", DoNothing);
            var alt_param = new AlertDialogParameters(dlg_param, "No", DoNothing, true);

            dlg_btn = this.Find<Button>("dlg");
            dlg_btn.Click += (sender, e) =>
            {
                Dialog.Show(container1, dlg_param);
            };
            dlg_ios_btn = this.Find<Button>("ios_dlg");
            dlg_ios_btn.Click += (sender, e) =>
            {
                CupertinoDialog.Show(container1, dlg_param);
            };
            alt_dlg_btn = this.Find<Button>("alt_dlg");
            alt_dlg_btn.Click += (sender, e) =>
            {
                AlertDialog.Show(container1, alt_param);
            };
            alt_dlg_ios_btn = this.Find<Button>("ios_altdlg");
            alt_dlg_ios_btn.Click += (sender, e) =>
            {
                CupertinoAlertDialog.Show(container1, alt_param);
            };
        }

        public void DoNothing() { }
    }
}
