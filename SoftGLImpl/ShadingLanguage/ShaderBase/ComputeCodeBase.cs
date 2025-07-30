using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public abstract partial class ComputeCodeBase : CodeBase {
        /// <summary>
        /// 这个常量的数值就是在布局限定符 local_size_x、local_size_y 和 local_size_z 中指定的数值。创建这个常量有两个目的。首先，它使得本地工作组的大小可以在 Shader 中被多次访问而无需依赖预处理。其次，它使得以多维形式表示的本地工作组大小可以直接按向量处理，而无须显式地构造。
        /// <para>The gl_WorkGroupSize variable is a constant that contains the local work-group size of the shader, in 3 dimensions. It is defined by the layout qualifiers local_size_x/y/z. This is a compile-time constant.</para>
        /// </summary>
        public readonly uvec3 gl_WorkGroupSize;// GLSL ≥ 4.30
        /// <summary>
        /// 这个向量记录的是传递给 glDispatchCompute(..)的参数（num_groups_x、num_groups_y 和num_groups_z）。在 Shader 中可以直接用此变量获取全局工作组的大小。 
        /// <para>This variable contains the number of work groups passed to the dispatch function</para>
        /// </summary>
        //[InAttribute]
        public readonly uvec3 gl_NumWorkGroups;
        /// <summary>
        /// 这个向量表示当前工作项在本地工作组中的位置，其范围为从 uvec3(0)到(gl_WorkGroupSize - uvec3(1))。 
        /// <para>This is the current invocation of the shader within the work group. Each of the XYZ components will be on the half-open range [0, gl_WorkGroupSize.XYZ).</para>
        /// </summary>
        //[InAttribute]
        public readonly uvec3 gl_LocalInvocationID;
        /// <summary>
        /// 这个向量表示当前本地工作组在全局工作组中的位置，其范围为从 uvec3(0)到(gl_NumWorkGroups - uvec3(1))。 
        /// <para>This is the current work group for this shader invocation. Each of the XYZ components will be on the half-open range [0, gl_NumWorkGroups.XYZ).</para>
        /// </summary>
        //[InAttribute]
        public readonly uvec3 gl_WorkGroupID;
        /// <summary>
        /// 这个向量表示当前工作项在全局工作组中的位置，其值为(gl_WorkGroupID * gl_WorkGroupSize + gl_LocalInvocationID)。 
        /// <para>This value uniquely identifies this particular invocation of the compute shader among all invocations of this compute dispatch call. It's a short-hand for the math computation: gl_WorkGroupID * gl_WorkGroupSize + gl_LocalInvocationID;</para>
        /// </summary>
        //[InAttribute]
        public readonly uvec3 gl_GlobalInvocationID;
        /// <summary>
        /// 这个数值是将 gl_LocalInvocationID 扁平化的结果，其值为(gl_LocalInvocationID.z * gl_WorkGroupSize.y * glWorkGroupSize.x + gl_LocalInvocationID.y * gl_WorkGroupSize.x + gl_LocalInvocationID.x)。
        /// <para>This is a 1D version of gl_LocalInvocationID. It identifies this invocation's index within the work group. It is short-hand for this math computation: gl_LocalInvocationIndex = gl_LocalInvocationID.z* gl_WorkGroupSize.x * gl_WorkGroupSize.y + gl_LocalInvocationID.y* gl_WorkGroupSize.x + gl_LocalInvocationID.x;</para>
        /// </summary>
        //[InAttribute]
        public readonly uint gl_LocalInvocationIndex;

        // moved to CodeBase
        //public struct gl_DepthRangeParameters {
        //    float near;
        //    float far;
        //    /// <summary>
        //    /// The diff value is the far value minus the near value.
        //    /// </summary>
        //    float diff;
        //};
        ///// <summary>
        ///// This struct provides access to the glDepthRange near and far values. The diff value is the far value minus the near value. Do recall that OpenGL makes no requirement that far is greater than near. With regard to multiple Viewports, gl_DepthRange only stores the range for viewport 0.
        ///// </summary>
        //[uniform]
        //public gl_DepthRangeParameters gl_DepthRange;

        /// <summary>
        /// gl_NumSamples is the number of samples in the current Framebuffer. If the framebuffer is not multisampled, then this value will be 1.
        /// </summary>
        //[uniform]
        public int gl_NumSamples; // GLSL 4.20

    }
}
