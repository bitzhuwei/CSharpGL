using System;

namespace CSharpGL.FileParser._3DSParser
{
    public struct TexCoord
    {
        public float U;
        public float V;

        public TexCoord(float u, float v)
        {
            U = u;
            V = v;
        }
    }

    public class ThreeDSMesh
    {
        // TODO: OO this
        // fields should be private
        // constructor with verts and faces
        // normalize in ctor

        public ThreeDSMaterial material = new ThreeDSMaterial();

        // The stored vertices 
        public Vector[] vertices;

        // The calculated normals
        public Vector[] normals;

        // The indices of the triangles which point to vertices
        public Triangle[] indices;

        // The coordinates which map the texture onto the entity
        public TexCoord[] texcoords;

        bool normalized = false;

        public void CalculateNormals()
        {
            if (indices == null) return;

            normals = new Vector[vertices.Length];

            Vector[] temps = new Vector[indices.Length];

            for (int ii = 0; ii < indices.Length; ii++)
            {
                Triangle tr = indices[ii];

                Vector v1 = vertices[tr.vertex1] - vertices[tr.vertex2];
                Vector v2 = vertices[tr.vertex2] - vertices[tr.vertex3];

                temps[ii] = v1.CrossProduct(v2);
                //Console.Write ("I");
            }

            for (int ii = 0; ii < vertices.Length; ii++)
            {
                Vector v = new Vector();
                int shared = 0;

                for (int jj = 0; jj < indices.Length; jj++)
                {
                    Triangle tr = indices[jj];
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

        public void Render()
        {
            /*if ( indices == null ) return;

            Gl.glMaterialfv (Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, material.Ambient);
            Gl.glMaterialfv (Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, material.Diffuse);
            Gl.glMaterialfv (Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, material.Specular);
            Gl.glMaterialf (Gl.GL_FRONT_AND_BACK, Gl.GL_SHININESS, material.Shininess);
				
            if (material.TextureId >= 0 ) 
            {
                Gl.glBindTexture ( Gl.GL_TEXTURE_2D, material.TextureId ); 
                Gl.glEnable( Gl.GL_TEXTURE_2D );
            }

            // Draw every triangle in the entity
            Gl.glBegin ( Gl.GL_TRIANGLES);		
            foreach ( Triangle tri in indices )
            { 
                // Vertex 1
                if (normalized) Gl.glNormal3d ( normals[tri.vertex1].X, normals[tri.vertex1].Y, normals[tri.vertex1].Z );
                if ( material.TextureId >= 0 ) Gl.glTexCoord2f ( texcoords [ tri.vertex1 ].U, texcoords [ tri.vertex1 ].V);
                Gl.glVertex3d ( vertices[tri.vertex1].X, vertices[tri.vertex1].Y, vertices[tri.vertex1].Z );

                // Vertex 2
                if (normalized) Gl.glNormal3d ( normals[tri.vertex2].X, normals[tri.vertex2].Y, normals[tri.vertex2].Z );
                if ( material.TextureId >= 0 ) Gl.glTexCoord2f ( texcoords [ tri.vertex2 ].U, texcoords [ tri.vertex2 ].V);
                Gl.glVertex3d ( vertices[tri.vertex2].X, vertices[tri.vertex2].Y, vertices[tri.vertex2].Z );

                // Vertex 3
                if (normalized) Gl.glNormal3d ( normals[tri.vertex3].X, normals[tri.vertex3].Y, normals[tri.vertex3].Z );
                if ( material.TextureId >= 0 ) Gl.glTexCoord2f( texcoords [ tri.vertex3 ].U, texcoords [ tri.vertex3 ].V);
                Gl.glVertex3d ( vertices[tri.vertex3].X, vertices[tri.vertex3].Y, vertices[tri.vertex3].Z );
            }
			
            Gl.glEnd();
            Gl.glDisable( Gl.GL_TEXTURE_2D );
            //Console.WriteLine ( Gl.glGetError () );
            */

        }
    }
}
