using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZMFileViewer {
    internal unsafe class EZMFileViewer_ : demoCode {
        public EZMFileViewer_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
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
            var position = new vec3(5, 6, -4) * 20;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            this.scene = new Scene(camera);

            this.scene.RootNode = new GroupNode();
            //(new FormObjPropertyGrid(scene)).Show();

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            var rootElement = this.scene.RootNode;
            rootElement.Children.Clear();
            string filename = @"media/ezm-demo/dwarf_anim.ezm";
            CreateTextureNode(filename);
            CreateBoneLineNode(filename);
            CreateBonePointNode(filename);

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }

        private void CreateBoneLineNode(string filename) {
            EZMFile ezmFile = EZMFile.Load(filename);
            ezmFile.LoadTextures();
            var rootElement = this.scene.RootNode;
            for (int i = 0; i < ezmFile.MeshSystem.Meshes.Length; i++) {
                EZMMesh mesh = ezmFile.MeshSystem.Meshes[i];
                var model = new NodeLineModel(mesh.Skeleton.Bones);
                var node = NodeLineNode.Create(model);
                rootElement.Children.Add(node);
            }
        }

        private void CreateBonePointNode(string filename) {
            EZMFile ezmFile = EZMFile.Load(filename);
            ezmFile.LoadTextures();
            var rootElement = this.scene.RootNode;
            for (int i = 0; i < ezmFile.MeshSystem.Meshes.Length; i++) {
                EZMMesh mesh = ezmFile.MeshSystem.Meshes[i];
                var model = new NodePointModel(mesh.Skeleton.Bones);
                var node = NodePointNode.Create(model);
                node.DiffuseColor = Color.Red;
                rootElement.Children.Add(node);
            }
        }

        private void CreateTextureNode(string filename) {
            EZMFile ezmFile = EZMFile.Load(filename);
            ezmFile.LoadTextures();
            var rootElement = this.scene.RootNode;
            for (int i = 0; i < ezmFile.MeshSystem.Meshes.Length; i++) {
                EZMMesh mesh = ezmFile.MeshSystem.Meshes[i];
                EZMAnimation animation = ezmFile.MeshSystem.Animations.Length > 0 ? ezmFile.MeshSystem.Animations[0] : null;
                var container = new EZMVertexBufferContainer(mesh, animation);
                for (int j = 0; j < mesh.MeshSections.Length; j++) {
                    var model = new EZMTextureModel(container, mesh.MeshSections[j]);
                    var node = EZMTextureNode.Create(model);
                    rootElement.Children.Add(node);
                }
            }
        }

        //private void CreateSectionNode(string filename)
        //{
        //    var random = new Random();
        //    EZMFile ezmFile = EZMFile.Load(filename);
        //    var rootElement = this.scene.RootNode;
        //    var model = new EZMSectionModel(ezmFile);
        //    var node = EZMSectionNode.Create(model);
        //    node.Color = Color.FromArgb(
        //        (byte)random.Next(0, 256),
        //        (byte)random.Next(0, 256),
        //        (byte)random.Next(0, 256),
        //        (byte)random.Next(0, 256)
        //        );
        //    //float max = node.ModelSize.max();
        //    //node.Scale *= 16.0f / max;
        //    //node.WorldPosition = new vec3(0, 0, 0);
        //    rootElement.Children.Add(node);
        //}

        //private void CreateDummyNodes(string filename)
        //{
        //    var random = new Random();
        //    EZMFile ezmFile = EZMFile.Load(filename);
        //    var rootElement = this.scene.RootNode;
        //    var mesh = ezmFile.MeshSystem.Meshes[0];
        //    byte[] positionBuffer = mesh.Vertexbuffer.Buffers[0].array;
        //    for (int i = 0; i < mesh.MeshSections.Length; i++)
        //    {
        //        var model = new EZMDummyModel(positionBuffer,
        //            mesh.MeshSections[i].Indexbuffer
        //            );
        //        var node = EZMDummyNode.Create(model);
        //        node.Color = Color.FromArgb(
        //            (byte)random.Next(0, 256),
        //            (byte)random.Next(0, 256),
        //            (byte)random.Next(0, 256),
        //            (byte)random.Next(0, 256)
        //            );
        //        //float max = node.ModelSize.max();
        //        //node.Scale *= 16.0f / max;
        //        //node.WorldPosition = new vec3(0, 0, 0);
        //        rootElement.Children.Add(node);
        //    }
        //}

    }
}
