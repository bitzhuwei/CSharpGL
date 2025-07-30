using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        private static unsafe ConcurrentBag<FragmentCodeBase[]> LinearInterpolationAndFragmentShaderStage4Patches(
            RenderContext context, int count, DrawElementsType type, IntPtr indices,
            GLVertexArrayObject vao, GLProgram program, GLBuffer indexBuffer,
            Dictionary<uint, VertexCodeBase> vertexID2Shader) {
            var result = new System.Collections.Concurrent.ConcurrentBag<FragmentCodeBase[]>();
            var fs = program.FragmentShader;
            if (fs == null) { return result; }

            throw new NotImplementedException();

            //return result;
        }
    }
}
