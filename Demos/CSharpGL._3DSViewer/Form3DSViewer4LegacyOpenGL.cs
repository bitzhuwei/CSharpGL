using CSharpGL._3DSFiles;
using CSharpGL.FileParser._3DSParser;
using CSharpGL.FileParser._3DSParser.ToLegacyOpenGL;
using CSharpGL.FileParser._3DSParser.ToLegacyOpenGL.ChunkDumpers;
using CSharpGL.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL._3DSViewer
{
    public partial class Form3DSViewer4LegacyOpenGL : Form
    {
        private float rotation;
        private float horizontal = 0;
        private float vertical = 0;
        private float zoom = 1;
        private Bitmap textureImage;
        private bool textureAdded = false;
        private Texture2D texture;

        ThreeDSModel4LegacyOpenGL model = null;

        public Form3DSViewer4LegacyOpenGL()
        {
            InitializeComponent();

            GL.ClearColor(0, 0, 0, 0);
        }

        //private void openToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (this.open3DSDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        try
        //        {
        //            var _3dsFile = new ThreeDSFile(this.open3DSDlg.FileName);
        //            if (_3dsFile.ThreeDSModel.Entities == null)
        //            {
        //                MessageBox.Show("No entity found!");
        //                return;
        //            }
        //            var builder = new StringBuilder();
        //            int i = 1;
        //            bool emptyVerticesFound = false, emptyIndicesFound = false, emptyTexCoordsFound = false;
        //            foreach (var entity in _3dsFile.ThreeDSModel.Entities)
        //            {
        //                builder.Append("entity "); builder.Append(i++); builder.Append(":");
        //                if (entity.vertices == null)
        //                {
        //                    if (!emptyVerticesFound)
        //                    { MessageBox.Show("No vertices in some entity!"); emptyVerticesFound = true; }
        //                }
        //                else
        //                { builder.Append(" "); builder.Append(entity.vertices.Length); builder.Append(" vertices"); }

        //                if (entity.indices == null)
        //                {
        //                    if (!emptyIndicesFound)
        //                    {
        //                        MessageBox.Show("No faces in some entity.");
        //                        emptyIndicesFound = true;
        //                    }
        //                }
        //                else
        //                { builder.Append(" "); builder.Append(entity.indices.Length); builder.Append(" indices"); }

        //                if (entity.texcoords == null)
        //                {
        //                    if (!emptyTexCoordsFound)
        //                    {
        //                        MessageBox.Show("No UV in some entity.");
        //                        emptyTexCoordsFound = true;
        //                    }
        //                }
        //                else
        //                { builder.Append(" "); builder.Append(entity.texcoords.Length); builder.Append(" UVs"); }

        //                builder.AppendLine();
        //            }

        //            if (i == 1)
        //            { builder.Append("no entity found."); }

        //            MessageBox.Show(builder.ToString(), "Info");
        //            this._3dsFile = _3dsFile;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Error");
        //        }
        //    }
        //}
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.open3DSDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    var parser = new ThreeDSParser();
                    var filename = this.open3DSDlg.FileName;
                    var tree = parser.Parse(filename);
                    ThreeDSModel4LegacyOpenGL model = null;
                    tree.Dump(out model);
                    if (model.Entities == null)
                    {
                        MessageBox.Show("No entity found!");
                        return;
                    }
                    var builder = new StringBuilder();
                    int i = 1;
                    bool emptyVerticesFound = false, emptyIndicesFound = false, emptyTexCoordsFound = false;
                    foreach (var entity in model.Entities)
                    {
                        builder.Append("entity "); builder.Append(i++); builder.Append(":");
                        if (entity.Vertexes == null)
                        {
                            if (!emptyVerticesFound)
                            { MessageBox.Show("No vertices in some entity!"); emptyVerticesFound = true; }
                        }
                        else
                        { builder.Append(" "); builder.Append(entity.Vertexes.Length); builder.Append(" vertices"); }

                        if (entity.TriangleIndexes == null)
                        {
                            if (!emptyIndicesFound)
                            {
                                MessageBox.Show("No faces in some entity.");
                                emptyIndicesFound = true;
                            }
                        }
                        else
                        { builder.Append(" "); builder.Append(entity.TriangleIndexes.Length); builder.Append(" indices"); }

                        if (entity.TexCoords == null)
                        {
                            if (!emptyTexCoordsFound)
                            {
                                MessageBox.Show("No UV in some entity.");
                                emptyTexCoordsFound = true;
                            }
                        }
                        else
                        { builder.Append(" "); builder.Append(entity.TexCoords.Length); builder.Append(" UVs"); }

                        builder.AppendLine();
                    }

                    if (i == 1)
                    { builder.Append("no entity found."); }

                    this.model = model;

                    MessageBox.Show(builder.ToString(), "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs args)
        {
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.LoadIdentity();
            GL.Translate(horizontal, vertical, 0);
            GL.Rotate(rotation, 0, 1, 0);
            GL.Scale(zoom, zoom, zoom);

            var model = this.model;
            if (model == null) { return; }

            foreach (var entity in model.Entities)
            {
                if (entity.Vertexes == null) { continue; }
                if (entity.TriangleIndexes == null) { continue; }

                if (this.textureAdded && entity.TexCoords != null)
                {
                    //GL.Disable(GL.GL_LIGHTING);
                    GL.Enable(GL.GL_TEXTURE_2D);
                    GL.BindTexture(GL.GL_TEXTURE_2D, this.texture.Name);
                    //GL.ShadeModel(GL.GL_SMOOTH);// Enables Smooth Shading
                    GL.Begin(PrimitiveModes.Triangles);
                    foreach (var triangle in entity.TriangleIndexes)
                    {
                        var point1 = entity.Vertexes[triangle.vertex1];
                        var uv1 = entity.TexCoords[triangle.vertex1];
                        GL.TexCoord(uv1.U, uv1.V);
                        GL.Vertex(point1.X, point1.Y, point1.Z);
                        var point2 = entity.Vertexes[triangle.vertex2];
                        var uv2 = entity.TexCoords[triangle.vertex2];
                        GL.TexCoord(uv2.U, uv2.V);
                        GL.Vertex(point2.X, point2.Y, point2.Z);
                        var point3 = entity.Vertexes[triangle.vertex3];
                        var uv3 = entity.TexCoords[triangle.vertex3];
                        GL.TexCoord(uv3.U, uv3.V);
                        GL.Vertex(point3.X, point3.Y, point3.Z);
                    }
                    GL.End();
                }
                else
                {
                    GL.Begin(PrimitiveModes.Triangles);
                    foreach (var triangle in entity.TriangleIndexes)
                    {
                        var point1 = entity.Vertexes[triangle.vertex1];
                        GL.Vertex(point1.X, point1.Y, point1.Z);
                        var point2 = entity.Vertexes[triangle.vertex2];
                        GL.Vertex(point2.X, point2.Y, point2.Z);
                        var point3 = entity.Vertexes[triangle.vertex3];
                        GL.Vertex(point3.X, point3.Y, point3.Z);
                    }
                    GL.End();
                }
            }

            rotation += 3;
        }

        private void glCanvas1_Resized(object sender, EventArgs e)
        {
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.LoadIdentity();
            GL.gluPerspective(60, (double)glCanvas1.Width / (double)glCanvas1.Height, 0.01, 1000);
            GL.gluLookAt(0, 5, -5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(GL.GL_MODELVIEW);
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            var zoomSpeed = 0.5f;
            var horizontalMoveSpeed = 0.2f;
            var verticalMoveSpeed = 0.2f;
            if (e.KeyCode == Keys.Q)
            {
                zoom *= (1 + zoomSpeed);
                if (zoom < 1e-10)
                {
                    MessageBox.Show("Scale too small.");
                    zoom = 0.00001f;

                }
            }
            else if (e.KeyCode == Keys.E)
            {
                zoom *= (1 - 0.5f);
            }
            else if (e.KeyCode == Keys.A)
            {
                horizontal += horizontalMoveSpeed;
            }
            else if (e.KeyCode == Keys.D)
            {
                horizontal -= horizontalMoveSpeed;
            }
            else if (e.KeyCode == Keys.W)
            {
                vertical += verticalMoveSpeed;
            }
            else if (e.KeyCode == Keys.S)
            {
                vertical -= verticalMoveSpeed;
            }
            this.UpdateInfo();
        }

        private void UpdateInfo()
        {
            this.lblInfo.Text = string.Format("Scale:{0:0.0000}", this.zoom);
        }

        private void toolStripItemOpenTexture_Click(object sender, EventArgs e)
        {
            if (openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textureAdded = false;
                try
                {
                    this.texture = new Texture2D();
                    this.textureImage = new Bitmap(openTextureDlg.FileName);
                    this.texture.Initialize(this.textureImage);

                    this.textureAdded = true;
                }
                catch (Exception ex)
                {
                    this.textureAdded = false;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lineTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (open3DSDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var _3dsFile = new ThreeDSFile(open3DSDlg.FileName);
                int uvMapCount = 0;
                int uvMapLength = 500;
                var pens = new Pen[] { new Pen(Color.Red), new Pen(Color.Green), new Pen(Color.Blue) };
                int penIndex = 0;
                foreach (var entity in _3dsFile.ThreeDSModel.Entities)
                {
                    using (var uvMap = new Bitmap(uvMapLength, uvMapLength))
                    {
                        var graphics = Graphics.FromImage(uvMap);
                        if (entity.texcoords != null && entity.indices != null)
                        {
                            foreach (var triangle in entity.indices)
                            {
                                var uv1 = entity.texcoords[triangle.vertex1];
                                var uv2 = entity.texcoords[triangle.vertex2];
                                var uv3 = entity.texcoords[triangle.vertex3];
                                var p1 = new Point((int)(uv1.U * uvMapLength), (int)(uv1.V * uvMapLength));
                                var p2 = new Point((int)(uv2.U * uvMapLength), (int)(uv2.V * uvMapLength));
                                var p3 = new Point((int)(uv3.U * uvMapLength), (int)(uv3.V * uvMapLength));
                                graphics.DrawLine(pens[penIndex], p1, p2);
                                graphics.DrawLine(pens[penIndex], p2, p3);
                                graphics.DrawLine(pens[penIndex], p3, p1);
                                penIndex = (penIndex + 1 == pens.Length) ? 0 : penIndex + 1;
                            }
                        }
                        else
                        {
                            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, uvMapLength, uvMapLength);
                        }
                        var file = new FileInfo(open3DSDlg.FileName);
                        uvMap.Save(Path.Combine(file.DirectoryName,
                            string.Format("{0}{1}.bmp", file.Name, uvMapCount)));
                        graphics.Dispose();
                        Process.Start("explorer", file.DirectoryName);
                    }
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show("WSAD for translate, QE for scale");
        }

    }
}
