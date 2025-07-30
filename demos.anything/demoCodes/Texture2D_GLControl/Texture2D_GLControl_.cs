using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texture2D {
    internal unsafe class Texture2D_GLControl_ : demoCode {
        public Texture2D_GLControl_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

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
            // How to use GlyphServer:
            var server = GlyphServer.DefaultServer;
            var keys = "Hello CSharpGL!";
            foreach (var item in keys) {
                GlyphInfo info;
                if (server.GetGlyphInfo(item, out info)) {
                    Console.WriteLine(info);
                }
                else {
                    Console.WriteLine("Glyph of [{0}] not exists!", item);
                }
            }

            SceneNodeBase rootElement = GetRootElement();
            WinCtrlRoot rootControl = GetRootControl();

            var position = new vec3(1, 0, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                RootNode = rootElement,
                RootControl = rootControl,
                clearColor = Color.SkyBlue.ToVec4(),
            };
            rootControl.Bind(this.canvas);

            var list = new ActionList();

            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);

            //var guiLayoutAction = new GUILayoutAction(scene.RootControl);
            //list.Add(guiLayoutAction);
            var guiRenderAction = new GUIRenderAction(scene.RootControl);
            list.Add(guiRenderAction);

            this.actionList = list;

            //Match(this.trvSceneObject, scene.RootNode);
            //this.trvSceneObject.ExpandAll();
            (new FormNodePropertyGrid(scene.RootNode)).Show();

            //Match(this.trvSceneGUI, scene.RootControl);
            //this.trvSceneGUI.ExpandAll();
            (new FormGLControlPropertyGrid(scene.RootControl)).Show();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);
            manipulater.StepLength = 0.1f;

        }
        private WinCtrlRoot GetRootControl() {
            var root = new WinCtrlRoot(this.canvas.Width, this.canvas.Height);

            //string folder = System.Windows.Forms.Application.StartupPath;
            //var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"particle.png"));
            var bitmap = new Bitmap("media/textures/particle.png");
            var winGLBitmap = new WinGLBitmap(bitmap, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            {
                var control = new CtrlImage(winGLBitmap, false) {
                    Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom
                };
                control.Location = new GUIPoint(10, 10);
                control.Width = 100; control.Height = 50;
                bitmap.Dispose();
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
            }
            {
                var control = new CtrlButton() { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 70);
                control.Width = 100; control.Height = 50;
                control.Focused = true;
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
            }
            {
                var control = new CtrlLabel(100) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 130);
                control.Width = 100; control.Height = 30;
                control.Text = "Hello CSharpGL!";
                control.RenderBackground = true;
                control.BackgroundColor = new vec4(1, 0, 0, 1);
                control.MouseUp += control_MouseUp;

                root.Children.Add(control);
            }

            return root;
        }

        void control_MouseUp(object sender, GLMouseEventArgs e) {
            MessageBox.Show(string.Format("This is a message from {0}!", sender));
        }

        private SceneNodeBase GetRootElement() {
            var rectangle = RectangleNode.Create();
            rectangle.Scale *= 3;
            //string folder = System.Windows.Forms.Application.StartupPath;
            //rectangle.TextureSource = new TextureSource(System.IO.Path.Combine(folder, @"texture2D.png"));
            rectangle.TextureSource = new TextureSource("media/textures/cloth.png");

            //var blend = RectangleNode.Create();
            //blend.Scale *= 1.5f;
            //blend.WorldPosition = new vec3(-0.5f, 0, 0.1f);
            //blend.RenderUnit.Methods[0].StateList.Add(new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            //blend.TextureSource = new TextureSource(@"particle.png");

            //var blend2 = RectangleNode.Create();
            //blend2.Scale *= 1.5f;
            //blend2.WorldPosition = new vec3(0.5f, 0, 0.2f);
            //blend2.RenderUnit.Methods[0].StateList.Add(new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            //blend2.TextureSource = new TextureSource(@"particle.png");

            // note: this tells us that the right way is to render the nearest transparenct object at last.
            var group = new GroupNode(rectangle);//, blend, blend2);

            var axis = AxisNode.Create();
            group.Children.Add(axis);
            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            if (this.scene != null) {
                this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);
            }

        }
    }
}
