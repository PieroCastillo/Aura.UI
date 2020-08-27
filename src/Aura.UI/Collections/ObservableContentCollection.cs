using Aura.UI.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Aura.UI.Collections
{
    [CollectionDataContract]
    public class ObservableContentCollection<T> : ObservableCollection<T>, INotifyCollectionContentChanged
     where T : INotifyPropertyChanged
    {
        #region Events

        public event NotifyCollectionContentChangedEventHandler CollectionContentChanged = delegate { };

        public event CollectionChangingEventHandler<T> CollectionChanging = delegate { };

        #endregion

        #region Constructors

        public ObservableContentCollection(IEnumerable<T> enumerable)
            : base(enumerable)
        {
            SubscribeToPropertyChanged(enumerable);
            SubscribeToCollectionChanged();

            FireContentChanged = true;
            CanClear = true;
        }

        public ObservableContentCollection() : this(new List<T>())
        {

        }

        #endregion

        #region Functions

        private void SubscribeToCollectionChanged()
        {
            CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                    SubscribeToPropertyChanged(e.NewItems);
                if (e.OldItems != null)
                    UnsubscribeFromPropertyChanged(e.OldItems);
            };
        }

        private void SubscribeToPropertyChanged(IEnumerable enumerable)
        {
            foreach (var item in enumerable.Cast<INotifyPropertyChanged>())
                item.PropertyChanged += OnItemPropertyChanged;
        }

        private void UnsubscribeFromPropertyChanged(IEnumerable enumerable)
        {
            foreach (var item in enumerable.Cast<INotifyPropertyChanged>())
                item.PropertyChanged -= OnItemPropertyChanged;
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (FireContentChanged)
                CollectionContentChanged(sender, e);
        }

        private bool OnCollectionChanging(CollectionChangeAction action, T item)
        {
            var eventArgs = new CollectionChangingEventArgs<T>(action, item);

            CollectionChanging(this, eventArgs);

            return eventArgs.Cancel;
        }

        public void Refresh()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        #endregion

        #region Overrides ObsetvableCollection<T>

        protected override void RemoveItem(int index)
        {
            var cancel = OnCollectionChanging(CollectionChangeAction.Remove, this[index]);

            if (!cancel)
                base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            if (CanClear) base.ClearItems();
        }

        protected override void InsertItem(int index, T item)
        {
            var cancel = OnCollectionChanging(CollectionChangeAction.Add, item);

            if (!cancel)
                base.InsertItem(index, item);
        }

        #endregion

        #region Properties

        public bool CanClear { get; set; }

        public bool FireContentChanged { get; set; }

        #endregion
    }

    public delegate void CollectionChangingEventHandler<T>(Object sender, CollectionChangingEventArgs<T> e);
}
