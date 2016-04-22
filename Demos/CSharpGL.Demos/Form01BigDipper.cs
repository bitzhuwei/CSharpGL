using CSharpGL.ModelAdapters;
using CSharpGL.Models;
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

namespace CSharpGL.Demos
{
    public partial class Form01BigDipper : Form
    {

        /// <summary>
        /// 要渲染的对象
        /// </summary>
        ModernRenderer renderer;

        bool cameraUpdated = true;

        public bool CameraUpdated
        {
            get { return cameraUpdated; }
        }
        /// <summary>
        /// 控制Camera的旋转、进退
        /// </summary>
        SatelliteRotator rotator;
        /// <summary>
        /// 摄像机
        /// </summary>
        Camera camera;

        private FormBulletinBoard bulletinBoard;
        private FormProperyGrid rendererPropertyGrid;
        private FormProperyGrid cameraPropertyGrid;
        private FormProperyGrid formPropertyGrid;

        public Form01BigDipper()
        {
            InitializeComponent();

            this.RenderMode = RenderModes.Render;

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            // 天蓝色背景
            //GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.ClearColor(0, 0, 0, 0);
        }


        public RenderModes RenderMode { get; set; }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            if (this.RenderMode == RenderModes.ColorCodedPicking)
            { GL.ClearColor(1, 1, 1, 1); }
            else if (this.RenderMode == RenderModes.Render)
            { GL.ClearColor(0, 0, 0, 0); }

            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            ModernRenderer renderer = this.renderer;
            if (renderer != null)
            {
                if (cameraUpdated)
                {
                    mat4 projectionMatrix = camera.GetProjectionMat4();
                    mat4 viewMatrix = camera.GetViewMat4();
                    mat4 modelMatrix = mat4.identity();
                    if (this.RenderMode == RenderModes.ColorCodedPicking)
                    { ((IColorCodedPicking)renderer).MVP = projectionMatrix * viewMatrix * modelMatrix; }
                    else if (this.RenderMode == RenderModes.Render)
                    {
                        renderer.SetUniformValue("projectionMatrix", projectionMatrix);
                        renderer.SetUniformValue("viewMatrix", viewMatrix);
                        renderer.SetUniformValue("modelMatrix", modelMatrix);
                    }
                    cameraUpdated = false;
                }
                renderer.Render(new RenderEventArgs(this.RenderMode, this.camera));
            }
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
                this.cameraUpdated = true;
            }

            {
                IColorCodedPicking pickable = this.renderer;
                pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();
                IPickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                    this.camera, e.X, e.Y, this.glCanvas1.Width, this.glCanvas1.Height, pickable);
                if (pickedGeometry != null)
                {
                    this.bulletinBoard.SetContent(pickedGeometry.ToString());
                }
                else
                {
                    this.bulletinBoard.SetContent("picked nothing.");
                }
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            rotator.MouseUp(e.X, e.Y);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.MouseWheel(e.Delta);
            cameraUpdated = true;
        }

        private void Form01ModernRenderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                IBufferable bufferable = new BigDipperAdapter(new BigDipper());
                ShaderCode[] shaders = new ShaderCode[2];
                shaders[0] = new ShaderCode(File.ReadAllText(@"Shaders\BigDipper.vert"), ShaderType.VertexShader);
                shaders[1] = new ShaderCode(File.ReadAllText(@"Shaders\BigDipper.frag"), ShaderType.FragmentShader);
                var propertyNameMap = new PropertyNameMap();
                propertyNameMap.Add("in_Position", "position");
                propertyNameMap.Add("in_Color", "color");
                string positionNameInIBufferable = "position";
                var renderer = new ModernRenderer(bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                renderer.Initialize();
                GLSwitch lineWidthSwitch = new LineWidthSwitch(10.0f);
                renderer.SwitchList.Add(lineWidthSwitch);
                GLSwitch pointSizeSwitch = new PointSizeSwitch(10.0f);
                renderer.SwitchList.Add(pointSizeSwitch);
                GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                renderer.SwitchList.Add(polygonModeSwitch);

                this.renderer = renderer;
            }
            {
                var frmBulletinBoard = new FormBulletinBoard();
                frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.bulletinBoard = frmBulletinBoard;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.renderer);
                frmPropertyGrid.Show();
                this.rendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.camera);
                frmPropertyGrid.Show();
                this.cameraPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }

        }

    }
}
