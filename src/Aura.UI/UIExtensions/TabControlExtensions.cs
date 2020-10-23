using Avalonia.Controls;
using System;
using System.Collections;
using Aura.UI.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Avalonia.Media;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
                    //var n_index = NewIndex(tabControl, tabItem);
                    ((IList)tabControl.Items).Remove(tabItem); //removes the tabitem itself
                    //tabControl.SelectedIndex = n_index;
                }
            }
            catch (Exception e)
            {
                throw new Exception("The TabItem does not exist", e);
            }
        }
        /*
        internal static int NewIndex(TabControl tabsHost, TabItem Item)
        {
            // gets the selected state of the tabitem to delete
            var item_S = Item.IsSelected;
            // Gets if the index of the item to delete
            var index = (tabsHost.Items as IList).IndexOf(Item);
            switch (item_S)
            {
                case true:
                    if (index == 0)
                    {
                        Debug.WriteLine("The index is 0 because the last index was 0");
                        return 0;
                    }
                        else if (index > 0)
                    {
                        Debug.WriteLine("The index decreased correctly");
                        return index--;
                    }
                    return 0;
                case false:
                    return tabsHost.SelectedIndex;
            }
        }
        internal static int NewIndex(TabControl tabsHost, int index)
        {
            var Item = (tabsHost.Items as IList)[index] as TabItem;
            // gets the selected state of the tabitem to delete
            var item_S = Item.IsSelected;
            switch (item_S)
            {
                case true:
                    //if (index == 0)
                    //{
                    //    Debug.WriteLine("The index is 0 because the last index was 0");
                    //    return 0;
                    //}
                    //else if (index > 0)
                    //{
                        Debug.WriteLine("The index decreased correctly");
                        return index--;
                //}
                //return 0;
                case false:
                    return tabsHost.SelectedIndex;
            }
        }
        */
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
                    //var item = (tabControl.Items as List<TabItem>).Select(x => x.IsSelected == true);
                    //tabControl.SelectedIndex = NewIndex(tabControl, index);
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
