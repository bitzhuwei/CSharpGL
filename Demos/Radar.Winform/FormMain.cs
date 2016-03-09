using CSharpGL;
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
            this.cameraRotator = new SatelliteRotator(this.camera);

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();

            this.modelRenderer.SetUniformValue("mvp",
                projectionMatrix * viewMatrix * modelMatrix);

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
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            cameraRotator.MouseUp(e.X, e.Y);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormMain_Load(object sender, EventArgs e)
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
                                if (value != 0.0f)
                                {
                                    vec3 color = colorBar.GetColor(min, max, value);
                                    colorList.Add(color);

                                    float x = vertexIndex % xSize;
                                    float y = (vertexIndex / xSize) % ySize;
                                    float z = (vertexIndex / ySize / xSize) % zSize;
                                    vec3 position = new vec3(x - xSize / 2, y - ySize / 2, z - zSize / 2);
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
            this.modelRenderer.Initialize();//不在此显式初始化也可以。

            this.glCanvas1.Invalidate();//重绘图形。

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("This is a diffuse reflection demo with directional light and ambient light.");
            builder.AppendLine("Use 'c' to switch camera types between perspective and ortho.");
            builder.AppendLine("Use mouse to rotate camera.");
            builder.AppendLine("Use 'j' to decrease vertex count.");
            builder.AppendLine("Use 'k' to increase vertex count.");

            MessageBox.Show(builder.ToString());
        }

    }
}
