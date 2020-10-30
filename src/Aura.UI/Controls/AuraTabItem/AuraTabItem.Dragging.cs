using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Native;
using Avalonia.Skia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.UI.Controls
{
    //public partial class AuraTabItem
    //{

    //    protected virtual void OnDragStarted(object sender, VectorEventArgs e)
    //    {
            
    //    }
    //    protected virtual void OnDragDelta(object sender, VectorEventArgs e)
    //    {
    //        //this.Bounds.Translate(e.Vector);
    //    }
    //    protected virtual void OnDragCompleted(object sender, VectorEventArgs e)
    //    {
    //        //var r_ =  this.Bounds.Translate(e.Vector);
    //        //var tab_v = this.GetParentTOfLogical<TabControl>();
    //        //if(tab_v is AuraTabView v_)
    //        //{
    //        //    var intersect_y_n = RectHelper.CheckInOut(this.Bounds, v_.dock_container.Bounds);
    //        //    if (intersect_y_n)
    //        //    {
    //        //        tab_v.CloseTab(this);
    //        //        var win = new TabbedWindow();
    //        //        win.WindowState = 0;
    //        //        win.Position = r_.Position.ToAvnPoint().ToAvaloniaPixelPoint();
    //        //        win.AddTab(this);
    //        //        win.Show();
    //        //    }
    //        //    else if (!intersect_y_n)
    //        //    {

    //        //    }
    //        //}
    //    }

    //    public event EventHandler<VectorEventArgs> DragStarted
    //    {
    //        add => AddHandler(DragStartedEvent, value);
    //        remove => RemoveHandler(DragStartedEvent, value);
    //    }
    //    public static readonly RoutedEvent<VectorEventArgs> DragStartedEvent =
    //        RoutedEvent.Register<AuraTabItem, VectorEventArgs>(nameof(DragStarted), RoutingStrategies.Bubble);

    //    public bool BlockXDrag
    //    {
    //        get => GetValue(BlockXDragProperty);
    //        set => SetValue(BlockXDragProperty, value);
    //    }
    //    public static readonly StyledProperty<bool> BlockXDragProperty =
    //        AvaloniaProperty.Register<AuraTabItem, bool>(nameof(BlockXDrag), false);

    //    public bool BlockYDrag
    //    {
    //        get => GetValue(BlockYDragProperty);
    //        set => SetValue(BlockYDragProperty, value);
    //    }
    //    public static readonly StyledProperty<bool> BlockYDragProperty =
    //        AvaloniaProperty.Register<AuraTabItem, bool>(nameof(BlockYDrag), true);
    //}
}
