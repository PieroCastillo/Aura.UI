using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Styling;

namespace Aura.UI.Controls
{
    public class ResizeDecorator : TemplatedControl
    {
        // protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        // {
        //     base.OnPropertyChanged(change);
        //
        //     if (ItemToResize != null)
        //     {
        //         DataContext = ItemToResize;
        //         this.Width = ItemToResize.Bounds.Width;
        //         this.Height = ItemToResize.Bounds.Height;
        //         //Canvas.SetLeft(this, ItemToResize.Bounds.Left);
        //         this.SetValue(Canvas.LeftProperty, ItemToResize.Bounds.Left);
        //         //Canvas.SetTop(this, ItemToResize.Bounds.Top);
        //         this.SetValue(Canvas.TopProperty, ItemToResize.Bounds.Top);
        //     }
        // }

        public Canvas CanvasLimit
        {
            get => GetValue(CanvasLimitProperty);
            set => SetValue(CanvasLimitProperty, value);
        }

        public static readonly StyledProperty<Canvas> CanvasLimitProperty =
            AvaloniaProperty.Register<ResizeDecorator, Canvas>(nameof(CanvasLimit));

        private Control _itemtoresize = new Control();
        
        public Control ItemToResize
        {
            get => _itemtoresize;
            set => SetAndRaise(ItemToResizeProperty, ref _itemtoresize, value);
        }

        public static readonly DirectProperty<ResizeDecorator, Control> ItemToResizeProperty =
            AvaloniaProperty.RegisterDirect<ResizeDecorator, Control>(
                nameof(ItemToResize),
                o => o.ItemToResize,
                (o, s) => o.ItemToResize = s);
        
        public bool IsVisibleDecorations
        {
            get => GetValue(IsVisibleDecorationsProperty);
            set => SetValue(IsVisibleDecorationsProperty, value);
        }

        public static readonly StyledProperty<bool> IsVisibleDecorationsProperty =
            AvaloniaProperty.Register<ResizeDecorator, bool>(nameof(IsVisibleDecorations), true);
        
    }
}