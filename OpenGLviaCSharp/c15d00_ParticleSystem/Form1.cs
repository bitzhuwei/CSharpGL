using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace c15d00_ParticleSystem
{
    public partial class Form1 : Form
    {
        private Scene scene;
        private ActionList actionList;

        public Form1()
        {
            InitializeComponent();

            this.winGLCanvas1.TimerTriggerInterval = 1 + (int)(1000.0f / 60.0f);
            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 1.6f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera);
            this.scene.ClearColor = Color.Black.ToVec4();
            {
                var groupNode = new GroupNode();//, attractorsNode);//, cubeNode);
                {
                    var node = ParticlesNode.Create(6000 / 128);
                    groupNode.Children.Add(node);
                }
                {
                    string folder = System.Windows.Forms.Application.StartupPath;
                    string filename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "floor.obj_");
                    var parser = new ObjVNFParser(true);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null)
                    {
                        MessageBox.Show(result.Error.ToString());
                    }
                    else
                    {
                        ObjVNFMesh mesh = result.Mesh;
                        var model = new ObjVNF(mesh);
                        var node = NoShadowNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                        node.WorldPosition = new vec3(0, -3, 0);
                        node.Color = new vec3(0, 1, 0);
                        node.Name = filename;
                        groupNode.Children.Add(node);
                    }
                }

                //var attractorsNode = AttractorsNode.Create(particlesNode);
                //var cubeNode = CubeNode.Create();
                //cubeNode.RenderUnit.Methods[0].SwitchList.Add(new PolygonModeSwitch(PolygonMode.Line));
                this.scene.RootNode = groupNode;
            }
            {
                var light = new PointLight(new vec3(1, 1, 1) * 30);
                this.scene.Lights.Add(light);
            }

            {
                var list = new ActionList();
                var transformAction = new TransformAction(scene.RootNode);
                list.Add(transformAction);
                var renderAction = new RenderAction(scene);
                list.Add(renderAction);
                var blinnPhongAction = new BlinnPhongAction(scene);
                list.Add(blinnPhongAction);
                this.actionList = list;
            }

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
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

    }
}
