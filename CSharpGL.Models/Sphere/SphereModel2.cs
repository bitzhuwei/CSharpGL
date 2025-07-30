using System;
using System.Collections.Generic;

namespace CSharpGL {
    /// <summary>
    /// </summary>
    internal class SphereModel2 {
        internal vec3[] positions;
        internal vec3[] normals;
        internal vec2[] texCoords;
        internal uint[] indexes;

        /// <summary>
        ///
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="X_SEGMENTS"></param>
        /// <param name="Y_SEGMENTS"></param>
        /// <returns></returns>
        internal SphereModel2(float radius = 1.0f, int X_SEGMENTS = 64, int Y_SEGMENTS = 64) {
            vec3[] positions = new vec3[(X_SEGMENTS + 1) * (Y_SEGMENTS + 1)];
            vec2[] texCoords = new vec2[(X_SEGMENTS + 1) * (Y_SEGMENTS + 1)];
            vec3[] normals = new vec3[(X_SEGMENTS + 1) * (Y_SEGMENTS + 1)];

            const float PI = (float)Math.PI;
            {
                int index = 0;
                for (uint y = 0; y <= Y_SEGMENTS; ++y) {
                    for (uint x = 0; x <= X_SEGMENTS; ++x) {
                        float xSegment = (float)x / (float)X_SEGMENTS;
                        float ySegment = (float)y / (float)Y_SEGMENTS;
                        float xPos = radius * (float)Math.Cos(xSegment * 2.0f * PI) * (float)Math.Sin(ySegment * PI);
                        float yPos = radius * (float)Math.Cos(ySegment * PI);
                        float zPos = radius * (float)Math.Sin(xSegment * 2.0f * PI) * (float)Math.Sin(ySegment * PI);

                        positions[index] = new vec3(xPos, yPos, zPos);
                        texCoords[index] = new vec2(xSegment, ySegment);
                        normals[index] = new vec3(xPos, yPos, zPos);
                        index++;
                    }
                }
                this.positions = positions;
                this.texCoords = texCoords;
                this.normals = normals;
            }
            {
                var indices = new List<uint>();
                bool oddRow = false;
                for (uint y = 0; y < Y_SEGMENTS; ++y) {
                    // even rows: y == 0, y == 2; and so on
                    if (!oddRow) {
                        for (int x = 0; x <= X_SEGMENTS; ++x) {
                            indices.Add((uint)(y * (X_SEGMENTS + 1) + x));
                            indices.Add((uint)((y + 1) * (X_SEGMENTS + 1) + x));
                        }
                    }
                    else {
                        for (int x = X_SEGMENTS; x >= 0; --x) {
                            indices.Add((uint)((y + 1) * (X_SEGMENTS + 1) + x));
                            indices.Add((uint)(y * (X_SEGMENTS + 1) + x));
                        }
                    }
                    oddRow = !oddRow;
                }
                this.indexes = indices.ToArray();
            }
        }
    }
}