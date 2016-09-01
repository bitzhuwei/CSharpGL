using CSharpGL;
using System;
using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            this.scientificCanvas.RenderTrigger = RenderTrigger.Manual;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var sceneObject = s as SceneObject;
            if (sceneObject != null)
            {
                sceneObject.UpdateAndRender();
            }
        }

        private void lblTimerEnabled_Click(object sender, EventArgs e)
        {
            bool start = !this.timer1.Enabled;
            this.timer1.Enabled = start;
            this.scientificCanvas.Scene.Running = start;
            if (start)
            { this.lblTimerEnabled.ToolTipText = "Stop"; }
            else
            { this.lblTimerEnabled.ToolTipText = "Start"; }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.scientificCanvas.Scene.Update();
            this.scientificCanvas.Invalidate();
        }
    }
}