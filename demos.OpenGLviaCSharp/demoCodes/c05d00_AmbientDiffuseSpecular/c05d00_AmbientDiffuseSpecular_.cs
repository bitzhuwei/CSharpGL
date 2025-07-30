using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c05d00_AmbientDiffuseSpecular {
    internal unsafe class c05d00_AmbientDiffuseSpecular_ : demoCode {
        public c05d00_AmbientDiffuseSpecular_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        //private NormalNode node;

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
            var position = new vec3(1, 0.6f, 1) * 14;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            (new FormObjPropertyGrid(this.scene)).Show();
            {
                var light = new DirectionalLight(new vec3(1, 1, 1));
                this.scene.lights.Add(light);
            }

            //string folder = System.Windows.Forms.Application.StartupPath;
            //string objFilename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "vnfHanoiTower.obj_");
            string objFilename = "vnfHanoiTower.obj_";
            var parser = new ObjVNFParser(true);
            ObjVNFResult result = parser.Parse(objFilename);
            if (result.Error != null) {
                MessageBox.Show(result.Error.ToString());
            }
            else {
                var model = new ObjVNF(result.Mesh);
                var node = NoShadowNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                float max = node.ModelSize.max();
                node.Scale *= 16.0f / max;
                this.scene.RootNode = node;
                (new FormObjPropertyGrid(node)).Show();
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var blinnPhongAction = new BlinnPhongAction(scene);
            list.Add(blinnPhongAction);
            //var renderAction = new RenderAction(scene);
            //list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
