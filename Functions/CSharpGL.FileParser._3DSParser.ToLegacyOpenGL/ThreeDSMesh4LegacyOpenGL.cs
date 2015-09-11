// Title:	Entity.cs
// Author: 	Scott Ellington <scott.ellington@gmail.com>
//
// Copyright (C) 2006 Scott Ellington and authors
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using CSharpGL.Objects;
using System;

namespace CSharpGL.FileParser._3DSParser.ToLegacyOpenGL
{

    public class ThreeDSMesh4LegacyOpenGL
    {
        // TODO: OO this
        // fields should be private
        // constructor with verts and faces
        // normalize in ctor

        //public ThreeDSMaterial material = new ThreeDSMaterial();
        public string UsesMaterial;

        // The stored vertices 
        public Vector[] Vertexes;

        // The calculated normals
        public Vector[] normals;

        // The indices of the triangles which point to vertices
        public Triangle[] TriangleIndexes;

        // The coordinates which map the texture onto the entity
        public TexCoord[] TexCoords;

        bool normalized = false;

        public void CalculateNormals()
        {
            if (TriangleIndexes == null) return;

            normals = new Vector[Vertexes.Length];

            Vector[] temps = new Vector[TriangleIndexes.Length];

            for (int ii = 0; ii < TriangleIndexes.Length; ii++)
            {
                Triangle tr = TriangleIndexes[ii];

                Vector v1 = Vertexes[tr.vertex1] - Vertexes[tr.vertex2];
                Vector v2 = Vertexes[tr.vertex2] - Vertexes[tr.vertex3];

                temps[ii] = v1.CrossProduct(v2);
                //Console.Write ("I");
            }

            for (int ii = 0; ii < Vertexes.Length; ii++)
            {
                Vector v = new Vector();
                int shared = 0;

                for (int jj = 0; jj < TriangleIndexes.Length; jj++)
                {
                    Triangle tr = TriangleIndexes[jj];
                    if (tr.vertex1 == ii || tr.vertex2 == ii || tr.vertex3 == ii)
                    {
                        v += temps[jj];
                        shared++;
                    }
                }

                normals[ii] = (v / shared).Normalize();
            }
            //Console.WriteLine ( "Normals Calculated!" );
            normalized = true;
        }

        public void Render(ThreeDSModel4LegacyOpenGL model, PolygonModes mode)
        {
            if (TriangleIndexes == null) return;

            var material = model.MaterialDict[this.UsesMaterial];

            GL.Materialfv(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT, material.Ambient);
            GL.Materialfv(GL.GL_FRONT_AND_BACK, GL.GL_DIFFUSE, material.Diffuse);
            GL.Materialfv(GL.GL_FRONT_AND_BACK, GL.GL_SPECULAR, material.Specular);
            GL.Materialf(GL.GL_FRONT_AND_BACK, GL.GL_SHININESS, material.Shininess);

            Texture2D texture = material.GetTexture();
            if (texture != null)
            {
                GL.Enable(GL.GL_TEXTURE_2D);
                texture.Bind();
            }
            //if (material.TextureId >= 0)
            //{
            //    GL.BindTexture(GL.GL_TEXTURE_2D, material.TextureId);
            //    GL.Enable(GL.GL_TEXTURE_2D);
            //}

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, mode);

            // Draw every triangle in the entity
            GL.Begin(GL.GL_TRIANGLES);
            foreach (Triangle tri in TriangleIndexes)
            {
                // Vertex 1
                if (normalized) GL.Normal3d(normals[tri.vertex1].X, normals[tri.vertex1].Y, normals[tri.vertex1].Z);
                if (texture != null) GL.TexCoord2f(TexCoords[tri.vertex1].U, TexCoords[tri.vertex1].V);
                GL.Vertex3d(Vertexes[tri.vertex1].X, Vertexes[tri.vertex1].Y, Vertexes[tri.vertex1].Z);

                // Vertex 2
                if (normalized) GL.Normal3d(normals[tri.vertex2].X, normals[tri.vertex2].Y, normals[tri.vertex2].Z);
                if (texture != null) GL.TexCoord2f(TexCoords[tri.vertex2].U, TexCoords[tri.vertex2].V);
                GL.Vertex3d(Vertexes[tri.vertex2].X, Vertexes[tri.vertex2].Y, Vertexes[tri.vertex2].Z);

                // Vertex 3
                if (normalized) GL.Normal3d(normals[tri.vertex3].X, normals[tri.vertex3].Y, normals[tri.vertex3].Z);
                if (texture != null) GL.TexCoord2f(TexCoords[tri.vertex3].U, TexCoords[tri.vertex3].V);
                GL.Vertex3d(Vertexes[tri.vertex3].X, Vertexes[tri.vertex3].Y, Vertexes[tri.vertex3].Z);
            }

            GL.End();

            if (texture != null)
            {
                texture.Unbind();
                GL.Disable(GL.GL_TEXTURE_2D);
            }

            //Console.WriteLine ( GL.GetError () );

        }
    }
}
