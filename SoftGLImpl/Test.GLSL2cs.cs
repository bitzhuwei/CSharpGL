
using bitzhuwei.GLSLFormat;
using SoftGLImpl;
using System.Text;
using System.Xml.Linq;

namespace bitzhuwei.glTForm {
    partial class VertCode : VertexCodeBase {
        // vert

        // [126]: interpolation_qualifier : 'flat' ;
        // [124]: invariant_qualifier : 'invariant' ;
        // [134]: precise_qualifier : 'precise' ;
        /*[precise]*/
        [invariant][interpolation(flat)][Out] vec3 vertexColor; // 禁用颜色插值

        // [289]: precision_qualifier : 'highp' ;
        [In] /*[precision(mode = highp)]*/ vec3 vWorldPos; // 输入高精度变量

        // [128]: layout_qualifier : 'layout' '(' layout_qualifier_id_list ')' ;
        // [91] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' ';' ;
        [layout(binding = 0, values = [std140])]
        [uniform]
        struct Matrices字 {
            mat4 projection;
            mat4 view;
        }
        Matrices字 Matrices;

        // [106]: parameter_declarator : type_specifier 'identifier' array_specifier ;
        [uniform] vec3[] colors/* [3] */;

        // [120]: single_declaration : fully_specified_type 'identifier' array_specifier '=' initializer ;
        // [163]: type_specifier : type_specifier_nonarray array_specifier ;
        [uniform] float[]/*[3]*/ fValues = new float[]/*[3]*/{ 1.0f, 2.0f, 3.0f };

        [subroutine] delegate void LightModel(vec3 pos, [Out] vec3 color);

        // [159]: storage_qualifier : 'subroutine' '(' type_name_list ')' ;
        // [160]: type_name_list : 'type_name' ;
        // [161]: type_name_list : type_name_list ',' 'type_name' ;
        [subroutine("LightModel")]
        void diffuseLight(vec3 pos, [Out] vec3 color) {
            color = vec3(0.8);
        }

        [subroutine("LightModel")]
        void specularLight(vec3 pos, [Out] vec3 color) {
            color = vec3(1.0);
        }


        // [296]: struct_declaration : type_specifier struct_declarator_list ';' ;
        struct SomeStruct { mat4 model; mat4 view; mat4 projection; }
        SomeStruct[] va/* [3] */; SomeStruct vb;

        // [90] declaration : 'precision' precision_qualifier type_specifier ';' ;
        /*precision*/ /*[precision(mode = highp)]*/
        float uselessVar0;

        // [25]: function_call_header_no_parameters : function_call_header 'void' ;
        void someFunc(/*void*/) {
        }

        public override void main() {
            // [66]: logical_xor_expression : logical_and_expression ;
            // [67]: logical_xor_expression : logical_xor_expression '^^' logical_and_expression ;
            bool a = false; bool b = false; bool c = false; bool d = false;
            bool x = XOR(XOR(XOR(a, b), c), d);
        }
    }
    partial class GeomCode : GeometryCodeBase {
        // geom
        // [94] declaration : type_qualifier ';' ;
        [layout(points)][In] static int inDesc;
        // [layout(values = [points])][In] static int inDesc;
        [layout(max_vertices = 2, values = [line_strip])][Out] static int outDesc;

        public override void main() {
        }
    }

    internal static partial class Test {

        public static void GLSL2cs() {
            var sourceVert = @"// vert

// [126]: interpolation_qualifier : 'flat' ;
// [124]: invariant_qualifier : 'invariant' ;
// [134]: precise_qualifier : 'precise' ;
precise invariant flat out vec3 vertexColor; // disable color interpolation

// [289]: precision_qualifier : 'highp' ;
in highp vec3 vWorldPos; // high precision input variable

// [128]: layout_qualifier : 'layout' '(' layout_qualifier_id_list ')' ;
// [91] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' ';' ;
layout(std140, binding = 0) uniform Matrices {
    mat4 projection;
    mat4 view;
};

// [106]: parameter_declarator : type_specifier 'identifier' array_specifier ;
uniform vec3 colors[3];

// [120]: single_declaration : fully_specified_type 'identifier' array_specifier '=' initializer ;
// [163]: type_specifier : type_specifier_nonarray array_specifier ;
uniform float[3] fValues = float[3](1.0,2.0,3.0);

subroutine void LightModel(vec3 pos, out vec3 color);

// [159]: storage_qualifier : 'subroutine' '(' type_name_list ')' ;
// [160]: type_name_list : 'type_name' ;
// [161]: type_name_list : type_name_list ',' 'type_name' ;
subroutine(LightModel) void diffuseLight(vec3 pos, out vec3 color) {
    color = vec3(0.8);
}

subroutine(LightModel) void specularLight(vec3 pos, out vec3 color) {
    color = vec3(1.0);
}


// [296]: struct_declaration : type_specifier struct_declarator_list ';' ;
struct SomeStruct { mat4 model; mat4 view; mat4 projection; }  va[3], vb ;

// [90] declaration : 'precision' precision_qualifier type_specifier ';' ;
precision highp float;

// [25]: function_call_header_no_parameters : function_call_header 'void' ;
void someFunc(void) {
}

void main() {
    // [66]: logical_xor_expression : logical_and_expression ;
    // [67]: logical_xor_expression : logical_xor_expression '^^' logical_and_expression ;
    bool a, b, c, d;
    bool x = a ^^ b ^^ c ^^ d;
}
";
            var sourceGeom = @"// geom
// [94] declaration : type_qualifier ';' ;
layout(points) in; 
// [layout(values = [points])][In] static int inDesc;
layout(line_strip, max_vertices = 2) out; 

void main(){
}
";
            var list = new (string source, string outputFilename)[] { (sourceVert, "vert.cs"), (sourceGeom, "geom.cs") };
            var parser = new CompilerGLSL();
            foreach (var item in list) {
                var tokens = parser.Analyze(item.source);
                var tree = parser.Parse(tokens);
                var unit = parser.Extract(tree, tokens, item.source);
                if (unit != null) {
                    using (var writer = new StreamWriter(item.outputFilename)) {
                        var config = new BlankConfig();
                        var context = new FormatContext(tokens, tabUnit: 4, tabCount: 0);
                        unit.FullFormat(config, writer, context);
                    }
                }
            }
        }
    }
}