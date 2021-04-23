using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Subjects;
using System.Windows.Input;
using Aura.UI.Controls.Generators;
using Aura.UI.Data;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;
using Avalonia.Data;

namespace Aura.UI.Controls
{
    public partial class CardCollection : HeaderedItemsControl
    {
        protected override IItemContainerGenerator CreateItemContainerGenerator()
        {
            return new CardCollectionItemContainerGenerator<CardControl>(
                this, 
                CardControl.ContentProperty,
                CardControl.ContentTemplateProperty, 
                CardControl.HeaderProperty, 
                CardControl.SecondaryHeaderProperty,
                CardControl.CommandProperty,
                CardControl.CommandParameterProperty);
        }
    }

    public enum CardCollectionTileMode
    {
        HorizontalDisposition,
        VerticalDisposition,
        UniformDisposition
    }
}