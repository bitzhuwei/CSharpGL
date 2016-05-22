using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CSharpGL
{
    /// <summary>
    /// 像Winform窗口里的控件一样的控件。
    /// </summary>
    public abstract class GLContainer : GLControl
    {
        public ICollection<GLControl> Controls { get; private set; }

        public GLContainer(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.Controls = new GLControlCollection(this);
        }

        public override void Layout()
        {
            base.Layout();

            foreach (var control in this.Controls)
            {
                control.Layout();
            }
        }

        /// <summary>
        /// 用<see cref="Add(item)"/>时自动实现双向绑定。
        /// </summary>
        class GLControlCollection : ICollection<GLControl>
        {
            private GLContainer container;
            ICollection<GLControl> collection = new Collection<GLControl>();

            public GLControlCollection(GLContainer container)
            {
                this.container = container;
            }
            public void Add(GLControl item)
            {
                item.Container = this.container;
                this.collection.Add(item);
            }

            public void Clear()
            {
                GLControl[] ie = (from item in this.collection select item).ToArray();

                this.collection.Clear();

                foreach (var item in this)
                {
                    item.Container = null;
                }
            }

            public bool Contains(GLControl item)
            {
                return this.collection.Contains(item);
            }

            public void CopyTo(GLControl[] array, int arrayIndex)
            {
                this.collection.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return this.collection.Count; }
            }

            public bool IsReadOnly
            {
                get { return ((ICollection<GLControl>)this.collection).IsReadOnly; }
            }

            public bool Remove(GLControl item)
            {
                bool result = this.collection.Remove(item);
                if (item != null) { item.Container = null; }
                return result;
            }

            public IEnumerator<GLControl> GetEnumerator()
            {
                return this.collection.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.collection.GetEnumerator();
            }
        }
    }

}

