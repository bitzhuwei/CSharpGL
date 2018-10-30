using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gocator
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private FirstPerspectiveManipulater manipulater;
        private Bitmap colorTable;
        private const int colorTableLength = 512;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseWheel += winGLCanvas1_MouseWheel;

            this.LoadColorTable();
        }

        void winGLCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            ICamera camera = this.scene.Camera;
            if (camera != null)
            {
                camera.MouseWheel(e.Delta);
            }
        }

        private void LoadColorTable()
        {
            this.colorTable = new Bitmap("color-table.bmp");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(-5, 6, 4) * 3;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera);
            this.scene.ClearColor = Color.Black.ToVec4();
            this.scene.RootNode = new GroupNode();

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            //this.manipulater = new FirstPerspectiveManipulater();
            //this.manipulater.Bind(camera, this.winGLCanvas1);

        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = this.openFileDialog1.FileName;
                int xLength = 0, yLength = 0; bool firstLine = true;
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(',', ' ');
                        xLength++;
                        if (firstLine)
                        {
                            yLength = parts.Length;
                            firstLine = false;
                        }
                        else
                        {
                            if (yLength != parts.Length)
                            {
                                MessageBox.Show("Not same Y length!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                float maxValue = 0; float minValue = 0; firstLine = true;
                var positions = new vec3[xLength * yLength];
                int startX = -xLength / 2; int startY = -yLength / 2;
                using (StreamReader sr = new StreamReader(filename))
                {
                    int x = 0;
                    int index = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(',', ' ');
                        int y = 0;
                        for (int t = 0; t < parts.Length; t++)
                        {
                            float value = float.Parse(parts[t]);
                            if (firstLine)
                            {
                                maxValue = value; minValue = value;
                                firstLine = false;
                            }
                            else
                            {
                                if (maxValue < value) { maxValue = value; }
                                if (minValue > value) { minValue = value; }
                            }
                            positions[index++] = new vec3(startX + x, startY + y, value);
                            y++;
                        }
                        x++;
                    }
                }

                BoundingBox box = positions.Move2Center();
                vec3 max = box.MaxPosition, min = box.MinPosition;
                float a = (max.x - min.x) / (max.z - min.z);
                float b = (max.y - min.y) / (max.z - min.z);
                if (a > b) { a = b; }
                max.x = max.x / a; max.y = max.y / a;
                min.x = min.x / a; min.y = min.y / a;
                for (int i = 0; i < positions.Length; i++)
                {
                    var pos = positions[i];
                    positions[i] = new vec3(pos.x / a, pos.y / a, pos.z);
                }
                var colors = new vec3[positions.Length];
                for (int i = 0; i < colors.Length; i++)
                {
                    float height = positions[i].z;
                    int c = (int)((height - minValue) / (maxValue - minValue) * colorTableLength);
                    if (c < 0) { c = 0; }
                    if (c >= colorTableLength) { c = colorTableLength - 1; }
                    colors[i] = this.colorTable.GetPixel(c, 0).ToVec3();
                }

                SceneNodeBase rootNode = this.scene.RootNode;
                rootNode.Children.Clear();
                var model = new NodePointModel(positions, colors);
                var node = NodePointNode.Create(model);
                node.DiffuseColor = Color.Red;
                rootNode.Children.Add(node);
                {
                    var arcball = new ArcBallManipulater(GLMouseButtons.Left | GLMouseButtons.Right);
                    arcball.Bind(this.scene.Camera, this.winGLCanvas1);
                    arcball.Rotated += arcball_Rotated;
                }
                //vec3 max = new vec3(xLength / 2, yLength / 2, maxValue);
                //vec3 min = new vec3(-xLength / 2, -yLength / 2, minValue);
                //vec3 center = max / 2.0f + min / 2.0f;
                vec3 center = new vec3();
                vec3 size = max - min;
                float v = size.x;
                if (v < size.y) { v = size.y; } if (v < size.z) { v = size.z; }
                this.scene.Camera.Position = center + size;
                this.scene.Camera.Target = center;
                //rootElement.WorldPosition = center;
                //this.manipulater.StepLength = v / 30.0f;
            }
        }

        void arcball_Rotated(object sender, ArcBallManipulater.Rotation e)
        {
            {
                SceneNodeBase node = this.scene.RootNode;
                if (node != null)
                {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

    }
}
