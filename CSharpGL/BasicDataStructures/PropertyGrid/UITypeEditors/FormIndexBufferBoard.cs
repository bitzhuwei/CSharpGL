using System;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class FormIndexBufferBoard : Form
    {
        private IndexBufferController controller;

        /// <summary>
        ///
        /// </summary>
        /// <param name="indexBuffer"></param>
        public FormIndexBufferBoard(IndexBuffer indexBuffer = null)
        {
            InitializeComponent();

            this.cmbDrawMode.Items.Clear();
            foreach (object item in Enum.GetValues(typeof(CSharpGL.DrawMode)))
            {
                this.cmbDrawMode.Items.Add((CSharpGL.DrawMode)item);
            }

            if (indexBuffer != null)
            {
                this.SetTarget(indexBuffer);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="indexBuffer"></param>
        public void SetTarget(IndexBuffer indexBuffer)
        {
            if (indexBuffer == null) { throw new ArgumentNullException(); }

            this.controller = indexBuffer.CreateController();

            UpdateUI(this.controller);

            this.Text = string.Format("{0}", this.controller);
        }

        private void UpdateUI(IndexBufferController indexBufferController)
        {
            int index = -1;
            foreach (object item in this.cmbDrawMode.Items)
            {
                index++;
                if ((DrawMode)item == indexBufferController.IndexBuffer.Mode)
                {
                    this.cmbDrawMode.SelectedIndex = index;
                    break;
                }
            }

            if (indexBufferController is ZeroIndexBufferController)
            {
                this.lblFirst.Text = "First Vertex:";
                this.lblCount.Text = "Vertex Count:";
                this.trackFirst.Minimum = 0;
                this.trackFirst.Maximum = indexBufferController.OriginalCount();
                this.trackFirst.Value = indexBufferController.First();
                this.trackCount.Minimum = 0;
                this.trackCount.Maximum = indexBufferController.OriginalCount();
                this.trackCount.Value = indexBufferController.Count();
                this.lblFirstValue.Text = this.trackFirst.Value.ToString();
                this.lblCountValue.Text = this.trackCount.Value.ToString();
                this.Text = string.Format("{0}", this.controller);
            }
            else if (indexBufferController is OneIndexBufferController)
            {
                this.lblFirst.Text = "First Index:";
                this.lblCount.Text = "Element Count:";
                this.trackFirst.Minimum = 0;
                this.trackFirst.Maximum = indexBufferController.OriginalCount();
                this.trackFirst.Value = indexBufferController.First();
                this.trackCount.Minimum = 0;
                this.trackCount.Maximum = indexBufferController.OriginalCount();
                this.trackCount.Value = indexBufferController.Count();
                this.lblFirstValue.Text = this.trackFirst.Value.ToString();
                this.lblCountValue.Text = this.trackCount.Value.ToString();
            }
            else
            {
                throw new Exception("Unexpected IndexBuffer type!");
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
            this.controller.IndexBuffer.Mode = ((DrawMode)this.cmbDrawMode.SelectedItem);
        }
    }

    internal abstract class IndexBufferController
    {
        public abstract IndexBuffer IndexBuffer { get; }

        public abstract int First();

        public abstract int Count();

        public abstract int OriginalCount();

        public abstract void SetFirst(int value);

        internal abstract void SetCount(int value);
    }

    internal class ZeroIndexBufferController : IndexBufferController
    {
        private ZeroIndexBuffer indexBuffer;

        public override IndexBuffer IndexBuffer
        {
            get { return this.indexBuffer; }
        }

        public ZeroIndexBufferController(ZeroIndexBuffer indexBuffer)
        {
            this.indexBuffer = indexBuffer;
        }

        public override int First()
        {
            return this.indexBuffer.FirstVertex;
        }

        public override int Count()
        {
            return this.indexBuffer.RenderingVertexCount;
        }

        public override int OriginalCount()
        {
            return this.indexBuffer.VertexCount;
        }

        public override void SetFirst(int value)
        {
            this.indexBuffer.FirstVertex = value;
        }

        internal override void SetCount(int value)
        {
            this.indexBuffer.RenderingVertexCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.indexBuffer);
        }
    }

    internal class OneIndexBufferController : IndexBufferController
    {
        public override IndexBuffer IndexBuffer
        {
            get { return this.indexBuffer; }
        }

        private OneIndexBuffer indexBuffer;

        public OneIndexBufferController(OneIndexBuffer indexBuffer)
        {
            this.indexBuffer = indexBuffer;
        }

        public override int First()
        {
            return this.indexBuffer.FirstVertex;
        }

        public override int Count()
        {
            return this.indexBuffer.RenderingVertexCount;
        }

        public override int OriginalCount()
        {
            return indexBuffer.VertexCount;
        }

        public override void SetFirst(int value)
        {
            this.indexBuffer.FirstVertex = value;
        }

        internal override void SetCount(int value)
        {
            this.indexBuffer.RenderingVertexCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.indexBuffer);
        }
    }

    internal static class ControllerFactory
    {
        public static IndexBufferController CreateController(this IndexBuffer indexBuffer)
        {
            {
                var ptr = indexBuffer as ZeroIndexBuffer;
                if (ptr != null)
                {
                    return new ZeroIndexBufferController(ptr);
                }
            }
            {
                var ptr = indexBuffer as OneIndexBuffer;
                if (ptr != null)
                {
                    return new OneIndexBufferController(ptr);
                }
            }
            {
                throw new Exception("Unexpected IndexBuffer type!");
            }
        }
    }
}