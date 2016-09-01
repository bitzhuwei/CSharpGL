using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {
        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 't' || e.KeyChar == 'T')
            {
                this.timer1.Enabled = !this.timer1.Enabled;
                this.scene.Running = this.timer1.Enabled;
            }
        }
    }
}