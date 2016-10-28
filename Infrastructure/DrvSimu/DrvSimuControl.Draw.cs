using System.Windows.Forms;

namespace DrvSimu
{
    public partial class DrvSimuControl
    {
        private void ScientificCanvas_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.Scene.Render();
        }
    }
}