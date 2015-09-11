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
using System.Collections.Generic;

namespace CSharpGL.FileParser._3DSParser.ToLegacyOpenGL
{

    public class ThreeDSMesh4LegacyOpenGL
    {
        public List<Tuple<string, ushort[]>> usingMaterialIndexesList = new List<Tuple<string, ushort[]>>();
        // TODO: OO this
        // fields should be private
        // constructor with verts and faces
        // normalize in ctor

        //public ThreeDSMaterial material = new ThreeDSMaterial();
        //public string UsesMaterial;

        // The stored vertices 
        public Vector[] Vertexes;

        // The calculated normals
        public Vector[] normals;

        // The indices of the triangles which point to vertices
        public Triangle[] TriangleIndexes;

        // The coordinates which map the texture onto the entity
        public TexCoord[] TexCoords;

        bool normalized = false;
        public ushort[] UsesIndexes;

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

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, mode);

            // Draw every triangle in the entity
            foreach (var item in this.usingMaterialIndexesList)
            {
                var material = model.MaterialDict[item.Item1];

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

                GL.Begin(GL.GL_TRIANGLES);
                foreach (var usingIndex in item.Item2)
                {
                    Triangle tri = this.TriangleIndexes[usingIndex];
                    // Vertex 1
                    if (normalized)
                    {
                        var normal = this.normals[tri.vertex1];
                        GL.Normal3d(normal.X, normal.Y, normal.Z);
                    }
                    if (texture != null)
                    {
                        var texCoord = this.TexCoords[tri.vertex1];
                        GL.TexCoord2f(texCoord.U, texCoord.V);
                    }
                    {
                        var vertex = this.Vertexes[tri.vertex1];
                        GL.Vertex3d(vertex.X, vertex.Y, vertex.Z);
                    }

                    // Vertex 2
                    if (normalized)
                    {
                        var normal = this.normals[tri.vertex2];
                        GL.Normal3d(normal.X, normal.Y, normal.Z);
                    }
                    if (texture != null)
                    {
                        var texCoord = this.TexCoords[tri.vertex2];
                        GL.TexCoord2f(texCoord.U, texCoord.V);
                    }
                    {
                        var vertex = this.Vertexes[tri.vertex2];
                        GL.Vertex3d(vertex.X, vertex.Y, vertex.Z);
                    }

                    // Vertex 3
                    if (normalized)
                    {
                        var normal = this.normals[tri.vertex3];
                        GL.Normal3d(normal.X, normal.Y, normal.Z);
                    }
                    if (texture != null)
                    {
                        var texCoord = this.TexCoords[tri.vertex3];
                        GL.TexCoord2f(texCoord.U, texCoord.V);
                    }
                    {
                        var vertex = this.Vertexes[tri.vertex3];
                        GL.Vertex3d(vertex.X, vertex.Y, vertex.Z);
                    }
                }
                GL.End();

                if (texture != null)
                {
                    texture.Unbind();
                    GL.Disable(GL.GL_TEXTURE_2D);
                }
            }

            //Console.WriteLine ( GL.GetError () );
        }
    }
}
