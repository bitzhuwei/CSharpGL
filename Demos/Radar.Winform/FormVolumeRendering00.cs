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
        /// <summary>
        /// 解析数据文件，得到3D纹理
        /// </summary>
        private RawDataProcessor processor = new RawDataProcessor();

        /// <summary>
        /// 从哪个角度观察模型
        /// </summary>
        private Camera camera;
        
        /// <summary>
        /// 旋转camera
        /// </summary>
        private SatelliteRotator rotator;

        /// <summary>
        /// 执行渲染指令
        /// </summary>
        private RadarRenderer radarRenderer = new RadarRenderer();

        /// <summary>
        /// 在窗口固定位置渲染一个坐标轴
        /// </summary>
        private SimpleUIAxis axis;

        private const string textureFilename = "floordata";


        public FormVolumeRendering00()
        {
            InitializeComponent();

            // 解析文件，得到3D数据纹理
            string datafilePrefix = @"data\floordata";
            string[] filenames = new string[20];
            for (int i = 0; i < 20; i++)
            {
                string filename = datafilePrefix + (i + 1).ToString() + ".txt";
                filenames[i] = filename;
            }
            processor.ReadFile(filenames, 921, 921, 20);

            // 初始化camera及其rotator
            this.camera = new Camera(CameraType.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
            this.camera.Position = new vec3(0, 0, 5);
            this.camera.Target = new vec3(0, 0, 0);
            this.camera.UpVector = new vec3(0, 1, 0);
            this.rotator = new SatelliteRotator(this.camera);
            radarRenderer.Initialize(processor);

            // 初始化axis
            this.axis = new SimpleUIAxis(
                new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom,
                new Padding(10, 10, 10, 10), new Size(50, 50)));
            this.axis.Initialize();

            // 初始化各个事件
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
                this.radarRenderer.SourceFactor = sourceFactors[sourceFactorIndex];
            }
            else if (e.KeyChar == 'd')
            {
                destFactorIndex++;
                if (destFactorIndex >= destFactors.Length) { destFactorIndex = 0; }
                this.radarRenderer.DestFactor = destFactors[destFactorIndex];
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

                this.radarRenderer.SourceFactor = sourceFactors[sourceFactorIndex];
                this.radarRenderer.DestFactor = destFactors[destFactorIndex];
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

                this.radarRenderer.SourceFactor = sourceFactors[sourceFactorIndex];
                this.radarRenderer.DestFactor = destFactors[destFactorIndex];
            }

            this.lblBlendFuncParams.Text = string.Format("{0} - {1}",
                sourceFactors[sourceFactorIndex],
                destFactors[destFactorIndex]);
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            // 改变窗口大小
            this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            // 缩放
            this.camera.MouseWheel(e.Delta);
        }

        // 执行渲染
        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            // 背景色：天蓝色
            //GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            // 背景色：黑色
            GL.ClearColor(0, 0, 0, 0);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            // 渲染坐标轴
            this.axis.Render(new RenderEventArgs(RenderModes.Render, this.camera));

            // camera准备
            this.camera.LegacyGLProjection();
            // 渲染radar
            radarRenderer.Render();

        }

        /// <summary>
        /// 旋转camera：鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            this.rotator.MouseDown(e.X, e.Y);
        }

        /// <summary>
        /// 旋转camera：鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.rotator.MouseMove(e.X, e.Y);

            UpdateCameraDirectionDisplay(this.camera);

            // camera位置不同时，要调整渲染各个层的顺序
            var direction = (camera.Target - camera.Position).normalize();
            this.radarRenderer.reverseRender4X = direction.x >= 0;
            this.radarRenderer.reverseRender4Y = direction.y >= 0;
            this.radarRenderer.reverseRender4Z = direction.z >= 0;
        }

        private void UpdateCameraDirectionDisplay(Camera camera)
        {
            var direction = camera.Target - camera.Position;
            this.lblCameraDirection.Text =
                string.Format("{0}, slice: {1}", direction,
                    this.radarRenderer.slice);
        }

        /// <summary>
        /// 旋转camera：鼠标弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            this.rotator.MouseUp(e.X, e.Y);
        }

        private void FormVolumeRendering01_Load(object sender, EventArgs e)
        {
            this.glCanvas1_Resize(this.glCanvas1, e);
        }

        /// <summary>
        /// 低于指定透明度的就不显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackAlpha_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackAlpha.Value / 100.0f;
            this.radarRenderer.alphaThreshold = value;
            this.lblAlphaThreshold.Text = value.ToShortString();
        }

        /// <summary>
        /// 指定要渲染的中间层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackSectionPosition_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackSectionPosition.Value / 100.0f;
            this.radarRenderer.sectionCenter = value;
            this.lblSectionPosition.Text = value.ToShortString();
        }

        /// <summary>
        /// 指定要渲染的层数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackSectionThickness_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackSectionThickness.Value / 100.0f;
            this.radarRenderer.halfThickness = value;
            this.lblSectionThick.Text = (value * 2).ToShortString();
        }

        /// <summary>
        /// 指定切割方式：将X轴方向切割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoSliceX_CheckedChanged(object sender, EventArgs e)
        {
            this.radarRenderer.slice = SliceAxis.X;

            UpdateCameraDirectionDisplay(this.camera);
        }

        /// <summary>
        /// 指定切割方式：将Y轴方向切割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoSliceY_CheckedChanged(object sender, EventArgs e)
        {
            this.radarRenderer.slice = SliceAxis.Y;

            UpdateCameraDirectionDisplay(this.camera);
        }

        /// <summary>
        /// 指定切割方式：将Z轴方向切割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoSliceZ_CheckedChanged(object sender, EventArgs e)
        {
            this.radarRenderer.slice = SliceAxis.Z;

            UpdateCameraDirectionDisplay(this.camera);
        }


    }
}
