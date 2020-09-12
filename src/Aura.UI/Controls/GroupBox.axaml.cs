using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    public class GroupBox : HeaderedContentControl, ICustomCornerRadius, IMaterial
    {
        public GroupBox()
        {
            this.InitializeComponent();
        }

        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<GroupBox, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));
        public ExperimentalAcrylicMaterial Material
        {
            get { return GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }
        public static readonly StyledProperty<ExperimentalAcrylicMaterial> MaterialProperty =
            AvaloniaProperty.Register<GroupBox, ExperimentalAcrylicMaterial>(nameof(Material), 
                new ExperimentalAcrylicMaterial()
                {
                    TintColor = Colors.White,
                    MaterialOpacity = 0.5,
                    TintOpacity = 0.85
                });

        public bool MaterialIsVisible
        {
            get { return GetValue(MaterialIsVisibleProperty); }
            set { SetValue(MaterialIsVisibleProperty, value); }
        }
        public static readonly StyledProperty<bool> MaterialIsVisibleProperty =
             AvaloniaProperty.Register<MaterialButton, bool>(nameof(MaterialIsVisible), true);

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
