using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public abstract class SoftGLAttribute : Attribute {
    }

    // conflict: in is C# keyword
    [AttributeUsage(AttributeTargets.All | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class InAttribute : SoftGLAttribute {
    }

    // conflict: out is C# keyword
    [AttributeUsage(AttributeTargets.All | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class OutAttribute : SoftGLAttribute {
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public sealed class uniformAttribute : SoftGLAttribute {
    }


    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public sealed class layoutAttribute : SoftGLAttribute {
        ///// <summary>
        ///// shared/packed/std140/std430
        ///// </summary>
        //public string memoryAlign = "shared";

        ///// <summary>
        ///// row_major/column_major
        ///// </summary>
        //public string matAlign = "column_major";

        public uint binding;
        public uint offset;
        public uint align;
        public uint set;
        /// <summary>
        /// push_constant
        /// 高效传递少量频繁更新的数据​ 到着色器
        /// </summary>
        public bool push_constant = false;
        public uint input_attachment_index;
        public uint location;
        public uint component;
        public uint index;
        /// <summary>
        ///// triangles/quads/isolines
        ///// </summary>
        //public string? teseDomain;
        ///// <summary>
        ///// equal_spacing/fractional_even_spacing/fractional_odd_spacing
        ///// </summary>
        //public string? teseInterpolationMode = "equal_spacing";
        ///// <summary>
        ///// cw/ccw
        ///// </summary>
        //public string teseWindingOrder = "ccw";
        ///// <summary>
        ///// 将细分生成的图元强制转换为点
        ///// </summary>
        //public bool point_mode = false;

        /////// <summary>
        /////// points
        /////// </summary>
        ////public string location;
        ///// <summary>
        ///// points/lines/lines_adjacency/triangles/triangles_adjacency
        ///// </summary>
        //public string? geomPrimitive;
        /// <summary>
        /// 几何着色器对每个输入图元的 ​并行调用次数​（即实例化次数）
        /// </summary>
        public uint invocations = 1;

        //// fragment shader
        //public bool origin_upper_left = false;
        //public bool pixel_center_integer = false;
        ///// <summary>
        ///// 未启用 early_fragment_tests，即深度/模板测试 ​在片段着色器之后执行。
        ///// </summary>
        //public bool early_fragment_tests = false;

        public uint local_size_x;
        public uint local_size_y;
        public uint local_size_z;
        public uint local_size_x_id;
        public uint local_size_y_id;
        public uint local_size_z_id;

        /// <summary>
        /// 指定着色器输出变量写入的 ​Transform Feedback 缓冲区索引。灵活分配顶点数据到多个缓冲区。
        /// 在 Transform Feedback 模式下，控制顶点数据输出到 ​多个缓冲区​ 的分配规则。
        /// 每个 xfb_buffer 对应一个绑定的缓冲区对象（通过 glBindBufferBase(GL_TRANSFORM_FEEDBACK_BUFFER, index, buffer)）。
        /// 允许多个输出变量按需分配到不同的缓冲区中（例如将位置、法线、颜色分开存储）。
        /// </summary>
        public uint xfb_buffer;
        /// <summary>
        /// 定义缓冲区的跨距（每个顶点的总字节数）。
        /// </summary>
        public uint xfb_stride;
        /// <summary>
        /// 指定变量在缓冲区中的字节偏移量（必须显式设置）。
        /// </summary>
        public uint xfb_offset;

        /// <summary>
        /// 在 ​Tessellation Control Shader（细分控制着色器）​​ 中，指定 ​每个面片（Patch）输出的控制点数量
        /// </summary>
        public uint? vertices;
        ///// <summary>
        ///// points/line_strip/triangle_strip
        ///// 在 ​GLSL 几何着色器（Geometry Shader）​​ 中声明 ​输出图元类型
        ///// </summary>
        //public string? geomOutPrimitive;
        /// <summary>
        /// 在 ​GLSL 几何着色器（Geometry Shader）​​ 中声明 单次调用最多输出的顶点数
        /// </summary>
        public int/*?*/ max_vertices = -1;
        /// <summary>
        /// 在 ​GLSL 几何着色器（Geometry Shader）​​ 中，stream 是用于 ​多流 Transform Feedback（多流变换反馈）​​ 的布局限定符，允许将几何着色器的输出分配到不同的 ​Transform Feedback 流​ 中
        /// 指定几何着色器输出的图元（Primitives）应发送到哪个 ​Transform Feedback 流​（Stream）。
        /// 将不同的输出类型（如位置、法线、颜色）分离到不同的缓冲区（Buffer），便于后续处理。
        /// 通过 layout(stream = N) 指定流的索引（N 是非负整数），每个流可绑定到独立的缓冲区。
        /// </summary>
        public uint stream = 0;

        public string[] values;
        ///// <summary>
        ///// depth_any/depth_greater/depth_less/depth_unchanged
        ///// 控制 ​深度测试（Depth Test）和深度写入（Depth Write）行为
        ///// </summary> 
        //public string depthMode = "depth_any";

        // layout(constant_id = 0) const int LIGHT_TYPE = 0;  // 定义特殊化常量
        /// <summary>
        /// 将着色器中的常量定义为 ​特殊化常量（Specialization Constant）​，允许在 ​着色器编译时​（而非运行时）动态设置其值，生成不同行为的着色器变体。
        /// </summary>
        public uint? constant_id;
        ///// <summary>
        ///// rgba32f/rgba16f/rg32f/rg16f/r11f_g11f_b10f/r32f/r16f/rgba16/rgb10_a2/rgba8/rg16/rg8/r16/r8/rgba16_snorm/rgba8_snorm/rg16_snorm/rg8_snorm/r16_snorm/r8_snorm/rgba32i/rgba16i/rgba8i/rg32i/rg16i/rg8i/r32i/r16i/r8i/rgba32ui/rgba16ui/rgb10_a2ui/rgba8ui/rg32ui/rg16ui/rg8ui/r32ui/r16ui/r8ui
        ///// </summary>
        //public string? imageType;

        //public layoutAttribute() { }
        //public layoutAttribute(uint location) {
        //    this.location = location;
        //}
        // layout(isolines, point_mode) in;
        public layoutAttribute(uint binding, params string[] values) {
            this.binding = binding;
            this.values = values;
        }
        public layoutAttribute(params string[] values) {
            this.values = values;
        }
        public override string ToString() {
            return string.Format("layout(location = {0})", this.location);
        }

        ///// <summary>
        ///// return (name, value)
        ///// </summary>
        ///// <param name="identifier"></param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public static (string, string) ParseLayoutParam(string identifier) {
        //    switch (identifier) {
        //    case "shared": return ("memoryAlign", "shared");
        //    case "packed": return ("memoryAlign", "packed");
        //    case "std140": return ("memoryAlign", "std140");
        //    case "std430": return ("memoryAlign", "std430");
        //    case "row_major": return ("matAlign", "row_major");
        //    case "column_major": return ("matAlign", "column_major");
        //    case "push_constant": return ("push_constant", "true");
        //    default: throw new NotImplementedException();
        //    }
        //}

    }


    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public sealed class patchAttribute : SoftGLAttribute {
        public uint location;

    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public sealed class interpolationAttribute : Attribute {
        /// <summary>
        /// smooth/flat/noperspective
        /// </summary>
        public string mode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode">smooth/flat/noperspective</param>
        public interpolationAttribute(string mode) {
            this.mode = mode;
        }
        public override string ToString() {
            return $"interpolation:{this.mode}";
        }
    }
    public sealed class preciseAttribute : Attribute { }
    public sealed class precisionAttribute : SoftGLAttribute {
        /// <summary>
        /// highp/mediump/lowp
        /// </summary>
        public string mode = CodeBase.highp;

    }
    public sealed class invariantAttribute : Attribute { }

    [System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public sealed class subroutineAttribute : Attribute {
        public readonly string[] typeNames;
        public subroutineAttribute(params string[] typeNames) {
            this.typeNames = typeNames;
        }
        public override string ToString() {
            return $"subroutine ({typeNames.Length} type names)";
        }
    }
}
