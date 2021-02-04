using Aura.UI.UIExtensions;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace Aura.UI.Controls
{
    public partial class Follower : TemplatedControl
    {
        static Follower()
        {
            //IsHitTestVisibleProperty.OverrideDefaultValue<Follower>(false);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            CanvasLayer.Children.Add(LayerControl);
            LayerControl.PointerMoved += LayerControlOnPointerMoved;
        }

        private void LayerControlOnPointerMoved(object sender, PointerEventArgs e)
        {
            var cv = OverlayLayer.GetOverlayLayer(this.GetParentTOfVisual<Window>());

            double delta_v, delta_h;
            //double delta_vlow, delta_hlow;

            delta_v = e.GetCurrentPoint(FollowerControl).Position.Y; //Math.Min(e.GetCurrentPoint(FollowerControl).Position.Y, FollowerControl.Bounds.Height - FollowerControl.MinHeight);
            var t = Canvas.GetTop(FollowerControl) + delta_v;
            var t_ = t - (FollowerControl.Bounds.Height / 2);
            var t_s = cv.Bounds.Height - t_ - FollowerControl.Bounds.Height;//

            if (t_s >= 0)
            {
                Canvas.SetBottom(FollowerControl, t_s);
                if (t_ >= 0)//Canvas.GetTop(FollowerControl) >= 0 || Canvas.GetBottom(FollowerControl) >= 0
                {
                    Canvas.SetTop(FollowerControl, t_); //
                }
            }

            delta_h = e.GetCurrentPoint(FollowerControl).Position.X; //Math.Min(e.GetCurrentPoint(FollowerControl).Position.X, FollowerControl.Bounds.Width + FollowerControl.MinWidth);

            var l = Canvas.GetLeft(FollowerControl) + delta_h;

            var l_ = l - (FollowerControl.Bounds.Width / 2);

            var l_s = cv.Bounds.Width - l_ - FollowerControl.Bounds.Width;//

            if (l_s >= 0)
            {
                Canvas.SetRight(FollowerControl, l_s);
                if (l_ >= 0)//Canvas.GetLeft(FollowerControl) >= 0 || Canvas.GetRight(FollowerControl) >= 0
                {
                    Canvas.SetLeft(FollowerControl, l_);
                }
            }

#if DEBUG
            //   Debug.WriteLine($"moved to Top:{t_} Bottom:{t_s} Left:{l_} Right:{l_s}");
#endif
        }

        // protected override void OnPointerMoved(PointerEventArgs e)
        // {
        //     base.OnPointerMoved(e);
        //
        //     //if (FollowerControl != null)
        //     //{
        //
        //     var cv = CanvasLayer;
        //
        //     double delta_v, delta_h;
        //     //double delta_vlow, delta_hlow;
        //
        //     delta_v = e.GetCurrentPoint(FollowerControl).Position.Y; //Math.Min(e.GetCurrentPoint(FollowerControl).Position.Y, FollowerControl.Bounds.Height - FollowerControl.MinHeight);
        //         var t = Canvas.GetTop(FollowerControl) + delta_v;
        //         var t_ = t - (FollowerControl.Bounds.Height / 2);
        //         var t_s = cv.Bounds.Height - t_ - FollowerControl.Bounds.Height;//
        //
        //
        //         if (t_s >= 0)
        //         {
        //             Canvas.SetBottom(FollowerControl, t_s);
        //             if (t_ >= 0 )//Canvas.GetTop(FollowerControl) >= 0 || Canvas.GetBottom(FollowerControl) >= 0
        //             {
        //                 Canvas.SetTop(FollowerControl, t_); //
        //             }
        //         }
        //
        //         delta_h = e.GetCurrentPoint(FollowerControl).Position.X; //Math.Min(e.GetCurrentPoint(FollowerControl).Position.X, FollowerControl.Bounds.Width + FollowerControl.MinWidth);
        //
        //         var l = Canvas.GetLeft(FollowerControl) + delta_h;
        //
        //         var l_ = l - (FollowerControl.Bounds.Width / 2);
        //
        //
        //         var l_s = cv.Bounds.Width - l_ - FollowerControl.Bounds.Width;//
        //
        //
        //         if (l_s >= 0)
        //         {
        //             Canvas.SetRight(FollowerControl, l_s);
        //             if (l_ >= 0 )//Canvas.GetLeft(FollowerControl) >= 0 || Canvas.GetRight(FollowerControl) >= 0
        //             {
        //                 Canvas.SetLeft(FollowerControl, l_);
        //             }
        //         }
        //
        //     #if DEBUG
        //     Debug.WriteLine($"moved to Top:{t_} Bottom:{t_s} Left:{l_} Right:{l_s}");
        //     #endif
        //
        //         //}
        // }
    }
}