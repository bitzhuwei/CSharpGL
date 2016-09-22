using System;
using System.IO;

namespace CSharpGL.TestHelpers
{
    public static class RotatieAngleTest
    {
        /// <summary>
        /// This test shows in what unit(degree or radian) does glRotatef() and glm.rotate() use.
        /// </summary>
        public static void Test()
        {
            using (var writer = new StreamWriter("test-rotationAngle.txt"))
            {
                int length = 5;
                for (int degreeAngle = 1; degreeAngle < 361; degreeAngle++)
                {
                    for (int x = -length; x < length; x++)
                    {
                        for (int y = -length; y < length; y++)
                        {
                            for (int z = -length; z < length; z++)
                            {
                                OpenGL.MatrixMode(OpenGL.GL_MODELVIEW_MATRIX);
                                OpenGL.LoadIdentity();
                                OpenGL.Rotatef(degreeAngle, x, y, z);
                                float[] matrix1 = new float[16];
                                OpenGL.GetFloat(GetTarget.ModelviewMatix, matrix1);
                                mat4 matrix2 = glm.rotate(degreeAngle, new vec3(x, y, z));
                                //mat4 matrix2 = glm.rotate((float)(degreeAngle * Math.PI / 180.0), new vec3(x, y, z));
                                writer.WriteLine("====================");
                                writer.WriteLine("{3}° x[{0}] y[{1}] z[{2}]", x, y, z, degreeAngle);
                                writer.WriteLine(matrix1.PrintVectors(4, ",", ";" + Environment.NewLine));
                                writer.WriteLine("------------");
                                writer.WriteLine(matrix2.ToArray().PrintVectors(4, ",", ";" + Environment.NewLine));
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
        public static void Test2()
        {
            using (var writer = new StreamWriter("test-quaternion2.txt"))
            {
                int length = 5;
                for (int degreeAngle = 1; degreeAngle < 361; degreeAngle++)
                {
                    for (int x = -length; x < length; x++)
                    {
                        for (int y = -length; y < length; y++)
                        {
                            for (int z = -length; z < length; z++)
                            {
                                var quaternion = new Quaternion(degreeAngle, new vec3(x, y, z));
                                mat3 matrix1 = quaternion.ToRotationMatrix();
                                Quaternion quaternion2 = matrix1.ToQuaternion();
                                writer.WriteLine("====================");
                                writer.WriteLine("{3}° x[{0}] y[{1}] z[{2}]", x, y, z, degreeAngle);
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