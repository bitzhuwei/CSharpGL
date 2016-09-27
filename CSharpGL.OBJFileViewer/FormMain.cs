using System.Windows.Forms;

namespace CSharpGL.OBJFileViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, System.EventArgs e)
        {
            this.Text = string.Format("CSharpGL.OBJViewer - {0}", this.lastfilename);
        }
    }
}