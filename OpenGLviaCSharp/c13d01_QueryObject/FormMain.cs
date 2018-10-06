using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c13d01_QueryObject
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private DrawModesNode drawModeNode;
        private ActionList actionList;
        private Picking pickingAction;
        private Query query;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
            {
                string[] modes = Enum.GetNames(typeof(CSharpGL.DrawMode));
                foreach (var mode in modes)
                {
                    this.cmbDrawMode.Items.Add(mode);
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(0, 0, 1) * 6;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            //this.triangleTip = new LegacyTriangleNode();
            //this.triangleTip.LineWidth = 10;

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            {
                this.query = new Query();
            }

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);

            this.cmbDrawMode.SelectedIndex = 0;
        }

        private SceneNodeBase GetRootNode()
        {
            var group = new GroupNode();
            {
                var model = new DrawModesModel();
                var node = DrawModesNode.Create(model, DrawModesModel.strPosition, DrawModesModel.strColor, model.GetSize());
                group.Children.Add(node);

                this.drawModeNode = node;
                (new FormPropertyGrid(node)).Show();
            }

            return group;
        }


        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                //vec4 clearColor = this.scene.ClearColor;
                //GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.ClearColor(0, 0, 0, 0);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                query.BeginQuery(QueryTarget.SamplesPassed);
                {
                    list.Act(new ActionParams(Viewport.GetCurrent()));
                }
                query.EndQuery(QueryTarget.SamplesPassed);
                int sampleCount = this.query.SampleCount();
                this.lblSampleCount.Text = string.Format("Sample Passed: {0}", sampleCount);
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void cmbDrawMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drawModeNode.DrawMode = (CSharpGL.DrawMode)Enum.Parse(typeof(CSharpGL.DrawMode), this.cmbDrawMode.SelectedItem.ToString());
        }

        private void rdoSmooth_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoSmooth.Checked)
            {
                this.drawModeNode.Method = DrawModesNode.EMethod.Smooth;
            }
            else
            {
                this.drawModeNode.Method = DrawModesNode.EMethod.Flat;
            }
        }

        private void rdoFlat_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoFlat.Checked)
            {
                this.drawModeNode.Method = DrawModesNode.EMethod.Flat;
            }
            else
            {
                this.drawModeNode.Method = DrawModesNode.EMethod.Smooth;
            }
        }

    }

    class TextureSource : ITextureSource
    {
        private static readonly Texture texture;
        static TextureSource()
        {
            texture = GetTexture();
        }
        private static Texture GetTexture()
        {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap(System.IO.Path.Combine(folder, @"cloth.png"));
            TexStorageBase storage = new TexImageBitmap(bmp, GL.GL_RGBA, 1, true);
            var texture = new Texture(storage,
                new TexParameterfv(TexParameter.PropertyName.TextureBorderColor, 1, 0, 0),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_BORDER),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_BORDER),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_BORDER),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bmp.Dispose();

            return texture;
        }


        #region ITextureSource 成员

        public Texture BindingTexture
        {
            get { return texture; }
        }

        #endregion
    }
}
