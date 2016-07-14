using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerrainDemo
{
    public partial class FormMain : Form
    {
        private List<TerrainRenderer> terrainRendererList = new List<TerrainRenderer>();
        private Camera camera;

        public FormMain()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.lblCamera.Text = string.Format("{0}", this.camera);
            this.lblTargetCount.Text = string.Format(" | {0}/{1}", this.targetIndex, this.terrainRendererList.Count);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                //var rotator = new FirstPerspectiveManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
            }
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerrainRenderer renderer = GetRenderer();
            if (renderer != null)
            {
                this.terrainRendererList.Clear();
                this.terrainRendererList.Add(renderer);
                renderer.Initialize();
                UpdateCamera();
                var frmPropertyGrid = new FormProperyGrid(renderer);
                frmPropertyGrid.Show();
            }
        }

        private void UpdateCamera()
        {
            if (this.terrainRendererList.Count > 0)
            {
                TerrainRenderer first = this.terrainRendererList[0];
                BoundingBox boundingBox = first.BoundingBox;
                for (int i = 1; i < this.terrainRendererList.Count; i++)
                {
                    boundingBox.Union(this.terrainRendererList[i].BoundingBox);
                }
                vec3 translate = boundingBox.GetCenter() - this.camera.Target;
                this.camera.Target = this.camera.Target + translate;
                this.camera.Position = this.camera.Position + translate;
            }
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
            var list = this.terrainRendererList.ToArray();
            foreach (var item in list)
            {
                item.Render(new RenderEventArg(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera));
            }
        }

        private void 添加OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerrainRenderer renderer = GetRenderer();
            if (renderer != null)
            {
                this.terrainRendererList.Add(renderer);
                renderer.Initialize();
                UpdateCamera();
                var frmPropertyGrid = new FormProperyGrid(renderer);
                frmPropertyGrid.Show();
            }
        }

        private TerrainRenderer GetRenderer()
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    var positionList = new List<vec3>();
                    string filename = this.openFileDialog1.FileName;
                    using (var streamReader = new System.IO.StreamReader(filename))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string line = streamReader.ReadLine();
                            string[] parts = line.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            float x = float.Parse(parts[0]);
                            float y = float.Parse(parts[1]);
                            float z = float.Parse(parts[2]);
                            positionList.Add(new vec3(x, y, z));
                        }
                    }
                    var renderer = TerrainRenderer.GetRenderer(positionList);
                    return renderer;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            return null;
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int targetIndex = -1;

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 't')
            {
                targetIndex++;
                if (targetIndex > this.terrainRendererList.Count) { targetIndex = 0; }

                if (targetIndex < this.terrainRendererList.Count)
                {
                    BoundingBox boundingBox = this.terrainRendererList[targetIndex].BoundingBox;
                    vec3 translate = boundingBox.GetCenter() - this.camera.Target;
                    this.camera.Target = this.camera.Target + translate;
                    this.camera.Position = this.camera.Position + translate;
                }
                else if (targetIndex == this.terrainRendererList.Count)
                {
                    UpdateCamera();
                }
            }
        }
    }
}
