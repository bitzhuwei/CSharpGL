using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class SceneObjectList
    {
        public event EventHandler<AddItemEventArgs<SceneObject>> ItemAdded;
        public event EventHandler<RemoveItemEventArgs<SceneObject>> ItemRemoved;
    }

    public class AddItemEventArgs<T>
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

    public class RemoveItemEventArgs<T>
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