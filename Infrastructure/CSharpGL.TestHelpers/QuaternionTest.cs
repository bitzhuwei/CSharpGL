using System;
using System.IO;

namespace CSharpGL.TestHelpers
{
    public static class QuaternionTest
    {
        public static void Test()
        {
            using (var writer = new StreamWriter("test-quaternion.txt"))
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
                                mat4 tmp = glm.rotate((float)(degreeAngle * Math.PI / 180.0f), new vec3(x, y, z));
                                mat3 matrix2 = tmp.to_mat3();
                                writer.WriteLine("====================");
                                writer.WriteLine("{3}° x[{0}] y[{1}] z[{2}]", x, y, z, degreeAngle);
                                writer.WriteLine(matrix1.ToArray().PrintVectors(3, ",", ";" + Environment.NewLine));
                                writer.WriteLine("------------");
                                writer.WriteLine(matrix2.ToArray().PrintVectors(3, ",", ";" + Environment.NewLine));
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