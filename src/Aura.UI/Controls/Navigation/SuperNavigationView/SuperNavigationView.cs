﻿using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":normal")]
    public partial class SuperNavigationView : TreeView, IItemsPresenterHost, IContentPresenterHost, IHeadered
    {
        private SuperNavigationViewItemBase _headeritem;

        static SuperNavigationView()
        {
            SelectionModeProperty.OverrideDefaultValue<SuperNavigationView>(SelectionMode.Single);
            SelectedItemProperty.Changed.AddClassHandler<SuperNavigationView>((x, e) => x.OnSelectedItemChanged(x, e));
        }

        public SuperNavigationView()
        {
            PseudoClasses.Add(":normal");
        }

        internal void SelectSingleItem(object item)
        {
            if (SelectedItem != item)
            {
                PseudoClasses.Remove(":normal");
                PseudoClasses.Add(":normal");
            }

            (SelectedItem as ISelectable).IsSelected = false;

            SelectedItems.Clear();
            SelectedItems.Add(item);

            (item as ISelectable).IsSelected = true;
            SelectedItem = item;
        }


        protected void OnSelectedItemChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            UpdateTitleAndSelectedContent();

            Debug.WriteLine("Item changed");
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _headeritem = this.GetControl<SuperNavigationViewItemBase>(e, "PART_HeaderItem");

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
        }

        void OnClose()
        {
            var s = SelectedItem as Control;
            if ((Items as IList<object>).Contains(s))
            {
                return;
            }
            else
            {
                var vs = s.GetVisualAncestors().OfType<SuperNavigationViewItemBase>().LastOrDefault();
                (s as SuperNavigationViewItemBase).IsSelected = false;
                SelectedItem = vs;
            }
        }

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

        protected virtual void UpdateTitleAndSelectedContent()
        {
            if (SelectedItem is SuperNavigationViewItemBase s)
            {
                SelectedContent = s.Content;
                Title = s.Title;
            }
        }
    }
}
