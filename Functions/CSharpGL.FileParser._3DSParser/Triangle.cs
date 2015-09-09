using System;

namespace CSharpGL.FileParser._3DSParser
{
    public struct Triangle
    {
        public int vertex1;
        public int vertex2;
        public int vertex3;

        public Triangle(int v1, int v2, int v3)
        {
            vertex1 = v1;
            vertex2 = v2;
            vertex3 = v3;
        }

        public override string ToString()
        {
            return String.Format("v1: {0} v2: {1} v3: {2}", vertex1, vertex2, vertex3);
        }
    }
}

