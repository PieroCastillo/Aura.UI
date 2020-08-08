using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Media;

namespace Aura.UI.Animate
{
    public class BrushTransition : Transition<IBrush>
    {
        public override IObservable<IBrush> DoTransition(IObservable<double> progress, IBrush oldValue, IBrush newValue)
        {
            return progress .Select(p =>
            {
                var f = Easing.Ease(p);
                return (IBrush)new SolidColorBrush() {
                   Opacity = ((newValue.Opacity - oldValue.Opacity) * f) + oldValue.Opacity
                };
            });
        }
    }
}
