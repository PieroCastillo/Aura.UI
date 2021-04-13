using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using DynamicData;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":normal")]
    public partial class NavigationView : TreeView, IItemsPresenterHost, IContentPresenterHost, IHeadered
    {
        private NavigationViewItemBase _headeritem;
        private AutoCompleteBox _completeBox;
        //public Dictionary<int, object> History
        //{
        //    get;
        //    private set;
        //}

        static NavigationView()
        {
            SelectionModeProperty.OverrideDefaultValue<NavigationView>(SelectionMode.Single);
            SelectedItemProperty.Changed.AddClassHandler<NavigationView>((x, e) => x.OnSelectedItemChanged(x, e));
            FocusableProperty.OverrideDefaultValue<NavigationView>(true);
            IsOpenProperty.Changed.AddClassHandler<NavigationView>((x, e) => x.OnIsOpenChanged(x, e));
        }

        public NavigationView()
        {
            PseudoClasses.Add(":normal");
            //History = new();
        }

        protected override void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.ItemsCollectionChanged(sender, e);

            ProcessString();//Sets the items of AutoCompleteBox
        }

        protected virtual IEnumerable<string> ProcessString()
        {
            var l = new AvaloniaList<string>(); // create a list
            var items = this.GetLogicalDescendants().OfType<NavigationViewItem>(); //gets the NavigationViewItem descendants
            foreach (NavigationViewItem nav in items)
            {
                if (nav.Header != null)
                {
                    l.Add(nav.Header.ToString());  //sets the strings
                    // Debug.WriteLine(nav.Header);
                }
            }
            // Debug.WriteLine($"(in strings processing) there are {items.Count()} strings");

            ItemsAsStrings = l;
            return ItemsAsStrings; // returns the list
        }

        internal void SelectSingleItemCore(object item)
        {
            if (SelectedItem != item)
            {
                PseudoClasses.Remove(":normal");
                PseudoClasses.Add(":normal");
            }

            if(SelectedItem is not null)
                (SelectedItem as ISelectable).IsSelected = false;

            (item as ISelectable).IsSelected = true;

            SelectedItems.Clear();
            SelectedItems.Add(item);

            var item_parents = (item as ILogical).GetLogicalAncestors().OfType<NavigationViewItem>();

            if (this.IsOpen)
            {
                foreach (NavigationViewItem n in item_parents)
                {
                    n.IsExpanded = true;
                }
            }
            // Debug.WriteLine($"{item_parents.Count()}");

            SelectedItem = item;
        }
        internal void SelectSingleItem(object item)
        {
            SelectSingleItemCore(item);
            //History.Add(History.Count + 1, item);
            //HistoryChanged();
        }

        //private void HistoryChanged()
        //{
        //    //foreach (NavigationViewItem item in History)
        //    //{
        //    //    Debug.WriteLine("\"" + item.Header.ToString() + "\"" + " in History");
        //    //}
        //    //Debug.WriteLine("-----------------------------------------------------------");

        //    var canGoB = History.Count <= 1 | History[0] == SelectedItem;
        //    var canGoF = History.Count <= 1 | History.Values.Last() == SelectedItem;

        //    switch (!canGoB)
        //    {
        //        case true:
        //            CanGoBack = true;
        //            break;
        //        case false:
        //            CanGoBack = false;
        //            break;
        //    }
        //    switch (!canGoF)
        //    {
        //        case true:
        //            CanGoForward = true;
        //            break;
        //        case false:
        //            CanGoForward = false;
        //            break;
        //    }
        //}

        //public void GoBack()
        //{
        //    if (CanGoBack)
        //    {
        //        var selectedHistoryIndex = History.Values.IndexOf(SelectedItem) + 1;
        //        SelectSingleItemCore(History[selectedHistoryIndex - 1]);
        //    }
        //}

        //public void GoForward()
        //{
        //    if (CanGoForward)
        //    {
        //        var selectedHistoryIndex = History.Values.IndexOf(SelectedItem) + 1;
        //        SelectSingleItemCore(History[selectedHistoryIndex + 1]);
        //    }
        //}

        protected void OnSelectedItemChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            UpdateTitleAndSelectedContent();

            // Debug.WriteLine("Item changed");
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _headeritem = this.GetControl<NavigationViewItemBase>(e, "PART_HeaderItem");
            _completeBox = this.GetControl<AutoCompleteBox>(e, "PART_AutoCompleteBox");
            _completeBox.SelectionChanged += CompleteBoxItemSelected;

            _headeritem.PointerPressed += (s, e_) =>
            {
                var e = IsOpen;
                var a = AlwaysOpen;
                if (a != true)
                {
                    switch (e)
                    {
                        case true:
                            IsOpen = false;
                            break;

                        case false:
                            IsOpen = true;
                            break;
                    }
                }
                else if (a == true)
                {
                    IsOpen = true;
                }
            };

            UpdateTitleAndSelectedContent();
            ProcessString();
        }

        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            base.OnAttachedToLogicalTree(e);

            if ((Items as IList)[0] is ISelectable s)
                SelectSingleItem(s);
        }

        private void CompleteBoxItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as AutoCompleteBox).SelectedItem; //gets the header string
            var val = this.GetLogicalDescendants()
                            .OfType<NavigationViewItem>().Where(x => x.Header == n); //select the nav-item by type and header

            var val_c = val.FirstOrDefault(); // converts to NavigationViewItem
            //
            // Debug.WriteLine($"there are {val.Count()} strings"); //prints the count
            if (val_c != null) //checks it
            {
                SelectSingleItem(val_c); //select it
            }
        }

        //private void OnClose()
        //{
        //    var s = SelectedItem as Control;
        //    if ((Items as IList<object>).Contains(s))
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        var vs = s.GetVisualAncestors().OfType<NavigationViewItemBase>().LastOrDefault();
        //        (s as NavigationViewItemBase).IsSelected = false;
        //        SelectedItem = vs;
        //    }
        //}

        ///<inheritdoc/>
        IAvaloniaList<ILogical> IContentPresenterHost.LogicalChildren => LogicalChildren;

        private IContentPresenter ContentPart { get; set; }

        bool IContentPresenterHost.RegisterContentPresenter(IContentPresenter presenter)
        {
            return RegisterContentPresenter(presenter);
        }

        ///<inheritdoc/>
        protected virtual bool RegisterContentPresenter(IContentPresenter presenter)
        {
            if (presenter.Name == "PART_SelectedContentPresenter")
            {
                ContentPart = presenter;
                return true;
            }
            return false;
        }

        ///<inheritdoc/>
        protected override void OnContainersMaterialized(ItemContainerEventArgs e)
        {
            base.OnContainersMaterialized(e);
            UpdateTitleAndSelectedContent();
        }

        ///<inheritdoc/>
        protected override void OnContainersDematerialized(ItemContainerEventArgs e)
        {
            base.OnContainersDematerialized(e);
            UpdateTitleAndSelectedContent();
        }

        protected virtual void OnIsOpenChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
        }

        protected virtual void UpdateTitleAndSelectedContent()
        {
            if (SelectedItem is NavigationViewItemBase s)
            {
                SelectedContent = s.Content;
                Title = s.Title;
            }
        }
    }
}