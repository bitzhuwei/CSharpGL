using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.SoftGL
{
    public class Pipeline00
    {
        static void Pipeline()
        {
            vec3[] positions = GetVertexPositions();
            vec4[] gl_Positions = VertexShader(positions);
            const int windowWidth = 800, windowHeight = 600;
            Fragment[] fragments = Rasterize(windowWidth, windowHeight, gl_Positions);
            fragments = FragmentShader(fragments);
        }

        private static Fragment[] FragmentShader(Fragment[] fragments)
        {
            throw new NotImplementedException();
        }

        private static Fragment[] Rasterize(int windowWidth, int windowHeight, vec4[] gl_Positions)
        {
            throw new NotImplementedException();
        }

        class Fragment
        {
            public readonly int x;
            public readonly int y;
            public vec4 color;
        }

        private static vec4? FragmentShader(vec4[] gl_Positions)
        {
            throw new NotImplementedException();
        }

        private static vec4[] VertexShader(vec3[] positions)
        {
            throw new NotImplementedException();
        }

        private static vec3[] GetVertexPositions()
        {
            throw new NotImplementedException();
        }

    }
}
