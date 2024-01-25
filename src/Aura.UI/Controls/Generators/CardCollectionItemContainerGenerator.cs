using Aura.UI.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Data;

namespace Aura.UI.Controls.Generators
{
    public class CardCollectionItemContainerGenerator<TCardControl> : ItemContainerGenerator<TCardControl> where TCardControl : CardControl, Control, new()
    {
        public CardCollectionItemContainerGenerator(
            Control owner,
            AvaloniaProperty contentProperty,
            AvaloniaProperty contentTemplateProperty,
            AvaloniaProperty headerProperty,
            AvaloniaProperty secondaryHeaderProperty,
            AvaloniaProperty commandProperty,
            AvaloniaProperty commandParameterProperty)
            : base(owner, contentProperty, contentTemplateProperty)
        {
            HeaderProperty = headerProperty;
            SecondaryHeaderProperty = secondaryHeaderProperty;
            CommandProperty = commandProperty;
            CommandParameterProperty = commandParameterProperty;
        }

        protected AvaloniaProperty HeaderProperty, SecondaryHeaderProperty, CommandProperty, CommandParameterProperty;

        protected override Control CreateContainer(object item)
        {
            var container = item as TCardControl;

            if (container is not null)
            {
                return container;
            }
            else if (item is ICardControlTemplate temp)
            {
                var result = new TCardControl();

                result.SetValue(SecondaryHeaderProperty, temp.SecondaryHeader, BindingPriority.Style);
                result.SetValue(ContentProperty, temp.Content, BindingPriority.Style);
                result.SetValue(HeaderProperty, temp.Header, BindingPriority.Style);
                result.SetValue(CommandProperty, temp.Command, BindingPriority.Style);
                result.SetValue(CommandParameterProperty, temp.CommandParameter, BindingPriority.Style);

                return result;
            }
            else
            {
                return new TCardControl();
            }
        }
    }
}