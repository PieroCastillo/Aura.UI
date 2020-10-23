//using Avalonia;
//using Avalonia.Collections;
//using Avalonia.Controls;
//using Avalonia.Controls.Generators;
//using Avalonia.Controls.Presenters;
//using Avalonia.Controls.Templates;
//using Avalonia.Input;
//using Avalonia.LogicalTree;
//using Avalonia.Metadata;
//using Avalonia.Styling;
//using Avalonia.VisualTree;
//using DynamicData;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Text;

//namespace Aura.UI.Controls.Primitives
//{
//    public class ItemsWindow : Window
//    {
//        #region Properties
//        private IEnumerable _items = new AvaloniaList<object>();
//        public IEnumerable Items
//        {
//            get => _items;
//            set => SetAndRaise(ItemsProperty, ref _items, value);
//        }
//        public static readonly DirectProperty<ItemsWindow, IEnumerable> ItemsProperty =
//            AvaloniaProperty.RegisterDirect<ItemsWindow, IEnumerable>(
//                nameof(Items),
//                o => o.Items,
//                (o, v) => o.Items = v);

//        private int _itemcount;
//        public int ItemCount
//        {
//            get => _itemcount;
//            private set => SetAndRaise(ItemCountProperty, ref _itemcount, value);
//        }
//        public static readonly DirectProperty<ItemsWindow, int> ItemCountProperty =
//            AvaloniaProperty.RegisterDirect<ItemsWindow, int>(
//                nameof(ItemCount),
//                o => o.ItemCount);

//        public ITemplate<IPanel> ItemsPanel
//        {
//            get => GetValue(ItemsPanelProperty);
//            set => SetValue(ItemsPanelProperty, value);
//        }
//        public readonly static StyledProperty<ITemplate<IPanel>> ItemsPanelProperty =
//            AvaloniaProperty.Register<ItemsWindow, ITemplate<IPanel>>(nameof(ItemsPanel));
//        public ITemplate ItemTemplate
//        {
//            get;
//            set;
//        }
//        public readonly static StyledProperty<ITemplate> ItemTemplateProperty;
//        public new IItemsPresenter Presenter
//        {
//            get;
//            protected set;
//        }
//        #endregion
//    }
//}
