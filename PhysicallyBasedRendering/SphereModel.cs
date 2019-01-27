using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    public class SphereModel
    {
        //public static readonly int indexCount;
        //public static readonly vec3[] positions;
        //public static readonly vec2[] uvs;
        //public static readonly vec3[] normals;
        public static readonly float[] bufferData;
        public static readonly uint[] indices;

        //public static readonly float[] vertices = new float[]
        //{
        //    // positions + texture Coords
        //    -1.0f, 1.0f, 0.0f, 0.0f, 1.0f,
        //    -1.0f, -1.0f, 0.0f, 0.0f, 0.0f,
        //    1.0f, 1.0f, 0.0f, 1.0f, 1.0f,
        //    1.0f, -1.0f, 0.0f, 1.0f, 0.0f, 
        //};
        static SphereModel()
        {
            var positions = new List<vec3>();
            var uvs = new List<vec2>();
            var normals = new List<vec3>();
            var indices = new List<uint>();

            const int X_SEGMENTS = 64;
            const int Y_SEGMENTS = 64;
            const float PI = 3.14159265359f;
            for (uint y = 0; y <= Y_SEGMENTS; ++y)
            {
                for (uint x = 0; x <= X_SEGMENTS; ++x)
                {
                    float xSegment = (float)x / (float)X_SEGMENTS;
                    float ySegment = (float)y / (float)Y_SEGMENTS;
                    float xPos = (float)(Math.Cos(xSegment * 2.0f * PI) * Math.Sin(ySegment * PI));
                    float yPos = (float)Math.Cos(ySegment * PI);
                    float zPos = (float)(Math.Sin(xSegment * 2.0f * PI) * Math.Sin(ySegment * PI));

                    positions.Add(new vec3(xPos, yPos, zPos));
                    uvs.Add(new vec2(xSegment, ySegment));
                    normals.Add(new vec3(xPos, yPos, zPos));
                }
            }

            bool oddRow = false;
            for (int y = 0; y < Y_SEGMENTS; ++y)
            {
                if (!oddRow) // even rows: y == 0, y == 2; and so on
                {
                    for (int x = 0; x <= X_SEGMENTS; ++x)
                    {
                        var a = y * (X_SEGMENTS + 1) + x;
                        var b = (y + 1) * (X_SEGMENTS + 1) + x;
                        indices.Add((uint)a);
                        indices.Add((uint)b);
                    }
                }
                else
                {
                    for (int x = X_SEGMENTS; x >= 0; --x)
                    {
                        var a = (y + 1) * (X_SEGMENTS + 1) + x;
                        var b = y * (X_SEGMENTS + 1) + x;
                        indices.Add((uint)a);
                        indices.Add((uint)b);
                    }
                }
                oddRow = !oddRow;
            }
            //indexCount = indices.Count;

            var data = new List<float>();
            for (int i = 0; i < positions.Count; ++i)
            {
                data.Add(positions[i].x);
                data.Add(positions[i].y);
                data.Add(positions[i].z);
                if (uvs.Count > 0)
                {
                    data.Add(uvs[i].x);
                    data.Add(uvs[i].y);
                }
                if (normals.Count > 0)
                {
                    data.Add(normals[i].x);
                    data.Add(normals[i].y);
                    data.Add(normals[i].z);
                }
            }

            SphereModel.bufferData = data.ToArray();
            SphereModel.indices = indices.ToArray();
        }
    }
}
