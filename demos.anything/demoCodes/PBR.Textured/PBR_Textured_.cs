using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Textured {
    internal unsafe class PBR_Textured_ : demoCode {
        public PBR_Textured_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
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

            Texture albedoMap = GetTexture(@"media/textures/rusted_iron/albedo.png", 0);
            Texture normalMap = GetTexture(@"media/textures/rusted_iron/normal.png", 1);
            Texture metallicMap = GetTexture(@"media/textures/rusted_iron/metallic.png", 2);
            Texture roughnessMap = GetTexture(@"media/textures/rusted_iron/roughness.png", 3);
            Texture aoMap = GetTexture(@"media/textures/rusted_iron/ao.png", 4);

            {
                var sphere = new Sphere2(); // Sphere(1, 40, 80);
                //var filename = Path.Combine(System.Windows.Forms.Application.StartupPath, "sphere2.obj_");
                var filename = "sphere2.obj_";
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
                            node.AlbedoMap = albedoMap;
                            node.NormalMap = normalMap;
                            node.MetallicMap = metallicMap;
                            node.RoughnessMap = roughnessMap;
                            node.AOMap = aoMap;
                            node.WorldPosition = new vec3(
                                (col - (nrColumns / 2)) * spacing,
                                (row - (nrRows / 2)) * spacing,
                                0.0f);
                            rootNode.Children.Add(node);
                        }
                    }
                }
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

        private Texture GetTexture(string filename, uint unitIndex) {
            var bmp = new Bitmap(filename);
            var winGLBitmap = new WinGLBitmap(bmp, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var storage = new TexImageBitmap(winGLBitmap);
            var texture = new Texture(storage,
                new MipmapBuilder(),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                // NOTE: use 'GL_LINEAR_MIPMAP_LINEAR' along with 'new MipmapBuilder(),'!
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.textureUnitIndex = unitIndex;
            texture.Initialize();
            bmp.Dispose();
            return texture;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
