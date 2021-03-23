using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using System.Diagnostics;

namespace Aura.UI.Controls.Primitives
{
    /// <summary>
    /// This window has custom border, but does not have template, because it's a primitive control <br/>
    /// This window should have the Follow Parts: <br/>
    /// Sides: <br/>
    /// Name = "PART_LeftBorder", Type = typeof(Border))<br/>
    /// Name = "PART_RightBorder", Type = typeof(Border))<br/>
    /// Name = "PART_TopBorder", Type = typeof(Border))<br/>
    /// Name = "PART_BottomBorder", Type = typeof(Border))<br/>
    /// Corners:<br/>
    /// Name = "PART_TopLeftBorder", Type = typeof(Border))<br/>
    /// Name = "PART_TopRightBorder", Type = typeof(Border))<br/>
    /// Name = "PART_BottomLeftBorder", Type = typeof(Border))<br/>
    /// Name = "PART_BottomRightBorder", Type = typeof(Border))<br/>
    /// </summary>
    public class CustomWindow : Window
    {
        public CustomWindow()
        {
            SystemDecorations = 0;
            InitializeBorderAndCorners();
        }

        protected void InitializeBorderAndCorners()
        {
            //Sides
            SetUpBorder<Border>("PART_LeftBorder", StandardCursorType.LeftSide, WindowEdge.West);
            SetUpBorder<Border>("PART_RightBorder", StandardCursorType.RightSide, WindowEdge.East);
            SetUpBorder<Border>("PART_TopBorder", StandardCursorType.TopSide, WindowEdge.North);
            SetUpBorder<Border>("PART_BottomBorder", StandardCursorType.BottomSide, WindowEdge.South);

            //Corners
            SetUpBorder<Border>("PART_TopLeftBorder", StandardCursorType.TopLeftCorner, WindowEdge.NorthWest);
            SetUpBorder<Border>("PART_TopRightBorder", StandardCursorType.TopRightCorner, WindowEdge.NorthEast);
            SetUpBorder<Border>("PART_BottomLeftBorder", StandardCursorType.BottomLeftCorner, WindowEdge.SouthWest);
            SetUpBorder<Border>("PART_BottomRightBorder", StandardCursorType.BottomRightCorner, WindowEdge.SouthEast);
        }

        protected void ResetBordersAndCorners()
        {
            //Sides
            ResetBorder<Border>("PART_LeftBorder", WindowEdge.West);//, StandardCursorType.LeftSide
            ResetBorder<Border>("PART_RightBorder", WindowEdge.East);//, StandardCursorType.RightSide
            ResetBorder<Border>("PART_TopBorder", WindowEdge.North);//, StandardCursorType.TopSide
            ResetBorder<Border>("PART_BottomBorder", WindowEdge.South);//, StandardCursorType.BottomSide

            //Corners
            ResetBorder<Border>("PART_TopLeftBorder", WindowEdge.NorthWest);//, StandardCursorType.TopLeftCorner
            ResetBorder<Border>("PART_TopRightBorder", WindowEdge.NorthEast);//, StandardCursorType.TopRightCorner
            ResetBorder<Border>("PART_BottomLeftBorder", WindowEdge.SouthWest);//, StandardCursorType.BottomLeftCorner
            ResetBorder<Border>("PART_BottomRightBorder", WindowEdge.SouthEast);//, StandardCursorType.BottomRightCorner
        }

        protected void MakeWindowDragger(Control control)
        {
            control.PointerPressed += (s, e) =>
            {
                BeginMoveDrag(e);
            };
        }

        internal void SetUpBorder<T>(string name, StandardCursorType cursorType, WindowEdge edge) where T : Control
        {
            Control? ctl = this.Find<T>(name);
            if (ctl != null)
            {
                ctl.Cursor = new Cursor(cursorType);
                ctl.PointerPressed += (s, e_) =>
                {
                    BeginResizeDrag(edge, e_);
                };
            }
            else
            {
#if DEBUG
                Debug.WriteLine("The referenced control does not exist");
#endif
            }
        }

        internal void ResetBorder<T>(string name, WindowEdge edge) where T : Control
        {
            Control? ctl = this.Find<T>(name);
            if (ctl != null)
            {
                ctl.PointerPressed -= (s, e_) =>
                {
                    BeginResizeDrag(edge, e_);
                };
            }
            else
            {
#if DEBUG
                Debug.WriteLine("The referenced control does not exist");
#endif
            }
        }

        public object ContentView
        {
            get => GetValue(ContentViewProperty);
            set => SetValue(ContentViewProperty, value);
        }

        public readonly static StyledProperty<object> ContentViewProperty =
            AvaloniaProperty.Register<CustomWindow, object>(nameof(ContentView));
    }
}