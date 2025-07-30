using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public abstract partial class CodeBase {
        public abstract void main();

        public struct gl_DepthRangeParameters {
            public float near;
            public float far;
            /// <summary>
            /// The diff value is the far value minus the near value.
            /// </summary>
            public float diff;
        };
        // TODO: move all uniforms to concrete shader types
        /// <summary>
        /// This struct provides access to the glDepthRange near and far values. The diff value is the far value minus the near value. Do recall that OpenGL makes no requirement that far is greater than near. With regard to multiple Viewports, gl_DepthRange only stores the range for viewport 0.
        /// </summary>
        //[uniform]
        public gl_DepthRangeParameters gl_DepthRange;

        /// <summary>
        /// gl_NumSamples is the number of samples in the current Framebuffer. If the framebuffer is not multisampled, then this value will be 1.
        /// </summary>
        //[uniform]
        int gl_NumSamples; // GLSL 4.20

        public const int gl_MaxVertexAttribs = 16;
        public const int gl_MaxVertexOutputComponents = 64;
        public const int gl_MaxVertexUniformComponents = 1024;
        public const int gl_MaxVertexTextureImageUnits = 16;
        public const int gl_MaxGeometryInputComponents = 64;
        public const int gl_MaxGeometryOutputComponents = 128;
        public const int gl_MaxGeometryUniformComponents = 1024;
        public const int gl_MaxGeometryTextureImageUnits = 16;
        public const int gl_MaxGeometryOutputVertices = 256;
        public const int gl_MaxGeometryTotalOutputComponents = 1024;
        public const int gl_MaxGeometryVaryingComponents = 64;
        public const int gl_MaxFragmentInputComponents = 128;
        public const int gl_MaxDrawBuffers = 8;
        public const int gl_MaxFragmentUniformComponents = 1024;
        /// <summary>
        /// This is the number of fragment shader texture image units.
        /// </summary>
        public const int gl_MaxTextureImageUnits = 16;
        public const int gl_MaxClipDistances = 8;
        public const int gl_MaxCombinedTextureImageUnits = 96;

        // Requires OpenGL 4.0
        public const int gl_MaxTessControlInputComponents = 128;
        public const int gl_MaxTessControlOutputComponents = 128;
        public const int gl_MaxTessControlUniformComponents = 1024;
        public const int gl_MaxTessControlTextureImageUnits = 16;
        public const int gl_MaxTessControlTotalOutputComponents = 4096;
        public const int gl_MaxTessEvaluationInputComponents = 128;
        public const int gl_MaxTessEvaluationOutputComponents = 128;
        public const int gl_MaxTessEvaluationUniformComponents = 1024;
        public const int gl_MaxTessEvaluationTextureImageUnits = 16;
        public const int gl_MaxTessPatchComponents = 120;
        public const int gl_MaxPatchVertices = 32;
        public const int gl_MaxTessGenLevel = 64;

        // Requires OpenGL 4.1
        public const int gl_MaxViewports = 16;
        public const int gl_MaxVertexUniformVectors = 256;
        public const int gl_MaxFragmentUniformVectors = 256;
        public const int gl_MaxVaryingVectors = 15;

        // Requires OpenGL 4.2
        public const int gl_MaxVertexImageUniforms = 0;
        public const int gl_MaxVertexAtomicCounters = 0;
        public const int gl_MaxVertexAtomicCounterBuffers = 0;
        public const int gl_MaxTessControlImageUniforms = 0;
        public const int gl_MaxTessControlAtomicCounters = 0;
        public const int gl_MaxTessControlAtomicCounterBuffers = 0;
        public const int gl_MaxTessEvaluationImageUniforms = 0;
        public const int gl_MaxTessEvaluationAtomicCounters = 0;
        public const int gl_MaxTessEvaluationAtomicCounterBuffers = 0;
        public const int gl_MaxGeometryImageUniforms = 0;
        public const int gl_MaxGeometryAtomicCounters = 0;
        public const int gl_MaxGeometryAtomicCounterBuffers = 0;
        public const int gl_MaxFragmentImageUniforms = 8;
        public const int gl_MaxFragmentAtomicCounters = 8;
        public const int gl_MaxFragmentAtomicCounterBuffers = 1;
        public const int gl_MaxCombinedImageUniforms = 8;
        public const int gl_MaxCombinedAtomicCounters = 8;
        public const int gl_MaxCombinedAtomicCounterBuffers = 1;
        public const int gl_MaxImageUnits = 8;
        public const int gl_MaxCombinedImageUnitsAndFragmentOutputs = 8;
        public const int gl_MaxImageSamples = 0;
        public const int gl_MaxAtomicCounterBindings = 1;
        public const int gl_MaxAtomicCounterBufferSize = 32;
        public const int gl_MinProgramTexelOffset = -8;
        public const int gl_MaxProgramTexelOffset = 7;

        // Requires OpenGL 4.3
        public static readonly ivec3 gl_MaxComputeWorkGroupCount = new ivec3(65535, 65535, 65535);
        public static readonly ivec3 gl_MaxComputeWorkGroupSize = new ivec3(1024, 1024, 64);
        public const int gl_MaxComputeUniformComponents = 512;
        public const int gl_MaxComputeTextureImageUnits = 16;
        public const int gl_MaxComputeImageUniforms = 8;
        public const int gl_MaxComputeAtomicCounters = 8;
        public const int gl_MaxComputeAtomicCounterBuffers = 1;

        // Requires OpenGL 4.4
        public const int gl_MaxTransformFeedbackBuffers = 4;
        public const int gl_MaxTransformFeedbackInterleavedComponents = 64;

        // const values for qualifiers layout(...)
        public const string shared = "shared";
        public const string packed = "packed";
        public const string std140 = "std140";
        public const string std430 = "std430";
        public const string row_major = "row_major";
        public const string column_major = "column_major";

        public const string triangles = "triangles";
        public const string quads = "quads";
        public const string isolines = "isolines";
        public const string equal_spacing = "equal_spacing";
        public const string fractional_even_spacing = "fractional_even_spacing";
        public const string fractional_odd_spacing = "fractional_odd_spacing";
        public const string cw = "cw";
        public const string ccw = "ccw";
        public const string point_mode = "point_mode";
        public const string points = "points";
        public const string lines = "lines";
        public const string lines_adjacency = "lines_adjacency";
        //public const string triangles = "triangles";
        public const string origin_upper_left = "origin_upper_left";
        public const string pixel_center_integer = "pixel_center_integer";
        public const string early_fragment_tests = "early_fragment_tests";
        //public const string points = "points";
        public const string line_strip = "line_strip";
        public const string triangle_strip = "triangle_strip";
        public const string depth_any = "depth_any";
        public const string depth_greater = "depth_greater";
        public const string depth_less = "depth_less";
        public const string depth_unchanged = "depth_unchanged";
        public const string rgba32f = "rgba32f";
        public const string rgba16f = "rgba16f";
        public const string rg32f = "rg32f";
        public const string rg16f = "rg16f";
        public const string r11f_g11f_b10f = "r11f_g11f_b10f";
        public const string r32f = "r32f";
        public const string r16f = "r16f";
        public const string rgba16 = "rgba16";
        public const string rgb10_a2 = "rgb10_a2";
        public const string rgba8 = "rgba8";
        public const string rg16 = "rg16";
        public const string rg8 = "rg8";
        public const string r16 = "r16";
        public const string r8 = "r8";
        public const string rgba16_snorm = "rgba16_snorm";
        public const string rgba8_snorm = "rgba8_snorm";
        public const string rg16_snorm = "rg16_snorm";
        public const string rg8_snorm = "rg8_snorm";
        public const string r16_snorm = "r16_snorm";
        public const string r8_snorm = "r8_snorm";
        public const string rgba32i = "rgba32i";
        public const string rgba16i = "rgba16i";
        public const string rgba8i = "rgba8i";
        public const string rg32i = "rg32i";
        public const string rg16i = "rg16i";
        public const string rg8i = "rg8i";
        public const string r32i = "r32i";
        public const string r16i = "r16i";
        public const string r8i = "r8i";
        public const string rgba32ui = "rgba32ui";
        public const string rgba16ui = "rgba16ui";
        public const string rgb10_a2ui = "rgb10_a2ui";
        public const string rgba8ui = "rgba8ui";
        public const string rg32ui = "rg32ui";
        public const string rg16ui = "rg16ui";
        public const string rg8ui = "rg8ui";
        public const string r32ui = "r32ui";
        public const string r16ui = "r16ui";
        public const string r8ui = "r8ui";
        public const string highp = "highp";
        public const string mediump = "mediump";
        public const string lowp = "lowp";

        public const string smooth = "smooth";
        public const string flat = "flat";
        public const string noperspective = "noperspective";

    }
}
