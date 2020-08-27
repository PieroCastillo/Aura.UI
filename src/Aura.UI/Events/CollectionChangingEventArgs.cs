using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Aura.UI.Events
{
    public class CollectionChangingEventArgs<T> : EventArgs
    {
        public CollectionChangingEventArgs(CollectionChangeAction action, T element)
        {
            Action = action;
            Element = element;

            Cancel = false;
        }

        public CollectionChangeAction Action { get; private set; }
        public T Element { get; private set; }
        public bool Cancel { get; set; }
    }
}
