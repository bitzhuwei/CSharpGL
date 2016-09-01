using System;

using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain
    {
        private void sceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormProperyGrid(this.scientificCanvas.Scene);
            form.PropertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
            form.ShowDialog();
            this.scientificCanvas.Invalidate();
        }

        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.scientificCanvas.Invalidate();
        }

        private void scientificCanvasMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormProperyGrid(this.scientificCanvas);
            form.PropertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
            form.ShowDialog();
            this.scientificCanvas.Invalidate();
        }
    }
}