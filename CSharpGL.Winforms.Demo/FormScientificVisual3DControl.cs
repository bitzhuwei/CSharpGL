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
        //SatelliteRotator rotator;

        public FormScientificVisual3DControl()
        {
            InitializeComponent();

            //this.rotator = new SatelliteRotator(this.scientificVisual3DControl1.Camera);

            this.Load += FormScientificVisual3DControl_Load;

            //this.scientificVisual3DControl1.MouseDown += scientificVisual3DControl1_MouseDown;
            //this.scientificVisual3DControl1.MouseMove += scientificVisual3DControl1_MouseMove;
            //this.scientificVisual3DControl1.MouseUp += scientificVisual3DControl1_MouseUp;
        }

        //void scientificVisual3DControl1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        this.rotator.MouseUp(e.X, e.Y);
        //    }
        //}

        //void scientificVisual3DControl1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (this.rotator.mouseDownFlag && e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        this.rotator.MouseMove(e.X, e.Y);
        //    }
        //}

        //void scientificVisual3DControl1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        this.rotator.SetBounds(this.scientificVisual3DControl1.Width, this.scientificVisual3DControl1.Height);
        //        this.rotator.MouseDown(e.X, e.Y);
        //    }
        //}

        void FormScientificVisual3DControl_Load(object sender, EventArgs e)
        {
            IUILayoutParam param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom,
                new Padding(10, 10, 10, 10), new Size(50, 50));
            var uiAxis = new SimpleUIAxis(param);
            uiAxis.Initialize();
            this.scientificVisual3DControl1.ElementList.Add(uiAxis);

        }

    }
}
