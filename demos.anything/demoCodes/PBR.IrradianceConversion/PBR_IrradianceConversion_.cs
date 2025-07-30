using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBR.IrradianceConversion {
    internal unsafe class PBR_IrradianceConversion_ : demoCode {
        public PBR_IrradianceConversion_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        int nrRows = 7;
        int nrColumns = 7;
        float spacing = 2.5f;

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
            var position = new vec3(-0.2f, 0, 1) * 14;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            var rootNode = new GroupNode();
            this.scene.RootNode = rootNode;

            Texture texEnvCubemap = LoadEnvCubeMap();
            Texture texHDR = LoadHDRTexture("media/textures/newport_loft.hdr");

            {
                var cubemapNode = CubemapNode.Create(texEnvCubemap, texHDR);
                rootNode.Children.Add(cubemapNode);
            }
            {
                var sphere = new Sphere2();//(1, 40, 80);
                var filename = Path.Combine(System.Windows.Forms.Application.StartupPath, "sphere2.obj_");
                sphere.DumpObjFile(filename, "sphere2");
                var parser = new ObjVNFParser(false, true);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null) {
                    Console.WriteLine("Error: {0}", result.Error);
                }
                else {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    // render rows*column number of spheres with varying metallic/roughness values scaled by rows and columns respectively
                    for (int row = 0; row < nrRows; ++row) {

                        for (int col = 0; col < nrColumns; ++col) {
                            var node = PBRNode.Create(model, model.GetSize(),
                                ObjVNF.strPosition, ObjVNF.strTexCoord, ObjVNF.strNormal);
                            node.Metallic = (float)row / (float)nrRows;
                            // we clamp the roughness to 0.025 - 1.0 as perfectly smooth surfaces (roughness of 0.0) tend to look a bit off
                            // on direct lighting.
                            node.Roughness = glm.clamp((float)col / (float)nrColumns, 0.05f, 1.0f);
                            node.WorldPosition = new vec3(
                                (col - (nrColumns / 2)) * spacing,
                                (row - (nrRows / 2)) * spacing,
                                0.0f);
                            rootNode.Children.Add(node);
                        }
                    }
                }
            }
            {
                var backgroundNode = BackgroundNode.Create(texEnvCubemap);
                rootNode.Children.Add(backgroundNode);
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }

        class PointerData : LeveledData {
            private IntPtr pointer;

            public PointerData(IntPtr pointer) {
                this.pointer = pointer;
            }
            public override IntPtr LockData() {
                return this.pointer;
            }
        }
        class PointerDataProvider : LeveledDataProvider {
            private PointerData data;
            public PointerDataProvider(PointerData data) {
                this.data = data;
            }

            public override IEnumerator<LeveledData> GetEnumerator() {
                yield return this.data;
            }
        }
        private unsafe Texture LoadHDRTexture(string filename) {
            // pbr: load the HDR environment map
            stb_Image.stbi_set_flip_vertically_on_load(true);
            int width, height, nrComponents;
            float* data = stb_Image.stbi_loadf(filename, &width, &height, &nrComponents, 0);
            var dataProvider = new PointerDataProvider(new PointerData(new IntPtr(data)));
            // note how we specify the texture's data value to be float
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RGB16F, width, height, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();

            return texture;
        }

        // pbr: setup cubemap to render to and attach to framebuffer
        private Texture LoadEnvCubeMap() {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 512, 512, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var envCubeMap = new Texture(storage,
                new MipmapBuilder(),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            envCubeMap.Initialize();
            return envCubeMap;
        }

    }
}
