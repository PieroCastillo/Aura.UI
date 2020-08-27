using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace Aura.UI.Collections
{
    interface INotifyCollectionContentChanged : INotifyCollectionChanged
    {
        event NotifyCollectionContentChangedEventHandler CollectionContentChanged;
    }

    public delegate void NotifyCollectionContentChangedEventHandler(Object sender, PropertyChangedEventArgs e);
}
