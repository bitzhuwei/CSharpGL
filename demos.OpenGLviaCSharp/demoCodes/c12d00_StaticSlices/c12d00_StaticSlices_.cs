using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c12d00_StaticSlices {
    internal unsafe class c12d00_StaticSlices_ : demoCode {
        public c12d00_StaticSlices_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
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
            var position = new vec3(5, 3, 4) * 0.2f;
            var center = new vec3(0, -0.1f, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.canvas);

            var manipulater = new ArcBallManipulater(GLMouseButtons.Left);
            manipulater.Bind(camera, this.canvas);
            {
                float angle = this.scene.RootNode.RotationAngle;
                vec3 axis = this.scene.RootNode.RotationAxis;
                manipulater.SetRotationMatrix(glm.rotate(angle, axis));
            }
            manipulater.Rotated += manipulater_Rotated;

            this.canvas.GLMouseWheel += Canvas_GLMouseWheel;
        }

        private void Canvas_GLMouseWheel(object sender, GLMouseEventArgs e) {
            this.scene.camera.MouseWheel(e.Delta);
        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e) {
            {
                SceneNodeBase node = this.scene.RootNode;
                if (node != null) {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();
            group.RotationAxis = new vec3(-0.8343f, -0.0144f, -0.5512f);
            group.RotationAngle = 179.260315f;
            {
                Texture tffTexture = InitTFF1DTexture("media/textures/tff.png");
                int width = 128, height = 128, depth = 128;
                byte[] volumeData = VolumeDataGenerator.GetData(width, height, depth);
                Texture volumeTexture = InitVolume3DTexture(volumeData, width, height, depth);

                int sliceCount = 512;
                StaticSlicesNode node = StaticSlicesNode.Create(sliceCount, tffTexture, volumeTexture);
                node.Scale = new vec3(1, 1, 225.0f / 256.0f);
                (new FormNodePropertyGrid(node)).Show();
                group.Children.Add(node);
            }
            {
                var node = AxisNode.Create();
                node.Scale = new vec3(1, 1, 1) * 3;
                group.Children.Add(node);
            }
            return group;
        }

        private byte[] GetVolumeData(string filename) {
            byte[] data;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs)) {
                int unReadCount = (int)fs.Length;
                data = new byte[unReadCount];
                br.Read(data, 0, unReadCount);
            }

            return data;
        }

        private Texture InitVolume3DTexture(byte[] data, int width, int height, int depth) {
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_RED, width, height, depth, GL.GL_RED, GL.GL_UNSIGNED_BYTE, new ArrayDataProvider<byte>(data));
            var texture = new Texture(storage, new MipmapBuilder(),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextrueBaseLevel, 0),
                new TexParameteri(TexParameter.PropertyName.TextureMaxLevel, 4));
            texture.Initialize();
            texture.textureUnitIndex = 2;

            return texture;
        }

        private Texture InitTFF1DTexture(string filename) {
            var bitmap = new System.Drawing.Bitmap(filename);
            var winGLBitmap = new WinGLBitmap(bitmap);
            const int width = 256;
            var storage = new TexImage1D(GL.GL_RGBA8, width,
                GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(winGLBitmap));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();
            texture.textureUnitIndex = 0;
            bitmap.Dispose();

            return texture;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
