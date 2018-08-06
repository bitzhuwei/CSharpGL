using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorCodedPicking
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private TeapotNode teapot;
        private DirectTextNode textNode;
        private ActionList actionList;

        private OperationState operationState = OperationState.PickingDraging;
        private Picking pickingAction;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseDown += glCanvas1_MouseDown;
            this.winGLCanvas1.MouseMove += glCanvas1_MouseMove;
            this.winGLCanvas1.MouseUp += glCanvas1_MouseUp;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.teapot = TeapotNode.Create(false);
            teapot.Children.Add(new LegacyBoundingBoxNode(teapot.ModelSize));
            var ground = GroundNode.Create(); ground.Color = Color.Gray.ToVec4(); ground.Scale *= 10; ground.WorldPosition = new vec3(0, -3, 0);
            this.textNode = new DirectTextNode() { Text = "Color Coded Picking" };
            var group = new GroupNode(this.teapot, ground, this.textNode);

            this.scene = new Scene(camera)
            {
                RootNode = group,
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();
            this.chkRenderWireframe_CheckedChanged(this.chkRenderWireframe, EventArgs.Empty);
            this.chkRenderBody_CheckedChanged(this.chkRenderBody, EventArgs.Empty);

            // uncomment these lines to enable manipualter of camera!
            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.BindingMouseButtons = System.Windows.Forms.MouseButtons.Right;
            //manipulater.Bind(camera, this.winGLCanvas1);
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

                DirectTextNode node = this.textNode;
                if (node != null)
                {
                    GL.Instance.DrawText(node.Position.X, node.Position.Y, node.TextColor, node.FontName, node.FontSize, node.Text);
                }
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.operationState == OperationState.Rotating)
            {
                IWorldSpace node = this.scene.RootNode;
                if (node != null)
                {
                    node.RotationAngle += 1;
                }
            }
        }

        private void chkRenderWireframe_CheckedChanged(object sender, EventArgs e)
        {
            this.teapot.RenderWireframe = this.chkRenderWireframe.Checked;
        }

        private void chkRenderBody_CheckedChanged(object sender, EventArgs e)
        {
            this.teapot.RenderBody = this.chkRenderBody.Checked;
        }


        enum OperationState
        {
            /// <summary>
            /// 
            /// </summary>
            PickingDraging,

            /// <summary>
            /// 
            /// </summary>
            Rotating,
        }

        private void rdoPickingDraging_CheckedChanged(object sender, EventArgs e)
        {
            this.operationState = OperationState.PickingDraging;
        }

        private void rdoRotating_CheckedChanged(object sender, EventArgs e)
        {
            this.operationState = OperationState.Rotating;
        }
    }
}
