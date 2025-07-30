using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c10d00_UserInterface {
    internal unsafe class c10d00_UserInterface_ : demoCode {
        public c10d00_UserInterface_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private List<LightBase> lights;
        private ShadowMappingAction shadowMappingAction;

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
            this.lights = GetSpotLights();

            var position = new vec3(1, 0.6f, 1) * 16;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();
            var rootControl = GetRootControl();
            rootControl.Bind(this.canvas);
            this.scene.RootControl = rootControl;

            // add lights.
            {
                var lightList = this.lights;
                float angle = 0;
                foreach (var light in lightList) {
                    this.scene.lights.Add(light);
                    var node = LightPositionNode.Create(light, angle);
                    angle += 360.0f / lightList.Count;
                    this.scene.RootNode.Children.Add(node);
                }
            }
            {
                var list = new ActionList();
                list.Add(new TransformAction(scene));
                var shadowMappingAction = new ShadowMappingAction(scene);
                list.Add(shadowMappingAction);
                this.shadowMappingAction = shadowMappingAction;
                list.Add(new RenderAction(scene));

                //var guiLayoutAction = new GUILayoutAction(scene.RootControl);
                //list.Add(guiLayoutAction);
                var guiRenderAction = new GUIRenderAction(scene.RootControl);
                list.Add(guiRenderAction);

                this.actionList = list;
            }
            {
                var node = DepthRectNode.Create();
                node.TextureSource = this.shadowMappingAction.LightEquipment;
                this.scene.RootNode.Children.Add(node);
            }

            (new FormNodePropertyGrid(scene.RootNode)).Show();

            (new FormGLControlPropertyGrid(scene.RootControl)).Show();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();
            var filenames = new string[] { "floor.obj_", };
            var colors = new Color[] { Color.Green, };
            for (int i = 0; i < filenames.Length; i++) {
                //string folder = System.Windows.Forms.Application.StartupPath;
                //string filename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", filenames[i]);
                string filename = filenames[i];
                var parser = new ObjVNFParser(true);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null) {
                    MessageBox.Show(result.Error.ToString());
                }
                else {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    var node = ShadowMappingNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                    node.WorldPosition = new vec3(0, i * 5, 0);
                    node.Scale = new vec3(1, 1, 1) * 4;
                    node.Color = colors[i].ToVec3();
                    //node.Name = filename;
                    group.Children.Add(node);
                }
            }
            {
                var parser = new ObjVNFParser(false);
                var hanoiTower = new GroupNode();
                ObjItem[] items = HanoiTower.GetDataSource();
                foreach (var item in items) {
                    var objFormat = item.model;
                    var filename = item.GetType().Name;
                    objFormat.DumpObjFile(filename, filename);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null) {
                        Console.WriteLine("Error: {0}", result.Error);
                    }
                    else {
                        ObjVNFMesh mesh = result.Mesh;
                        var model = new ObjVNF(mesh);
                        var node = ShadowMappingNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                        node.WorldPosition = item.position;
                        node.Color = item.color;
                        //node.Name = filename;
                        hanoiTower.Children.Add(node);
                    }
                }
                group.Children.Add(hanoiTower);
            }

            return group;
        }

        private WinCtrlRoot GetRootControl() {
            var root = new WinCtrlRoot(this.canvas.Width, this.canvas.Height);

            {
                var control = new CtrlLabel(100) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Top };
                control.Width = 100; control.Height = 30;
                control.Text = "Hello CSharpGL!";
                control.RenderBackground = true;
                control.BackgroundColor = new vec4(1, 0, 0, 1);
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
                control.Location = new GUIPoint(10, root.Height - control.Height - 10);
            }
            {
                var control = new CtrlButton() { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Top };
                control.Width = 100; control.Height = 50;
                control.Focused = true;
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
                control.Location = new GUIPoint(10, root.Height - control.Height - 50);
            }
            {
                //string folder = System.Windows.Forms.Application.StartupPath;
                //var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"image.png"));
                var bitmap = new Bitmap("media/textures/cloth.png");
                var winGLBitmap = new WinGLBitmap(bitmap);
                var control = new CtrlImage(winGLBitmap, false) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Top };
                control.Width = 100; control.Height = 50;
                bitmap.Dispose();
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
                control.Location = new GUIPoint(10, root.Height - control.Height - 110);
            }

            return root;
        }

        void control_MouseUp(object sender, GLMouseEventArgs e) {
            MessageBox.Show(string.Format("This is a message from {0}!", sender));
        }

        private static List<LightBase> GetSpotLights() {
            var list = new List<LightBase>();
            double radian = 120.0 / 180.0 * Math.PI / 2.0;
            {
                var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(1, 0, 0));
                light.Diffuse = new vec3(1, 1, 1);
                light.Specular = new vec3(1, 1, 1);
                list.Add(light);
            }
            //{
            //    var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
            //    light.Diffuse = new vec3(0, 1, 0);
            //    light.Specular = new vec3(0, 1, 0);
            //    list.Add(light);
            //}
            //{
            //    var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
            //    light.Diffuse = new vec3(0, 0, 1);
            //    light.Specular = new vec3(0, 0, 1);
            //    list.Add(light);
            //}

            return list;
        }

        private static List<LightBase> GetDirctionalLights() {
            var list = new List<LightBase>();
            {
                var light = new CSharpGL.DirectionalLight(new vec3(3, 3, 3));
                light.Diffuse = new vec3(1, 0, 0);
                light.Specular = new vec3(1, 0, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.DirectionalLight(new vec3(3, 3, 3));
                light.Diffuse = new vec3(0, 1, 0);
                light.Specular = new vec3(0, 1, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.DirectionalLight(new vec3(3, 3, 3));
                light.Diffuse = new vec3(0, 0, 1);
                light.Specular = new vec3(0, 0, 1);
                list.Add(light);
            }

            return list;
        }

        private static List<LightBase> GetPointLights() {
            var list = new List<LightBase>();
            {
                var light = new CSharpGL.PointLight(new vec3(3, 3, 3), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(1, 0, 0);
                light.Specular = new vec3(1, 0, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.PointLight(new vec3(3, 3, 3), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(0, 1, 0);
                light.Specular = new vec3(0, 1, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.PointLight(new vec3(3, 3, 3), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(0, 0, 1);
                light.Specular = new vec3(0, 0, 1);
                list.Add(light);
            }

            return list;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
