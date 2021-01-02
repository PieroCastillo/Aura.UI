using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":normal")]
    public partial class SuperNavigationView : TreeView, IItemsPresenterHost,IContentPresenterHost, IHeadered
    {
        static SuperNavigationView()
        {
            SelectionModeProperty.OverrideDefaultValue<SuperNavigationView>(SelectionMode.Single);
            SelectedItemProperty.Changed.AddClassHandler<SuperNavigationView>((x, e) => x.OnSelectedItemChanged(x, e));
        }

        public SuperNavigationView()
        {
            PseudoClasses.Add(":normal");
        }

        protected void OnSelectedItemChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            UpdateTitleAndSelectedContent();
            PseudoClasses.Remove(":normal");
            PseudoClasses.Add(":normal");
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            UpdateTitleAndSelectedContent();
        }

        ///<inheritdoc/>
        IAvaloniaList<ILogical> IContentPresenterHost.LogicalChildren  => LogicalChildren;
        private IContentPresenter ContentPart { get; set; }

        bool IContentPresenterHost.RegisterContentPresenter(IContentPresenter presenter)
        {
            return RegisterContentPresenter(presenter);
        }

        ///<inheritdoc/>
        protected virtual bool RegisterContentPresenter(IContentPresenter presenter)
        {
            if(presenter.Name == "PART_SelectedContentPresenter")
            {
                ContentPart = presenter;
                return true;
            }
            return false;
        }

        protected override void OnContainersMaterialized(ItemContainerEventArgs e)
        {
            base.OnContainersMaterialized(e);
            UpdateTitleAndSelectedContent();
        }

        protected override void OnContainersDematerialized(ItemContainerEventArgs e)
        {
            base.OnContainersDematerialized(e);
            UpdateTitleAndSelectedContent();
        }

        protected virtual void UpdateTitleAndSelectedContent()
        {
            if(SelectedItem is SuperNavigationViewItem s)
            {
                SelectedContent = s.Content;
                Title = s.Title;
            }
        }
    }
}
