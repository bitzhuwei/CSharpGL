using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.LightEffects
{
    public partial class FormDiffuseReflectionController : Form
    {
        private DiffuseReflectionRenderer diffuseReflectionRenderer;

        public FormDiffuseReflectionController(DiffuseReflectionRenderer diffuseReflectionRenderer)
        {
            InitializeComponent();

            this.diffuseReflectionRenderer = diffuseReflectionRenderer;
            this.lblKd.Text = diffuseReflectionRenderer.Kd.ToShortString();
            Color color = Color.Red;
            this.lblLightColorDisplay.BackColor = color;
            this.lblLightColor.Text = string.Format("R:{0} G:{1} B:{2}", color.R, color.G, color.B);
        }

        private void trackKd_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackKd.Value;
            this.lblKd.Text = value.ToShortString();
            this.diffuseReflectionRenderer.Kd = value;
        }

        private void FormDiffuseReflectionController_Load(object sender, EventArgs e)
        {

        }

        private void lblLightColorDisplay_Click(object sender, EventArgs e)
        {
            if (this.lightColorDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = this.lightColorDlg.Color;
                this.diffuseReflectionRenderer.lightColor = new GLM.vec3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
                this.lblLightColorDisplay.BackColor = color;
                this.lblLightColor.Text = string.Format("R:{0} G:{1} B:{2}", color.R, color.G, color.B);
            }
        }
    }
}
