using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.ColorCodedPicking;
using CSharpGL.Objects.Demos;
using CSharpGL.Objects.Demos.UIs;
using CSharpGL.UIs;
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
    public partial class FormColorCodedPicking : Form
    {
        SimpleUIAxis uiAxis;
        DemoColorCodedPickingElement element;
        SatelliteRotator rotator;
        Camera camera;

        public FormColorCodedPicking()
        {
            InitializeComponent();

            //if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            //{
            //    this.camera = CameraDictionary.Instance[this.GetType().Name];
            //}
            //else
            {
                this.camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                //CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }

            const int size = 3;
            this.camera.Position = new vec3(size * 3, size * 3, size * 3);

            rotator = new SatelliteRotator(this.camera);

            element = new DemoColorCodedPickingElement(size);
            element.Initialize();
            //element.BeforeRendering += element_BeforeRendering;
            //element.AfterRendering += element_AfterRendering;

            Padding uiPadding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            Size uiSize = new System.Drawing.Size(50, 50);
            IUILayoutParam uiParam = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, uiPadding, uiSize);
            uiAxis = new SimpleUIAxis(uiParam);
            uiAxis.Initialize();

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;

            this.Load += FormColorCodedPicking_Load;
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (this.camera != null)
            {
                this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);

                this.glCanvas1.Invalidate();
            }
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);

            this.glCanvas1.Invalidate();
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.ResetShaderProgram();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;

            element.SetShaderProgram(mvp);
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            element.Render(arg);
            uiAxis.Render(arg);
        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                this.rotator.MouseDown(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.rotator.MouseDownFlag && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.rotator.MouseMove(e.X, e.Y);

                this.glCanvas1.Invalidate();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                IPickedGeometry pickedGeometry = this.Pick(e.X, e.Y);
                if (pickedGeometry != null)
                {
                    this.txtPickedInfo.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss.ff} {1}",
                        DateTime.Now, pickedGeometry);
                }
                else
                {
                    this.txtPickedInfo.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss.ff} {1}",
                        DateTime.Now, "nothing picked");
                }
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.rotator.MouseUp(e.X, e.Y);
            }
        }

        private void FormColorCodedPicking_Load(object sender, EventArgs e)
        {
            this.txtPickedInfo.Text = string.Format("camera type: {0}", this.camera.CameraType);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Use 'c' to switch camera types between perspective and ortho");
            builder.AppendLine("Use 'j' to increase faces");
            builder.AppendLine("Use 'k' to decrease faces");
            //builder.AppendLine("Use right click to pick a primitive.");
            builder.AppendLine("Click Down Right Mouse to pick a primitive.");
            MessageBox.Show(builder.ToString());
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'j')
            {
                this.element.Count++;

                this.glCanvas1.Invalidate();
            }
            else if (e.KeyChar == 'k')
            {
                this.element.Count--;

                this.glCanvas1.Invalidate();
            }
            else if (e.KeyChar == 'c')
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
                        break;
                }

                this.glCanvas1.Invalidate();
            }
        }

        //private void glCanvas1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        IPickedGeometry pickedGeometry = this.Pick(e.X, e.Y);
        //        if (pickedGeometry != null)
        //        {
        //            this.txtPickedInfo.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss.ff} {1}",
        //                DateTime.Now, pickedGeometry);
        //        }
        //        else
        //        {
        //            this.txtPickedInfo.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss.ff} {1}",
        //                DateTime.Now, "nothing picked");
        //        }
        //    }
        //}

        private IPickedGeometry Pick(int x, int y)
        {
            //this.glCanvas1.MakeCurrent();
            // render the scene for color-coded picking.
            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            SharedStageInfo info = new SharedStageInfo();
            info.Reset();
            var arg = new RenderEventArgs(RenderModes.HitTest, this.camera);

            IColorCodedPicking pickable = this.element;
            info.RenderForPicking(pickable, arg);

            GL.Flush();

            // get coded color.
            //byte[] codedColor = new byte[4];
            UnmanagedArray<byte> codedColor = new UnmanagedArray<byte>(4);
            GL.ReadPixels(x, this.glCanvas1.Height - y - 1, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, codedColor.Header);
            if (codedColor[0] == byte.MaxValue && codedColor[1] == byte.MaxValue
                && codedColor[2] == byte.MaxValue && codedColor[3] == byte.MaxValue)
            {
                // This is when (x, y) is on background and no primitive is picked.
                return null;
            }

            /* // This is how is vertexID coded into color in vertex shader.
             * 	int objectID = gl_VertexID;
                codedColor = vec4(
                    float(objectID & 0xFF), 
                    float((objectID >> 8) & 0xFF), 
                    float((objectID >> 16) & 0xFF), 
                    float((objectID >> 24) & 0xFF));
             */

            // get vertexID from coded color.
            // the vertexID is the last vertex that constructs the primitive.
            // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
            uint shiftedR = (uint)codedColor[0];
            uint shiftedG = (uint)codedColor[1] << 8;
            uint shiftedB = (uint)codedColor[2] << 16;
            uint shiftedA = (uint)codedColor[3] << 24;
            uint stageVertexID = shiftedR + shiftedG + shiftedB + shiftedA;

            // get picked primitive.
            IPickedGeometry pickedGeometry = null;
            pickedGeometry = ((IColorCodedPicking)this.element).Pick(stageVertexID);

            return pickedGeometry;
        }
    }
}
