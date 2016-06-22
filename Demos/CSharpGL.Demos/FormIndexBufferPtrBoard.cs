using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class FormIndexBufferPtrBoard : Form
    {
        private IndexBufferPtrController controller;

        public FormIndexBufferPtrBoard(IndexBufferPtr indexBufferPtr = null)
        {
            InitializeComponent();

            if (indexBufferPtr != null)
            {
                this.SetTarget(indexBufferPtr);
            }
        }

        public void SetTarget(IndexBufferPtr indexBufferPtr)
        {
            if (indexBufferPtr == null) { throw new ArgumentNullException(); }

            this.controller = indexBufferPtr.CreateController();

            UpdateUI(this.controller);

            this.Text = string.Format("{0}", this.controller);
        }

        private void UpdateUI(IndexBufferPtrController indexBufferPtrController)
        {
            if (indexBufferPtrController is ZeroIndexBufferPtrController)
            {
                this.lblFirst.Text = "First Vertex:";
                this.lblCount.Text = "Vertex Count:";
                this.trackFirst.Minimum = indexBufferPtrController.First();
                this.trackFirst.Maximum = indexBufferPtrController.Count();
                this.trackFirst.Value = indexBufferPtrController.First();
                this.trackCount.Minimum = indexBufferPtrController.First();
                this.trackCount.Maximum = indexBufferPtrController.Count();
                this.trackCount.Value = indexBufferPtrController.Count();
                this.lblFirstValue.Text = this.trackFirst.Value.ToString();
                this.lblCountValue.Text = this.trackCount.Value.ToString();
                this.Text = string.Format("{0}", this.controller);
            }
            else if (indexBufferPtrController is OneIndexBufferPtrController)
            {
                this.lblFirst.Text = "First Index:";
                this.lblCount.Text = "Element Count:";
                this.trackFirst.Minimum = indexBufferPtrController.First();
                this.trackFirst.Maximum = indexBufferPtrController.Count();
                this.trackFirst.Value = indexBufferPtrController.First();
                this.trackCount.Minimum = indexBufferPtrController.First();
                this.trackCount.Maximum = indexBufferPtrController.Count();
                this.trackCount.Value = indexBufferPtrController.Count();
                this.lblFirstValue.Text = this.trackFirst.Value.ToString();
                this.lblCountValue.Text = this.trackCount.Value.ToString();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void trackFirst_Scroll(object sender, EventArgs e)
        {
            this.controller.SetFirst(this.trackFirst.Value);
            this.lblFirstValue.Text = this.trackFirst.Value.ToString();
            this.Text = string.Format("{0}", this.controller);
        }

        private void trackCount_Scroll(object sender, EventArgs e)
        {
            this.controller.SetCount(this.trackCount.Value);
            this.lblCountValue.Text = this.trackCount.Value.ToString();
            this.Text = string.Format("{0}", this.controller);
        }
    }

    abstract class IndexBufferPtrController
    {

        public abstract int First();
        public abstract int Count();

        public abstract void SetFirst(int value);

        internal abstract void SetCount(int value);

    }

    class ZeroIndexBufferPtrController : IndexBufferPtrController
    {
        private ZeroIndexBufferPtr ptr;

        public ZeroIndexBufferPtrController(ZeroIndexBufferPtr ptr)
        {
            // TODO: Complete member initialization
            this.ptr = ptr;
        }


        public override int First()
        {
            return this.ptr.FirstVertex;
        }

        public override int Count()
        {
            return this.ptr.VertexCount;
        }

        public override void SetFirst(int value)
        {
            this.ptr.FirstVertex = value;
        }

        internal override void SetCount(int value)
        {
            this.ptr.VertexCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.ptr);
        }
    }
    class OneIndexBufferPtrController : IndexBufferPtrController
    {
        private OneIndexBufferPtr ptr;

        public OneIndexBufferPtrController(OneIndexBufferPtr ptr)
        {
            // TODO: Complete member initialization
            this.ptr = ptr;
        }


        public override int First()
        {
            return this.ptr.FirstIndex;
        }

        public override int Count()
        {
            return ptr.ElementCount;
        }

        public override void SetFirst(int value)
        {
            this.ptr.FirstIndex = value;
        }

        internal override void SetCount(int value)
        {
            this.ptr.ElementCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.ptr);
        }
    }
    static class ControllerFactory
    {
        public static IndexBufferPtrController CreateController(this IndexBufferPtr indexBufferPtr)
        {
            {
                var ptr = indexBufferPtr as ZeroIndexBufferPtr;
                if (ptr != null)
                {
                    return new ZeroIndexBufferPtrController(ptr);
                }
            }
            {
                var ptr = indexBufferPtr as OneIndexBufferPtr;
                if (ptr != null)
                {
                    return new OneIndexBufferPtrController(ptr);
                }
            }
            {
                throw new NotImplementedException();
            }
        }
    }
}
