using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        private static unsafe readonly Func<int, IntPtr, FragmentCodeBase, bool> alwaysHasValidDepth = (width, depthBuffer, fsInstance) => {
            return true;
        };
        private static unsafe readonly Func<int, IntPtr, FragmentCodeBase, bool> hasValidDepth24uint = (width, depthBuffer, fsInstance) => {
            var depthTestPlatform = (byte*)depthBuffer;// [viewport.z, viewport.w];
            var x = (int)fsInstance.gl_FragCoord.x;
            var y = (int)fsInstance.gl_FragCoord.y;
            var coord = (y * width + x) * 3;
            uint preDepth = 0;
            for (int i = 0; i < 3; i++) { preDepth += (uint)(depthTestPlatform[coord + i] << i); }
            var postDepth = (uint)fsInstance.gl_FragCoord.z * (1 << 24);
            // TODO: switch (depthfunc(..)) { .. }
            var result = postDepth <= preDepth;// fragment is nearer or equal.
            return result;
        };
        private static unsafe readonly Func<int, IntPtr, FragmentCodeBase, bool> hasValidDepth32float = (width, depthBuffer, fsInstance) => {
            var depthTestPlatform = (float*)depthBuffer;// [viewport.z, viewport.w];
            var x = (int)fsInstance.gl_FragCoord.x;
            var y = (int)fsInstance.gl_FragCoord.y;
            var coord = y * width + x;
            var preDepth = depthTestPlatform[coord];
            // TODO: switch (depthfunc(..)) { .. }
            var result = fsInstance.gl_FragCoord.z <= preDepth;// fragment is nearer or equal.
            return result;
        };
    }
}
