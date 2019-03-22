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
        }

        private void FormMain_Load(object sender, EventArgs e) {
            var position = new vec3(5, 3, 4) * 0.4f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var scene = new Scene(camera);
            scene.RootNode = GetNodes();
            {
                var light = new DirectionalLight(new vec3(1, 3, -1));
                scene.Lights.Add(light);
            }
            this.scene = scene;

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var shadowAction = new ShadowMappingAction(scene);
            list.Add(shadowAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // uncomment these lines to enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Right;
            manipulater.Bind(camera, this.winGLCanvas1);
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
            {
                var model = new Sphere(1, 10, 10);
                var node = SphereLineNode.Create(model);
                node.Name = "1 Line";
                this.lineNode = node;
                (new FormPropertyGrid(node)).Show();
                groupNode.Children.Add(node);
            }
            //{
            //    var model = new Sphere(1, 20, 40);
            //    var texture = GetTexture();
            //    var node = SphereTextureNode.Create(model, texture);
            //    node.Name = "2 Texture";
            //    (new FormPropertyGrid(node)).Show();
            //    groupNode.Children.Add(node);
            //}
            //{
            //    var model = new Sphere(1, 20, 40);
            //    var texture = GetTexture();
            //    var node = ShadowMappingNode.Create(model, Sphere.strPosition, Sphere.strNormal, model.Size);
            //    node.Name = "3 Light/Shadow";
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
            //        node.WorldPosition = new vec3(0, -2, 0);
            //        node.Color = Color.Green.ToVec3();
            //        node.Name = filename;
            //        groupNode.Children.Add(node);
            //    }
            //}
            {

            }

            return groupNode;
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
        private void button1_Click(object sender, EventArgs e) {
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

        private void button2_Click(object sender, EventArgs e) {
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
            this.btnPrintCanvas.Enabled = true;
        }
    }
}
