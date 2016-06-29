using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace System
{
    public class AddItemEventArgs<T> : EventArgs
    {
        public T NewItem { get; private set; }

        public AddItemEventArgs(T newItem)
        {
            this.NewItem = newItem;
        }

        public override string ToString()
        {
            return string.Format("Added item: {0}", NewItem);
        }
    }

    public class RemoveItemEventArgs<T> : EventArgs
    {
        public T RemovedItem { get; private set; }

        public RemoveItemEventArgs(T removedItem)
        {
            this.RemovedItem = removedItem;
        }

        public override string ToString()
        {
            return string.Format("Removed item: {0}", RemovedItem);
        }
    }
}