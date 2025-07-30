using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSightOfAssimpNet {
    internal unsafe class FirstSightOfAssimpNet_ : demoCode {
        public FirstSightOfAssimpNet_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private FirstPerspectiveManipulater manipulater;
        private JointNode jointNode;
        private SkeletonNode skeletonNode;

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
            var position = new vec3(5, 4, 3) * 3;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            this.scene = new Scene(camera);

            this.scene.RootNode = new AssimpGroupNode();
            //(new FormPropertyGrid(scene)).Show();

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);
            this.manipulater = manipulater;

            var rootElement = this.scene.RootNode;
            rootElement.Children.Clear();

            string filename = @"media/irr-demo/animMesh.irr";
            if (File.Exists(filename)) {
                this.OpenFile(filename);
            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
        private void OpenFile(string filename) {
            var importer = new Assimp.AssimpImporter();
            Assimp.Scene aiScene = null;
            try {
                aiScene = importer.ImportFile(filename, Assimp.PostProcessSteps.GenerateSmoothNormals | Assimp.PostProcessSteps.Triangulate | Assimp.PostProcessSteps.FlipUVs);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            var container = new AssimpSceneContainer(aiScene, filename);
            CreateAnimationNodes(aiScene, container);
            CreateSkeletonNode(aiScene, container);
            CreateJointNode(aiScene, container);

            //{
            //    this.cmbAnimationIndex.Items.Clear();
            //    int count = container.aiScene.AnimationCount;
            //    for (int i = 0; i < count; i++) {
            //        this.cmbAnimationIndex.Items.Add(string.Format("Animation {0}", i));
            //    }
            //}
        }

        private void CreateJointNode(Assimp.Scene aiScene, AssimpSceneContainer container) {
            var rootElement = this.scene.RootNode;
            var model = new JointModel(aiScene, container.GetAllBoneInfos());
            var node = JointNode.Create(model);
            node.DiffuseColor = Color.Red;
            this.jointNode = node;
            rootElement.Children.Add(node);
        }

        private void CreateSkeletonNode(Assimp.Scene aiScene, AssimpSceneContainer container) {
            var rootElement = this.scene.RootNode;
            var model = new SkeletonModel(aiScene, container.GetAllBoneInfos());
            var node = SkeletonNode.Create(model);
            this.skeletonNode = node;
            rootElement.Children.Add(node);
        }

        private void CreateAnimationNodes(Assimp.Scene aiScene, AssimpSceneContainer container) {
            var rootElement = this.scene.RootNode;
            bool first = true; vec3 max = new vec3(); vec3 min = new vec3();
            var models = new AnimationModel[aiScene.MeshCount];
            if (aiScene.HasMeshes) {
                int index = 0;
                foreach (Assimp.Mesh mesh in aiScene.Meshes) {
                    models[index++] = new AnimationModel(mesh, container);
                }
            }
            if (aiScene.RootNode != null) {
                mat4 parentTransform = mat4.identity();
                BuildNode(aiScene.RootNode, parentTransform, models, rootElement, ref max, ref min, ref first);
            }

            vec3 center = max / 2.0f + min / 2.0f;
            vec3 size = max - min;
            float v = size.x;
            if (v < size.y) { v = size.y; }
            if (v < size.z) { v = size.z; }
            this.scene.camera.Position = center + size;
            this.scene.camera.Target = center;
            //rootElement.WorldPosition = center;
            this.manipulater.StepLength = v / 30.0f;
        }

        private void BuildNode(Assimp.Node aiNode, mat4 parentTransform, AnimationModel[] models, SceneNodeBase rootElement, ref vec3 max, ref vec3 min, ref bool first) {
            mat4 thisTransform = parentTransform * aiNode.Transform.ToMat4();
            if (aiNode.HasMeshes) {
                vec3 worldPosition, scale; vec4 rotation;
                thisTransform.ParseRST(out worldPosition, out scale, out rotation);
                foreach (int meshIndex in aiNode.MeshIndices) {
                    AnimationModel model = models[meshIndex];
                    GetBound(model.mesh, ref max, ref min, ref first);
                    var node = AnimationNode.Create(model);
                    var random = new Random();
                    node.DiffuseColor = Color.FromArgb(
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256)
                        );
                    node.WorldPosition = worldPosition;
                    node.Scale = scale;
                    node.RotationAxis = new vec3(rotation.x, rotation.y, rotation.z);
                    node.RotationAngle = rotation.w;
                    rootElement.Children.Add(node);
                }
            }

            if (aiNode.HasChildren) {
                foreach (Assimp.Node child in aiNode.Children) {
                    BuildNode(child, thisTransform, models, rootElement, ref max, ref min, ref first);
                }
            }
        }

        private void GetBound(Assimp.Mesh mesh, ref vec3 max, ref vec3 min, ref bool first) {
            foreach (var item in mesh.Vertices) {
                if (first) {
                    max = new vec3(item.X, item.Y, item.Z);
                    min = max;
                    first = false;
                }
                else {
                    if (max.x < item.X) { max.x = item.X; }
                    if (max.y < item.Y) { max.y = item.Y; }
                    if (max.z < item.Z) { max.z = item.Z; }

                    if (item.X < min.x) { min.x = item.X; }
                    if (item.Y < min.y) { min.y = item.Y; }
                    if (item.Z < min.z) { min.z = item.Z; }
                }
            }
        }
    }

}
