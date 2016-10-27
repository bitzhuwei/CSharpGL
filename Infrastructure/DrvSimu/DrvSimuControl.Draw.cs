using CSharpGL;
using System.Drawing;
using System.Windows.Forms;

namespace DrvSimu
{
    public partial class ScientificCanvas
    {
        private void ScientificCanvas_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.Scene.Render();
        }
    }
}