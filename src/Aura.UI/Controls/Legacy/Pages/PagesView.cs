using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using System.Collections;

namespace Aura.UI.Controls.Legacy
{
    /// <summary>
    /// Show a collection of <see cref="Page"/>
    /// </summary>
    public class PagesView : SelectingItemsControl
    {
        #region Properties

        /// <summary>
        /// Defines if the Title of the Selected <see cref="Page"/> can change the Title of the Parent Window
        /// </summary>
        public bool CanChangeTheWindowTitle
        {
            get => GetValue(CanChangeTheWindowTitleProperty);
            set => SetValue(CanChangeTheWindowTitleProperty, value);
        }

        public static readonly StyledProperty<bool> CanChangeTheWindowTitleProperty =
            AvaloniaProperty.Register<PagesView, bool>(nameof(CanChangeTheWindowTitle), true);

        #endregion Properties

        /// <summary>
        /// Backs to the previous page
        /// </summary>
        public void Previous()
        {
            try
            {
                Page Index;
                if ((Items as IList)[SelectedIndex - 1] != null)
                {
                    var _index = (Items as IList)[SelectedIndex - 1] as Page;
                    Index = _index;

                    if (Items != null)
                    {
                        if (Index != null & Index.GetType() == typeof(Page))
                        {
                            foreach (Page item in Items)
                            {
                                item.IsSelected = false;
                            }
                            SelectedItem = Index as Page;
                            (Index as Page).IsSelected = true;
                            if (CanChangeTheWindowTitle == true)
                            {
                                this.GetParentWindowOfLogical().Title = (Index as Page).Title;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Go to the indexed Page
        /// </summary>
        /// <param name="index">Index of the page</param>
        public void GoTo(int index)
        {
            try
            {
                if ((Items as IList)[index] != null)
                {
                    foreach (Page item in Items)
                    {
                        item.IsSelected = false;
                    }
                    SelectedItem = (Items as IList)[index];
                    ((Items as IList)[index] as Page).IsSelected = true;
                    if (CanChangeTheWindowTitle == true)
                    {
                        this.GetParentWindowOfLogical().Title = ((Items as IList)[index] as Page).Title;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Nexts to the next Page
        /// </summary>
        public void Next()
        {
            try
            {
                Page Index;
                if ((Items as IList)[SelectedIndex + 1] != null)
                {
                    var _index = (Items as IList)[SelectedIndex + 1] as Page;
                    Index = _index;
                    if (Items != null)
                    {
                        if (Index != null & Index.GetType() == typeof(Page))
                        {
                            foreach (Page item in Items)
                            {
                                item.IsSelected = false;
                            }
                            SelectedItem = Index as Page;
                            (Index as Page).IsSelected = true;
                            if (CanChangeTheWindowTitle == true)
                            {
                                this.GetParentWindowOfLogical().Title = (Index as Page).Title;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}