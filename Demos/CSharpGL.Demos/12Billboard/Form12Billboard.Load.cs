using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form12Billboard : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.scene = new Scene(camera);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                const int gridsPer2Unit = 20;
                const int scale = 2;
                var ground = GroundRenderer.Create(new GroundModel(gridsPer2Unit * scale));
                ground.Scale = scale;
                //ground.Initialize();
                //this.ground = ground;
                var obj = new SceneObject();
                obj.Renderer = ground;
                this.scene.ObjectList.Add(obj);
            }
            //MovableRenderer movableRenderer;
            {
                movableRenderer = MovableRenderer.Create(new Teapot());
                movableRenderer.Scale = 0.1f;
                //movableRenderer.Initialize();
                var obj = new SceneObject();
                obj.Renderer = movableRenderer;
                obj.ScriptList.Add(new TransformScript());
                this.scene.ObjectList.Add(obj);
            }
            {
                BillboardRenderer billboardRenderer = BillboardRenderer.GetRenderer(new BillboardModel());
                billboardRenderer.Initialize();
                var obj = new SceneObject();
                obj.Renderer = billboardRenderer;
                //obj.ScriptList.Add(new TransformScript());
                var updatePosition = new UpdateBillboardPosition(movableRenderer);
                obj.ScriptList.Add(updatePosition);
                this.scene.ObjectList.Add(obj);
            }
            {
                var labelRenderer = new LabelRenderer();
                labelRenderer.Initialize();
                labelRenderer.Text = "Teapot - CSharpGL";
                var obj = new SceneObject();
                obj.Renderer = labelRenderer;
                //obj.ScriptList.Add(new TransformScript());
                var updatePosition = new UpdateLabelPosition(movableRenderer);
                obj.ScriptList.Add(updatePosition);
                this.scene.ObjectList.Add(obj);
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128), -100, 100);
                //uiAxis.Initialize();
                this.scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }

        }

        private string[] timerEnabledSign = { "-", "/", "|", "\\", };
        private int timerEnableSignIndex = 0;
        private MovableRenderer movableRenderer;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerEnableSignIndex++;
            if (timerEnableSignIndex >= timerEnabledSign.Length)
            { timerEnableSignIndex = 0; }
            this.lblTimerEnabled.Text = timerEnabledSign[timerEnableSignIndex];

            foreach (var sceneObject in this.scene.ObjectList)
            {
                foreach (var obj in sceneObject)
                {
                    obj.Update(this.timer1.Interval);
                }
            }
        }
    }
}
