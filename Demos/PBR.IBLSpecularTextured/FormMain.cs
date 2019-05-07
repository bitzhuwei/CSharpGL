using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PBR.IBLSpecularTextured {
    public partial class FormMain : Form {
        private Scene scene;
        private ActionList actionList;

        public FormMain() {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        float spacing = 2.5f;
        private void FormMain_Load(object sender, EventArgs e) {
            var position = new vec3(9.3968f, -0.7408f, 2.9288f);
            var center = new vec3(-0.0710f, -2.2829f, 1.3023f);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            var rootNode = new GroupNode();
            this.scene.RootNode = rootNode;

            Texture texBRDF = LoadBRDFTexture();
            texBRDF.TextureUnitIndex = 2;
            Texture prefilterMap = LoadPrefilterMap();
            prefilterMap.TextureUnitIndex = 1;
            Texture irradianceMap = LoadIrradianceMap();
            irradianceMap.TextureUnitIndex = 0;
            Texture environmentMap = LoadEnvironmentMap();
            Texture texHDR = LoadHDRTexture("newport_loft.hdr");

            {
                var node = CubemapNode.Create(environmentMap, texHDR);
                rootNode.Children.Add(node);
            }
            {
                var node = IrradianceNode.Create(irradianceMap, environmentMap);
                rootNode.Children.Add(node);
            }
            {
                var node = PrefilterNode.Create(prefilterMap, environmentMap);
                rootNode.Children.Add(node);
            }
            {
                var node = BRDFNode.Create(texBRDF);
                rootNode.Children.Add(node);
            }
            {
                var textureGroups = new string[] { "cerberus", "cerberus", "gold", "grass", "plastic", "rock", "rusted_iron", "wall", "wood" };
                var models = new ObjVNF[textureGroups.Length];
                {
                    var filename = Path.Combine(System.Windows.Forms.Application.StartupPath, "cerberus.obj_");
                    var parser = new ObjVNFParser(false, false);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null) {
                        MessageBox.Show(string.Format("Error: {0}", result.Error));
                        return;
                    }
                    ObjVNFMesh mesh = result.Mesh;
                    // scale it to 0.1 percent.
                    for (int i = 0; i < mesh.vertexes.Length; i++) {
                        mesh.vertexes[i] = mesh.vertexes[i] / 10;
                    }
                    //// Dump texture coordinates' layout.
                    //{
                    //    vec2[] texCoords = mesh.texCoords;
                    //    int polygon = (mesh.faces[0] is ObjVNFTriangle) ? 3 : 4;
                    //    int index = 0;
                    //    var indices = new uint[polygon * mesh.faces.Length];
                    //    foreach (var face in mesh.faces) {
                    //        foreach (var vertexIndex in face.VertexIndexes()) {
                    //            indices[index++] = vertexIndex;
                    //        }
                    //    }
                    //    var bmp = TexCoordAnalyzer.DumpLines(texCoords, indices, 1024);
                    //    bmp.Save("cerberus.texCoords.png");
                    //}
                    var model = new ObjVNF(mesh);
                    models[0] = model;
                }
                {
                    var sphere = new Sphere2();//(1, 40, 80);
                    var filename = Path.Combine(System.Windows.Forms.Application.StartupPath, "sphere2.obj_");
                    sphere.DumpObjFile(filename, "sphere2");
                    var parser = new ObjVNFParser(false, true);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null) {
                        MessageBox.Show(string.Format("Error: {0}", result.Error));
                        return;
                    }
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    for (int i = 1; i < textureGroups.Length; i++) {
                        models[i] = model;
                    }
                }

                for (int i = 0; i < textureGroups.Length; i++) {
                    ObjVNF model = models[i];
                    string group = textureGroups[i];
                    var node = PBRNode.Create(model, model.GetSize(),
                        ObjVNF.strPosition, ObjVNF.strTexCoord, ObjVNF.strNormal);
                    node.IrradianceMap = irradianceMap;
                    node.PrefilterMap = prefilterMap;
                    node.texBRDF = texBRDF;
                    Texture albedo = GetTexture(string.Format(@"Textures\{0}\albedo.png", group), 3);
                    node.AlbedoMap = albedo;
                    Texture ao = GetTexture(string.Format(@"Textures\{0}\ao.png", group), 4);
                    node.AOMap = ao;
                    Texture metallic = GetTexture(string.Format(@"Textures\{0}\metallic.png", group), 5);
                    node.MetallicMap = metallic;
                    Texture normal = GetTexture(string.Format(@"Textures\{0}\normal.png", group), 6);
                    node.NormalMap = normal;
                    Texture roughness = GetTexture(string.Format(@"Textures\{0}\roughness.png", group), 7);
                    node.RoughnessMap = roughness;
                    if (i == 0) {
                        node.WorldPosition = new vec3(0, -5, 0);
                    }
                    else {
                        node.WorldPosition = new vec3(
                            0.0f,
                            0.0f,
                            ((textureGroups.Length / 2.0f) - i) * spacing);
                    }
                    rootNode.Children.Add(node);
                }
            }
            {
                var backgroundNode = BackgroundNode.Create(environmentMap);
                rootNode.Children.Add(backgroundNode);
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
        }

        private Texture GetTexture(string filename, uint unitIndex) {
            var bmp = new Bitmap(filename);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
            var storage = new TexImageBitmap(bmp);
            var texture = new Texture(storage,
                new MipmapBuilder(),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                // NOTE: use 'GL_LINEAR_MIPMAP_LINEAR' along with 'new MipmapBuilder(),'!
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.TextureUnitIndex = unitIndex;
            texture.Initialize();
            bmp.Dispose();
            return texture;
        }

        private Texture LoadBRDFTexture() {
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RG16F, 512, 512, GL.GL_RG, GL.GL_FLOAT);
            var texture = new Texture(storage,
                // be sure to set wrapping mode to GL_CLAMP_TO_EDGE
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            return texture;
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
        private Texture LoadEnvironmentMap() {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 512, 512, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var envCubeMap = new Texture(storage,
                new MipmapBuilder(), // This is can also be done inside CubemapNode.DoInitialize().
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            envCubeMap.Initialize();
            return envCubeMap;
        }

        // pbr: create an irradiance cubemap.
        private Texture LoadIrradianceMap() {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 32, 32, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var envCubeMap = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            envCubeMap.Initialize();
            return envCubeMap;
        }

        // pbr: create a pre-filter cubemap.
        private Texture LoadPrefilterMap() {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 128, 128, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var envCubeMap = new Texture(storage,
                // generate mipmaps for the cubemap so OpenGL automatically allocates the required memory.
                new MipmapBuilder(),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                // be sure to set minifcation filter to mip_linear 
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            envCubeMap.Initialize();
            return envCubeMap;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e) {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

    }
}
