using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos.UIs;
using CSharpGL.Objects.UIs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormScientificVisual3DControl : Form
    {

        public FormScientificVisual3DControl()
        {
            InitializeComponent();

            this.Load += FormScientificVisual3DControl_Load;
        }

        void FormScientificVisual3DControl_Load(object sender, EventArgs e)
        {
            //IUILayoutParam param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom,
            //    new Padding(10, 10, 10, 10), new Size(50, 50));
            //var uiAxis = new SimpleUIAxis(param);
            //uiAxis.Initialize();
            //this.scientificVisual3DControl1.ElementList.Add(uiAxis);

        }

    }
}
