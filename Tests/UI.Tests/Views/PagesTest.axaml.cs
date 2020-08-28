using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Toolkit.Extensions;

namespace UI.Tests.Views
{
    public class PagesTest : Window
    {
        Button NextPage_btn;
        Button PreviousPage_btn;
        PagesView pagesvw;
        TextBox goto_box;
        Button goto_btn;
        public PagesTest()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            PreviousPage_btn = this.Find<Button>("P_pages");
            NextPage_btn = this.Find<Button>("N_pages");
            pagesvw = this.Find<PagesView>("PagesVW");
            goto_box = this.Find<TextBox>("GotoPage");
            goto_btn = this.Find<Button>("Goto_btn");

            PreviousPage_btn.Click += PreviousPage_btn_Click;
            NextPage_btn.Click += NextPage_btn_Click;
            goto_btn.Click += Goto_btn_Click;
        }

        private void Goto_btn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (goto_box.Text.IsNumeric() == true)
            {
                pagesvw.GoTo(int.Parse(goto_box.Text));
            }
        }


        private void NextPage_btn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pagesvw.Next();
        }

        private void PreviousPage_btn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pagesvw.Previous();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
