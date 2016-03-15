using CSharpGL;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.UIs;
using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radar.Winform
{
    public partial class FormVolumeRendering00 : Form
    {
        private RawDataProcessor processor = new RawDataProcessor();
        private TranformationMgr m_pTransform = new TranformationMgr();
        private RendererHelper m_Renderer = new RendererHelper();

        private Camera camera;
        private SatelliteRotator rotator;
        private SectionRendererHelper section_Renderer = new SectionRendererHelper();
        private SimpleUIAxis axis;

        private bool nFlags;
        private const string textureFilename = "floordata";


        public FormVolumeRendering00()
        {
            InitializeComponent();
            string datafilePrefix = @"data\floordata";
            string[] filenames = new string[20];
            for (int i = 0; i < 20; i++)
            {
                string filename = datafilePrefix + (i + 1).ToString() + ".txt";
                filenames[i] = filename;
            }
            processor.ReadFile(filenames, 921, 921, 20);
            m_Renderer.Initialize(processor, m_pTransform);

            this.camera = new Camera(CameraType.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
            this.camera.Position = new vec3(0, 0, 5);
            this.camera.Target = new vec3(0, 0, 0);
            this.camera.UpVector = new vec3(0, 1, 0);
            this.rotator = new SatelliteRotator(this.camera);
            section_Renderer.Initialize(processor);

            this.axis = new SimpleUIAxis(
                new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom,
                new Padding(10, 10, 10, 10), new Size(50, 50)));
            this.axis.Initialize();

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
        }

        uint[] sourceFactors = new uint[] 
        {
            GL.GL_ZERO, GL.GL_ONE, 
            GL.GL_SRC_COLOR, GL.GL_ONE_MINUS_SRC_COLOR, 
            GL.GL_DST_COLOR, GL.GL_ONE_MINUS_DST_COLOR, 
            GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, 
            GL.GL_DST_ALPHA, GL.GL_ONE_MINUS_DST_ALPHA, 
            //GL.GL_CONSTANT_COLOR, GL.GL_ONE_MINUS_CONSTANT_COLOR, 
            //GL.GL_CONSTANT_ALPHA, GL.GL_ONE_MINUS_CONSTANT_ALPHA, 
            GL.GL_SRC_ALPHA_SATURATE 
        };
        uint[] destFactors = new uint[] 
        {
            GL.GL_ZERO, GL.GL_ONE, 
            GL.GL_SRC_COLOR, GL.GL_ONE_MINUS_SRC_COLOR, 
            GL.GL_DST_COLOR, GL.GL_ONE_MINUS_DST_COLOR, 
            GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, 
            GL.GL_DST_ALPHA, GL.GL_ONE_MINUS_DST_ALPHA, 
            //GL.GL_CONSTANT_COLOR, GL.GL_ONE_MINUS_CONSTANT_COLOR, 
            //GL.GL_CONSTANT_ALPHA, GL.GL_ONE_MINUS_CONSTANT_ALPHA 
        };
        int sourceFactorIndex = 3;
        int destFactorIndex = 3;
        void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                sourceFactorIndex++;
                if (sourceFactorIndex >= sourceFactors.Length) { sourceFactorIndex = 0; }
                this.m_Renderer.SourceFactor = sourceFactors[sourceFactorIndex];
                this.section_Renderer.SourceFactor = sourceFactors[sourceFactorIndex];
            }
            else if (e.KeyChar == 'd')
            {
                destFactorIndex++;
                if (destFactorIndex >= destFactors.Length) { destFactorIndex = 0; }
                this.m_Renderer.DestFactor = destFactors[destFactorIndex];
                this.section_Renderer.DestFactor = destFactors[destFactorIndex];
            }
            else if (e.KeyChar == 'a')
            {
                destFactorIndex--;
                if (destFactorIndex < 0)
                {
                    destFactorIndex = destFactors.Length - 1;
                    sourceFactorIndex--;
                    if (sourceFactorIndex < 0)
                    { sourceFactorIndex = sourceFactors.Length - 1; }
                }

                this.m_Renderer.SourceFactor = sourceFactors[sourceFactorIndex];
                this.m_Renderer.DestFactor = destFactors[destFactorIndex];
                this.section_Renderer.SourceFactor = sourceFactors[sourceFactorIndex];
                this.section_Renderer.DestFactor = destFactors[destFactorIndex];
            }
            else if (e.KeyChar == 'b')
            {
                destFactorIndex++;
                if (destFactorIndex >= destFactors.Length)
                {
                    destFactorIndex = 0;
                    sourceFactorIndex++;
                    if (sourceFactorIndex >= sourceFactors.Length)
                    { sourceFactorIndex = 0; }
                }

                this.m_Renderer.SourceFactor = sourceFactors[sourceFactorIndex];
                this.m_Renderer.DestFactor = destFactors[destFactorIndex];
                this.section_Renderer.SourceFactor = sourceFactors[sourceFactorIndex];
                this.section_Renderer.DestFactor = destFactors[destFactorIndex];
            }

            this.lblBlendFuncParams.Text = string.Format("{0} - {1}",
                sourceFactors[sourceFactorIndex],
                destFactors[destFactorIndex]);
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            m_Renderer.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            //section_Renderer.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            m_Renderer.MouseWheel(e.Delta);
            //section_Renderer.MouseWheel(e.Delta);
            this.camera.MouseWheel(e.Delta);
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.ClearColor(0, 0, 0, 0);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            this.axis.Render(new RenderEventArgs(RenderModes.Render, this.camera));

            this.camera.LegacyGLProjection();
            //m_Renderer.Render();
            section_Renderer.Render();

        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                lastPoint = e.Location;
                nFlags = true;

                this.rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                this.rotator.MouseDown(e.X, e.Y);
            }
        }

        Point lastPoint = new Point();

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nFlags && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                m_pTransform.Rotate(lastPoint.Y - e.Y, lastPoint.X - e.X, 0);
                lastPoint = e.Location;

                this.rotator.MouseMove(e.X, e.Y);

                UpdateCameraDirectionDisplay(this.camera);
            }
        }

        private void UpdateCameraDirectionDisplay(Camera camera)
        {
            var direction = camera.Target - camera.Position;
            this.lblCameraDirection.Text = string.Format("{0}", direction);
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                nFlags = false;

                this.rotator.MouseUp(e.X, e.Y);
            }
        }

        private void FormVolumeRendering01_Load(object sender, EventArgs e)
        {
            this.glCanvas1_Resize(this.glCanvas1, e);

        }


        private void trackAlpha_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackAlpha.Value / 100.0f;
            this.m_Renderer.alphaThreshold = value;
            this.section_Renderer.alphaThreshold = value;
            this.lblAlphaThreshold.Text = value.ToShortString();
        }

        private void trackNegativeZ_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackNegativeZ.Value / 100.0f;
            this.m_Renderer.negativeZ = value;
            this.lblNegativeZ.Text = value.ToShortString();
        }

        private void trackPositiveZ_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackPositiveZ.Value / 100.0f;
            this.m_Renderer.positiveZ = value;
            this.lblPositiveZ.Text = value.ToShortString();
        }

        float interval = 0.1f;
        private void trackSectionHeight_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackSectionHeight.Value / 100.0f;
            //this.section_Renderer.negativeZ = value - 0.1f;
            //this.section_Renderer.positiveZ = value + 0.1f;
            this.section_Renderer.negativeZ = value - interval;
            this.section_Renderer.positiveZ = value + interval;
        }
    }
}
