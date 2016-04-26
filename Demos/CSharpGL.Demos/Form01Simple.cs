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
                if (this.RenderMode == RenderModes.ColorCodedPicking)
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

            if (this.RenderMode == RenderModes.ColorCodedPicking)
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

        DragParam dragParam;

        private FormBulletinBoard mouseBoard;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                PickedGeometry pickedGeometry = RunPicking(e.X, e.Y);
                if (pickedGeometry != null)
                {
                    var dragParam = new DragParam(camera, pickedGeometry);
                    dragParam.lastFarPos = glm.unProject(new vec3(e.X, glCanvas1.Height - e.Y - 1, 1),
                        dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    dragParam.lastNearPos = glm.unProject(new vec3(e.X, glCanvas1.Height - e.Y - 1, 0),
                        dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    this.dragParam = dragParam;

                    this.lblRightMouseDown.Text = string.Format("near: [{0}] far: [{1}] depth: [{2}]",
                        dragParam.lastNearPos, dragParam.lastFarPos, dragParam.targetDepth);
                }
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.MouseMove(e.X, e.Y);
                //this.cameraUpdated = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                if (this.dragParam != null)
                {
                    var farPos = glm.unProject(new vec3(e.X, glCanvas1.Height - e.Y - 1, 1),
                        dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    var nearPos = glm.unProject(new vec3(e.X, glCanvas1.Height - e.Y - 1, 0),
                        dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    vec3[] differences = new vec3[dragParam.targetDepth.Length];
                    for (int i = 0; i < differences.Length; i++)
                    {
                        differences[i] = (nearPos - dragParam.lastNearPos) * (1 - dragParam.targetDepth[i])
                            + (farPos - dragParam.lastFarPos) * dragParam.targetDepth[i];
                    }
                    dragParam.lastFarPos = farPos;
                    dragParam.lastNearPos = nearPos;

                    this.rendererDict[this.selectedModel].MovePositions(
                        differences, dragParam.pickedGeometry.Indexes);

                    this.lblRightMouseMove.Text = string.Format("near: [{0}] far: [{1}] diff: [{2}]",
                        nearPos, farPos, differences);
                }
                else
                { this.mouseBoard.SetContent("Mouse Move: No action."); }
            }
            else
            {
                RunPicking(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                //this.pickedGeometry = null;
                this.dragParam = null;

                this.mouseBoard.SetContent("Mouse Up: No action.");
            }
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.MouseWheel(e.Delta);
            //cameraUpdated = true;
        }

        private PickedGeometry RunPicking(int x, int y)
        {
            lock (this.synObj)
            {
                {
                    this.glCanvas1_OpenGLDraw(selectedModel, null);
                    Color c = GL.ReadPixel(x, this.glCanvas1.Height - y - 1);
                    c = Color.FromArgb(255, c);
                    this.lblReadColor.BackColor = c;
                    var depth = new UnmanagedArray<float>(1);
                    GL.ReadPixels(x, glCanvas1.Height - y - 1, 1, 1,
                        GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT, depth.Header);
                    var targetDepth = depth[0];
                    depth.Dispose();
                    this.lblText.Text = string.Format(
                        "Position: {0}, {1}, Depth: {2}",
                            new Point(x, y), this.lblReadColor.BackColor, targetDepth);
                }
                {
                    IColorCodedPicking pickable = this.rendererDict[this.SelectedModel];
                    pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();
                    PickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                        this.camera, x, y, this.glCanvas1.Width, this.glCanvas1.Height, pickable);
                    if (pickedGeometry != null)
                    {
                        this.RunPickingBoard.SetContent(pickedGeometry.ToString(
                            camera.GetProjectionMat4(), camera.GetViewMat4()));
                    }
                    else
                    {
                        this.RunPickingBoard.SetContent("picked nothing.");
                    }

                    return pickedGeometry;
                }
            }
        }

        private void Form01ModernRenderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 2);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                Random random = new Random();
                var bufferables = new IBufferable[]{
                    new BigDipperAdapter(new BigDipper()),
                    new ChainModelAdapter(new ChainModel(random.Next(7, 100), 5, 5)),
                };
                var keys = new GeometryModel[] { GeometryModel.BigDipper, GeometryModel.Chain, };
                for (int i = 0; i < bufferables.Length; i++)
                {
                    IBufferable bufferable = bufferables[i];
                    GeometryModel key = keys[i];
                    ShaderCode[] shaders = new ShaderCode[2];
                    shaders[0] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.vert"), ShaderType.VertexShader);
                    shaders[1] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.frag"), ShaderType.FragmentShader);
                    var propertyNameMap = new PropertyNameMap();
                    propertyNameMap.Add("in_Position", "position");
                    propertyNameMap.Add("in_Color", "color");
                    string positionNameInIBufferable = "position";
                    var renderer = ModernRendererFactory.GetModernRenderer(bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    renderer.Initialize();
                    GLSwitch lineWidthSwitch = new LineWidthSwitch(10.0f);
                    renderer.SwitchList.Add(lineWidthSwitch);
                    GLSwitch pointSizeSwitch = new PointSizeSwitch(10.0f);
                    renderer.SwitchList.Add(pointSizeSwitch);
                    GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                    renderer.SwitchList.Add(polygonModeSwitch);

                    this.rendererDict.Add(key, renderer);
                }
                this.SelectedModel = GeometryModel.BigDipper;
            }
            {
                var frmBulletinBoard = new FormBulletinBoard();
                //frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.RunPickingBoard = frmBulletinBoard;
            }
            {
                var frmBulletinBoard = new FormBulletinBoard();
                frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.mouseBoard = frmBulletinBoard;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.rendererDict[this.SelectedModel]);
                frmPropertyGrid.Show();
                //this.rendererPropertyGrid = frmPropertyGrid;
            }
            //{
            //    var frmPropertyGrid = new FormProperyGrid();
            //    frmPropertyGrid.DisplayObject(this.camera);
            //    frmPropertyGrid.Show();
            //    this.cameraPropertyGrid = frmPropertyGrid;
            //}
            //{
            //    var frmPropertyGrid = new FormProperyGrid();
            //    frmPropertyGrid.DisplayObject(this);
            //    frmPropertyGrid.Show();
            //    this.formPropertyGrid = frmPropertyGrid;
            //}

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

        class DragParam
        {
            public DragParam(Camera camera, PickedGeometry pickedGeometry)
            {
                this.pickedGeometry = pickedGeometry;
                this.projectionMatrix = camera.GetProjectionMat4();
                this.viewMatrix = camera.GetViewMat4();
                var viewport = new int[4]; GL.GetInteger(GetTarget.Viewport, viewport);
                this.viewport = new vec4(viewport[0], viewport[1], viewport[2], viewport[3]);

                this.targetDepth = new float[pickedGeometry.Positions.Length];
                for (int i = 0; i < pickedGeometry.Positions.Length; i++)
                {
                    var worldPos = new vec3(projectionMatrix * viewMatrix * new vec4(pickedGeometry.Positions[i], 1));
                    vec3 projectedPos = glm.project(worldPos, viewMatrix, projectionMatrix, this.viewport);
                    vec3 win = new vec3(projectedPos.x, projectedPos.y, 1);
                    vec3 farPos = glm.unProject(win,
                        viewMatrix, projectionMatrix, this.viewport);
                    win.z = 0;
                    //vec3 nearPos = glm.unProject(win,
                    //    dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    vec3 vTarget = worldPos - camera.Position;//nearPos;
                    vec3 vFar = farPos - camera.Position;// nearPos;
                    float x = vTarget.x / vFar.x;
                    float y = vTarget.y / vFar.y;
                    float z = vTarget.z / vFar.z;
                    this.targetDepth[i] = x / 3 + y / 3 + z / 3;
                }
            }

            public vec3 lastFarPos;
            public vec3 lastNearPos;
            public float[] targetDepth;
            public mat4 projectionMatrix;
            public mat4 viewMatrix;
            public vec4 viewport;
            public PickedGeometry pickedGeometry;
        }
    }
}
