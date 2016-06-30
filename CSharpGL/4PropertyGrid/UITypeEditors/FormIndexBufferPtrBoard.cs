using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL
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
        private ZeroIndexBufferPtr indexBufferPtr;

        public ZeroIndexBufferPtrController(ZeroIndexBufferPtr indexBufferPtr)
        {
            this.indexBufferPtr = indexBufferPtr;
        }


        public override int First()
        {
            return this.indexBufferPtr.FirstVertex;
        }

        public override int Count()
        {
            return this.indexBufferPtr.VertexCount;
        }

        public override void SetFirst(int value)
        {
            this.indexBufferPtr.FirstVertex = value;
        }

        internal override void SetCount(int value)
        {
            this.indexBufferPtr.VertexCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.indexBufferPtr);
        }
    }
    class OneIndexBufferPtrController : IndexBufferPtrController
    {
        private OneIndexBufferPtr indexBufferPtr;

        public OneIndexBufferPtrController(OneIndexBufferPtr indexBufferPtr)
        {
            this.indexBufferPtr = indexBufferPtr;
        }


        public override int First()
        {
            return this.indexBufferPtr.FirstIndex;
        }

        public override int Count()
        {
            return indexBufferPtr.ElementCount;
        }

        public override void SetFirst(int value)
        {
            this.indexBufferPtr.FirstIndex = value;
        }

        internal override void SetCount(int value)
        {
            this.indexBufferPtr.ElementCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.indexBufferPtr);
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
