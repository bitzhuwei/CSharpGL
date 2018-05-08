using System;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class FormDrawCommandBoard : Form
    {
        private IndexBufferController controller;

        /// <summary>
        ///
        /// </summary>
        /// <param name="drawCmd"></param>
        public FormDrawCommandBoard(IDrawCommand drawCmd = null)
        {
            InitializeComponent();

            this.cmbDrawMode.Items.Clear();
            foreach (object item in Enum.GetValues(typeof(CSharpGL.DrawMode)))
            {
                this.cmbDrawMode.Items.Add((CSharpGL.DrawMode)item);
            }

            if (drawCmd != null)
            {
                this.SetTarget(drawCmd);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="drawCmd"></param>
        public void SetTarget(IDrawCommand drawCmd)
        {
            if (drawCmd == null) { throw new ArgumentNullException(); }

            this.controller = drawCmd.CreateController();

            UpdateUI(this.controller);

            this.Text = string.Format("{0}", this.controller);
        }

        private void UpdateUI(IndexBufferController drawCmdController)
        {
            int index = -1;
            foreach (object item in this.cmbDrawMode.Items)
            {
                index++;
                if ((DrawMode)item == drawCmdController.DrawCmd.CurrentMode)
                {
                    this.cmbDrawMode.SelectedIndex = index;
                    break;
                }
            }

            if (drawCmdController is ZeroIndexBufferController)
            {
                this.lblFirst.Text = "First Vertex:";
                this.lblCount.Text = "Vertex Count:";
                this.trackFirst.Minimum = 0;
                this.trackFirst.Maximum = drawCmdController.OriginalCount();
                this.trackFirst.Value = drawCmdController.First();
                this.trackCount.Minimum = 0;
                this.trackCount.Maximum = drawCmdController.OriginalCount();
                this.trackCount.Value = drawCmdController.Count();
                this.lblFirstValue.Text = this.trackFirst.Value.ToString();
                this.lblCountValue.Text = this.trackCount.Value.ToString();
                this.Text = string.Format("{0}", this.controller);
            }
            else if (drawCmdController is OneIndexBufferController)
            {
                this.lblFirst.Text = "First Index:";
                this.lblCount.Text = "Element Count:";
                this.trackFirst.Minimum = 0;
                this.trackFirst.Maximum = drawCmdController.OriginalCount();
                this.trackFirst.Value = drawCmdController.First();
                this.trackCount.Minimum = 0;
                this.trackCount.Maximum = drawCmdController.OriginalCount();
                this.trackCount.Value = drawCmdController.Count();
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
            this.controller.DrawCmd.CurrentMode = ((DrawMode)this.cmbDrawMode.SelectedItem);
        }
    }

    internal abstract class IndexBufferController
    {
        public abstract IDrawCommand DrawCmd { get; }

        public abstract int First();

        public abstract int Count();

        public abstract int OriginalCount();

        public abstract void SetFirst(int value);

        internal abstract void SetCount(int value);
    }

    internal class ZeroIndexBufferController : IndexBufferController
    {
        private DrawArraysCmd drawCmd;

        public override IDrawCommand DrawCmd
        {
            get { return this.drawCmd; }
        }

        public ZeroIndexBufferController(DrawArraysCmd drawCmd)
        {
            this.drawCmd = drawCmd;
        }

        public override int First()
        {
            return this.drawCmd.FirstVertex;
        }

        public override int Count()
        {
            return this.drawCmd.VertexCount;
        }

        public override int OriginalCount()
        {
            return this.drawCmd.MaxVertexCount;
        }

        public override void SetFirst(int value)
        {
            this.drawCmd.FirstVertex = value;
        }

        internal override void SetCount(int value)
        {
            this.drawCmd.VertexCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.drawCmd);
        }
    }

    internal class OneIndexBufferController : IndexBufferController
    {
        public override IDrawCommand DrawCmd
        {
            get { return this.drawCmd; }
        }

        private DrawElementsCmd drawCmd;

        public OneIndexBufferController(DrawElementsCmd drawCmd)
        {
            this.drawCmd = drawCmd;
        }

        public override int First()
        {
            return this.drawCmd.FirstVertex;
        }

        public override int Count()
        {
            return this.drawCmd.VertexCount;
        }

        public override int OriginalCount()
        {
            return drawCmd.IndexBufferObject.Length;
        }

        public override void SetFirst(int value)
        {
            this.drawCmd.FirstVertex = value;
        }

        internal override void SetCount(int value)
        {
            this.drawCmd.VertexCount = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.drawCmd);
        }
    }

    internal static class ControllerFactory
    {
        public static IndexBufferController CreateController(this IDrawCommand drawCmd)
        {
            {
                var ptr = drawCmd as DrawArraysCmd;
                if (ptr != null)
                {
                    return new ZeroIndexBufferController(ptr);
                }
            }
            {
                var ptr = drawCmd as DrawElementsCmd;
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