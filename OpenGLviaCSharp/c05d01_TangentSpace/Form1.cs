using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c05d01_TangentSpace
{
    public partial class Form1 : Form
    {

        private Scene scene;
        private ActionList actionList;

        public Form1()
        {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
            // render event.
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            // resize event.
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var scene = new Scene(camera);
            scene.RootNode = GetRootNode();
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // uncomment these lines to enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Right;
            manipulater.Bind(camera, this.winGLCanvas1);
            manipulater.StepLength = 0.1f;
        }

        private SceneNodeBase GetRootNode()
        {
            var group = new GroupNode();

            var sphere = new Sphere(1, 40, 80);
            var filename = "sphere.obj_";
            sphere.DumpObjFile(filename, "sphere");
            var parser = new ObjVNFParser(false);
            ObjVNFResult result = parser.Parse(filename);
            if (result.Error != null)
            {
                Console.WriteLine("Error: {0}", result.Error);
            }
            else
            {
                ObjVNFMesh mesh = result.Mesh;
                var model = new ObjVNF(mesh);
                model.DumpObjFile("vnf" + filename, "sphere");
                var sphereNode = ObjVNFNode.Create(mesh);
                (new FormProperyGrid(sphereNode)).Show();
                group.Children.Add(sphereNode);
                {
                    var planeNode = PlaneNode.Create();
                    planeNode.Color = new vec4(1, 1, 1, 1);
                    planeNode.WorldPosition = new vec3(0, 1, 0);
                    planeNode.Scale = new vec3(1, 1, 1) * 0.5f;
                    sphereNode.Children.Add(planeNode);
                }
                {
                    var axisNode = AxisNode.Create();
                    axisNode.WorldPosition = new vec3(0, 1, 0);
                    axisNode.Scale = new vec3(1, 1, 1) * 0.5f;
                    sphereNode.Children.Add(axisNode);
                }
            }

            return group;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

    }
}
