using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Rendering.SceneGraph;
using Avalonia.Skia;

namespace Aura.UI.Rendering
{
    public abstract class AuraDrawOperationBase : ICustomDrawOperation
    {
        public AuraDrawOperationBase(Rect bounds)
        {
            Bounds = bounds;
        }

        public virtual Rect Bounds { get; private set; }

        public virtual void Dispose()
        {
            // do nothing
        }

        public virtual bool Equals(ICustomDrawOperation? other) => false;
        public virtual bool HitTest(Point p) => true;

        public virtual void Render(ImmediateDrawingContext context)
        {
        }
    }
}