using Aura.UI.Controls.Generators;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;

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