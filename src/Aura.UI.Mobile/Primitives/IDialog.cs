using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Mobile.Primitives
{
    public interface IDialog : IHeadered, IContentControl
    {
        public object AgreeButtonContent { get; set; }
    }
}
