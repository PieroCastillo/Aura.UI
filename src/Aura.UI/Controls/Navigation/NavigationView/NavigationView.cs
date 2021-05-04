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
using Avalonia.VisualTree;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":normal",":compact")]
    public partial class NavigationView : TreeView, IItemsPresenterHost, IContentPresenterHost, IHeadered
    {
        private Button _headeritem;
        private AutoCompleteBox _completeBox;
        private SplitView _splitVw;
        private const double LittleWidth = 1005;
        private const double VeryLittleWidth = 650;

        static NavigationView()
        {
            SelectionModeProperty.OverrideDefaultValue<NavigationView>(SelectionMode.Single);
            SelectedItemProperty.Changed.AddClassHandler<NavigationView>((x, e) => x.OnSelectedItemChanged(x, e));
            FocusableProperty.OverrideDefaultValue<NavigationView>(true);
            IsOpenProperty.Changed.AddClassHandler<NavigationView>((x, e) => x.OnIsOpenChanged(x, e));
            IsFloatingHeaderProperty.Changed.Subscribe(x =>
            {
                if(x.Sender is NavigationView nw)
                    nw.UpdateHeaderVisibility();
            });
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
                var isLittle = rect.Width <= LittleWidth;
                var isVeryLittle = rect.Width <= VeryLittleWidth;

                if (!isLittle && !isVeryLittle)
                {
                    UpdatePseudoClasses(false);
                    DisplayMode = SplitViewDisplayMode.CompactInline;
                }
                else if(isLittle && !isVeryLittle)
                {
                    UpdatePseudoClasses(false);
                    DisplayMode = SplitViewDisplayMode.CompactOverlay;
                    IsOpen = false;
                    foreach (var navigationViewItemBase in this.GetLogicalDescendants().OfType<NavigationViewItemBase>())
                    {
                        navigationViewItemBase.IsExpanded = false;
                    }
                }
                else if(isLittle && isVeryLittle)
                {
                    UpdatePseudoClasses(true);
                    DisplayMode = SplitViewDisplayMode.Overlay;
                    IsOpen = false;
                    foreach (var navigationViewItemBase in this.GetLogicalDescendants().OfType<NavigationViewItemBase>())
                    {
                        navigationViewItemBase.IsExpanded = false;
                    }
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

        private void UpdateHeaderVisibility() => HeaderVisible = IsOpen | IsFloatingHeader;
        
        protected void OnSelectedItemChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            UpdateTitleAndSelectedContent();
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _headeritem = this.GetControl<Button>(e, "PART_HeaderItem");
            _completeBox = this.GetControl<AutoCompleteBox>(e, "PART_AutoCompleteBox");
            _splitVw = this.GetControl<SplitView>(e,"split");

            _headeritem.Click += delegate
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
        //protected override IItemContainerGenerator CreateItemContainerGenerator()
          //  => new NavigationViewContainerGenerator(this, NavigationViewItem.ContentProperty, NavigationViewItem.ItemsProperty, NavigationViewItem.HeaderProperty, NavigationViewItem.TitleProperty, NavigationViewItem.IsExpandedProperty);

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
            UpdateHeaderVisibility();
        }

        private void UpdatePseudoClasses(bool isCompact)
        {
            switch (isCompact)
            {
                case true:
                    PseudoClasses.Add(":compact");
                    break;
                case false:
                    PseudoClasses.Remove("compact");
                    break;
            }
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