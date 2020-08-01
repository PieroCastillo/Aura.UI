using Avalonia.Controls;
using System;
using System.Collections;

namespace Aura.UI.UIExtensions
{
    public static class TabControlExtensions
    {
        /// <summary>
        /// Removes the TabItem.
        /// </summary>
        /// <param name="tabControl">The TabControl Parent</param>
        /// <param name="tabItem">The TabItem to Remove</param>
        public static void CloseTab(this TabControl tabControl, TabItem tabItem)
        {
            try
            {
                if (tabItem == null)
                {

                }
                else
                {
                    ((IList)tabControl.Items).Remove(tabItem); //removes the tabitem itself
                }
            }
            catch (Exception e)
            {
                throw new Exception("The TabItem does not exist", e);
            }
        }
        /// <summary>
        /// Removes a TabItem with its index number.
        /// </summary>
        /// <param name="tabControl">A TabControl Parent</param>
        /// <param name="index">The TabItem Index</param>
        public static void CloseTab(this TabControl tabControl, int index)
        {
            index--;
            try
            {
                if (index < 0)
                {

                }
                else
                {
                    ((IList)tabControl.Items).RemoveAt(index);
                }
            }
            catch (Exception e)
            {
                throw new Exception("the index must be greater than 0", e);
            }
        }
        /// <summary>
        /// Add a TabItem
        /// </summary>
        /// <param name="tabControl">The TabControl Parent</param>
        /// <param name="TabItemToAdd">The TabItem to Add</param>
        /// <returns>If the method has been done correctly,return bool if it has been done correctly or false if it has been done incorrectly</returns>
        public static bool AddTab(this TabControl tabControl, TabItem TabItemToAdd,bool Focus)
        {
            try
            {
                //Thanks to Grooky, this is possible
                ((IList)tabControl.Items).Add(TabItemToAdd);
                switch (Focus)
                {
                    case true:
                        TabItemToAdd.IsSelected = true;
                        break;
                }
                return true;
            }
            catch (SystemException e)
            {
                return false;
                throw new SystemException("The Item to add is null", e);
            }

        }

    }
}
