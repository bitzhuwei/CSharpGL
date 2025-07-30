using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class type_specifier_nonarray_struct_specifier : Vntype_specifier_nonarray {
        // [287]: type_specifier_nonarray : struct_specifier ;

        private readonly Vnstruct_specifier struct_specifier0;

        public type_specifier_nonarray_struct_specifier(Vnstruct_specifier struct_specifier0) {
            this._tokenRange = new TokenRange(struct_specifier0);
            this.struct_specifier0 = struct_specifier0;
        }

        public override string GetTypeName() {
            return this.struct_specifier0.structName;
        }
        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;

        public string GetStructName() {
            return this.struct_specifier0.structName;
        }

        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.struct_specifier0.FullFormat(preConfig, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.struct_specifier0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item2 in this.struct_specifier0.YieldTokens(writer, context)) {
        //        yield return item2;
        //    }
        //}
    }
    partial class type_specifier_nonarray_string : Vntype_specifier_nonarray {
        // [168]: type_specifier_nonarray : 'void' ;
        // [169]: type_specifier_nonarray : 'float' ;
        // [170]: type_specifier_nonarray : 'double' ;
        // [171]: type_specifier_nonarray : 'int' ;
        // [172]: type_specifier_nonarray : 'uint' ;
        // [173]: type_specifier_nonarray : 'bool' ;
        // [174]: type_specifier_nonarray : 'vec2' ;
        // [175]: type_specifier_nonarray : 'vec3' ;
        // [176]: type_specifier_nonarray : 'vec4' ;
        // [177]: type_specifier_nonarray : 'dvec2' ;
        // [178]: type_specifier_nonarray : 'dvec3' ;
        // [179]: type_specifier_nonarray : 'dvec4' ;
        // [180]: type_specifier_nonarray : 'bvec2' ;
        // [181]: type_specifier_nonarray : 'bvec3' ;
        // [182]: type_specifier_nonarray : 'bvec4' ;
        // [183]: type_specifier_nonarray : 'ivec2' ;
        // [184]: type_specifier_nonarray : 'ivec3' ;
        // [185]: type_specifier_nonarray : 'ivec4' ;
        // [186]: type_specifier_nonarray : 'uvec2' ;
        // [187]: type_specifier_nonarray : 'uvec3' ;
        // [188]: type_specifier_nonarray : 'uvec4' ;
        // [189]: type_specifier_nonarray : 'mat2' ;
        // [190]: type_specifier_nonarray : 'mat3' ;
        // [191]: type_specifier_nonarray : 'mat4' ;
        // [192]: type_specifier_nonarray : 'mat2x2' ;
        // [193]: type_specifier_nonarray : 'mat2x3' ;
        // [194]: type_specifier_nonarray : 'mat2x4' ;
        // [195]: type_specifier_nonarray : 'mat3x2' ;
        // [196]: type_specifier_nonarray : 'mat3x3' ;
        // [197]: type_specifier_nonarray : 'mat3x4' ;
        // [198]: type_specifier_nonarray : 'mat4x2' ;
        // [199]: type_specifier_nonarray : 'mat4x3' ;
        // [200]: type_specifier_nonarray : 'mat4x4' ;
        // [201]: type_specifier_nonarray : 'dmat2' ;
        // [202]: type_specifier_nonarray : 'dmat3' ;
        // [203]: type_specifier_nonarray : 'dmat4' ;
        // [204]: type_specifier_nonarray : 'dmat2x2' ;
        // [205]: type_specifier_nonarray : 'dmat2x3' ;
        // [206]: type_specifier_nonarray : 'dmat2x4' ;
        // [207]: type_specifier_nonarray : 'dmat3x2' ;
        // [208]: type_specifier_nonarray : 'dmat3x3' ;
        // [209]: type_specifier_nonarray : 'dmat3x4' ;
        // [210]: type_specifier_nonarray : 'dmat4x2' ;
        // [211]: type_specifier_nonarray : 'dmat4x3' ;
        // [212]: type_specifier_nonarray : 'dmat4x4' ;
        // [213]: type_specifier_nonarray : 'atomic_uint' ;
        // [214]: type_specifier_nonarray : 'sampler2D' ;
        // [215]: type_specifier_nonarray : 'sampler3D' ;
        // [216]: type_specifier_nonarray : 'samplerCube' ;
        // [217]: type_specifier_nonarray : 'sampler2DShadow' ;
        // [218]: type_specifier_nonarray : 'samplerCubeShadow' ;
        // [219]: type_specifier_nonarray : 'sampler2DArray' ;
        // [220]: type_specifier_nonarray : 'sampler2DArrayShadow' ;
        // [221]: type_specifier_nonarray : 'samplerCubeArray' ;
        // [222]: type_specifier_nonarray : 'samplerCubeArrayShadow' ;
        // [223]: type_specifier_nonarray : 'isampler2D' ;
        // [224]: type_specifier_nonarray : 'isampler3D' ;
        // [225]: type_specifier_nonarray : 'isamplerCube' ;
        // [226]: type_specifier_nonarray : 'isampler2DArray' ;
        // [227]: type_specifier_nonarray : 'isamplerCubeArray' ;
        // [228]: type_specifier_nonarray : 'usampler2D' ;
        // [229]: type_specifier_nonarray : 'usampler3D' ;
        // [230]: type_specifier_nonarray : 'usamplerCube' ;
        // [231]: type_specifier_nonarray : 'usampler2DArray' ;
        // [232]: type_specifier_nonarray : 'usamplerCubeArray' ;
        // [233]: type_specifier_nonarray : 'sampler1D' ;
        // [234]: type_specifier_nonarray : 'sampler1DShadow' ;
        // [235]: type_specifier_nonarray : 'sampler1DArray' ;
        // [236]: type_specifier_nonarray : 'sampler1DArrayShadow' ;
        // [237]: type_specifier_nonarray : 'isampler1D' ;
        // [238]: type_specifier_nonarray : 'isampler1DArray' ;
        // [239]: type_specifier_nonarray : 'usampler1D' ;
        // [240]: type_specifier_nonarray : 'usampler1DArray' ;
        // [241]: type_specifier_nonarray : 'sampler2DRect' ;
        // [242]: type_specifier_nonarray : 'sampler2DRectShadow' ;
        // [243]: type_specifier_nonarray : 'isampler2DRect' ;
        // [244]: type_specifier_nonarray : 'usampler2DRect' ;
        // [245]: type_specifier_nonarray : 'samplerBuffer' ;
        // [246]: type_specifier_nonarray : 'isamplerBuffer' ;
        // [247]: type_specifier_nonarray : 'usamplerBuffer' ;
        // [248]: type_specifier_nonarray : 'sampler2DMS' ;
        // [249]: type_specifier_nonarray : 'isampler2DMS' ;
        // [250]: type_specifier_nonarray : 'usampler2DMS' ;
        // [251]: type_specifier_nonarray : 'sampler2DMSArray' ;
        // [252]: type_specifier_nonarray : 'isampler2DMSArray' ;
        // [253]: type_specifier_nonarray : 'usampler2DMSArray' ;
        // [254]: type_specifier_nonarray : 'image2D' ;
        // [255]: type_specifier_nonarray : 'iimage2D' ;
        // [256]: type_specifier_nonarray : 'uimage2D' ;
        // [257]: type_specifier_nonarray : 'image3D' ;
        // [258]: type_specifier_nonarray : 'iimage3D' ;
        // [259]: type_specifier_nonarray : 'uimage3D' ;
        // [260]: type_specifier_nonarray : 'imageCube' ;
        // [261]: type_specifier_nonarray : 'iimageCube' ;
        // [262]: type_specifier_nonarray : 'uimageCube' ;
        // [263]: type_specifier_nonarray : 'imageBuffer' ;
        // [264]: type_specifier_nonarray : 'iimageBuffer' ;
        // [265]: type_specifier_nonarray : 'uimageBuffer' ;
        // [266]: type_specifier_nonarray : 'image1D' ;
        // [267]: type_specifier_nonarray : 'iimage1D' ;
        // [268]: type_specifier_nonarray : 'uimage1D' ;
        // [269]: type_specifier_nonarray : 'image1DArray' ;
        // [270]: type_specifier_nonarray : 'iimage1DArray' ;
        // [271]: type_specifier_nonarray : 'uimage1DArray' ;
        // [272]: type_specifier_nonarray : 'image2DRect' ;
        // [273]: type_specifier_nonarray : 'iimage2DRect' ;
        // [274]: type_specifier_nonarray : 'uimage2DRect' ;
        // [275]: type_specifier_nonarray : 'image2DArray' ;
        // [276]: type_specifier_nonarray : 'iimage2DArray' ;
        // [277]: type_specifier_nonarray : 'uimage2DArray' ;
        // [278]: type_specifier_nonarray : 'imageCubeArray' ;
        // [279]: type_specifier_nonarray : 'iimageCubeArray' ;
        // [280]: type_specifier_nonarray : 'uimageCubeArray' ;
        // [281]: type_specifier_nonarray : 'image2DMS' ;
        // [282]: type_specifier_nonarray : 'iimage2DMS' ;
        // [283]: type_specifier_nonarray : 'uimage2DMS' ;
        // [284]: type_specifier_nonarray : 'image2DMSArray' ;
        // [285]: type_specifier_nonarray : 'iimage2DMSArray' ;
        // [286]: type_specifier_nonarray : 'uimage2DMSArray' ;
        // [288]: type_specifier_nonarray : 'type_name' ;

        private readonly Token tkContent;
        public type_specifier_nonarray_string(Token tkContent) {
            this._tokenRange = new TokenRange(tkContent);
            this.tkContent = tkContent;
        }

        public override string GetTypeName() {
            return this.tkContent.value;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkContent, preConfig, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value); yield return this.tkContent.value;
        //}


        //public static readonly type_specifier_nonarray_string @void = new(nameof(@void));
        //public static readonly type_specifier_nonarray_string @float = new(nameof(@float));
        //public static readonly type_specifier_nonarray_string @double = new(nameof(@double));
        //public static readonly type_specifier_nonarray_string @int = new(nameof(@int));
        //public static readonly type_specifier_nonarray_string @uint = new(nameof(@uint));
        //public static readonly type_specifier_nonarray_string @bool = new(nameof(@bool));
        //public static readonly type_specifier_nonarray_string @vec2 = new(nameof(@vec2));
        //public static readonly type_specifier_nonarray_string @vec3 = new(nameof(@vec3));
        //public static readonly type_specifier_nonarray_string @vec4 = new(nameof(@vec4));
        //public static readonly type_specifier_nonarray_string @dvec2 = new(nameof(@dvec2));
        //public static readonly type_specifier_nonarray_string @dvec3 = new(nameof(@dvec3));
        //public static readonly type_specifier_nonarray_string @dvec4 = new(nameof(@dvec4));
        //public static readonly type_specifier_nonarray_string @bvec2 = new(nameof(@bvec2));
        //public static readonly type_specifier_nonarray_string @bvec3 = new(nameof(@bvec3));
        //public static readonly type_specifier_nonarray_string @bvec4 = new(nameof(@bvec4));
        //public static readonly type_specifier_nonarray_string @ivec2 = new(nameof(@ivec2));
        //public static readonly type_specifier_nonarray_string @ivec3 = new(nameof(@ivec3));
        //public static readonly type_specifier_nonarray_string @ivec4 = new(nameof(@ivec4));
        //public static readonly type_specifier_nonarray_string @uvec2 = new(nameof(@uvec2));
        //public static readonly type_specifier_nonarray_string @uvec3 = new(nameof(@uvec3));
        //public static readonly type_specifier_nonarray_string @uvec4 = new(nameof(@uvec4));
        //public static readonly type_specifier_nonarray_string @mat2 = new(nameof(@mat2));
        //public static readonly type_specifier_nonarray_string @mat3 = new(nameof(@mat3));
        //public static readonly type_specifier_nonarray_string @mat4 = new(nameof(@mat4));
        //public static readonly type_specifier_nonarray_string @mat2x2 = new(nameof(@mat2x2));
        //public static readonly type_specifier_nonarray_string @mat2x3 = new(nameof(@mat2x3));
        //public static readonly type_specifier_nonarray_string @mat2x4 = new(nameof(@mat2x4));
        //public static readonly type_specifier_nonarray_string @mat3x2 = new(nameof(@mat3x2));
        //public static readonly type_specifier_nonarray_string @mat3x3 = new(nameof(@mat3x3));
        //public static readonly type_specifier_nonarray_string @mat3x4 = new(nameof(@mat3x4));
        //public static readonly type_specifier_nonarray_string @mat4x2 = new(nameof(@mat4x2));
        //public static readonly type_specifier_nonarray_string @mat4x3 = new(nameof(@mat4x3));
        //public static readonly type_specifier_nonarray_string @mat4x4 = new(nameof(@mat4x4));
        //public static readonly type_specifier_nonarray_string @dmat2 = new(nameof(@dmat2));
        //public static readonly type_specifier_nonarray_string @dmat3 = new(nameof(@dmat3));
        //public static readonly type_specifier_nonarray_string @dmat4 = new(nameof(@dmat4));
        //public static readonly type_specifier_nonarray_string @dmat2x2 = new(nameof(@dmat2x2));
        //public static readonly type_specifier_nonarray_string @dmat2x3 = new(nameof(@dmat2x3));
        //public static readonly type_specifier_nonarray_string @dmat2x4 = new(nameof(@dmat2x4));
        //public static readonly type_specifier_nonarray_string @dmat3x2 = new(nameof(@dmat3x2));
        //public static readonly type_specifier_nonarray_string @dmat3x3 = new(nameof(@dmat3x3));
        //public static readonly type_specifier_nonarray_string @dmat3x4 = new(nameof(@dmat3x4));
        //public static readonly type_specifier_nonarray_string @dmat4x2 = new(nameof(@dmat4x2));
        //public static readonly type_specifier_nonarray_string @dmat4x3 = new(nameof(@dmat4x3));
        //public static readonly type_specifier_nonarray_string @dmat4x4 = new(nameof(@dmat4x4));
        //public static readonly type_specifier_nonarray_string @atomic_uint = new(nameof(@atomic_uint));
        //public static readonly type_specifier_nonarray_string @sampler1D = new(nameof(@sampler1D));
        //public static readonly type_specifier_nonarray_string @sampler2D = new(nameof(@sampler2D));
        //public static readonly type_specifier_nonarray_string @sampler3D = new(nameof(@sampler3D));
        //public static readonly type_specifier_nonarray_string @samplerCube = new(nameof(@samplerCube));
        //public static readonly type_specifier_nonarray_string @sampler1DShadow = new(nameof(@sampler1DShadow));
        //public static readonly type_specifier_nonarray_string @sampler2DShadow = new(nameof(@sampler2DShadow));
        //public static readonly type_specifier_nonarray_string @samplerCubeShadow = new(nameof(@samplerCubeShadow));
        //public static readonly type_specifier_nonarray_string @sampler1DArray = new(nameof(@sampler1DArray));
        //public static readonly type_specifier_nonarray_string @sampler2DArray = new(nameof(@sampler2DArray));
        //public static readonly type_specifier_nonarray_string @sampler1DArrayShadow = new(nameof(@sampler1DArrayShadow));
        //public static readonly type_specifier_nonarray_string @sampler2DArrayShadow = new(nameof(@sampler2DArrayShadow));
        //public static readonly type_specifier_nonarray_string @samplerCubeArray = new(nameof(@samplerCubeArray));
        //public static readonly type_specifier_nonarray_string @samplerCubeArrayShadow = new(nameof(@samplerCubeArrayShadow));
        //public static readonly type_specifier_nonarray_string @isampler1D = new(nameof(@isampler1D));
        //public static readonly type_specifier_nonarray_string @isampler2D = new(nameof(@isampler2D));
        //public static readonly type_specifier_nonarray_string @isampler3D = new(nameof(@isampler3D));
        //public static readonly type_specifier_nonarray_string @isamplerCube = new(nameof(@isamplerCube));
        //public static readonly type_specifier_nonarray_string @isampler1DArray = new(nameof(@isampler1DArray));
        //public static readonly type_specifier_nonarray_string @isampler2DArray = new(nameof(@isampler2DArray));
        //public static readonly type_specifier_nonarray_string @isamplerCubeArray = new(nameof(@isamplerCubeArray));
        //public static readonly type_specifier_nonarray_string @usampler1D = new(nameof(@usampler1D));
        //public static readonly type_specifier_nonarray_string @usampler2D = new(nameof(@usampler2D));
        //public static readonly type_specifier_nonarray_string @usampler3D = new(nameof(@usampler3D));
        //public static readonly type_specifier_nonarray_string @usamplerCube = new(nameof(@usamplerCube));
        //public static readonly type_specifier_nonarray_string @usampler1DArray = new(nameof(@usampler1DArray));
        //public static readonly type_specifier_nonarray_string @usampler2DArray = new(nameof(@usampler2DArray));
        //public static readonly type_specifier_nonarray_string @usamplerCubeArray = new(nameof(@usamplerCubeArray));
        //public static readonly type_specifier_nonarray_string @sampler2DRect = new(nameof(@sampler2DRect));
        //public static readonly type_specifier_nonarray_string @sampler2DRectShadow = new(nameof(@sampler2DRectShadow));
        //public static readonly type_specifier_nonarray_string @isampler2DRect = new(nameof(@isampler2DRect));
        //public static readonly type_specifier_nonarray_string @usampler2DRect = new(nameof(@usampler2DRect));
        //public static readonly type_specifier_nonarray_string @samplerBuffer = new(nameof(@samplerBuffer));
        //public static readonly type_specifier_nonarray_string @isamplerBuffer = new(nameof(@isamplerBuffer));
        //public static readonly type_specifier_nonarray_string @usamplerBuffer = new(nameof(@usamplerBuffer));
        //public static readonly type_specifier_nonarray_string @sampler2DMS = new(nameof(@sampler2DMS));
        //public static readonly type_specifier_nonarray_string @isampler2DMS = new(nameof(@isampler2DMS));
        //public static readonly type_specifier_nonarray_string @usampler2DMS = new(nameof(@usampler2DMS));
        //public static readonly type_specifier_nonarray_string @sampler2DMSArray = new(nameof(@sampler2DMSArray));
        //public static readonly type_specifier_nonarray_string @isampler2DMSArray = new(nameof(@isampler2DMSArray));
        //public static readonly type_specifier_nonarray_string @usampler2DMSArray = new(nameof(@usampler2DMSArray));
        //public static readonly type_specifier_nonarray_string @image1D = new(nameof(@image1D));
        //public static readonly type_specifier_nonarray_string @iimage1D = new(nameof(@iimage1D));
        //public static readonly type_specifier_nonarray_string @uimage1D = new(nameof(@uimage1D));
        //public static readonly type_specifier_nonarray_string @image2D = new(nameof(@image2D));
        //public static readonly type_specifier_nonarray_string @iimage2D = new(nameof(@iimage2D));
        //public static readonly type_specifier_nonarray_string @uimage2D = new(nameof(@uimage2D));
        //public static readonly type_specifier_nonarray_string @image3D = new(nameof(@image3D));
        //public static readonly type_specifier_nonarray_string @iimage3D = new(nameof(@iimage3D));
        //public static readonly type_specifier_nonarray_string @uimage3D = new(nameof(@uimage3D));
        //public static readonly type_specifier_nonarray_string @image2DRect = new(nameof(@image2DRect));
        //public static readonly type_specifier_nonarray_string @iimage2DRect = new(nameof(@iimage2DRect));
        //public static readonly type_specifier_nonarray_string @uimage2DRect = new(nameof(@uimage2DRect));
        //public static readonly type_specifier_nonarray_string @imageCube = new(nameof(@imageCube));
        //public static readonly type_specifier_nonarray_string @iimageCube = new(nameof(@iimageCube));
        //public static readonly type_specifier_nonarray_string @uimageCube = new(nameof(@uimageCube));
        //public static readonly type_specifier_nonarray_string @imageBuffer = new(nameof(@imageBuffer));
        //public static readonly type_specifier_nonarray_string @iimageBuffer = new(nameof(@iimageBuffer));
        //public static readonly type_specifier_nonarray_string @uimageBuffer = new(nameof(@uimageBuffer));
        //public static readonly type_specifier_nonarray_string @image1DArray = new(nameof(@image1DArray));
        //public static readonly type_specifier_nonarray_string @iimage1DArray = new(nameof(@iimage1DArray));
        //public static readonly type_specifier_nonarray_string @uimage1DArray = new(nameof(@uimage1DArray));
        //public static readonly type_specifier_nonarray_string @image2DArray = new(nameof(@image2DArray));
        //public static readonly type_specifier_nonarray_string @iimage2DArray = new(nameof(@iimage2DArray));
        //public static readonly type_specifier_nonarray_string @uimage2DArray = new(nameof(@uimage2DArray));
        //public static readonly type_specifier_nonarray_string @imageCubeArray = new(nameof(@imageCubeArray));
        //public static readonly type_specifier_nonarray_string @iimageCubeArray = new(nameof(@iimageCubeArray));
        //public static readonly type_specifier_nonarray_string @uimageCubeArray = new(nameof(@uimageCubeArray));
        //public static readonly type_specifier_nonarray_string @image2DMS = new(nameof(@image2DMS));
        //public static readonly type_specifier_nonarray_string @iimage2DMS = new(nameof(@iimage2DMS));
        //public static readonly type_specifier_nonarray_string @uimage2DMS = new(nameof(@uimage2DMS));
        //public static readonly type_specifier_nonarray_string @image2DMSArray = new(nameof(@image2DMSArray));
        //public static readonly type_specifier_nonarray_string @iimage2DMSArray = new(nameof(@iimage2DMSArray));
        //public static readonly type_specifier_nonarray_string @uimage2DMSArray = new(nameof(@uimage2DMSArray));

    }

    /// <summary>
    /// Correspond to the Vn node type_specifier_nonarray in the grammar(GLSL).
    /// </summary>
    abstract partial class Vntype_specifier_nonarray : IFullFormat {
        public abstract string GetTypeName();
        //public abstract void Format(TextWriter writer, FormatContext context);
        //public abstract IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);
        public abstract TokenRange Scope { get; }
        public abstract void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }
}

