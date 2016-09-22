using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                                writer.WriteLine(matrix1.ToArray().PrintVectors(3));
                                writer.WriteLine("------------");
                                writer.WriteLine(matrix2.ToArray().PrintVectors(3));
                                //if (!Same(matrix1, matrix2))
                                //{
                                //    Console.WriteLine("Error!");
                                //}
                            }
                        }
                    }
                }

                writer.WriteLine("Test finished.");
            }
        }

        public static bool Same(mat3 matrix1, mat3 matrix2)
        {
            if (TrueOne(matrix1, matrix2)) { return true; }
            if (TrueTwo(matrix1, matrix2)) { return true; }

            return false;
        }
        public static bool TrueOne(mat3 matrix1, mat3 matrix2)
        {
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (Math.Abs(matrix1[column, row] - matrix2[column, row]) > 0.05)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static bool TrueTwo(mat3 matrix1, mat3 matrix2)
        {
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (Math.Abs(matrix1[column, row] + matrix2[column, row]) > 0.05)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
