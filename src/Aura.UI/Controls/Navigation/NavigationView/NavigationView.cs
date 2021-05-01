using Aura.UI.Controls.Generators;
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":normal")]
    public partial class NavigationView : TreeView, IItemsPresenterHost, IContentPresenterHost, IHeadered
    {
        private NavigationViewItemBase _headeritem;
        private AutoCompleteBox _completeBox;

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
            this.GetObservable(BoundsProperty).Subscribe(async (bounds)=>
            {
                OnBoundsChanged(bounds);
            });
        }

        protected virtual async Task OnBoundsChanged(Rect rect)
        {
            if (DynamicDisplayMode)
            {
                var isLittle = rect.Width <= 1000 && 700 > rect.Width;
                var isVeryLittle = rect.Width <= 700;
                var isOpen = IsOpen;

                if (!isLittle)
                {
                    DisplayMode = SplitViewDisplayMode.CompactInline;

                    if (isOpen || (DisplayMode == (SplitViewDisplayMode.Overlay | SplitViewDisplayMode.CompactOverlay)))
                    {
                        IsOpen = true;
                    }
                    else
                    {
                        IsOpen = false;
                    }
                }
                else if(isLittle && !isVeryLittle)
                {
                    DisplayMode = SplitViewDisplayMode.CompactOverlay;
                    IsOpen = false;
                }
                else
                {
                    DisplayMode = SplitViewDisplayMode.Overlay;
                    IsOpen = false;
                }
            }
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
        }
        protected void OnSelectedItemChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            UpdateTitleAndSelectedContent();
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _headeritem = this.GetControl<NavigationViewItemBase>(e, "PART_HeaderItem");
            _completeBox = this.GetControl<AutoCompleteBox>(e, "PART_AutoCompleteBox");

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
            _headeritem.Bind(NavigationViewItemBase.IsOpenProperty, this.GetObservable(IsOpenProperty));

            UpdateTitleAndSelectedContent();
        }

        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            base.OnAttachedToLogicalTree(e);

            if (Items is IList l && l.Count >= 1 && l[0] is ISelectable s)
                SelectSingleItem(s);
        }
        

        ///<inheritdoc/>
        IAvaloniaList<ILogical> IContentPresenterHost.LogicalChildren => LogicalChildren;

        private IContentPresenter ContentPart { get; set; }

        bool IContentPresenterHost.RegisterContentPresenter(IContentPresenter presenter)
        {
            return RegisterContentPresenter(presenter);
        }
        protected override IItemContainerGenerator CreateItemContainerGenerator()
            => new NavigationViewContainerGenerator(this, NavigationViewItem.ContentProperty, NavigationViewItem.ItemsProperty, NavigationViewItem.HeaderProperty, NavigationViewItem.TitleProperty, NavigationViewItem.IsExpandedProperty);

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