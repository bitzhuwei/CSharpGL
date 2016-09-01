using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain : Form
    {
        public Scene scene;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
        }
    }
}