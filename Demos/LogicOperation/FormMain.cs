using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace LogicOperation
{
    public partial class FormMain : Form
    {
        Scene scene;
        private ActionList actionList;
        private PickingAction pickingAction;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetRootElement();

            var position = new vec3(4, 3, 5) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)

            {
                RootElement = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            var tansformAction = new TransformAction(scene);
            var renderAction = new RenderAction(scene);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(renderAction);
            this.actionList = actionList;

            this.pickingAction = new PickingAction(scene);

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);

            foreach (var item in Enum.GetNames(typeof(LogicOperationCode)))
            {
                this.cmbLogicOperation.Items.Add(item);
            }
        }


        private SceneNodeBase GetRootElement()
        {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"Lenna.png"));
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            var texture = new Texture(new TexImageBitmap(bitmap));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bitmap.Dispose();

            var group = new GroupNode();
            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    var outlineCubeNode = LogicOperationNode.Create(texture);
                    outlineCubeNode.Scale = new vec3(1, 1, 1) * 0.6f;
                    outlineCubeNode.WorldPosition = new vec3(x - 1, 0, z - 1);
                    group.Children.Add(outlineCubeNode);
                }
            }
            return group;
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

        private void cmbLogicOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.scene != null)
            {
                var op = (LogicOperationCode)Enum.Parse(typeof(LogicOperationCode), cmbLogicOperation.SelectedItem.ToString());
                TraverseNodes(this.scene.RootElement, op);
            }
        }

        private void TraverseNodes(SceneNodeBase sceneNodeBase, LogicOperationCode op)
        {
            var node = sceneNodeBase as LogicOperationNode;
            if (node != null)
            {
                node.SetOperation(op);
            }

            foreach (var item in sceneNodeBase.Children)
            {
                TraverseNodes(item, op);
            }
        }

    }
}
