//using Avalonia;
//using Avalonia.Markup.Xaml.Styling;
//using Avalonia.Styling;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Aura.UI.Managers
//{
//    public class Theme : AvaloniaObject, ITheme
//    {
//        public Styles Styles
//        {
//            get => GetValue(StylesProperty);
//            set => SetValue(StylesProperty, value);
//        }
//        public readonly static StyledProperty<Styles> StylesProperty =
//            AvaloniaProperty.Register<Theme, Styles>(nameof(Styles));
//        public string ID
//        {
//            get => GetValue(IDProperty);
//            set => SetValue(IDProperty, value);
//        }
//        public readonly static StyledProperty<string> IDProperty =
//            AvaloniaProperty.Register<AvaloniaObject, string>(nameof(ID));

//        public static ITheme CreateTheme(Styles styles, string @ID)
//        {
//            return new Theme { Styles = styles, ID = @ID};
//        }
//    }

//    public class DefaultThemes
//    {
//        protected IStyle lightResources = new StyleInclude(new Uri(""));
//        public static ITheme LightTheme = Theme.CreateTheme(, "LightTheme");
//        public static ITheme DarkTheme;
//    }
//}
