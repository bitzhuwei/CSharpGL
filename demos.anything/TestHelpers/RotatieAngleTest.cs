using System;
using System.Diagnostics;
using System.IO;

namespace CSharpGL.TestHelpers {
    public static class RotatieAngleTest {
        /// <summary>
        /// This test shows in what unit(degree or radian) does glRotatef() and glm.rotate() use.
        /// </summary>
        public unsafe static void Test() {
            var gl = GL.Current; Debug.Assert(gl != null);
            using (var writer = new StreamWriter("test-rotationAngle.txt")) {
                int length = 5;
                for (int angleDegree = 1; angleDegree < 361; angleDegree++) {
                    for (int x = -length; x < length; x++) {
                        for (int y = -length; y < length; y++) {
                            for (int z = -length; z < length; z++) {
                                gl.glMatrixMode(GL.GL_MODELVIEW_MATRIX);
                                gl.glLoadIdentity();
                                gl.glRotatef(angleDegree, x, y, z);
                                var matrix1 = new float[16];
                                fixed (float* p = matrix1) {
                                    gl.glGetFloatv((uint)GetTarget.ModelviewMatix, p);
                                }
                                mat4 matrix2 = glm.rotate(angleDegree, new vec3(x, y, z));
                                //mat4 matrix2 = glm.rotate((float)(angleDegree * Math.PI / 180.0), new vec3(x, y, z));
                                writer.WriteLine("====================");
                                writer.WriteLine("{3}° x[{0}] y[{1}] z[{2}]", x, y, z, angleDegree);
                                //writer.WriteLine(matrix1.PrintVectors(4, ",", ";" + Environment.NewLine));
                                writer.WriteLine(matrix1);
                                writer.WriteLine("------------");
                                //writer.WriteLine(matrix2.ToArray().PrintVectors(4, ",", ";" + Environment.NewLine));
                                writer.WriteLine(matrix2);
                                //}
                            }
                        }
                    }
                }

                writer.WriteLine("Test finished.");
            }
        }

        /// <summary>
        /// </summary>
        public static void Test2() {
            using (var writer = new StreamWriter("test-quaternion2.txt")) {
                int length = 5;
                for (int angleDegree = 1; angleDegree < 361; angleDegree++) {
                    for (int x = -length; x < length; x++) {
                        for (int y = -length; y < length; y++) {
                            for (int z = -length; z < length; z++) {
                                var quaternion = new Quaternion(angleDegree, new vec3(x, y, z));
                                mat3 matrix1 = quaternion.ToRotationMatrix();
                                Quaternion quaternion2 = matrix1.ToQuaternion();
                                writer.WriteLine("====================");
                                writer.WriteLine("{3}° x[{0}] y[{1}] z[{2}]", x, y, z, angleDegree);
                                writer.WriteLine(quaternion);
                                writer.WriteLine("------------");
                                writer.WriteLine(quaternion2);
                                //}
                            }
                        }
                    }
                }

                writer.WriteLine("Test finished.");
            }
        }
    }
}