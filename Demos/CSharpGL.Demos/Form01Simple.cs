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
    public partial class Form01Simple : Form
    {
        public enum GeometryModel
        {
            BigDipper,
            Chain,
        }

        private GeometryModel selectedModel = GeometryModel.BigDipper;
        public GeometryModel SelectedModel
        {
            get { return selectedModel; }
            set
            {
                if (value != selectedModel)
                {
                    selectedModel = value;
                    if (this.rendererPropertyGrid != null)
                    { this.rendererPropertyGrid.DisplayObject(this.rendererDict[value]); }
                    //this.cameraUpdated = true;
                    this.UpdateMVP(this.rendererDict[this.selectedModel]);
                }
            }
        }

        Dictionary<GeometryModel, ModernRenderer> rendererDict = new Dictionary<GeometryModel, ModernRenderer>();

        ///// <summary>
        ///// 要渲染的对象
        ///// </summary>
        //ModernRenderer renderer;

        //bool cameraUpdated = true;

        //public bool CameraUpdated
        //{
        //    get { return cameraUpdated; }
        //}

        /// <summary>
        /// 控制Camera的旋转、进退
        /// </summary>
        SatelliteRotator rotator;
        /// <summary>
        /// 摄像机
        /// </summary>
        Camera camera;

        private FormBulletinBoard RunPickingBoard;
        private FormProperyGrid rendererPropertyGrid;
        private FormProperyGrid cameraPropertyGrid;
        private FormProperyGrid formPropertyGrid;

        public Form01Simple()
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
            GL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} {1}", this.Name, this.rendererDict[this.selectedModel].DrawMode);
        }

        public Color ClearColor { get; set; }

        RenderModes renderMode;
        private readonly object synObj = new object();

        public RenderModes RenderMode
        {
            get { return renderMode; }
            set
            {
                if (value != renderMode)
                {
                    renderMode = value;
                    this.UpdateMVP(this.rendererDict[this.selectedModel]);
                }
            }
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            lock (this.synObj)
            {
                if (this.RenderMode == RenderModes.ColorCodedPicking
                    || this.renderMode == RenderModes.ColorCodedPickingPoints)
                { GL.ClearColor(1, 1, 1, 1); }
                else if (this.RenderMode == RenderModes.Render)
                { GL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f); }

                GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

                ModernRenderer renderer = this.rendererDict[this.SelectedModel];
                if (renderer != null)
                {
                    //if (cameraUpdated)
                    {
                        UpdateMVP(renderer);
                        //cameraUpdated = false;
                    }
                    renderer.Render(new RenderEventArgs(RenderMode, this.camera));
                }
            }
        }

        private void UpdateMVP(ModernRenderer renderer)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();

            if (this.RenderMode == RenderModes.ColorCodedPicking
                || this.RenderMode == RenderModes.ColorCodedPickingPoints)
            {
                IColorCodedPicking picking = renderer;
                picking.MVP = projectionMatrix * viewMatrix * modelMatrix;
            }
            else if (this.RenderMode == RenderModes.Render)
            {
                renderer.SetUniformValue("projectionMatrix", projectionMatrix);
                renderer.SetUniformValue("viewMatrix", viewMatrix);
                renderer.SetUniformValue("modelMatrix", modelMatrix);
            }
            else
            { throw new NotImplementedException(); }
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.MouseWheel(e.Delta);
            //cameraUpdated = true;
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lock (this.synObj)
                    {
                        Save2PictureHelper.Save2Picture(0, 0,
                            this.glCanvas1.Width, this.glCanvas1.Height,
                            dlgSaveFile.FileName);
                    }
                }
            }
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (camera != null)
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
        }


    }
}
