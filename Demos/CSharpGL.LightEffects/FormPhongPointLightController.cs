using GLM;
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
    public partial class FormPhongPointLightController : Form
    {
        private PhongPointLightRenderer renderer;

        public FormPhongPointLightController(PhongPointLightRenderer renderer)
        {
            InitializeComponent();

            this.renderer = renderer;
            {
                this.trackKd.Value = (int)renderer.Kd;
                this.lblKd.Text = renderer.Kd.ToShortString();
            }
            {
                vec3 c = 255 * renderer.lightColor;
                Color color = Color.FromArgb((int)c.x, (int)c.y, (int)c.z);
                this.lblLightColorDisplay.BackColor = color;
                this.lblLightColor.Text = string.Format("R:{0} G:{1} B:{2}", color.R, color.G, color.B);
            }
            {
                vec3 c = 255 * renderer.globalAmbientColor;
                Color color = Color.FromArgb((int)c.x, (int)c.y, (int)c.z);
                this.lblGlobalAmbientDisplay.BackColor = color;
                this.lblGlobalAmbient.Text = string.Format("R:{0} G:{1} B:{2}", color.R, color.G, color.B);
            }
            {
                float value = renderer.lightPosition.x;
                this.trackLightPositionX.Value = (int)value;
                this.lblLightPositionX.Text = value.ToShortString();
            }
            {
                float value = renderer.lightPosition.y;
                this.trackLightPositionY.Value = (int)value;
                this.lblLightPositionY.Text = value.ToShortString();
            }
            {
                float value = renderer.lightPosition.z;
                this.trackLightPositionZ.Value = (int)value;
                this.lblLightPositionZ.Text = value.ToShortString();
            }
            {
                float value = renderer.Ks;
                this.trackKs.Value = (int)value;
                this.lblKs.Text = value.ToShortString();
            }
            {
                float value = renderer.shininess;
                this.trackShininess.Value = (int)(value * 100);
                this.lblShininess.Text = value.ToShortString();
            }
        }

        private void trackKd_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackKd.Value;
            this.lblKd.Text = value.ToShortString();
            this.renderer.Kd = value;
        }

        private void FormDiffuseReflectionController_Load(object sender, EventArgs e)
        {

        }

        private void lblLightColorDisplay_Click(object sender, EventArgs e)
        {
            if (this.lightColorDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = this.lightColorDlg.Color;
                this.renderer.lightColor = new GLM.vec3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
                this.lblLightColorDisplay.BackColor = color;
                this.lblLightColor.Text = string.Format("R:{0} G:{1} B:{2}", color.R, color.G, color.B);
            }
        }

        private void lblGlobalAmbient_Click(object sender, EventArgs e)
        {
            if (this.lightColorDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = this.lightColorDlg.Color;
                this.renderer.globalAmbientColor = new GLM.vec3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
                this.lblGlobalAmbientDisplay.BackColor = color;
                this.lblGlobalAmbient.Text = string.Format("R:{0} G:{1} B:{2}", color.R, color.G, color.B);
            }
        }

        private void trackLightPositionX_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackLightPositionX.Value;
            this.lblLightPositionX.Text = value.ToShortString();
            this.renderer.lightPosition.x = value;
        }

        private void trackLightPositionY_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackLightPositionY.Value;
            this.lblLightPositionY.Text = value.ToShortString();
            this.renderer.lightPosition.y = value;
        }

        private void trackLightPositionZ_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackLightPositionZ.Value;
            this.lblLightPositionZ.Text = value.ToShortString();
            this.renderer.lightPosition.z = value;
        }

        private void trackKs_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackKs.Value;
            this.lblKs.Text = value.ToShortString();
            this.renderer.Ks = value;
        }

        private void trackShininess_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackShininess.Value / 100.0f;
            this.lblShininess.Text = value.ToShortString();
            this.renderer.shininess = value;
        }
    }
}
