using System;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class FormIndexBufferPtrBoard : Form
    {
        private IndexBufferPtrController controller;

        /// <summary>
        ///
        /// </summary>
        /// <param name="indexBufferPtr"></param>
        public FormIndexBufferPtrBoard(IndexBufferPtr indexBufferPtr = null)
        {
            InitializeComponent();

            this.cmbDrawMode.Items.Clear();
            foreach (object item in Enum.GetValues(typeof(CSharpGL.DrawMode)))
            {
                this.cmbDrawMode.Items.Add((CSharpGL.DrawMode)item);
            }

            if (indexBufferPtr != null)
            {
                this.SetTarget(indexBufferPtr);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="indexBufferPtr"></param>
        public void SetTarget(IndexBufferPtr indexBufferPtr)
        {
            if (indexBufferPtr == null) { throw new ArgumentNullException(); }

            this.controller = indexBufferPtr.CreateController();

            UpdateUI(this.controller);

            this.Text = string.Format("{0}", this.controller);
        }

        private void UpdateUI(IndexBufferPtrController indexBufferPtrController)
        {
            int index = -1;
            foreach (object item in this.cmbDrawMode.Items)
            {
                index++;
                if ((DrawMode)item == indexBufferPtrController.IndexBufferPtr.Mode)
                {
                    this.cmbDrawMode.SelectedIndex = index;
                    break;
                }
            }

            if (indexBufferPtrController is ZeroIndexBufferPtrController)
            {
                this.lblFirst.Text = "First Vertex:";
                this.lblCount.Text = "Vertex Count:";
                this.trackFirst.Minimum = 0;
                this.trackFirst.Maximum = indexBufferPtrController.OriginalCount();
                this.trackFirst.Value = indexBufferPtrController.First();
                this.trackCount.Minimum = 0;
                this.trackCount.Maximum = indexBufferPtrController.OriginalCount();
                this.trackCount.Value = indexBufferPtrController.Count();
                this.lblFirstValue.Text = this.trackFirst.Value.ToString();
                this.lblCountValue.Text = this.trackCount.Value.ToString();
                this.Text = string.Format("{0}", this.controller);
            }
            else if (indexBufferPtrController is OneIndexBufferPtrController)
            {
                this.lblFirst.Text = "First Index:";
                this.lblCount.Text = "Element Count:";
                this.trackFirst.Minimum = 0;
                this.trackFirst.Maximum = indexBufferPtrController.OriginalCount();
                this.trackFirst.Value = indexBufferPtrController.First();
                this.trackCount.Minimum = 0;
                this.trackCount.Maximum = indexBufferPtrController.OriginalCount();
                this.trackCount.Value = indexBufferPtrController.Count();
                this.lblFirstValue.Text = this.trackFirst.Value.ToString();
                this.lblCountValue.Text = this.trackCount.Value.ToString();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(this.txtFirst.Text, out value))
            {
                if (value < this.trackFirst.Minimum) { value = this.trackFirst.Minimum; }
                else if (value > this.trackFirst.Maximum) { value = this.trackFirst.Maximum; }

                this.trackFirst.Value = value;
            }
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(this.txtCount.Text, out value))
            {
                if (value < this.trackCount.Minimum) { value = this.trackCount.Minimum; }
                else if (value > this.trackCount.Maximum) { value = this.trackCount.Maximum; }

                this.trackCount.Value = value;
            }
        }

        private void trackFirst_ValueChanged(object sender, EventArgs e)
        {
            this.controller.SetFirst(this.trackFirst.Value);
            this.lblFirstValue.Text = this.trackFirst.Value.ToString();
            this.Text = string.Format("{0}", this.controller);
        }

        private void trackCount_ValueChanged(object sender, EventArgs e)
        {
            this.controller.SetCount(this.trackCount.Value);
            this.lblCountValue.Text = this.trackCount.Value.ToString();
            this.Text = string.Format("{0}", this.controller);
        }

        private void cmbDrawMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.IndexBufferPtr.Mode = ((DrawMode)this.cmbDrawMode.SelectedItem);
        }
    }

    internal abstract class IndexBufferPtrController
    {
        public abstract IndexBufferPtr IndexBufferPtr { get; }

        public abstract int First();

        public abstract int Count();

        public abstract int OriginalCount();

        public abstract void SetFirst(int value);

        internal abstract void SetCount(int value);
    }

    internal class ZeroIndexBufferPtrController : IndexBufferPtrController
    {
        private ZeroIndexBufferPtr indexBufferPtr;

        public override IndexBufferPtr IndexBufferPtr
        {
            get { return this.indexBufferPtr; }
        }

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

        public override int OriginalCount()
        {
            return this.indexBufferPtr.OriginalVertexCount;
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

    internal class OneIndexBufferPtrController : IndexBufferPtrController
    {
        public override IndexBufferPtr IndexBufferPtr
        {
            get { return this.indexBufferPtr; }
        }

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
            return this.indexBufferPtr.ElementCount;
        }

        public override int OriginalCount()
        {
            return indexBufferPtr.Length;
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

    internal static class ControllerFactory
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