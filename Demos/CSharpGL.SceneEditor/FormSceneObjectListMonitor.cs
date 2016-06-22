using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

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
            if(scene!=null)
            {
                this.timer1.Enabled = true;
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            foreach (var item in this.scene.ObjectList)
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
