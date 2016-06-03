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
    public partial class Form01Renderer : Form
    {
        public enum GeometryModel
        {
            Axis,
            BigDipper,
            Chain,
            Tetrahedron,
            Cube,
            Sphere,
            Teapot,
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
                    if (this.pickableRendererPropertyGrid != null)
                    {
                        this.pickableRendererPropertyGrid.DisplayObject(this.rendererDict[value].PickableRenderer);
                        this.highlightRendererPropertyGrid.DisplayObject(this.rendererDict[value].Highlighter);
                        this.frmIndexBufferPtrBoard.SetTarget(this.rendererDict[value].PickableRenderer.IndexBufferPtr);
                    }

                    //this.cameraUpdated = true;
                    this.UpdateMVP(this.rendererDict[this.selectedModel]);
                }
            }
        }

        Dictionary<GeometryModel, HighlightedPickableRenderer> rendererDict = new Dictionary<GeometryModel, HighlightedPickableRenderer>();

        ///// <summary>
        ///// 要渲染的对象
        ///// </summary>
        //Renderer renderer;

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

        private FormBulletinBoard pickedGeometryBoard;
        private FormProperyGrid pickableRendererPropertyGrid;
        private FormProperyGrid highlightRendererPropertyGrid;
        private FormProperyGrid formPropertyGrid;

        public Form01Renderer()
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
            OpenGL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);
            this.TextColor = Color.White;

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} {1}", this.Name,
                this.rendererDict[this.selectedModel].PickableRenderer.Mode);
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

        public Color TextColor { get; set; }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            lock (this.synObj)
            {
                //GL.Enable(GL.GL_SCISSOR_TEST);
                //GL.Scissor(0, 0, this.glCanvas1.Width, this.glCanvas1.Height);

                RenderersDraw(this.renderMode);

                DrawText(e);

            }
        }

        private void RenderersDraw(RenderModes renderMode, bool renderScene = true, bool renderUI = true)
        {
            var arg = new RenderEventArgs(renderMode, this.glCanvas1.ClientRectangle, this.camera, this.PickingGeometryType);
            if (renderMode == RenderModes.ColorCodedPicking)
            {
                if (renderScene)
                {
                    ColorCodedPicking.Render4Picking(arg, this.rendererDict[this.selectedModel].PickableRenderer);
                }
            }
            else if (renderMode == RenderModes.Render)
            {
                OpenGL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);

                OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

                if (renderScene) { SceneRenderersDraw(arg); }
                if (renderUI) { UIRenderersDraw(arg); }
            }
        }

        private void UIRenderersDraw(RenderEventArgs arg)
        {
            GLControl uiRoot = this.uiRoot;
            if (uiRoot != null)
            {
                uiRoot.Layout();
                mat4 projection, view, model;
                projection = glAxis.GetOrthoProjection();
                vec3 position = (this.camera.Position - this.camera.Target).normalize();
                view = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
                float length = Math.Max(glAxis.Size.Width, glAxis.Size.Height) / 2;
                model = glm.scale(mat4.identity(),
                    new vec3(length, length, length));
                glAxis.Renderer.SetUniform("projectionMatrix", projection);
                glAxis.Renderer.SetUniform("viewMatrix", view);
                glAxis.Renderer.SetUniform("modelMatrix", model);

                glAxis.Render(arg);
            }
        }

        private void SceneRenderersDraw(RenderEventArgs arg)
        {
            HighlightedPickableRenderer renderer = this.rendererDict[this.SelectedModel];
            if (renderer != null)
            {
                //if (cameraUpdated)
                {
                    UpdateMVP(renderer);
                    //cameraUpdated = false;
                }

                renderer.Render(arg);
            }
        }

        private void DrawText(PaintEventArgs e)
        {
            PickedGeometry pickedGeometry = this.pickedGeometry;
            if (pickedGeometry != null)
            {
                string content = string.Format("[index: {0}]",
                    pickedGeometry.Indexes.PrintArray());
                SizeF size = e.Graphics.MeasureString(content, font);
                // make sure the text be displayed.
                int x = this.lastMousePosition.X - (int)(size.Width / 2) + 20;
                if (x + (int)(size.Width) - 20 >= this.glCanvas1.Width)
                { x = this.glCanvas1.Width - (int)size.Width + 20; }
                else if (x < 0)
                { x = 0; }
                // make sure the text be displayed.
                int y = this.glCanvas1.Height - this.lastMousePosition.Y - 1;
                if (y + size.Height + 1 >= this.glCanvas1.Height)
                { y = this.glCanvas1.Height - 15 - 5; }
                else if (y < 15) { if (y > 0) { y += 15; } else { y = 15; } }
                else { y += 15; }
                OpenGL.DrawText(x, y,
                    this.TextColor, "Courier New", fontSize,
                    content);
                this.lblDrawText.Text = content;
            }
            else
            {
                OpenGL.DrawText(this.lastMousePosition.X,
                    this.glCanvas1.Height - this.lastMousePosition.Y - 1,
                    this.TextColor, "Courier New", fontSize,
                    "");
                this.lblDrawText.Text = "";
            }
            {
                // Cross cursor shows where the mouse is.
                OpenGL.DrawText(this.lastMousePosition.X - offset.X,
                    this.glCanvas1.Height - (this.lastMousePosition.Y + offset.Y) - 1,
                    Color.Red, "Courier New", crossCursorSize, "o");
            }
        }

        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);


        const float fontSize = 20.0f;
        Font font = new Font("Courier New", fontSize);

        private void UpdateMVP(HighlightedPickableRenderer renderer)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            if (this.RenderMode == RenderModes.ColorCodedPicking)
            {
                renderer.PickableRenderer.MVP = mvp;
            }
            else if (this.RenderMode == RenderModes.Render)
            {
                renderer.Highlighter.MVP = mvp;
                renderer.PickableRenderer.SetUniform("projectionMatrix", projectionMatrix);
                renderer.PickableRenderer.SetUniform("viewMatrix", viewMatrix);
                renderer.PickableRenderer.SetUniform("modelMatrix", modelMatrix);
            }
            else
            { throw new NotImplementedException(); }
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.MouseWheel(e.Delta);
            //cameraUpdated = true;
            this.UpdateMVP(this.rendererDict[this.selectedModel]);
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
            {
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
                this.UpdateMVP(this.rendererDict[this.selectedModel]);

                this.uiRoot.Size = this.glCanvas1.Size;
            }
        }

        private void Form01Renderer_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in this.rendererDict)
            {
                item.Value.Dispose();
            }
        }



    }
}
