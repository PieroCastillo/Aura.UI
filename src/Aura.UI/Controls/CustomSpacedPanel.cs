using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Aura.UI.Controls
{
    public class CustomSpacedPanel : WrapPanel
    {
        protected override void ChildrenChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.ChildrenChanged(sender, e);

            foreach(IControl control in this.Children)
            {
                var slider = new Slider();

            }
        }
    }
}
