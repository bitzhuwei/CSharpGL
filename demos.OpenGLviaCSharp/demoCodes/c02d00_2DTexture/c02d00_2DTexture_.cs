using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02d00_2DTexture {
    internal unsafe class c02d00_2DTexture_ : demoCode {
        public c02d00_2DTexture_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene? scene;
        private ActionList? actionList;
        private CubeNode? cubeNode;
        private SphereNode? sphereNode;

        public override void display(GL gl) {
            var list = this.actionList; var scene = this.scene;
            if (list != null && scene != null) {
                vec4 clearColor = scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        public override void init(GL gl) {
            var position = new vec3(0, 3, 8) * 0.3f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            {
                Texture texture = Utility.LoadTexture2D("media/textures/cloth.png");
                texture.textureUnitIndex = 0;//TODO: use some manager to manage this unit index thing.
                this.cubeNode = CubeNode.Create(texture);
                this.cubeNode.WorldPosition = new vec3(2, 0, 0);
            }
            {
                Texture texture = Utility.LoadTexture2D("media/textures/earth.png");
                texture.textureUnitIndex = 1;
                this.sphereNode = SphereNode.Create(texture);
                this.sphereNode.WorldPosition = new vec3(-2, 0, 0);
            }
            {
                var scene = new Scene(camera);
                var rootNode = new GroupNode();
                rootNode.Children.Add(this.cubeNode);
                rootNode.Children.Add(this.sphereNode);
                scene.RootNode = rootNode;
                this.scene = scene;
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // uncomment these lines to enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Left | GLMouseButtons.Right; // System.Windows.Forms.MouseButtons.Left;
            manipulater.Bind(camera, this.canvas);

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
