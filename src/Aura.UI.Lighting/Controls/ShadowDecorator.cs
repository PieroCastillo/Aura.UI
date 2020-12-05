using Avalonia.Controls;
using Avalonia.Media;

namespace Aura.UI.Lighting.Controls
{
    public class ShadowDecorator : Border
    {
        static ShadowDecorator()
        {
            IsHitTestVisibleProperty.OverrideDefaultValue<ShadowDecorator>(false);
        }

        public ShadowDecorator(LightBox _base)
        {
            _lightBox = _base;
        }

        private LightBox _lightBox;

        public void UpdateShadow(Control control)
        {
            var p = _lightBox.GetLightPoint();

            CornerRadius = LightBox.GetLightCornerRadius(control);
            
            var b = new BoxShadow();
            b.Blur = _lightBox.LightHeight;
            b.Color = Colors.Black;
            b.OffsetX = Bounds.Left - _lightBox.GetLightPoint().X - _lightBox.Bounds.Left;
            b.OffsetY = Bounds.Top - _lightBox.GetLightPoint().Y - _lightBox.Bounds.Top;

            BoxShadow = new BoxShadows(b);
        }
    }
}