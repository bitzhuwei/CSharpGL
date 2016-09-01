using System;

using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormSceneObjectListMonitor : Form
    {
        private Scene scene;

        public FormSceneObjectListMonitor(Scene scene)
        {
            InitializeComponent();

            this.scene = scene;
            if (scene != null)
            {
                this.timer1.Enabled = true;
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            foreach (var item in this.scene.RootObject)
            {
                this.textBox1.AppendText(item.DumpToText());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application_Idle(sender, e);
        }
    }
}