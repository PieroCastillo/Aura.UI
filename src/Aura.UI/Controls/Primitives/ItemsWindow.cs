using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Controls.Utils;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.Metadata;
using Avalonia.VisualTree;
using System.Linq;
using Avalonia;

namespace Aura.UI.Controls
{
    public class ItemsWindow : ContentWindow
    {
        public List<Control> Items
        {
            get;
            set;
        }
    }
}
