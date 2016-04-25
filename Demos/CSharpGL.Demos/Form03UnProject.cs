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

namespace CSharpGL.Demos
{
    public partial class Form03UnProject : Form
    {
        Camera camera;
        SatelliteRotator rotator;

        float[] clearColor = new float[4];

        Random random = new Random();

        public Form03UnProject()
        {
            InitializeComponent();

            // 天蓝色背景
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);

            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(-1, -1, -1);
                camera.Target = new vec3();
                camera.UpVector = new vec3(0, 1, 0);
                this.camera = camera;
                this.rotator = new SatelliteRotator(this.camera);
            }

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.MouseClick += glCanvas1_MouseClick;
        }



        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            rotator.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (rotator.MouseDownFlag)
            {
                rotator.MouseMove(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            rotator.MouseUp(e.X, e.Y);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.MouseWheel(e.Delta);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);

            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            this.camera.LegacyGLProjection();
            //GL.MatrixMode(GL.GL_MODELVIEW);
            //GL.LoadIdentity();

            GL.PointSize(100);
            GL.LineWidth(100);

            GL.Begin(PrimitiveMode.Lines);
            for (int i = 0; i < positionList.Count; i++)
            {
                var bytes = new byte[4]; random.NextBytes(bytes);
                GL.Color(colorList[i].x, colorList[i].y, colorList[i].z);
                GL.Vertex(positionList[i].x, positionList[i].y, positionList[i].z);
            }
            GL.End();
        }

        private vec3 RandomColor()
        {
            return new vec3(
               (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
        }

        List<vec3> positionList = new List<vec3>();
        List<vec3> colorList = new List<vec3>();
        void glCanvas1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                {
                    vec3 position = glm.unProject(new vec3(e.X, this.glCanvas1.Height - e.Y - 1, 0),
                       camera.GetViewMat4(), camera.GetProjectionMat4(),
                       new vec4(0, 0, this.glCanvas1.Width, this.glCanvas1.Height));

                    this.colorList.Add(RandomColor());
                    this.positionList.Add(position);
                }
                {
                    vec3 position = glm.unProject(new vec3(e.X, this.glCanvas1.Height - e.Y - 1, 1),
                       camera.GetViewMat4(), camera.GetProjectionMat4(),
                       new vec4(0, 0, this.glCanvas1.Width, this.glCanvas1.Height));

                    this.colorList.Add(RandomColor());
                    this.positionList.Add(position);
                }
            }
        }

        private void Form00GLCanvas_Load(object sender, EventArgs e)
        {
            //this.positionList.Add(new vec3(1, 1, 0));
            //this.positionList.Add(new vec3(-1, 1, 0));
            //this.positionList.Add(new vec3(-1, -1, 0));
            //this.positionList.Add(new vec3(1, -1, 0));
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                mat4 projection = camera.GetProjectionMat4();
                mat4 view = camera.GetViewMat4();
                int[] viewport = new int[4];
                GL.GetInteger(GetTarget.Viewport, viewport);

                var points = new List<Point>();
                var nearList = new List<vec3>();
                var farList = new List<vec3>();
                //Random random = new Random();
                //points.Add(new Point(this.glCanvas1.Width / 2, 0));
                //points.Add(new Point(this.glCanvas1.Width / 2, this.glCanvas1.Height / 2));
                for (int i = 0; i < 10; i++)
                {
                    points.Add(
                        new Point(
                            random.Next(0, this.glCanvas1.Width),
                            random.Next(0, this.glCanvas1.Height)));
                }

                //points.Add(new Point(0, this.glCanvas1.Height));
                //points.Add(new Point(this.glCanvas1.Width, this.glCanvas1.Height));
                //points.Add(new Point(this.glCanvas1.Width, 0));
                //points.Add(new Point(0, 0));
                foreach (var item in points)
                {
                    {
                        vec3 worldPos = glm.unProject(
                            new vec3(item.X, this.glCanvas1.Height - item.Y, 0),
                            view, projection, new vec4(viewport[0], viewport[1], viewport[2], viewport[3]));

                        vec3 modelPos = new vec3(glm.inverse(view) * new vec4(worldPos, 1.0f));
                        vec3 newWorldPos = new vec3(view * new vec4(modelPos, 1.0f));
                        nearList.Add(worldPos);
                    }
                    {
                        vec3 worldPos = glm.unProject(
                            new vec3(item.X, this.glCanvas1.Height - item.Y, 1),
                            view, projection, new vec4(viewport[0], viewport[1], viewport[2], viewport[3]));

                        vec3 modelPos = new vec3(glm.inverse(view) * new vec4(worldPos, 1.0f));
                        vec3 newWorldPos = new vec3(view * new vec4(modelPos, 1.0f));
                        farList.Add(worldPos);
                    }
                }
                vec3 original = camera.Position;
                for (int i = 0; i < nearList.Count; i++)
                {
                    vec3 near = nearList[i];
                    vec3 far = farList[i];
                    //Console.WriteLine(far.x / near.x);
                    //Console.WriteLine(far.y / near.y);
                    //Console.WriteLine(far.z / near.z);
                    vec3 v1 = near - original;
                    vec3 v2 = far - original;
                    Console.WriteLine(v2.x / v1.x);
                    Console.WriteLine(v2.y / v1.y);
                    Console.WriteLine(v2.z / v1.z);
                    Console.WriteLine("------------------");
                }
            }
        }

    }
}
