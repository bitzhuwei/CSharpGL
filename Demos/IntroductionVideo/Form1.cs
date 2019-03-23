using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IntroductionVideo {
    public partial class Form1 : Form {
        private Scene scene;
        private ActionList actionList;
        //private CubeNode cubeNode;

        public Form1() {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
            // render event.
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            // resize event.
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseDown += glCanvas1_MouseDown;
            this.winGLCanvas1.MouseMove += glCanvas1_MouseMove;
            this.winGLCanvas1.MouseUp += glCanvas1_MouseUp;

            this.winGLCanvas1.MouseDown += winGLCanvas1_MouseDown;
            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
            this.winGLCanvas1.MouseUp += winGLCanvas1_MouseUp;
        }


        private void FormMain_Load(object sender, EventArgs e) {
            var position = new vec3(5, 3, 4) * 0.4f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var scene = new Scene(camera);
            scene.RootNode = GetNodes();
            {
                //var light = new DirectionalLight(new vec3(1, 3, -1));
                var light = new SpotLight(new vec3(1, 3, -1) * 0.5f, new vec3(), (float)Math.Cos(120.0 / 180.0 * Math.PI));
                scene.Lights.Add(light);
            }
            this.scene = scene;
            //WinCtrlRoot rootControl = GetRootControl();
            //scene.RootControl = rootControl;
            //rootControl.Bind(this.winGLCanvas1);

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var lightAction = new BlinnPhongAction(scene);
            list.Add(lightAction);
            var shadowAction = new ShadowMappingAction(scene);
            list.Add(shadowAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            var billboardSortAction = new BillboardSortAction(scene.RootNode, camera);
            list.Add(billboardSortAction);
            var billboardRenderAction = new BillboardRenderAction(camera, billboardSortAction);
            list.Add(billboardRenderAction);
            //var guiRenderAction = new GUIRenderAction(scene.RootControl);
            //list.Add(guiRenderAction);

            this.actionList = list;

            //// uncomment these lines to enable manipualter of camera!
            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.BindingMouseButtons = GLMouseButtons.Right;
            //manipulater.Bind(camera, this.winGLCanvas1);
            var arcball = new ArcBallManipulater(GLMouseButtons.Right);
            arcball.Bind(camera, this.winGLCanvas1);
            arcball.Rotated += arcball_Rotated;
        }

        void arcball_Rotated(object sender, ArcBallManipulater.Rotation e) {
            {
                var node = this.shadowMappingNode;
                if (node != null) {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
            {
                var node = this.textureNode;
                if (node != null) {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }

        }

        private WinCtrlRoot GetRootControl() {
            var root = new WinCtrlRoot(this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            string folder = System.Windows.Forms.Application.StartupPath;
            {
                var bmp = new Bitmap(System.IO.Path.Combine(folder, @"mouseUp.png"));
                var control = new CtrlImage(bmp, false) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 10);
                control.Width = 25; control.Height = 25;
                bmp.Dispose();
                root.Children.Add(control);
                this.ctrlMouseUp = control;
            }
            {
                var bmp = new Bitmap(System.IO.Path.Combine(folder, @"leftDown.png"));
                var control = new CtrlImage(bmp, false) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 10);
                control.Width = 25; control.Height = 25;
                bmp.Dispose();
                root.Children.Add(control);
                control.EnableGUIRendering = ThreeFlags.None;
                this.ctrlLeftDown = control;
            }
            {
                var bmp = new Bitmap(System.IO.Path.Combine(folder, @"rightDown.png"));
                var control = new CtrlImage(bmp, false) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 10);
                control.Width = 25; control.Height = 25;
                bmp.Dispose();
                root.Children.Add(control);
                control.EnableGUIRendering = ThreeFlags.None;
                this.ctrlRightDown = control;
            }

            return root;
        }

        void winGLCanvas1_MouseUp(object sender, MouseEventArgs e) {
            if (this.ctrlMouseUp == null) { return; }

            this.ctrlMouseUp.EnableGUIRendering = ThreeFlags.BeforeChildren;
            this.ctrlLeftDown.EnableGUIRendering = ThreeFlags.None;
            this.ctrlRightDown.EnableGUIRendering = ThreeFlags.None;
        }

        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e) {
            if (this.ctrlMouseUp == null) { return; }

            var p = e.Location;
            this.ctrlMouseUp.Location = new GUIPoint(p.X, this.winGLCanvas1.Height - p.Y - 1 - this.ctrlMouseUp.Height);
            this.ctrlLeftDown.Location = new GUIPoint(p.X, this.winGLCanvas1.Height - p.Y - 1 - this.ctrlLeftDown.Height);
            this.ctrlRightDown.Location = new GUIPoint(p.X, this.winGLCanvas1.Height - p.Y - 1 - this.ctrlRightDown.Height);
        }

        void winGLCanvas1_MouseDown(object sender, MouseEventArgs e) {
            if (this.ctrlMouseUp == null) { return; }

            this.ctrlMouseUp.EnableGUIRendering = ThreeFlags.None;
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                this.ctrlLeftDown.EnableGUIRendering = ThreeFlags.BeforeChildren;
                this.ctrlRightDown.EnableGUIRendering = ThreeFlags.None;
            }
            else {
                this.ctrlLeftDown.EnableGUIRendering = ThreeFlags.None;
                this.ctrlRightDown.EnableGUIRendering = ThreeFlags.BeforeChildren;
            }
        }

        private GroupNode GetNodes() {
            var groupNode = new GroupNode();
            //{
            //    var model = new Sphere(1, 10, 10);
            //    var node = SpherePointNode.Create(model);
            //    node.Name = "0 Point";
            //    this.pointNode = node;
            //    (new FormPropertyGrid(node)).Show();
            //    groupNode.Children.Add(node);
            //}
            //{
            //    var model = new Sphere(1, 20, 40);
            //    var node = SphereLineNode.Create(model);
            //    node.Name = "1 Line";
            //    this.lineNode = node;
            //    (new FormPropertyGrid(node)).Show();
            //    groupNode.Children.Add(node);
            //}
            //{
            //    var model = new Sphere(0.3f, 20, 40);
            //    var node = SphereLightNode.Create(model, Sphere.strPosition, Sphere.strNormal, model.Size);
            //    node.Name = "1 Line";
            //    (new FormPropertyGrid(node)).Show();
            //    groupNode.Children.Add(node);
            //}
            {
                var model = new Sphere(1, 20, 40);
                var texture = GetTexture();
                var node = SphereTextureNode.Create(model, texture);
                node.Name = "2 Texture";
                this.textureNode = node;
                (new FormPropertyGrid(node)).Show();
                groupNode.Children.Add(node);
                {
                    TextBillboardNode billboard = CreateText("亚洲", new vec3(-0.7f, 0.75f, 0.1f) * 1.1f);
                    node.Children.Add(billboard);
                }
                {
                    TextBillboardNode billboard = CreateText("非洲", new vec3(-0.3f, 0.1f, -0.9f) * 1.1f);
                    node.Children.Add(billboard);
                }
                {
                    TextBillboardNode billboard = CreateText("欧洲", new vec3(-0.11f, 0.7f, -0.7f) * 1.1f);
                    node.Children.Add(billboard);
                }
                {
                    TextBillboardNode billboard = CreateText("北美洲", new vec3(0.76f, 0.59f, 0.25f) * 1.1f);
                    node.Children.Add(billboard);
                }
                {
                    TextBillboardNode billboard = CreateText("南美洲", new vec3(0.88f, -0.15f, -0.45f) * 1.1f);
                    node.Children.Add(billboard);
                }
                {//南极洲
                    TextBillboardNode billboard = CreateText("南极洲", new vec3(0, -1, 0) * 1.1f);
                    node.Children.Add(billboard);
                }
                {
                    TextBillboardNode billboard = CreateText("澳洲", new vec3(-0.63f, -0.45f, 0.63f) * 1.1f);
                    node.Children.Add(billboard);
                }
            }
            //{
            //    var model = new Sphere(0.3f, 30, 60);
            //    var texture = GetTexture();
            //    var node = ShadowMappingNode.Create(model, Sphere.strPosition, Sphere.strNormal, model.Size);
            //    node.Name = "3 Light/Shadow";
            //    this.shadowMappingNode = node;
            //    (new FormPropertyGrid(node)).Show();
            //    groupNode.Children.Add(node);
            //}
            //{
            //    string folder = System.Windows.Forms.Application.StartupPath;
            //    string filename = System.IO.Path.Combine(folder, "floor.obj_");
            //    var parser = new ObjVNFParser(true);
            //    ObjVNFResult result = parser.Parse(filename);
            //    if (result.Error != null) {
            //        MessageBox.Show(result.Error.ToString());
            //    }
            //    else {
            //        ObjVNFMesh mesh = result.Mesh;
            //        var model = new ObjVNF(mesh);
            //        var node = ShadowMappingNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
            //        node.WorldPosition = new vec3(0, -1.2f, 0);
            //        node.Color = Color.Green.ToVec3();
            //        node.Name = filename;
            //        groupNode.Children.Add(node);
            //    }
            //}
            {

            }

            return groupNode;
        }

        private TextBillboardNode CreateText(string text, vec3 position) {
            int width = 100, height = 40, capacity = 100;
            GlyphServer server = GlyphServer.Create(new Font("华文行楷", 32), text.Distinct());
            var billboard = TextBillboardNode.Create(width, height, capacity, server);
            billboard.Text = text;
            billboard.Color = Color.White.ToVec3();
            billboard.EnableRendering = ThreeFlags.None;// we don't render it in RenderAction. we render it in BillboardRenderAction.
            billboard.WorldPosition = position;
            return billboard;
        }
        private Texture GetTexture() {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap(System.IO.Path.Combine(folder, @"earth.png"));
            TexStorageBase storage = new TexImageBitmap(bmp, GL.GL_RGBA, 1, true);
            var texture = new Texture(storage,
                new TexParameterfv(TexParameter.PropertyName.TextureBorderColor, 1, 0, 0),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bmp.Dispose();

            return texture;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e) {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //this.cubeNode.RotationAxis = new vec3(0, 1, 0);
            //this.cubeNode.RotationAngle += 7f;
            //this.sphereNode.RotationAxis = new vec3(0, 1, 0);
            //this.sphereNode.RotationAngle += 7f;
            //if (this.lineNode != null) {
            //    this.lineNode.RotationAxis = new vec3(0, 1, 0);
            //    this.lineNode.RotationAngle += 31;
            //}
            //if (this.textureNode != null) {
            //    this.textureNode.RotationAxis = new vec3(0, 1, 0);
            //    this.textureNode.RotationAngle += 31;
            //}
            //{
            //    var node = this.scene.RootNode;
            //    if (node != null) {
            //        node.RotationAxis = new vec3(0, 1, 0);
            //        node.RotationAngle += 11;
            //    }
            //}

            if (this.currentButton == this.btnPoints) {
                if (Points(this.btnPoints)) {
                    this.timer1.Enabled = false;
                }
            }
            else if (this.currentButton == this.btnLines) {
                if (Lines(this.btnLines)) {
                    this.timer1.Enabled = false;
                }
            }
            else if (this.currentButton == this.btnTexture) {
                if (Texture(this.btnTexture)) {
                    this.timer1.Enabled = false;
                }
            }
            else if (this.currentButton == this.btnAutoPrintCanvas) {
                if (AutoPrintCanvas(this.btnAutoPrintCanvas)) {
                    this.timer1.Enabled = false;
                }
            }
        }

        Button currentButton;

        private bool Lines(Button button) {
            if (increase) {
                SphereLineNode node = this.lineNode;
                var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
                cmd.VertexCount = currentIndex;
            }
            else {
                DumpImage(string.Format("{0:0000}.png", currentIndex));

                currentIndex++;
                if (currentIndex > totalVertexCount) {
                    currentIndex = 0;
                    button.Enabled = true;
                    return true;
                }
            }

            increase = !increase;

            return false;
        }

        private bool Points(Button button) {
            if (increase) {
                SpherePointNode node = this.pointNode;
                var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
                cmd.VertexCount = currentIndex;
            }
            else {
                DumpImage(string.Format("{0:0000}.png", currentIndex));

                currentIndex++;
                if (currentIndex > totalVertexCount) {
                    currentIndex = 0;
                    button.Enabled = true;
                    return true;
                }
            }

            increase = !increase;

            return false;
        }

        private void DumpImage(string filename) {
            int width = this.winGLCanvas1.Width;
            int height = this.winGLCanvas1.Height;
            var final = new Bitmap(width, height);
            var data = final.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //glGetTexImage((uint)texture.Target, 0, GL_BGRA, GL_UNSIGNED_BYTE, data.Scan0);
            GL.Instance.ReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
            final.UnlockBits(data);
            final.RotateFlip(RotateFlipType.Rotate180FlipX);
            final.Save(filename);
        }

        private SpherePointNode pointNode;
        int currentIndex = 0;
        int totalVertexCount = 0;
        bool increase = true;
        private SphereLineNode lineNode;
        private ShadowMappingNode shadowMappingNode;
        private CtrlImage ctrlMouseUp;
        private CtrlImage ctrlLeftDown;
        private CtrlImage ctrlRightDown;
        private void btnPoint_Click(object sender, EventArgs e) {
            SpherePointNode node = this.pointNode;
            if (node == null) { return; }

            currentIndex = 0;
            var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
            totalVertexCount = cmd.VertexCount;
            increase = true;

            this.currentButton = this.btnPoints;
            this.timer1.Enabled = true;
            this.btnPoints.Enabled = false;
        }

        private void btnLine_Click(object sender, EventArgs e) {
            SphereLineNode node = this.lineNode;
            if (node == null) { return; }

            currentIndex = 0;
            var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
            totalVertexCount = cmd.VertexCount;
            increase = true;

            this.currentButton = this.btnLines;
            this.timer1.Enabled = true;
            this.btnLines.Enabled = false;
        }

        private void btnPrintCanvas_Click(object sender, EventArgs e) {
            this.btnPrintCanvas.Enabled = false;
            PrintScreen();
            this.btnPrintCanvas.Enabled = true;
        }

        private void PrintScreen() {
            int width = this.winGLCanvas1.Width;
            int height = this.winGLCanvas1.Height;
            var final = new Bitmap(width, height);
            var data = final.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //glGetTexImage((uint)texture.Target, 0, GL_BGRA, GL_UNSIGNED_BYTE, data.Scan0);
            GL.Instance.ReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
            final.UnlockBits(data);
            final.RotateFlip(RotateFlipType.Rotate180FlipX);
            string filename = string.Format("PrintCanvas{0:yyyyMMdd-HHmmss}.png", DateTime.Now);
            final.Save(filename);
        }

        private Point autoPrintCanvasPosition;
        private SphereTextureNode textureNode;
        private void btnAutoPrintCanvas_Click(object sender, EventArgs e) {
            this.autoPrintCanvasPosition = Control.MousePosition;
            this.currentButton = this.btnAutoPrintCanvas;

            this.timer1.Enabled = !this.timer1.Enabled;
            this.btnAutoPrintCanvas.Text = string.Format("Auto Print Canvas {0}",
                this.timer1.Enabled ? "!" : ".");
        }

        private bool AutoPrintCanvas(Button button) {
            if (Control.MousePosition != this.autoPrintCanvasPosition) {
                PrintScreen();

                this.autoPrintCanvasPosition = Control.MousePosition;
            }

            return false;
        }

        private void btnTexture_Click(object sender, EventArgs e) {
            SphereTextureNode node = this.textureNode;
            if (node == null) { return; }

            var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
            currentIndex = cmd.VertexCount;
            increase = true;

            this.currentButton = this.btnTexture;
            this.timer1.Enabled = true;
            this.btnTexture.Enabled = false;
        }

        private bool Texture(Button button) {
            if (increase) {
                SphereTextureNode node = this.textureNode;
                var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
                //cmd.VertexCount = currentIndex;
                cmd.FirstVertex = currentIndex;
            }
            else {
                DumpImage(string.Format("{0:0000}.png", currentIndex));

                currentIndex--;
                if (currentIndex < 0) {
                    currentIndex = 0;
                    button.Enabled = true;
                    return true;
                }
            }

            increase = !increase;

            return false;
        }

    }
}
