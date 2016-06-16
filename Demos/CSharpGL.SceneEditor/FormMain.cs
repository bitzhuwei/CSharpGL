using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain : Form
    {
        const string strOpenGL = "OpenGL";

        private SceneObjectList sceneObjectList = new SceneObjectList();

        [Category(strOpenGL)]
        public Camera Camera { get; private set; }

        [Category(strOpenGL)]
        public Color ClearColor { get; set; }

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
        }

    }
}
