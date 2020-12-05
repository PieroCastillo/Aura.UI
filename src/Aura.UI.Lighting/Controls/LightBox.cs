using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;

namespace Aura.UI.Lighting.Controls
{
    public partial class LightBox : Decorator
    {
        public Point GetLightPoint()
        {
            object p = LightPoint.GetValue();

            return Getpoint(p);
        }

        private Point Getpoint(object p)
        {
            //var s = (LightDefaultPositions)p;

            if (p is LightDefaultPositions s)
            {
                switch (s)
                {
                    case LightDefaultPositions.Center: 
                        return new Point(Bounds.Width / 2, Bounds.Height / 2);
                    case LightDefaultPositions.BottomLeft:
                        return new Point(0,0);
                    case LightDefaultPositions.BottomRight:
                        return new Point(Bounds.Width, 0);
                    case LightDefaultPositions.TopLeft:
                        return new Point(0, Bounds.Height);
                    case LightDefaultPositions.TopRight: 
                        return new Point(Bounds.Width, Bounds.Height);
                }
            }
                
            if (p is Point sp)
            {
                return sp;
            }
            else
            {
                return new Point(0,0);
            }
        }


        public void ArrangeShadows()
        {
            var children = (IList<Control>) this.GetLogicalDescendants();

            foreach (var child in children)
            {
                ShadowDecorator s = new ShadowDecorator(this);
                s.UpdateShadow(child);
                AdornerLayer.SetAdornedElement(s,child);
            }
        }

        private List<ShadowDecorator> _shadows = new List<ShadowDecorator>();
        
        public void UpdateShadows()
        {
            var children = (IList<Control>) this.GetLogicalDescendants();
            foreach (var child in children)
            {
                ShadowDecorator s = (ShadowDecorator)AdornerLayer.GetAdornedElement(child);
                s.UpdateShadow(child);
            }
        }
    }
}