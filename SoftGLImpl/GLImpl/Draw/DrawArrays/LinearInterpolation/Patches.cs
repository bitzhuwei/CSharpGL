using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4Patches(
            RenderContext context, int count,
            GLVertexArrayObject vao, GLProgram program, Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();
            var fs = program.FragmentShader;
            if (fs == null) { return result; }

            throw new NotImplementedException();

            //return result;
        }
    }
}
