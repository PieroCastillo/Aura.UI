using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
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
        }

        public SuperNavigationView()
        {
            SelectedItemProperty.Changed.AddClassHandler<SuperNavigationView>((x, e) => x.OnSelectedItemChanged(x, e));
            PseudoClasses.Add(":normal");
        }

        protected void OnSelectedItemChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            UpdateTitleAndSelectedContent();
            PseudoClasses.Remove(":normal");
            PseudoClasses.Add(":normal");
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

        protected virtual void UpdateTitleAndSelectedContent()
        {
            if(ContentPart != null & SelectedItem is SuperNavigationViewItem & SelectedItem != null)
            {
                SelectedContent = (SelectedItem as SuperNavigationViewItem).Content;
                Title = (SelectedItem as SuperNavigationViewItem).Title;
            }
        }
    }
}
