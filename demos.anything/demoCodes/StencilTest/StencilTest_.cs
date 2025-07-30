using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StencilTest {
    internal unsafe class StencilTest_ : demoCode {
        public StencilTest_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        Scene scene;
        private ActionList actionList;
        private Picking pickingAction;
        IPickable lastPickedNode;


        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

        }

        public override void init(GL gl) {
            var rootElement = GetRootElement();

            var position = new vec3(4, 3, 5) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                RootNode = rootElement,
                clearColor = Color.SkyBlue.ToVec4(),
            };

            //Match(this.trvScene, scene.RootNode);
            //this.trvScene.ExpandAll();
            (new FormNodePropertyGrid(scene.RootNode)).Show();

            var tansformAction = new TransformAction(scene);
            var renderAction = new RenderAction(scene);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(renderAction);
            this.actionList = actionList;

            this.pickingAction = new Picking(scene);

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLMouseMove += Canvas_GLMouseMove;

        }

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            if (x < 0 || this.canvas.Width <= x) { return; }
            if (y < 0 || this.canvas.Height <= y) { return; }

            var pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.canvas.Width, this.canvas.Height);

            var lastNode = this.lastPickedNode as OutlineCubeNode;

            this.lastPickedNode = null;// we will pick again.

            OutlineCubeNode currentNode = null;
            if (pickedGeometry != null) {
                currentNode = pickedGeometry.FromObject as OutlineCubeNode;
            }

            if (lastNode != currentNode) {
                if (lastNode != null) { lastNode.DisplayOutline = false; }

                if (currentNode != null) { currentNode.DisplayOutline = true; }
            }

            this.lastPickedNode = currentNode;
            this.mainForm.SetInfo(string.Format("picked: {0}", this.lastPickedNode));

        }

        private SceneNodeBase GetRootElement() {
            // demo 1:
            //return StencilTestNode.Create();

            // demo 2:
            //var quaterNode = QuaterNode.Create();
            //var bottleNode = KleinBottleNode.Create(new KleinBottleModel());
            //bottleNode.Scale = new vec3(1, 1, 1) * 0.1f;
            //var group = new HowStencilTestWorkNode();
            //group.Children.Add(quaterNode);
            //group.Children.Add(bottleNode);
            //return group;

            // demo 3:
            var clearStencilNode = ClearStencilNode.Create(); // this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.
            //string folder = System.Windows.Forms.Application.StartupPath;
            //var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"flower.png"));
            var bitmap = new Bitmap("media/textures/flower.png");
            var winGLBitmap = new WinGLBitmap(bitmap, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            var texture = new Texture(new TexImageBitmap(winGLBitmap));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bitmap.Dispose();

            var group = new GroupNode(clearStencilNode);
            for (int x = 0; x < 3; x++) {
                for (int z = 0; z < 3; z++) {
                    var outlineCubeNode = OutlineCubeNode.Create(texture);
                    outlineCubeNode.Scale = new vec3(1, 1, 1) * 0.6f;
                    outlineCubeNode.WorldPosition = new vec3(x - 1, 0, z - 1);
                    group.Children.Add(outlineCubeNode);
                }
            }
            return group;
        }
        void clearBuffer_On(object sender, EventArgs e) {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glClear(GL.GL_STENCIL_BUFFER_BIT);
        }

        //private SceneNodeBase GetRootElement()
        //{
        //    int width = 600, height = 400;
        //    var innerCamera = new Camera(new vec3(0, 2, 5), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspective, width, height);
        //    (innerCamera as IPerspectiveViewCamera).Far = 50;
        //    IFramebufferProvider source = new DepthFramebufferProvider();
        //    var rtt = new RTTRenderer(width, height, innerCamera, source);
        //    {
        //        var teapot = DepthTextureRenderer.Create();
        //        rtt.Children.Add(teapot);
        //        var ground = GroundRenderer.Create(); ground.Color = Color.Gray.ToVec4(); ground.Scale *= 10; ground.WorldPosition = new vec3(0, -3, 0);
        //        rtt.Children.Add(ground);
        //    }

        //    var rectangle = RectangleRenderer.Create();
        //    rectangle.TextureSource = rtt;

        //    var group = new GroupRenderer();
        //    group.Children.Add(rtt);// rtt must be before rectangle.
        //    group.Children.Add(rectangle);
        //    //group.WorldPosition = new vec3(3, 0.5f, 0);// this looks nice.

        //    return group;
        //}

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
