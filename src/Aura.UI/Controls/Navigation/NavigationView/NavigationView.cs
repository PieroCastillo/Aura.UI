using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Threading;
using System;
using System.Collections;
using System.Linq;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":normal", ":compact")]
    public partial class NavigationView : TreeView
    {
        private Button? _headeritem;
        private SplitView? _splitVw;
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
                if (x.Sender is NavigationView nw)
                    nw.UpdateHeaderVisibility();
            });
        }

        public NavigationView()
        {
            _title = "";
            _selectedcontent = "";
            _itemsasstrings = new AvaloniaList<string>();
            _autoCompleteBox = new AutoCompleteBox();
            
            PseudoClasses.Add(":normal");
            this.GetObservable(BoundsProperty).Subscribe(async (bounds) =>
            {
                await Dispatcher.UIThread.InvokeAsync(() => OnBoundsChanged(bounds));
            });
        }

        protected virtual void OnBoundsChanged(Rect rect)
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
                else if (isLittle && !isVeryLittle)
                {
                    UpdatePseudoClasses(false);
                    DisplayMode = SplitViewDisplayMode.CompactOverlay;
                    IsOpen = false;
                    foreach (var navigationViewItemBase in this.GetLogicalDescendants().OfType<NavigationViewItemBase>())
                    {
                        navigationViewItemBase.IsExpanded = false;
                    }
                }
                else if (isLittle && isVeryLittle)
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

        internal void SelectSingleItemCore(object? item)
        {
            if (SelectedItem != item)
            {
                PseudoClasses.Remove(":normal");
                PseudoClasses.Add(":normal");
            }

            if (SelectedItem is not null)
                ((SelectedItem as ISelectable)!).IsSelected = false;

            if (item is not null) ((item as ISelectable)!).IsSelected = true;

            if (SelectedItem is null || item is null) return;
            
            SelectedItems.Clear();
            SelectedItems.Add(item);

            SelectedItem = item;
        }
        internal void SelectSingleItem(object? item)
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

            var btn = this.GetControl<Button>(e, "PART_HeaderItem");
            
            if(btn is null) return;
            
            _headeritem = btn;
            _splitVw = this.GetControl<SplitView>(e, "split");

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
                    PseudoClasses.Remove(":compact");
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