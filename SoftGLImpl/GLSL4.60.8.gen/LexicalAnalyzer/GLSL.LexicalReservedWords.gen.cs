using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class CompilerGLSL {

        public static class reservedWord {
            /// <summary>
            /// ;
            /// </summary>
            public const string @Semicolon符 = ";";
            /// <summary>
            /// (
            /// </summary>
            public const string @LeftParenthesis符 = "(";
            /// <summary>
            /// )
            /// </summary>
            public const string @RightParenthesis符 = ")";
            /// <summary>
            /// [
            /// </summary>
            public const string @LeftBracket符 = "[";
            /// <summary>
            /// ]
            /// </summary>
            public const string @RightBracket符 = "]";
            /// <summary>
            /// .
            /// </summary>
            public const string @Dot符 = ".";
            /// <summary>
            /// ++
            /// </summary>
            public const string @Plus符Plus符 = "++";
            /// <summary>
            /// --
            /// </summary>
            public const string @Dash符Dash符 = "--";
            /// <summary>
            /// void
            /// </summary>
            public const string @void = "void";
            /// <summary>
            /// ,
            /// </summary>
            public const string @Comma符 = ",";
            /// <summary>
            /// +
            /// </summary>
            public const string @Plus符 = "+";
            /// <summary>
            /// -
            /// </summary>
            public const string @Dash符 = "-";
            /// <summary>
            /// !
            /// </summary>
            public const string @Bang符 = "!";
            /// <summary>
            /// ~
            /// </summary>
            public const string @Tilde符 = "~";
            /// <summary>
            /// *
            /// </summary>
            public const string @Asterisk符 = "*";
            /// <summary>
            /// /
            /// </summary>
            public const string @Slash符 = "/";
            /// <summary>
            /// %
            /// </summary>
            public const string @Percent符 = "%";
            /// <summary>
            /// <<
            /// </summary>
            public const string @LeftAngle符LeftAngle符 = "<<";
            /// <summary>
            /// >>
            /// </summary>
            public const string @RightAngle符RightAngle符 = ">>";
            /// <summary>
            /// <
            /// </summary>
            public const string @LeftAngle符 = "<";
            /// <summary>
            /// >
            /// </summary>
            public const string @RightAngle符 = ">";
            /// <summary>
            /// <=
            /// </summary>
            public const string @LeftAngle符Equal符 = "<=";
            /// <summary>
            /// >=
            /// </summary>
            public const string @RightAngle符Equal符 = ">=";
            /// <summary>
            /// ==
            /// </summary>
            public const string @Equal符Equal符 = "==";
            /// <summary>
            /// !=
            /// </summary>
            public const string @Bang符Equal符 = "!=";
            /// <summary>
            /// &
            /// </summary>
            public const string @And符 = "&";
            /// <summary>
            /// ^
            /// </summary>
            public const string @Caret符 = "^";
            /// <summary>
            /// |
            /// </summary>
            public const string @Pipe符 = "|";
            /// <summary>
            /// &&
            /// </summary>
            public const string @And符And符 = "&&";
            /// <summary>
            /// ^^
            /// </summary>
            public const string @Caret符Caret符 = "^^";
            /// <summary>
            /// ||
            /// </summary>
            public const string @Pipe符Pipe符 = "||";
            /// <summary>
            /// ?
            /// </summary>
            public const string @Question符 = "?";
            /// <summary>
            /// :
            /// </summary>
            public const string @Colon符 = ":";
            /// <summary>
            /// =
            /// </summary>
            public const string @Equal符 = "=";
            /// <summary>
            /// *=
            /// </summary>
            public const string @Asterisk符Equal符 = "*=";
            /// <summary>
            /// /=
            /// </summary>
            public const string @Slash符Equal符 = "/=";
            /// <summary>
            /// %=
            /// </summary>
            public const string @Percent符Equal符 = "%=";
            /// <summary>
            /// +=
            /// </summary>
            public const string @Plus符Equal符 = "+=";
            /// <summary>
            /// -=
            /// </summary>
            public const string @Dash符Equal符 = "-=";
            /// <summary>
            /// <<=
            /// </summary>
            public const string @LeftAngle符LeftAngle符Equal符 = "<<=";
            /// <summary>
            /// >>=
            /// </summary>
            public const string @RightAngle符RightAngle符Equal符 = ">>=";
            /// <summary>
            /// &=
            /// </summary>
            public const string @And符Equal符 = "&=";
            /// <summary>
            /// ^=
            /// </summary>
            public const string @Caret符Equal符 = "^=";
            /// <summary>
            /// |=
            /// </summary>
            public const string @Pipe符Equal符 = "|=";
            /// <summary>
            /// precision
            /// </summary>
            public const string @precision = "precision";
            /// <summary>
            /// {
            /// </summary>
            public const string @LeftBrace符 = "{";
            /// <summary>
            /// }
            /// </summary>
            public const string @RightBrace符 = "}";
            /// <summary>
            /// invariant
            /// </summary>
            public const string @invariant = "invariant";
            /// <summary>
            /// smooth
            /// </summary>
            public const string @smooth = "smooth";
            /// <summary>
            /// flat
            /// </summary>
            public const string @flat = "flat";
            /// <summary>
            /// noperspective
            /// </summary>
            public const string @noperspective = "noperspective";
            /// <summary>
            /// layout
            /// </summary>
            public const string @layout = "layout";
            /// <summary>
            /// shared
            /// </summary>
            public const string @shared = "shared";
            /// <summary>
            /// precise
            /// </summary>
            public const string @precise = "precise";
            /// <summary>
            /// const
            /// </summary>
            public const string @const = "const";
            /// <summary>
            /// in
            /// </summary>
            public const string @in = "in";
            /// <summary>
            /// out
            /// </summary>
            public const string @out = "out";
            /// <summary>
            /// inout
            /// </summary>
            public const string @inout = "inout";
            /// <summary>
            /// centroid
            /// </summary>
            public const string @centroid = "centroid";
            /// <summary>
            /// patch
            /// </summary>
            public const string @patch = "patch";
            /// <summary>
            /// sample
            /// </summary>
            public const string @sample = "sample";
            /// <summary>
            /// uniform
            /// </summary>
            public const string @uniform = "uniform";
            /// <summary>
            /// buffer
            /// </summary>
            public const string @buffer = "buffer";
            /// <summary>
            /// coherent
            /// </summary>
            public const string @coherent = "coherent";
            /// <summary>
            /// volatile
            /// </summary>
            public const string @volatile = "volatile";
            /// <summary>
            /// restrict
            /// </summary>
            public const string @restrict = "restrict";
            /// <summary>
            /// readonly
            /// </summary>
            public const string @readonly = "readonly";
            /// <summary>
            /// writeonly
            /// </summary>
            public const string @writeonly = "writeonly";
            /// <summary>
            /// subroutine
            /// </summary>
            public const string @subroutine = "subroutine";
            /// <summary>
            /// float
            /// </summary>
            public const string @float = "float";
            /// <summary>
            /// double
            /// </summary>
            public const string @double = "double";
            /// <summary>
            /// int
            /// </summary>
            public const string @int = "int";
            /// <summary>
            /// uint
            /// </summary>
            public const string @uint = "uint";
            /// <summary>
            /// bool
            /// </summary>
            public const string @bool = "bool";
            /// <summary>
            /// vec2
            /// </summary>
            public const string @vec2 = "vec2";
            /// <summary>
            /// vec3
            /// </summary>
            public const string @vec3 = "vec3";
            /// <summary>
            /// vec4
            /// </summary>
            public const string @vec4 = "vec4";
            /// <summary>
            /// dvec2
            /// </summary>
            public const string @dvec2 = "dvec2";
            /// <summary>
            /// dvec3
            /// </summary>
            public const string @dvec3 = "dvec3";
            /// <summary>
            /// dvec4
            /// </summary>
            public const string @dvec4 = "dvec4";
            /// <summary>
            /// bvec2
            /// </summary>
            public const string @bvec2 = "bvec2";
            /// <summary>
            /// bvec3
            /// </summary>
            public const string @bvec3 = "bvec3";
            /// <summary>
            /// bvec4
            /// </summary>
            public const string @bvec4 = "bvec4";
            /// <summary>
            /// ivec2
            /// </summary>
            public const string @ivec2 = "ivec2";
            /// <summary>
            /// ivec3
            /// </summary>
            public const string @ivec3 = "ivec3";
            /// <summary>
            /// ivec4
            /// </summary>
            public const string @ivec4 = "ivec4";
            /// <summary>
            /// uvec2
            /// </summary>
            public const string @uvec2 = "uvec2";
            /// <summary>
            /// uvec3
            /// </summary>
            public const string @uvec3 = "uvec3";
            /// <summary>
            /// uvec4
            /// </summary>
            public const string @uvec4 = "uvec4";
            /// <summary>
            /// mat2
            /// </summary>
            public const string @mat2 = "mat2";
            /// <summary>
            /// mat3
            /// </summary>
            public const string @mat3 = "mat3";
            /// <summary>
            /// mat4
            /// </summary>
            public const string @mat4 = "mat4";
            /// <summary>
            /// mat2x2
            /// </summary>
            public const string @mat2x2 = "mat2x2";
            /// <summary>
            /// mat2x3
            /// </summary>
            public const string @mat2x3 = "mat2x3";
            /// <summary>
            /// mat2x4
            /// </summary>
            public const string @mat2x4 = "mat2x4";
            /// <summary>
            /// mat3x2
            /// </summary>
            public const string @mat3x2 = "mat3x2";
            /// <summary>
            /// mat3x3
            /// </summary>
            public const string @mat3x3 = "mat3x3";
            /// <summary>
            /// mat3x4
            /// </summary>
            public const string @mat3x4 = "mat3x4";
            /// <summary>
            /// mat4x2
            /// </summary>
            public const string @mat4x2 = "mat4x2";
            /// <summary>
            /// mat4x3
            /// </summary>
            public const string @mat4x3 = "mat4x3";
            /// <summary>
            /// mat4x4
            /// </summary>
            public const string @mat4x4 = "mat4x4";
            /// <summary>
            /// dmat2
            /// </summary>
            public const string @dmat2 = "dmat2";
            /// <summary>
            /// dmat3
            /// </summary>
            public const string @dmat3 = "dmat3";
            /// <summary>
            /// dmat4
            /// </summary>
            public const string @dmat4 = "dmat4";
            /// <summary>
            /// dmat2x2
            /// </summary>
            public const string @dmat2x2 = "dmat2x2";
            /// <summary>
            /// dmat2x3
            /// </summary>
            public const string @dmat2x3 = "dmat2x3";
            /// <summary>
            /// dmat2x4
            /// </summary>
            public const string @dmat2x4 = "dmat2x4";
            /// <summary>
            /// dmat3x2
            /// </summary>
            public const string @dmat3x2 = "dmat3x2";
            /// <summary>
            /// dmat3x3
            /// </summary>
            public const string @dmat3x3 = "dmat3x3";
            /// <summary>
            /// dmat3x4
            /// </summary>
            public const string @dmat3x4 = "dmat3x4";
            /// <summary>
            /// dmat4x2
            /// </summary>
            public const string @dmat4x2 = "dmat4x2";
            /// <summary>
            /// dmat4x3
            /// </summary>
            public const string @dmat4x3 = "dmat4x3";
            /// <summary>
            /// dmat4x4
            /// </summary>
            public const string @dmat4x4 = "dmat4x4";
            /// <summary>
            /// atomic_uint
            /// </summary>
            public const string @atomic_uint = "atomic_uint";
            /// <summary>
            /// sampler2D
            /// </summary>
            public const string @sampler2D = "sampler2D";
            /// <summary>
            /// sampler3D
            /// </summary>
            public const string @sampler3D = "sampler3D";
            /// <summary>
            /// samplerCube
            /// </summary>
            public const string @samplerCube = "samplerCube";
            /// <summary>
            /// sampler2DShadow
            /// </summary>
            public const string @sampler2DShadow = "sampler2DShadow";
            /// <summary>
            /// samplerCubeShadow
            /// </summary>
            public const string @samplerCubeShadow = "samplerCubeShadow";
            /// <summary>
            /// sampler2DArray
            /// </summary>
            public const string @sampler2DArray = "sampler2DArray";
            /// <summary>
            /// sampler2DArrayShadow
            /// </summary>
            public const string @sampler2DArrayShadow = "sampler2DArrayShadow";
            /// <summary>
            /// samplerCubeArray
            /// </summary>
            public const string @samplerCubeArray = "samplerCubeArray";
            /// <summary>
            /// samplerCubeArrayShadow
            /// </summary>
            public const string @samplerCubeArrayShadow = "samplerCubeArrayShadow";
            /// <summary>
            /// isampler2D
            /// </summary>
            public const string @isampler2D = "isampler2D";
            /// <summary>
            /// isampler3D
            /// </summary>
            public const string @isampler3D = "isampler3D";
            /// <summary>
            /// isamplerCube
            /// </summary>
            public const string @isamplerCube = "isamplerCube";
            /// <summary>
            /// isampler2DArray
            /// </summary>
            public const string @isampler2DArray = "isampler2DArray";
            /// <summary>
            /// isamplerCubeArray
            /// </summary>
            public const string @isamplerCubeArray = "isamplerCubeArray";
            /// <summary>
            /// usampler2D
            /// </summary>
            public const string @usampler2D = "usampler2D";
            /// <summary>
            /// usampler3D
            /// </summary>
            public const string @usampler3D = "usampler3D";
            /// <summary>
            /// usamplerCube
            /// </summary>
            public const string @usamplerCube = "usamplerCube";
            /// <summary>
            /// usampler2DArray
            /// </summary>
            public const string @usampler2DArray = "usampler2DArray";
            /// <summary>
            /// usamplerCubeArray
            /// </summary>
            public const string @usamplerCubeArray = "usamplerCubeArray";
            /// <summary>
            /// sampler1D
            /// </summary>
            public const string @sampler1D = "sampler1D";
            /// <summary>
            /// sampler1DShadow
            /// </summary>
            public const string @sampler1DShadow = "sampler1DShadow";
            /// <summary>
            /// sampler1DArray
            /// </summary>
            public const string @sampler1DArray = "sampler1DArray";
            /// <summary>
            /// sampler1DArrayShadow
            /// </summary>
            public const string @sampler1DArrayShadow = "sampler1DArrayShadow";
            /// <summary>
            /// isampler1D
            /// </summary>
            public const string @isampler1D = "isampler1D";
            /// <summary>
            /// isampler1DArray
            /// </summary>
            public const string @isampler1DArray = "isampler1DArray";
            /// <summary>
            /// usampler1D
            /// </summary>
            public const string @usampler1D = "usampler1D";
            /// <summary>
            /// usampler1DArray
            /// </summary>
            public const string @usampler1DArray = "usampler1DArray";
            /// <summary>
            /// sampler2DRect
            /// </summary>
            public const string @sampler2DRect = "sampler2DRect";
            /// <summary>
            /// sampler2DRectShadow
            /// </summary>
            public const string @sampler2DRectShadow = "sampler2DRectShadow";
            /// <summary>
            /// isampler2DRect
            /// </summary>
            public const string @isampler2DRect = "isampler2DRect";
            /// <summary>
            /// usampler2DRect
            /// </summary>
            public const string @usampler2DRect = "usampler2DRect";
            /// <summary>
            /// samplerBuffer
            /// </summary>
            public const string @samplerBuffer = "samplerBuffer";
            /// <summary>
            /// isamplerBuffer
            /// </summary>
            public const string @isamplerBuffer = "isamplerBuffer";
            /// <summary>
            /// usamplerBuffer
            /// </summary>
            public const string @usamplerBuffer = "usamplerBuffer";
            /// <summary>
            /// sampler2DMS
            /// </summary>
            public const string @sampler2DMS = "sampler2DMS";
            /// <summary>
            /// isampler2DMS
            /// </summary>
            public const string @isampler2DMS = "isampler2DMS";
            /// <summary>
            /// usampler2DMS
            /// </summary>
            public const string @usampler2DMS = "usampler2DMS";
            /// <summary>
            /// sampler2DMSArray
            /// </summary>
            public const string @sampler2DMSArray = "sampler2DMSArray";
            /// <summary>
            /// isampler2DMSArray
            /// </summary>
            public const string @isampler2DMSArray = "isampler2DMSArray";
            /// <summary>
            /// usampler2DMSArray
            /// </summary>
            public const string @usampler2DMSArray = "usampler2DMSArray";
            /// <summary>
            /// image2D
            /// </summary>
            public const string @image2D = "image2D";
            /// <summary>
            /// iimage2D
            /// </summary>
            public const string @iimage2D = "iimage2D";
            /// <summary>
            /// uimage2D
            /// </summary>
            public const string @uimage2D = "uimage2D";
            /// <summary>
            /// image3D
            /// </summary>
            public const string @image3D = "image3D";
            /// <summary>
            /// iimage3D
            /// </summary>
            public const string @iimage3D = "iimage3D";
            /// <summary>
            /// uimage3D
            /// </summary>
            public const string @uimage3D = "uimage3D";
            /// <summary>
            /// imageCube
            /// </summary>
            public const string @imageCube = "imageCube";
            /// <summary>
            /// iimageCube
            /// </summary>
            public const string @iimageCube = "iimageCube";
            /// <summary>
            /// uimageCube
            /// </summary>
            public const string @uimageCube = "uimageCube";
            /// <summary>
            /// imageBuffer
            /// </summary>
            public const string @imageBuffer = "imageBuffer";
            /// <summary>
            /// iimageBuffer
            /// </summary>
            public const string @iimageBuffer = "iimageBuffer";
            /// <summary>
            /// uimageBuffer
            /// </summary>
            public const string @uimageBuffer = "uimageBuffer";
            /// <summary>
            /// image1D
            /// </summary>
            public const string @image1D = "image1D";
            /// <summary>
            /// iimage1D
            /// </summary>
            public const string @iimage1D = "iimage1D";
            /// <summary>
            /// uimage1D
            /// </summary>
            public const string @uimage1D = "uimage1D";
            /// <summary>
            /// image1DArray
            /// </summary>
            public const string @image1DArray = "image1DArray";
            /// <summary>
            /// iimage1DArray
            /// </summary>
            public const string @iimage1DArray = "iimage1DArray";
            /// <summary>
            /// uimage1DArray
            /// </summary>
            public const string @uimage1DArray = "uimage1DArray";
            /// <summary>
            /// image2DRect
            /// </summary>
            public const string @image2DRect = "image2DRect";
            /// <summary>
            /// iimage2DRect
            /// </summary>
            public const string @iimage2DRect = "iimage2DRect";
            /// <summary>
            /// uimage2DRect
            /// </summary>
            public const string @uimage2DRect = "uimage2DRect";
            /// <summary>
            /// image2DArray
            /// </summary>
            public const string @image2DArray = "image2DArray";
            /// <summary>
            /// iimage2DArray
            /// </summary>
            public const string @iimage2DArray = "iimage2DArray";
            /// <summary>
            /// uimage2DArray
            /// </summary>
            public const string @uimage2DArray = "uimage2DArray";
            /// <summary>
            /// imageCubeArray
            /// </summary>
            public const string @imageCubeArray = "imageCubeArray";
            /// <summary>
            /// iimageCubeArray
            /// </summary>
            public const string @iimageCubeArray = "iimageCubeArray";
            /// <summary>
            /// uimageCubeArray
            /// </summary>
            public const string @uimageCubeArray = "uimageCubeArray";
            /// <summary>
            /// image2DMS
            /// </summary>
            public const string @image2DMS = "image2DMS";
            /// <summary>
            /// iimage2DMS
            /// </summary>
            public const string @iimage2DMS = "iimage2DMS";
            /// <summary>
            /// uimage2DMS
            /// </summary>
            public const string @uimage2DMS = "uimage2DMS";
            /// <summary>
            /// image2DMSArray
            /// </summary>
            public const string @image2DMSArray = "image2DMSArray";
            /// <summary>
            /// iimage2DMSArray
            /// </summary>
            public const string @iimage2DMSArray = "iimage2DMSArray";
            /// <summary>
            /// uimage2DMSArray
            /// </summary>
            public const string @uimage2DMSArray = "uimage2DMSArray";
            /// <summary>
            /// highp
            /// </summary>
            public const string @highp = "highp";
            /// <summary>
            /// mediump
            /// </summary>
            public const string @mediump = "mediump";
            /// <summary>
            /// lowp
            /// </summary>
            public const string @lowp = "lowp";
            /// <summary>
            /// struct
            /// </summary>
            public const string @struct = "struct";
            /// <summary>
            /// if
            /// </summary>
            public const string @if = "if";
            /// <summary>
            /// else
            /// </summary>
            public const string @else = "else";
            /// <summary>
            /// switch
            /// </summary>
            public const string @switch = "switch";
            /// <summary>
            /// case
            /// </summary>
            public const string @case = "case";
            /// <summary>
            /// default
            /// </summary>
            public const string @default = "default";
            /// <summary>
            /// while
            /// </summary>
            public const string @while = "while";
            /// <summary>
            /// do
            /// </summary>
            public const string @do = "do";
            /// <summary>
            /// for
            /// </summary>
            public const string @for = "for";
            /// <summary>
            /// continue
            /// </summary>
            public const string @continue = "continue";
            /// <summary>
            /// break
            /// </summary>
            public const string @break = "break";
            /// <summary>
            /// return
            /// </summary>
            public const string @return = "return";
            /// <summary>
            /// discard
            /// </summary>
            public const string @discard = "discard";

        }

        /// <summary>
        /// if <paramref name="token"/> is a reserved word, assign correspond kind and return true.
        /// <para>otherwise, return false.</para>
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static bool CheckReservedWord(AnalyzingToken token) {
            bool isReservedWord = true;
            switch (token.value) {
            case reservedWord.@Semicolon符: token.kind = st.@Semicolon符; break;
            case reservedWord.@LeftParenthesis符: token.kind = st.@LeftParenthesis符; break;
            case reservedWord.@RightParenthesis符: token.kind = st.@RightParenthesis符; break;
            case reservedWord.@LeftBracket符: token.kind = st.@LeftBracket符; break;
            case reservedWord.@RightBracket符: token.kind = st.@RightBracket符; break;
            case reservedWord.@Dot符: token.kind = st.@Dot符; break;
            case reservedWord.@Plus符Plus符: token.kind = st.@Plus符Plus符; break;
            case reservedWord.@Dash符Dash符: token.kind = st.@Dash符Dash符; break;
            case reservedWord.@void: token.kind = st.@void; break;
            case reservedWord.@Comma符: token.kind = st.@Comma符; break;
            case reservedWord.@Plus符: token.kind = st.@Plus符; break;
            case reservedWord.@Dash符: token.kind = st.@Dash符; break;
            case reservedWord.@Bang符: token.kind = st.@Bang符; break;
            case reservedWord.@Tilde符: token.kind = st.@Tilde符; break;
            case reservedWord.@Asterisk符: token.kind = st.@Asterisk符; break;
            case reservedWord.@Slash符: token.kind = st.@Slash符; break;
            case reservedWord.@Percent符: token.kind = st.@Percent符; break;
            case reservedWord.@LeftAngle符LeftAngle符: token.kind = st.@LeftAngle符LeftAngle符; break;
            case reservedWord.@RightAngle符RightAngle符: token.kind = st.@RightAngle符RightAngle符; break;
            case reservedWord.@LeftAngle符: token.kind = st.@LeftAngle符; break;
            case reservedWord.@RightAngle符: token.kind = st.@RightAngle符; break;
            case reservedWord.@LeftAngle符Equal符: token.kind = st.@LeftAngle符Equal符; break;
            case reservedWord.@RightAngle符Equal符: token.kind = st.@RightAngle符Equal符; break;
            case reservedWord.@Equal符Equal符: token.kind = st.@Equal符Equal符; break;
            case reservedWord.@Bang符Equal符: token.kind = st.@Bang符Equal符; break;
            case reservedWord.@And符: token.kind = st.@And符; break;
            case reservedWord.@Caret符: token.kind = st.@Caret符; break;
            case reservedWord.@Pipe符: token.kind = st.@Pipe符; break;
            case reservedWord.@And符And符: token.kind = st.@And符And符; break;
            case reservedWord.@Caret符Caret符: token.kind = st.@Caret符Caret符; break;
            case reservedWord.@Pipe符Pipe符: token.kind = st.@Pipe符Pipe符; break;
            case reservedWord.@Question符: token.kind = st.@Question符; break;
            case reservedWord.@Colon符: token.kind = st.@Colon符; break;
            case reservedWord.@Equal符: token.kind = st.@Equal符; break;
            case reservedWord.@Asterisk符Equal符: token.kind = st.@Asterisk符Equal符; break;
            case reservedWord.@Slash符Equal符: token.kind = st.@Slash符Equal符; break;
            case reservedWord.@Percent符Equal符: token.kind = st.@Percent符Equal符; break;
            case reservedWord.@Plus符Equal符: token.kind = st.@Plus符Equal符; break;
            case reservedWord.@Dash符Equal符: token.kind = st.@Dash符Equal符; break;
            case reservedWord.@LeftAngle符LeftAngle符Equal符: token.kind = st.@LeftAngle符LeftAngle符Equal符; break;
            case reservedWord.@RightAngle符RightAngle符Equal符: token.kind = st.@RightAngle符RightAngle符Equal符; break;
            case reservedWord.@And符Equal符: token.kind = st.@And符Equal符; break;
            case reservedWord.@Caret符Equal符: token.kind = st.@Caret符Equal符; break;
            case reservedWord.@Pipe符Equal符: token.kind = st.@Pipe符Equal符; break;
            case reservedWord.@precision: token.kind = st.@precision; break;
            case reservedWord.@LeftBrace符: token.kind = st.@LeftBrace符; break;
            case reservedWord.@RightBrace符: token.kind = st.@RightBrace符; break;
            case reservedWord.@invariant: token.kind = st.@invariant; break;
            case reservedWord.@smooth: token.kind = st.@smooth; break;
            case reservedWord.@flat: token.kind = st.@flat; break;
            case reservedWord.@noperspective: token.kind = st.@noperspective; break;
            case reservedWord.@layout: token.kind = st.@layout; break;
            case reservedWord.@shared: token.kind = st.@shared; break;
            case reservedWord.@precise: token.kind = st.@precise; break;
            case reservedWord.@const: token.kind = st.@const; break;
            case reservedWord.@in: token.kind = st.@in; break;
            case reservedWord.@out: token.kind = st.@out; break;
            case reservedWord.@inout: token.kind = st.@inout; break;
            case reservedWord.@centroid: token.kind = st.@centroid; break;
            case reservedWord.@patch: token.kind = st.@patch; break;
            case reservedWord.@sample: token.kind = st.@sample; break;
            case reservedWord.@uniform: token.kind = st.@uniform; break;
            case reservedWord.@buffer: token.kind = st.@buffer; break;
            case reservedWord.@coherent: token.kind = st.@coherent; break;
            case reservedWord.@volatile: token.kind = st.@volatile; break;
            case reservedWord.@restrict: token.kind = st.@restrict; break;
            case reservedWord.@readonly: token.kind = st.@readonly; break;
            case reservedWord.@writeonly: token.kind = st.@writeonly; break;
            case reservedWord.@subroutine: token.kind = st.@subroutine; break;
            case reservedWord.@float: token.kind = st.@float; break;
            case reservedWord.@double: token.kind = st.@double; break;
            case reservedWord.@int: token.kind = st.@int; break;
            case reservedWord.@uint: token.kind = st.@uint; break;
            case reservedWord.@bool: token.kind = st.@bool; break;
            case reservedWord.@vec2: token.kind = st.@vec2; break;
            case reservedWord.@vec3: token.kind = st.@vec3; break;
            case reservedWord.@vec4: token.kind = st.@vec4; break;
            case reservedWord.@dvec2: token.kind = st.@dvec2; break;
            case reservedWord.@dvec3: token.kind = st.@dvec3; break;
            case reservedWord.@dvec4: token.kind = st.@dvec4; break;
            case reservedWord.@bvec2: token.kind = st.@bvec2; break;
            case reservedWord.@bvec3: token.kind = st.@bvec3; break;
            case reservedWord.@bvec4: token.kind = st.@bvec4; break;
            case reservedWord.@ivec2: token.kind = st.@ivec2; break;
            case reservedWord.@ivec3: token.kind = st.@ivec3; break;
            case reservedWord.@ivec4: token.kind = st.@ivec4; break;
            case reservedWord.@uvec2: token.kind = st.@uvec2; break;
            case reservedWord.@uvec3: token.kind = st.@uvec3; break;
            case reservedWord.@uvec4: token.kind = st.@uvec4; break;
            case reservedWord.@mat2: token.kind = st.@mat2; break;
            case reservedWord.@mat3: token.kind = st.@mat3; break;
            case reservedWord.@mat4: token.kind = st.@mat4; break;
            case reservedWord.@mat2x2: token.kind = st.@mat2x2; break;
            case reservedWord.@mat2x3: token.kind = st.@mat2x3; break;
            case reservedWord.@mat2x4: token.kind = st.@mat2x4; break;
            case reservedWord.@mat3x2: token.kind = st.@mat3x2; break;
            case reservedWord.@mat3x3: token.kind = st.@mat3x3; break;
            case reservedWord.@mat3x4: token.kind = st.@mat3x4; break;
            case reservedWord.@mat4x2: token.kind = st.@mat4x2; break;
            case reservedWord.@mat4x3: token.kind = st.@mat4x3; break;
            case reservedWord.@mat4x4: token.kind = st.@mat4x4; break;
            case reservedWord.@dmat2: token.kind = st.@dmat2; break;
            case reservedWord.@dmat3: token.kind = st.@dmat3; break;
            case reservedWord.@dmat4: token.kind = st.@dmat4; break;
            case reservedWord.@dmat2x2: token.kind = st.@dmat2x2; break;
            case reservedWord.@dmat2x3: token.kind = st.@dmat2x3; break;
            case reservedWord.@dmat2x4: token.kind = st.@dmat2x4; break;
            case reservedWord.@dmat3x2: token.kind = st.@dmat3x2; break;
            case reservedWord.@dmat3x3: token.kind = st.@dmat3x3; break;
            case reservedWord.@dmat3x4: token.kind = st.@dmat3x4; break;
            case reservedWord.@dmat4x2: token.kind = st.@dmat4x2; break;
            case reservedWord.@dmat4x3: token.kind = st.@dmat4x3; break;
            case reservedWord.@dmat4x4: token.kind = st.@dmat4x4; break;
            case reservedWord.@atomic_uint: token.kind = st.@atomic_uint; break;
            case reservedWord.@sampler2D: token.kind = st.@sampler2D; break;
            case reservedWord.@sampler3D: token.kind = st.@sampler3D; break;
            case reservedWord.@samplerCube: token.kind = st.@samplerCube; break;
            case reservedWord.@sampler2DShadow: token.kind = st.@sampler2DShadow; break;
            case reservedWord.@samplerCubeShadow: token.kind = st.@samplerCubeShadow; break;
            case reservedWord.@sampler2DArray: token.kind = st.@sampler2DArray; break;
            case reservedWord.@sampler2DArrayShadow: token.kind = st.@sampler2DArrayShadow; break;
            case reservedWord.@samplerCubeArray: token.kind = st.@samplerCubeArray; break;
            case reservedWord.@samplerCubeArrayShadow: token.kind = st.@samplerCubeArrayShadow; break;
            case reservedWord.@isampler2D: token.kind = st.@isampler2D; break;
            case reservedWord.@isampler3D: token.kind = st.@isampler3D; break;
            case reservedWord.@isamplerCube: token.kind = st.@isamplerCube; break;
            case reservedWord.@isampler2DArray: token.kind = st.@isampler2DArray; break;
            case reservedWord.@isamplerCubeArray: token.kind = st.@isamplerCubeArray; break;
            case reservedWord.@usampler2D: token.kind = st.@usampler2D; break;
            case reservedWord.@usampler3D: token.kind = st.@usampler3D; break;
            case reservedWord.@usamplerCube: token.kind = st.@usamplerCube; break;
            case reservedWord.@usampler2DArray: token.kind = st.@usampler2DArray; break;
            case reservedWord.@usamplerCubeArray: token.kind = st.@usamplerCubeArray; break;
            case reservedWord.@sampler1D: token.kind = st.@sampler1D; break;
            case reservedWord.@sampler1DShadow: token.kind = st.@sampler1DShadow; break;
            case reservedWord.@sampler1DArray: token.kind = st.@sampler1DArray; break;
            case reservedWord.@sampler1DArrayShadow: token.kind = st.@sampler1DArrayShadow; break;
            case reservedWord.@isampler1D: token.kind = st.@isampler1D; break;
            case reservedWord.@isampler1DArray: token.kind = st.@isampler1DArray; break;
            case reservedWord.@usampler1D: token.kind = st.@usampler1D; break;
            case reservedWord.@usampler1DArray: token.kind = st.@usampler1DArray; break;
            case reservedWord.@sampler2DRect: token.kind = st.@sampler2DRect; break;
            case reservedWord.@sampler2DRectShadow: token.kind = st.@sampler2DRectShadow; break;
            case reservedWord.@isampler2DRect: token.kind = st.@isampler2DRect; break;
            case reservedWord.@usampler2DRect: token.kind = st.@usampler2DRect; break;
            case reservedWord.@samplerBuffer: token.kind = st.@samplerBuffer; break;
            case reservedWord.@isamplerBuffer: token.kind = st.@isamplerBuffer; break;
            case reservedWord.@usamplerBuffer: token.kind = st.@usamplerBuffer; break;
            case reservedWord.@sampler2DMS: token.kind = st.@sampler2DMS; break;
            case reservedWord.@isampler2DMS: token.kind = st.@isampler2DMS; break;
            case reservedWord.@usampler2DMS: token.kind = st.@usampler2DMS; break;
            case reservedWord.@sampler2DMSArray: token.kind = st.@sampler2DMSArray; break;
            case reservedWord.@isampler2DMSArray: token.kind = st.@isampler2DMSArray; break;
            case reservedWord.@usampler2DMSArray: token.kind = st.@usampler2DMSArray; break;
            case reservedWord.@image2D: token.kind = st.@image2D; break;
            case reservedWord.@iimage2D: token.kind = st.@iimage2D; break;
            case reservedWord.@uimage2D: token.kind = st.@uimage2D; break;
            case reservedWord.@image3D: token.kind = st.@image3D; break;
            case reservedWord.@iimage3D: token.kind = st.@iimage3D; break;
            case reservedWord.@uimage3D: token.kind = st.@uimage3D; break;
            case reservedWord.@imageCube: token.kind = st.@imageCube; break;
            case reservedWord.@iimageCube: token.kind = st.@iimageCube; break;
            case reservedWord.@uimageCube: token.kind = st.@uimageCube; break;
            case reservedWord.@imageBuffer: token.kind = st.@imageBuffer; break;
            case reservedWord.@iimageBuffer: token.kind = st.@iimageBuffer; break;
            case reservedWord.@uimageBuffer: token.kind = st.@uimageBuffer; break;
            case reservedWord.@image1D: token.kind = st.@image1D; break;
            case reservedWord.@iimage1D: token.kind = st.@iimage1D; break;
            case reservedWord.@uimage1D: token.kind = st.@uimage1D; break;
            case reservedWord.@image1DArray: token.kind = st.@image1DArray; break;
            case reservedWord.@iimage1DArray: token.kind = st.@iimage1DArray; break;
            case reservedWord.@uimage1DArray: token.kind = st.@uimage1DArray; break;
            case reservedWord.@image2DRect: token.kind = st.@image2DRect; break;
            case reservedWord.@iimage2DRect: token.kind = st.@iimage2DRect; break;
            case reservedWord.@uimage2DRect: token.kind = st.@uimage2DRect; break;
            case reservedWord.@image2DArray: token.kind = st.@image2DArray; break;
            case reservedWord.@iimage2DArray: token.kind = st.@iimage2DArray; break;
            case reservedWord.@uimage2DArray: token.kind = st.@uimage2DArray; break;
            case reservedWord.@imageCubeArray: token.kind = st.@imageCubeArray; break;
            case reservedWord.@iimageCubeArray: token.kind = st.@iimageCubeArray; break;
            case reservedWord.@uimageCubeArray: token.kind = st.@uimageCubeArray; break;
            case reservedWord.@image2DMS: token.kind = st.@image2DMS; break;
            case reservedWord.@iimage2DMS: token.kind = st.@iimage2DMS; break;
            case reservedWord.@uimage2DMS: token.kind = st.@uimage2DMS; break;
            case reservedWord.@image2DMSArray: token.kind = st.@image2DMSArray; break;
            case reservedWord.@iimage2DMSArray: token.kind = st.@iimage2DMSArray; break;
            case reservedWord.@uimage2DMSArray: token.kind = st.@uimage2DMSArray; break;
            case reservedWord.@highp: token.kind = st.@highp; break;
            case reservedWord.@mediump: token.kind = st.@mediump; break;
            case reservedWord.@lowp: token.kind = st.@lowp; break;
            case reservedWord.@struct: token.kind = st.@struct; break;
            case reservedWord.@if: token.kind = st.@if; break;
            case reservedWord.@else: token.kind = st.@else; break;
            case reservedWord.@switch: token.kind = st.@switch; break;
            case reservedWord.@case: token.kind = st.@case; break;
            case reservedWord.@default: token.kind = st.@default; break;
            case reservedWord.@while: token.kind = st.@while; break;
            case reservedWord.@do: token.kind = st.@do; break;
            case reservedWord.@for: token.kind = st.@for; break;
            case reservedWord.@continue: token.kind = st.@continue; break;
            case reservedWord.@break: token.kind = st.@break; break;
            case reservedWord.@return: token.kind = st.@return; break;
            case reservedWord.@discard: token.kind = st.@discard; break;

            default: isReservedWord = false; break;
            }

            return isReservedWord;
        }
    }
}
