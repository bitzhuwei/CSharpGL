using System.Windows.Forms;

namespace CSharpGL.OBJFileViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
            this.Load += FormMain_Load;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle);
        }

        private void Application_Idle(object sender, System.EventArgs e)
        {
            this.Text = string.Format("CSharpGL.OBJViewer - {0}", this.lastfilename);
        }
    }
}