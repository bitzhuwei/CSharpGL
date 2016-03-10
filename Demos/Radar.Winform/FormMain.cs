using CSharpGL;
using CSharpGL.Enumerations;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.ModernRendering;
using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Radar.Winform
{
    public partial class FormMain : Form
    {
        Camera camera;
        SatelliteRotator cameraRotator;
        ModernRenderer modelRenderer;

        public FormMain()
        {
            InitializeComponent();


            this.camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
            this.camera.Position = new vec3(0, 0, 80);
            this.camera.Target = new vec3(0, 0, 0);
            this.camera.UpVector = new vec3(0, 1, 0);
            this.cameraRotator = new SatelliteRotator(this.camera);

            LoadModel();

            GL.ClearColor(0, 0, 0, 0);
            this.glCanvas1.Resize += glCanvas1_Resize;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;

            this.glCanvas1.Invalidate();

        }

        void glCanvas1_Resize(object sender, EventArgs e)
        {
            this.modelRenderer.SetUniformValue("canvasWidth", (float)this.glCanvas1.Width);
            this.modelRenderer.SetUniformValue("canvasHeight", (float)this.glCanvas1.Height);
        }

        int pointSize = 2;
        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();

            this.modelRenderer.SetUniformValue("mvp",
                projectionMatrix * viewMatrix * modelMatrix);

            GL.PointSize(pointSize);

            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            this.modelRenderer.Render(arg);
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                switch (this.camera.CameraType)
                {
                    case CameraType.Perspecitive:
                        this.camera.CameraType = CameraType.Ortho;
                        break;
                    case CameraType.Ortho:
                        this.camera.CameraType = CameraType.Perspecitive;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (e.KeyChar == 'j')
            {
                this.modelRenderer.DecreaseVertexCount();
            }
            else if (e.KeyChar == 'k')
            {
                this.modelRenderer.IncreaseVertexCount();
            }
            else if (e.KeyChar == 'p')
            {
                switch (this.modelRenderer.polygonMode)
                {
                    case PolygonModes.Points:
                        this.modelRenderer.polygonMode = PolygonModes.Lines;
                        break;
                    case PolygonModes.Lines:
                        this.modelRenderer.polygonMode = PolygonModes.Filled;
                        break;
                    case PolygonModes.Filled:
                        this.modelRenderer.polygonMode = PolygonModes.Points;
                        break;
                    default:
                        break;
                }
            }

            this.glCanvas1.Invalidate();
        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            cameraRotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            cameraRotator.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cameraRotator.MouseDownFlag)
            {
                cameraRotator.MouseMove(e.X, e.Y);

                this.glCanvas1.Invalidate();
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            cameraRotator.MouseUp(e.X, e.Y);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);

            this.glCanvas1.Invalidate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {


            StringBuilder builder = new StringBuilder();
            builder.AppendLine("This is a diffuse reflection demo with directional light and ambient light.");
            builder.AppendLine("Use 'c' to switch camera types between perspective and ortho.");
            builder.AppendLine("Use mouse to rotate camera.");
            builder.AppendLine("Use 'j' to decrease vertex count.");
            builder.AppendLine("Use 'k' to increase vertex count.");

            //MessageBox.Show(builder.ToString());


            this.glCanvas1.Invalidate();//重绘图形。

        }

        private void LoadModel()
        {
            string datafilePrefix = @"data\floordata";
            int noneZeroItemCount = 0;
            bool minSet = false, maxSet = false;
            float min = 0, max = 0;
            char[] separator = new char[] { ' ', '\t', '\r', '\n' };
            for (int i = 0; i < 20; i++)
            {
                string filename = datafilePrefix + (i + 1).ToString() + ".txt";
                //using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                using (var sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var part in parts)
                        {
                            float value;
                            if (float.TryParse(part, out value))
                            {
                                if (value != 0.0f) { noneZeroItemCount++; }
                                if (!minSet) { min = value; minSet = true; }
                                if (!maxSet) { max = value; maxSet = true; }

                                if (value < min) { min = value; }
                                if (max < value) { max = value; }
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                }
            }

            ColorBar colorBar = ColorBar.GetDefault();
            int xSize = 921, ySize = 921, zSize = 20;
            int vertexIndex = 0;
            List<vec3> positionList = new List<vec3>();
            List<vec3> colorList = new List<vec3>();
            for (int i = 0; i < 20; i++)
            {
                string filename = datafilePrefix + (i + 1).ToString() + ".txt";
                using (var sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var part in parts)
                        {
                            float value;
                            if (float.TryParse(part, out value))
                            {
                                if (value != 0.0f)
                                {
                                    vec3 color = colorBar.GetColor(min, max, value);
                                    //vec3 color = new vec3(1, 1, 1);
                                    colorList.Add(color);

                                    float x = vertexIndex % xSize;
                                    float y = (vertexIndex % (xSize * ySize)) / ySize;
                                    float z = vertexIndex / ySize / xSize;

                                    if (vertexIndex !=
                                        x + y * xSize + z * ySize * xSize)
                                    {
                                        Console.WriteLine("asdf");
                                    }
                                    vec3 position = new vec3(x - xSize / 2, y - ySize / 2, z - zSize / 2);
                                    position = position / 10;
                                    positionList.Add(position);
                                }

                                vertexIndex++;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                }
            }

            RadarModel model = new RadarModel(positionList, colorList);
            CodeShader[] codeShaders = new CodeShader[2];
            codeShaders[0] = new CodeShader(File.ReadAllText("Radar.vert"), CodeShader.GLSLShaderType.VertexShader);
            codeShaders[1] = new CodeShader(File.ReadAllText("Radar.frag"), CodeShader.GLSLShaderType.FragmentShader);
            PropertyNameMap propertyNameMap = PropertyNameMap.Parse(XElement.Load("Radar.PropertyNameMap.xml"));
            UniformNameMap uniformNameMap = UniformNameMap.Parse(XElement.Load("Radar.UniformNameMap.xml"));
            this.modelRenderer = new ModernRenderer(model, codeShaders, propertyNameMap, uniformNameMap);
            this.modelRenderer.SwitchList.Add(new PointSpriteSwitch());
            this.modelRenderer.Initialize();//不在此显式初始化也可以。
            this.modelRenderer.SetUniformValue("canvasWidth", (float)this.glCanvas1.Width);
            this.modelRenderer.SetUniformValue("canvasHeight", (float)this.glCanvas1.Height);
            this.modelRenderer.SetUniformValue("brightness", 1.0f);
            Texture2D texture = new Texture2D();
            texture.Initialize(new Bitmap("cloud30.png"));
            this.modelRenderer.SetUniformValue("cloudTexture", new samplerValue(texture.Name, ActiveTextureIndex.Texture0));
        }

        private void trackPointSize_Scroll(object sender, EventArgs e)
        {
            this.pointSize = trackPointSize.Value;

            this.modelRenderer.SetUniformValue("pointSize", (float)trackPointSize.Value);

            this.glCanvas1.Invalidate();
        }

    }
}
