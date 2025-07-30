using CSharpGL;
using demos.anything;
using demos.anything.demoCodes.DistanceFieldFont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DistanceFieldFont {
    internal unsafe class DistanceFieldFont_ : demoCode {
        public DistanceFieldFont_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private SingleLineNode singleLineNode;

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
            SceneNodeBase rootElement = GetRootElement();

            var position = new vec3(1, 0, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                RootNode = rootElement,
                clearColor = Color.SkyBlue.ToVec4(),
            };
            var list = new ActionList();

            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);

            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);
            manipulater.StepLength = 0.1f;

            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            var builder = new StringBuilder();
            builder.AppendLine($"I: increase font size");
            builder.AppendLine($"J: decrease font size");
            builder.AppendLine($"T: change text");
            MessageBox.Show(builder.ToString());
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.I) {
                SingleLineNode node = this.singleLineNode;
                if (node != null) {
                    node.FontSize++;
                }
            }
            else if (e.KeyData == GLKeys.J) {
                SingleLineNode node = this.singleLineNode;
                if (node != null) {
                    node.FontSize--;
                }
            }
            else if (e.KeyData == GLKeys.T) {
                var frmSetText = new FormSetText();
                if (frmSetText.ShowDialog() == DialogResult.OK) {
                    SingleLineNode node = this.singleLineNode;
                    if (node != null) {
                        node.Text = frmSetText.GetText();
                    }
                }
            }
        }

        //private SceneNodeBase GetRootElement()
        //{
        //    var rectangle = DistanceFieldNode.Create();
        //    rectangle.Scale *= 3;
        //    string folder = System.Windows.Forms.Application.StartupPath;
        //    rectangle.TextureSource = new TextureSource(System.IO.Path.Combine(folder, @"texture2D.png"));

        //    var group = new GroupNode(rectangle);//, blend, blend2);

        //    var axis = AxisNode.Create();
        //    group.Children.Add(axis);
        //    return group;
        //}

        private SceneNodeBase GetRootElement() {
            var group = new GroupNode();
            {
                string dictFilename = "media/fonts/VeraMoBI.ttf_sdf.txt";
                string glyphsFilename = "media/fonts/VeraMoBI.ttf_sdf.png";
                GlyphServer server = GlyphServer.Load(dictFilename, glyphsFilename);
                var node = SingleLineNode.Create(100, server);
                node.TextColor = Color.Red;
                node.Text = "The quick brown fox jumps over a lazy dog!";
                group.Children.Add(node);
                this.singleLineNode = node;
            }
            {
                var axis = AxisNode.Create();
                group.Children.Add(axis);
            }

            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            if (this.scene != null) {
                this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);
            }

        }
    }
}
