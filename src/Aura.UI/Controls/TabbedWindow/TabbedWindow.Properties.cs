using Avalonia;
using Avalonia.Collections;
using Avalonia.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class TabbedWindow
    {
        #region Properties
        /// <summary>
        /// Sets the margin of the itemspresenter
        /// </summary>
        public Thickness ItemsMargin
        {
            get => GetValue(ItemsMarginProperty);
            set => SetValue(ItemsMarginProperty, value);
        }
        public readonly static StyledProperty<Thickness> ItemsMarginProperty =
            AvaloniaProperty.Register<AuraTabView, Thickness>(nameof(ItemsMargin));

        /// <summary>
        /// Gets or Sets the SecondaryBackground
        /// </summary>
        public IBrush SecondaryBackground
        {
            get => GetValue(SecondaryBackgroundProperty);
            set => SetValue(SecondaryBackgroundProperty, value);
        }
        public readonly static StyledProperty<IBrush> SecondaryBackgroundProperty =
            AvaloniaProperty.Register<AuraTabView, IBrush>(nameof(SecondaryBackground));

        protected IEnumerable _tabitems = new AvaloniaList<AuraTabItem>();
        public IEnumerable TabItems
        {
            get => _tabitems;
            set => SetAndRaise(TabItemsProperty, ref _tabitems, value);
        }
        public static readonly DirectProperty<TabbedWindow, IEnumerable> TabItemsProperty =
            AvaloniaProperty.RegisterDirect<TabbedWindow, IEnumerable>(
                nameof(TabItems),
                o => o.TabItems,
                (o, v) => o.TabItems = v);
        #endregion
    }
}
