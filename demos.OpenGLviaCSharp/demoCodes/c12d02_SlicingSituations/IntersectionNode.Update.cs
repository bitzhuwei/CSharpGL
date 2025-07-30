using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d02_SlicingSituations {


    partial class IntersectionNode {
        // Ax + By + Cz + D = 0;
        class Plane {
            public float A;
            public float B;
            public float C;
            public float D;

            public Plane(float A, float B, float C, float D) {
                this.A = A; this.B = B; this.C = C; this.D = D;
            }
        }
        // point1 + point2;
        class LineSegment {
            vec3 point1;
            vec3 point2;

            public LineSegment(vec3 point1, vec3 point2) {
                this.point1 = point1; this.point2 = point2;
            }

            public bool GetIntesection(out vec3 point, Plane plane) {
                var A = new vec3(plane.A, plane.B, plane.C);
                //set var point = point1 * alpha + point2 * (1 - alpha);
                //according to plane: A.dot(point) + plane.D = 0;
                float alpha = -(A.dot(point2) + plane.D) / (A.dot(point1 - point2));
                bool result = (0 <= alpha && alpha <= 1);
                point = point1 * alpha + point2 * (1 - alpha);
                return result;
            }
        }
        private static readonly LineSegment[] lineSegments = new LineSegment[]
        {
            // X
            new LineSegment(new vec3(+0, +1, +1), new vec3(+1, +1, +1)),
            new LineSegment(new vec3(+0, +0, +1), new vec3(+1, +0, +1)),
            new LineSegment(new vec3(+0, +1, +0), new vec3(+1, +1, +0)),
            new LineSegment(new vec3(+0, +0, +0), new vec3(+1, +0, +0)),
            // Y
            new LineSegment(new vec3(+1, +0, +1), new vec3(+1, +1, +1)),
            new LineSegment(new vec3(+0, +0, +1), new vec3(+0, +1, +1)),
            new LineSegment(new vec3(+1, +0, +0), new vec3(+1, +1, +0)),
            new LineSegment(new vec3(+0, +0, +0), new vec3(+0, +1, +0)),
            // Z
            new LineSegment(new vec3(+1, +1, +0), new vec3(+1, +1, +1)),
            new LineSegment(new vec3(+1, +0, +0), new vec3(+1, +0, +1)),
            new LineSegment(new vec3(+0, +1, +0), new vec3(+0, +1, +1)),
            new LineSegment(new vec3(+0, +0, +0), new vec3(+0, +0, +1)),
        };

        // plane: (x, 0, 0) (0, y, 0) (0, 0, z)
        public unsafe void SetSlicePlane(float x, float y, float z) {
            var a = new vec3(x - 0, 0 - y, 0 - 0);
            var b = new vec3(0 - 0, y - 0, 0 - z);
            var v = a.cross(b);
            // Ax + By + Cz + D = 0;
            float A = v.x, B = v.y, C = v.z;
            float D = -(A * x); // or D = -(B * y); or D = -(C * z);
            var plane = new Plane(A, B, C, D);
            var list = new List<vec3>();
            foreach (var line in lineSegments) {
                vec3 point;
                if (line.GetIntesection(out point, plane)) {
                    if (!list.Contains(point)) {
                        list.Add(point);
                    }
                }
            }

            int length = list.Count;
            var positions = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            int index = 0;
            for (int i = 0; i < length - 2; i++) {
                for (int j = i + 1; j < length - 1; j++) {
                    for (int k = j + 1; k < length; k++) {
                        positions[index++] = list[i];
                        positions[index++] = list[j];
                        positions[index++] = list[k];
                    }
                }
            }
            this.positionBuffer.UnmapBuffer();

            int triangleCount = length * (length - 1) * (length - 2) / (3 * 2 * 1);
            this.drawCommand.vertexCount = triangleCount * 3;
        }

    }
}
