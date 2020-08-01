

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    public class SuperListBoxItem : ListBoxItem
    {
        Button AnyControlContainer;
        TextBlock Text1Container;
        TextBlock Text2Container;
        public SuperListBoxItem()
        {
            this.InitializeComponent();
            AnyControlContainer = this.Find<Button>("ImageContent");
            Text1Container = this.Find<TextBlock>("PrincipalText");
            Text2Container = this.Find<TextBlock>("SecondaryText");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        //Text 1
        public string Text1
        {
            get { return GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }
        public static readonly StyledProperty<string> Text1Property =
            AvaloniaProperty.Register<SuperListBoxItem, string>(nameof(Text1), "NombreDeObjeto");
        //Text 2
        public string Text2
        {
            get { return GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }
        public static readonly StyledProperty<string> Text2Property =
            AvaloniaProperty.Register<SuperListBoxItem, string>(nameof(Text2), "NombreDeUbicación");
        //Image 
        public Control AnyControl
        {
            get { return GetValue(AnyControlProperty); }
            set { SetValue(AnyControlProperty, value); }
        }
        public static readonly StyledProperty<Control> AnyControlProperty =
            AvaloniaProperty.Register<SuperListBoxItem, Control>(nameof(AnyControl));
    }
}
