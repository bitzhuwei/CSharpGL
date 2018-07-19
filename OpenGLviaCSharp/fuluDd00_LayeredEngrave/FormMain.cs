using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fuluDd00_LayeredEngrave
{
    public partial class FormMain : Form
    {

        private Scene scene;
        private ActionList actionList;
        private PeelingNode peelingNode;
        private RaycastNode raycastNode;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 4, 3) * 0.3f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var scene = new Scene(camera);
            var rootElement = GetTree(scene);
            scene.RootNode = rootElement;
            scene.ClearColor = Color.SkyBlue.ToVec4();
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // Note: uncomment this to enable camera movement.
            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.StepLength = 0.1f;
            //manipulater.Bind(camera, this.winGLCanvas1);
        }

        private SceneNodeBase GetTree(Scene scene)
        {
            var groupNode = new GroupNode();
            {
                var children = new List<SceneNodeBase>();
                const float alpha = 0.2f;
                var colors = new vec4[] {
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),
                    new vec4(1, 1, 0, alpha), new vec4(0.5f, 0.5f, 0.5f, alpha), new vec4(1, 0, 1, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),
                    
                    new vec4(1, 1, 0, alpha), new vec4(0.5f, 0.5f, 0.5f, alpha), new vec4(1, 0, 1, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),
                    
                    new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha),
                    new vec4(1, 1, 0, alpha), new vec4(1, 1, 0, alpha), new vec4(1, 1, 0, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha),

                };

                var size = new vec3(5, 5, 5);
                //int index = 0;
                //for (int k = -1; k < 2; k++)
                //{
                //    for (int j = -1; j < 2; j++)
                //    {
                //        for (int i = -1; i < 2; i++)
                //        {
                //            if (j == 1 && (k != 0 || i != 0)) { continue; }

                //            vec3 worldPosition = new vec3(i * 2, j * 2, k * 2);// +new vec3(-2.375f, -1.75f, 0);
                //            //var cubeNode = CubeNode.Create(new CubeModel(), CubeModel.positions);
                //            //var cubeNode = CubeNode.Create(new RectangleModel(), RectangleModel.strPosition);
                //            var cubeNode = CubeNode.Create(new Sphere(0.5f), Sphere.strPosition);
                //            cubeNode.WorldPosition = worldPosition;
                //            cubeNode.Color = colors[index++];
                //            cubeNode.Name = string.Format("{0},{1},{2}:{3}", k, j, i, cubeNode.Color);

                //            children.Add(cubeNode);
                //        }
                //    }
                //}

                {
                    string folder = System.Windows.Forms.Application.StartupPath;
                    string objFilename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "vnfHanoiTower.obj_");
                    var parser = new ObjVNFParser(true);
                    ObjVNFResult result = parser.Parse(objFilename);
                    if (result.Error != null)
                    {
                        MessageBox.Show(result.Error.ToString());
                    }
                    else
                    {
                        var model = new ObjVNF(result.Mesh);
                        var cubeNode = CubeNode.Create(model, ObjVNF.strPosition);
                        cubeNode.Color = Color.Red.ToVec4();
                        size = model.GetSize();
                        float max = size.max();
                        size = new vec3(max, max, max);
                        children.Add(cubeNode);
                    }
                }
                this.peelingNode = new PeelingNode(size, children.ToArray());
                groupNode.Children.Add(this.peelingNode);
            }
            {
                this.raycastNode = RaycastNode.Create(this.peelingNode);
                groupNode.Children.Add(this.raycastNode);
            }

            return groupNode;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var node = this.raycastNode;
            if (node != null)
            {
                node.RotationAxis = new vec3(0, 1, 0);
                node.RotationAngle += 1;
            }
        }

    }
}
