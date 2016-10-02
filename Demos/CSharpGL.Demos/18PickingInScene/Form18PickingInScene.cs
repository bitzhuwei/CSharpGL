using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene : Form
    {
        public RenderModes RenderMode { get; set; }

        public Form18PickingInScene()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            this.RenderMode = RenderModes.Render;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            //Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            this.scene.Render(this.RenderMode, this.glCanvas1.ClientRectangle, true, this.PickingGeometryType);

            this.DrawText(e);
        }

        private void DrawText(PaintEventArgs e)
        {
            Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            PickedGeometry pickedGeometry = this.pickedGeometry;
            if (pickedGeometry != null)
            {
                string content = string.Format("[index: {0}]",
                    pickedGeometry.VertexIds.PrintArray());
                //SizeF size = e.Graphics.MeasureString(content, font);
                Size size = this.uiText.Size;
                // make sure the text be displayed.
                int x = mousePosition.X - (size.Width / 2);
                if (x + (size.Width) >= this.glCanvas1.Width)
                { x = this.glCanvas1.Width - size.Width; }
                else if (x < 0)
                { x = 0; }
                // make sure the text be displayed.
                int y = this.glCanvas1.Height - mousePosition.Y - 1;
                if (y + size.Height + 1 >= this.glCanvas1.Height)
                { y = this.glCanvas1.Height - 15 - 5; }
                else if (y < 15) { if (y > 0) { y += 15; } else { y = 15; } }
                else { y += 15; }
                //OpenGL.DrawText(x, y,
                //    this.TextColor, "Courier New", fontSize,
                //    content);
                this.lblDrawText.Text = content;
                Padding margin = this.uiText.Margin;
                margin.Left = x; margin.Bottom = y;
                this.uiText.Margin = margin;
                this.uiText.Text = content;
                this.uiText.Enabled = true;
            }
            else
            {
                //OpenGL.DrawText(mousePosition.X,
                //    this.glCanvas1.Height - mousePosition.Y - 1,
                //    this.TextColor, "Courier New", fontSize,
                //    "");
                this.lblDrawText.Text = "";
                //this.uiText.Text = "";
                this.uiText.Enabled = false;
            }
        }

        private readonly Object synObj = new Object();

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1')
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '2')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '3')
            {
                var frmPropertyGrid = new FormProperyGrid(this);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '4')
            {
                if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lock (synObj)
                    {
                        string filename = dlgSaveFile.FileName;
                        Bitmap bitmap = Save2PictureHelper.ScreenShot(0, 0, this.glCanvas1.Width, this.glCanvas1.Height);
                        bitmap.Save(filename);
                        Process.Start("explorer", "/select, " + filename);
                    }
                }
            }
        }

        private void cmbPickingGeometryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PickingGeometryType = (GeometryType)this.cmbPickingGeometryType.SelectedItem;
        }

        private void cmbRenderMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RenderMode = (RenderModes)this.cmbRenderMode.SelectedItem;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            this.scene.Dispose();
            this.bulletinBoard.Close();
        }
    }
}