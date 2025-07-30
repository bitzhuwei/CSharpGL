using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class CompilerGLSL {
        /// <summary>
        /// Vt types are used both for lexical-analyze and syntax-parse.
        /// <para>Vn types are only for syntax-parse.</para>
        /// <para>Vt is quoted in ''.</para>
        /// <para>Vn is not quoted in ''.</para>
        /// </summary>
        public static class st {
            // Vt
            /// <summary>
            /// Something wrong within the source code.
            /// </summary>
            public const int Error错 = -1; // "'×'";

            /// <summary>
            /// '¥'
            /// </summary>
            public const int @终 = 0; // "'¥'"

            /// <summary>
            /// 'blockComment'
            /// </summary>
            public const int @blockComment块 = 1; // "'blockComment'"
            /// <summary>
            /// 'inlineComment'
            /// </summary>
            public const int @inlineComment行 = 2; // "'inlineComment'"
            /// <summary>
            /// ';'
            /// </summary>
            public const int @Semicolon符 = 3; // "';'"
            /// <summary>
            /// 'identifier'
            /// </summary>
            public const int @identifier = 4; // "'identifier'"
            /// <summary>
            /// 'intConstant'
            /// </summary>
            public const int @intConstant = 5; // "'intConstant'"
            /// <summary>
            /// 'uintConstant'
            /// </summary>
            public const int @uintConstant = 6; // "'uintConstant'"
            /// <summary>
            /// 'floatConstant'
            /// </summary>
            public const int @floatConstant = 7; // "'floatConstant'"
            /// <summary>
            /// 'boolConstant'
            /// </summary>
            public const int @boolConstant = 8; // "'boolConstant'"
            /// <summary>
            /// 'doubleConstant'
            /// </summary>
            public const int @doubleConstant = 9; // "'doubleConstant'"
            /// <summary>
            /// '('
            /// </summary>
            public const int @LeftParenthesis符 = 10; // "'('"
            /// <summary>
            /// ')'
            /// </summary>
            public const int @RightParenthesis符 = 11; // "')'"
            /// <summary>
            /// '['
            /// </summary>
            public const int @LeftBracket符 = 12; // "'['"
            /// <summary>
            /// ']'
            /// </summary>
            public const int @RightBracket符 = 13; // "']'"
            /// <summary>
            /// '.'
            /// </summary>
            public const int @Dot符 = 14; // "'.'"
            /// <summary>
            /// '++'
            /// </summary>
            public const int @Plus符Plus符 = 15; // "'++'"
            /// <summary>
            /// '--'
            /// </summary>
            public const int @Dash符Dash符 = 16; // "'--'"
            /// <summary>
            /// 'void'
            /// </summary>
            public const int @void = 17; // "'void'"
            /// <summary>
            /// ','
            /// </summary>
            public const int @Comma符 = 18; // "','"
            /// <summary>
            /// '+'
            /// </summary>
            public const int @Plus符 = 19; // "'+'"
            /// <summary>
            /// '-'
            /// </summary>
            public const int @Dash符 = 20; // "'-'"
            /// <summary>
            /// '!'
            /// </summary>
            public const int @Bang符 = 21; // "'!'"
            /// <summary>
            /// '~'
            /// </summary>
            public const int @Tilde符 = 22; // "'~'"
            /// <summary>
            /// '*'
            /// </summary>
            public const int @Asterisk符 = 23; // "'*'"
            /// <summary>
            /// '/'
            /// </summary>
            public const int @Slash符 = 24; // "'/'"
            /// <summary>
            /// '%'
            /// </summary>
            public const int @Percent符 = 25; // "'%'"
            /// <summary>
            /// '<<'
            /// </summary>
            public const int @LeftAngle符LeftAngle符 = 26; // "'<<'"
            /// <summary>
            /// '>>'
            /// </summary>
            public const int @RightAngle符RightAngle符 = 27; // "'>>'"
            /// <summary>
            /// '<'
            /// </summary>
            public const int @LeftAngle符 = 28; // "'<'"
            /// <summary>
            /// '>'
            /// </summary>
            public const int @RightAngle符 = 29; // "'>'"
            /// <summary>
            /// '<='
            /// </summary>
            public const int @LeftAngle符Equal符 = 30; // "'<='"
            /// <summary>
            /// '>='
            /// </summary>
            public const int @RightAngle符Equal符 = 31; // "'>='"
            /// <summary>
            /// '=='
            /// </summary>
            public const int @Equal符Equal符 = 32; // "'=='"
            /// <summary>
            /// '!='
            /// </summary>
            public const int @Bang符Equal符 = 33; // "'!='"
            /// <summary>
            /// '&'
            /// </summary>
            public const int @And符 = 34; // "'&'"
            /// <summary>
            /// '^'
            /// </summary>
            public const int @Caret符 = 35; // "'^'"
            /// <summary>
            /// '|'
            /// </summary>
            public const int @Pipe符 = 36; // "'|'"
            /// <summary>
            /// '&&'
            /// </summary>
            public const int @And符And符 = 37; // "'&&'"
            /// <summary>
            /// '^^'
            /// </summary>
            public const int @Caret符Caret符 = 38; // "'^^'"
            /// <summary>
            /// '||'
            /// </summary>
            public const int @Pipe符Pipe符 = 39; // "'||'"
            /// <summary>
            /// '?'
            /// </summary>
            public const int @Question符 = 40; // "'?'"
            /// <summary>
            /// ':'
            /// </summary>
            public const int @Colon符 = 41; // "':'"
            /// <summary>
            /// '='
            /// </summary>
            public const int @Equal符 = 42; // "'='"
            /// <summary>
            /// '*='
            /// </summary>
            public const int @Asterisk符Equal符 = 43; // "'*='"
            /// <summary>
            /// '/='
            /// </summary>
            public const int @Slash符Equal符 = 44; // "'/='"
            /// <summary>
            /// '%='
            /// </summary>
            public const int @Percent符Equal符 = 45; // "'%='"
            /// <summary>
            /// '+='
            /// </summary>
            public const int @Plus符Equal符 = 46; // "'+='"
            /// <summary>
            /// '-='
            /// </summary>
            public const int @Dash符Equal符 = 47; // "'-='"
            /// <summary>
            /// '<<='
            /// </summary>
            public const int @LeftAngle符LeftAngle符Equal符 = 48; // "'<<='"
            /// <summary>
            /// '>>='
            /// </summary>
            public const int @RightAngle符RightAngle符Equal符 = 49; // "'>>='"
            /// <summary>
            /// '&='
            /// </summary>
            public const int @And符Equal符 = 50; // "'&='"
            /// <summary>
            /// '^='
            /// </summary>
            public const int @Caret符Equal符 = 51; // "'^='"
            /// <summary>
            /// '|='
            /// </summary>
            public const int @Pipe符Equal符 = 52; // "'|='"
            /// <summary>
            /// 'precision'
            /// </summary>
            public const int @precision = 53; // "'precision'"
            /// <summary>
            /// '{'
            /// </summary>
            public const int @LeftBrace符 = 54; // "'{'"
            /// <summary>
            /// '}'
            /// </summary>
            public const int @RightBrace符 = 55; // "'}'"
            /// <summary>
            /// 'invariant'
            /// </summary>
            public const int @invariant = 56; // "'invariant'"
            /// <summary>
            /// 'smooth'
            /// </summary>
            public const int @smooth = 57; // "'smooth'"
            /// <summary>
            /// 'flat'
            /// </summary>
            public const int @flat = 58; // "'flat'"
            /// <summary>
            /// 'noperspective'
            /// </summary>
            public const int @noperspective = 59; // "'noperspective'"
            /// <summary>
            /// 'layout'
            /// </summary>
            public const int @layout = 60; // "'layout'"
            /// <summary>
            /// 'shared'
            /// </summary>
            public const int @shared = 61; // "'shared'"
            /// <summary>
            /// 'precise'
            /// </summary>
            public const int @precise = 62; // "'precise'"
            /// <summary>
            /// 'const'
            /// </summary>
            public const int @const = 63; // "'const'"
            /// <summary>
            /// 'in'
            /// </summary>
            public const int @in = 64; // "'in'"
            /// <summary>
            /// 'out'
            /// </summary>
            public const int @out = 65; // "'out'"
            /// <summary>
            /// 'inout'
            /// </summary>
            public const int @inout = 66; // "'inout'"
            /// <summary>
            /// 'centroid'
            /// </summary>
            public const int @centroid = 67; // "'centroid'"
            /// <summary>
            /// 'patch'
            /// </summary>
            public const int @patch = 68; // "'patch'"
            /// <summary>
            /// 'sample'
            /// </summary>
            public const int @sample = 69; // "'sample'"
            /// <summary>
            /// 'uniform'
            /// </summary>
            public const int @uniform = 70; // "'uniform'"
            /// <summary>
            /// 'buffer'
            /// </summary>
            public const int @buffer = 71; // "'buffer'"
            /// <summary>
            /// 'coherent'
            /// </summary>
            public const int @coherent = 72; // "'coherent'"
            /// <summary>
            /// 'volatile'
            /// </summary>
            public const int @volatile = 73; // "'volatile'"
            /// <summary>
            /// 'restrict'
            /// </summary>
            public const int @restrict = 74; // "'restrict'"
            /// <summary>
            /// 'readonly'
            /// </summary>
            public const int @readonly = 75; // "'readonly'"
            /// <summary>
            /// 'writeonly'
            /// </summary>
            public const int @writeonly = 76; // "'writeonly'"
            /// <summary>
            /// 'subroutine'
            /// </summary>
            public const int @subroutine = 77; // "'subroutine'"
            /// <summary>
            /// 'type_name'
            /// </summary>
            public const int @type_name = 78; // "'type_name'"
            /// <summary>
            /// 'float'
            /// </summary>
            public const int @float = 79; // "'float'"
            /// <summary>
            /// 'double'
            /// </summary>
            public const int @double = 80; // "'double'"
            /// <summary>
            /// 'int'
            /// </summary>
            public const int @int = 81; // "'int'"
            /// <summary>
            /// 'uint'
            /// </summary>
            public const int @uint = 82; // "'uint'"
            /// <summary>
            /// 'bool'
            /// </summary>
            public const int @bool = 83; // "'bool'"
            /// <summary>
            /// 'vec2'
            /// </summary>
            public const int @vec2 = 84; // "'vec2'"
            /// <summary>
            /// 'vec3'
            /// </summary>
            public const int @vec3 = 85; // "'vec3'"
            /// <summary>
            /// 'vec4'
            /// </summary>
            public const int @vec4 = 86; // "'vec4'"
            /// <summary>
            /// 'dvec2'
            /// </summary>
            public const int @dvec2 = 87; // "'dvec2'"
            /// <summary>
            /// 'dvec3'
            /// </summary>
            public const int @dvec3 = 88; // "'dvec3'"
            /// <summary>
            /// 'dvec4'
            /// </summary>
            public const int @dvec4 = 89; // "'dvec4'"
            /// <summary>
            /// 'bvec2'
            /// </summary>
            public const int @bvec2 = 90; // "'bvec2'"
            /// <summary>
            /// 'bvec3'
            /// </summary>
            public const int @bvec3 = 91; // "'bvec3'"
            /// <summary>
            /// 'bvec4'
            /// </summary>
            public const int @bvec4 = 92; // "'bvec4'"
            /// <summary>
            /// 'ivec2'
            /// </summary>
            public const int @ivec2 = 93; // "'ivec2'"
            /// <summary>
            /// 'ivec3'
            /// </summary>
            public const int @ivec3 = 94; // "'ivec3'"
            /// <summary>
            /// 'ivec4'
            /// </summary>
            public const int @ivec4 = 95; // "'ivec4'"
            /// <summary>
            /// 'uvec2'
            /// </summary>
            public const int @uvec2 = 96; // "'uvec2'"
            /// <summary>
            /// 'uvec3'
            /// </summary>
            public const int @uvec3 = 97; // "'uvec3'"
            /// <summary>
            /// 'uvec4'
            /// </summary>
            public const int @uvec4 = 98; // "'uvec4'"
            /// <summary>
            /// 'mat2'
            /// </summary>
            public const int @mat2 = 99; // "'mat2'"
            /// <summary>
            /// 'mat3'
            /// </summary>
            public const int @mat3 = 100; // "'mat3'"
            /// <summary>
            /// 'mat4'
            /// </summary>
            public const int @mat4 = 101; // "'mat4'"
            /// <summary>
            /// 'mat2x2'
            /// </summary>
            public const int @mat2x2 = 102; // "'mat2x2'"
            /// <summary>
            /// 'mat2x3'
            /// </summary>
            public const int @mat2x3 = 103; // "'mat2x3'"
            /// <summary>
            /// 'mat2x4'
            /// </summary>
            public const int @mat2x4 = 104; // "'mat2x4'"
            /// <summary>
            /// 'mat3x2'
            /// </summary>
            public const int @mat3x2 = 105; // "'mat3x2'"
            /// <summary>
            /// 'mat3x3'
            /// </summary>
            public const int @mat3x3 = 106; // "'mat3x3'"
            /// <summary>
            /// 'mat3x4'
            /// </summary>
            public const int @mat3x4 = 107; // "'mat3x4'"
            /// <summary>
            /// 'mat4x2'
            /// </summary>
            public const int @mat4x2 = 108; // "'mat4x2'"
            /// <summary>
            /// 'mat4x3'
            /// </summary>
            public const int @mat4x3 = 109; // "'mat4x3'"
            /// <summary>
            /// 'mat4x4'
            /// </summary>
            public const int @mat4x4 = 110; // "'mat4x4'"
            /// <summary>
            /// 'dmat2'
            /// </summary>
            public const int @dmat2 = 111; // "'dmat2'"
            /// <summary>
            /// 'dmat3'
            /// </summary>
            public const int @dmat3 = 112; // "'dmat3'"
            /// <summary>
            /// 'dmat4'
            /// </summary>
            public const int @dmat4 = 113; // "'dmat4'"
            /// <summary>
            /// 'dmat2x2'
            /// </summary>
            public const int @dmat2x2 = 114; // "'dmat2x2'"
            /// <summary>
            /// 'dmat2x3'
            /// </summary>
            public const int @dmat2x3 = 115; // "'dmat2x3'"
            /// <summary>
            /// 'dmat2x4'
            /// </summary>
            public const int @dmat2x4 = 116; // "'dmat2x4'"
            /// <summary>
            /// 'dmat3x2'
            /// </summary>
            public const int @dmat3x2 = 117; // "'dmat3x2'"
            /// <summary>
            /// 'dmat3x3'
            /// </summary>
            public const int @dmat3x3 = 118; // "'dmat3x3'"
            /// <summary>
            /// 'dmat3x4'
            /// </summary>
            public const int @dmat3x4 = 119; // "'dmat3x4'"
            /// <summary>
            /// 'dmat4x2'
            /// </summary>
            public const int @dmat4x2 = 120; // "'dmat4x2'"
            /// <summary>
            /// 'dmat4x3'
            /// </summary>
            public const int @dmat4x3 = 121; // "'dmat4x3'"
            /// <summary>
            /// 'dmat4x4'
            /// </summary>
            public const int @dmat4x4 = 122; // "'dmat4x4'"
            /// <summary>
            /// 'atomic_uint'
            /// </summary>
            public const int @atomic_uint = 123; // "'atomic_uint'"
            /// <summary>
            /// 'sampler2D'
            /// </summary>
            public const int @sampler2D = 124; // "'sampler2D'"
            /// <summary>
            /// 'sampler3D'
            /// </summary>
            public const int @sampler3D = 125; // "'sampler3D'"
            /// <summary>
            /// 'samplerCube'
            /// </summary>
            public const int @samplerCube = 126; // "'samplerCube'"
            /// <summary>
            /// 'sampler2DShadow'
            /// </summary>
            public const int @sampler2DShadow = 127; // "'sampler2DShadow'"
            /// <summary>
            /// 'samplerCubeShadow'
            /// </summary>
            public const int @samplerCubeShadow = 128; // "'samplerCubeShadow'"
            /// <summary>
            /// 'sampler2DArray'
            /// </summary>
            public const int @sampler2DArray = 129; // "'sampler2DArray'"
            /// <summary>
            /// 'sampler2DArrayShadow'
            /// </summary>
            public const int @sampler2DArrayShadow = 130; // "'sampler2DArrayShadow'"
            /// <summary>
            /// 'samplerCubeArray'
            /// </summary>
            public const int @samplerCubeArray = 131; // "'samplerCubeArray'"
            /// <summary>
            /// 'samplerCubeArrayShadow'
            /// </summary>
            public const int @samplerCubeArrayShadow = 132; // "'samplerCubeArrayShadow'"
            /// <summary>
            /// 'isampler2D'
            /// </summary>
            public const int @isampler2D = 133; // "'isampler2D'"
            /// <summary>
            /// 'isampler3D'
            /// </summary>
            public const int @isampler3D = 134; // "'isampler3D'"
            /// <summary>
            /// 'isamplerCube'
            /// </summary>
            public const int @isamplerCube = 135; // "'isamplerCube'"
            /// <summary>
            /// 'isampler2DArray'
            /// </summary>
            public const int @isampler2DArray = 136; // "'isampler2DArray'"
            /// <summary>
            /// 'isamplerCubeArray'
            /// </summary>
            public const int @isamplerCubeArray = 137; // "'isamplerCubeArray'"
            /// <summary>
            /// 'usampler2D'
            /// </summary>
            public const int @usampler2D = 138; // "'usampler2D'"
            /// <summary>
            /// 'usampler3D'
            /// </summary>
            public const int @usampler3D = 139; // "'usampler3D'"
            /// <summary>
            /// 'usamplerCube'
            /// </summary>
            public const int @usamplerCube = 140; // "'usamplerCube'"
            /// <summary>
            /// 'usampler2DArray'
            /// </summary>
            public const int @usampler2DArray = 141; // "'usampler2DArray'"
            /// <summary>
            /// 'usamplerCubeArray'
            /// </summary>
            public const int @usamplerCubeArray = 142; // "'usamplerCubeArray'"
            /// <summary>
            /// 'sampler1D'
            /// </summary>
            public const int @sampler1D = 143; // "'sampler1D'"
            /// <summary>
            /// 'sampler1DShadow'
            /// </summary>
            public const int @sampler1DShadow = 144; // "'sampler1DShadow'"
            /// <summary>
            /// 'sampler1DArray'
            /// </summary>
            public const int @sampler1DArray = 145; // "'sampler1DArray'"
            /// <summary>
            /// 'sampler1DArrayShadow'
            /// </summary>
            public const int @sampler1DArrayShadow = 146; // "'sampler1DArrayShadow'"
            /// <summary>
            /// 'isampler1D'
            /// </summary>
            public const int @isampler1D = 147; // "'isampler1D'"
            /// <summary>
            /// 'isampler1DArray'
            /// </summary>
            public const int @isampler1DArray = 148; // "'isampler1DArray'"
            /// <summary>
            /// 'usampler1D'
            /// </summary>
            public const int @usampler1D = 149; // "'usampler1D'"
            /// <summary>
            /// 'usampler1DArray'
            /// </summary>
            public const int @usampler1DArray = 150; // "'usampler1DArray'"
            /// <summary>
            /// 'sampler2DRect'
            /// </summary>
            public const int @sampler2DRect = 151; // "'sampler2DRect'"
            /// <summary>
            /// 'sampler2DRectShadow'
            /// </summary>
            public const int @sampler2DRectShadow = 152; // "'sampler2DRectShadow'"
            /// <summary>
            /// 'isampler2DRect'
            /// </summary>
            public const int @isampler2DRect = 153; // "'isampler2DRect'"
            /// <summary>
            /// 'usampler2DRect'
            /// </summary>
            public const int @usampler2DRect = 154; // "'usampler2DRect'"
            /// <summary>
            /// 'samplerBuffer'
            /// </summary>
            public const int @samplerBuffer = 155; // "'samplerBuffer'"
            /// <summary>
            /// 'isamplerBuffer'
            /// </summary>
            public const int @isamplerBuffer = 156; // "'isamplerBuffer'"
            /// <summary>
            /// 'usamplerBuffer'
            /// </summary>
            public const int @usamplerBuffer = 157; // "'usamplerBuffer'"
            /// <summary>
            /// 'sampler2DMS'
            /// </summary>
            public const int @sampler2DMS = 158; // "'sampler2DMS'"
            /// <summary>
            /// 'isampler2DMS'
            /// </summary>
            public const int @isampler2DMS = 159; // "'isampler2DMS'"
            /// <summary>
            /// 'usampler2DMS'
            /// </summary>
            public const int @usampler2DMS = 160; // "'usampler2DMS'"
            /// <summary>
            /// 'sampler2DMSArray'
            /// </summary>
            public const int @sampler2DMSArray = 161; // "'sampler2DMSArray'"
            /// <summary>
            /// 'isampler2DMSArray'
            /// </summary>
            public const int @isampler2DMSArray = 162; // "'isampler2DMSArray'"
            /// <summary>
            /// 'usampler2DMSArray'
            /// </summary>
            public const int @usampler2DMSArray = 163; // "'usampler2DMSArray'"
            /// <summary>
            /// 'image2D'
            /// </summary>
            public const int @image2D = 164; // "'image2D'"
            /// <summary>
            /// 'iimage2D'
            /// </summary>
            public const int @iimage2D = 165; // "'iimage2D'"
            /// <summary>
            /// 'uimage2D'
            /// </summary>
            public const int @uimage2D = 166; // "'uimage2D'"
            /// <summary>
            /// 'image3D'
            /// </summary>
            public const int @image3D = 167; // "'image3D'"
            /// <summary>
            /// 'iimage3D'
            /// </summary>
            public const int @iimage3D = 168; // "'iimage3D'"
            /// <summary>
            /// 'uimage3D'
            /// </summary>
            public const int @uimage3D = 169; // "'uimage3D'"
            /// <summary>
            /// 'imageCube'
            /// </summary>
            public const int @imageCube = 170; // "'imageCube'"
            /// <summary>
            /// 'iimageCube'
            /// </summary>
            public const int @iimageCube = 171; // "'iimageCube'"
            /// <summary>
            /// 'uimageCube'
            /// </summary>
            public const int @uimageCube = 172; // "'uimageCube'"
            /// <summary>
            /// 'imageBuffer'
            /// </summary>
            public const int @imageBuffer = 173; // "'imageBuffer'"
            /// <summary>
            /// 'iimageBuffer'
            /// </summary>
            public const int @iimageBuffer = 174; // "'iimageBuffer'"
            /// <summary>
            /// 'uimageBuffer'
            /// </summary>
            public const int @uimageBuffer = 175; // "'uimageBuffer'"
            /// <summary>
            /// 'image1D'
            /// </summary>
            public const int @image1D = 176; // "'image1D'"
            /// <summary>
            /// 'iimage1D'
            /// </summary>
            public const int @iimage1D = 177; // "'iimage1D'"
            /// <summary>
            /// 'uimage1D'
            /// </summary>
            public const int @uimage1D = 178; // "'uimage1D'"
            /// <summary>
            /// 'image1DArray'
            /// </summary>
            public const int @image1DArray = 179; // "'image1DArray'"
            /// <summary>
            /// 'iimage1DArray'
            /// </summary>
            public const int @iimage1DArray = 180; // "'iimage1DArray'"
            /// <summary>
            /// 'uimage1DArray'
            /// </summary>
            public const int @uimage1DArray = 181; // "'uimage1DArray'"
            /// <summary>
            /// 'image2DRect'
            /// </summary>
            public const int @image2DRect = 182; // "'image2DRect'"
            /// <summary>
            /// 'iimage2DRect'
            /// </summary>
            public const int @iimage2DRect = 183; // "'iimage2DRect'"
            /// <summary>
            /// 'uimage2DRect'
            /// </summary>
            public const int @uimage2DRect = 184; // "'uimage2DRect'"
            /// <summary>
            /// 'image2DArray'
            /// </summary>
            public const int @image2DArray = 185; // "'image2DArray'"
            /// <summary>
            /// 'iimage2DArray'
            /// </summary>
            public const int @iimage2DArray = 186; // "'iimage2DArray'"
            /// <summary>
            /// 'uimage2DArray'
            /// </summary>
            public const int @uimage2DArray = 187; // "'uimage2DArray'"
            /// <summary>
            /// 'imageCubeArray'
            /// </summary>
            public const int @imageCubeArray = 188; // "'imageCubeArray'"
            /// <summary>
            /// 'iimageCubeArray'
            /// </summary>
            public const int @iimageCubeArray = 189; // "'iimageCubeArray'"
            /// <summary>
            /// 'uimageCubeArray'
            /// </summary>
            public const int @uimageCubeArray = 190; // "'uimageCubeArray'"
            /// <summary>
            /// 'image2DMS'
            /// </summary>
            public const int @image2DMS = 191; // "'image2DMS'"
            /// <summary>
            /// 'iimage2DMS'
            /// </summary>
            public const int @iimage2DMS = 192; // "'iimage2DMS'"
            /// <summary>
            /// 'uimage2DMS'
            /// </summary>
            public const int @uimage2DMS = 193; // "'uimage2DMS'"
            /// <summary>
            /// 'image2DMSArray'
            /// </summary>
            public const int @image2DMSArray = 194; // "'image2DMSArray'"
            /// <summary>
            /// 'iimage2DMSArray'
            /// </summary>
            public const int @iimage2DMSArray = 195; // "'iimage2DMSArray'"
            /// <summary>
            /// 'uimage2DMSArray'
            /// </summary>
            public const int @uimage2DMSArray = 196; // "'uimage2DMSArray'"
            /// <summary>
            /// 'highp'
            /// </summary>
            public const int @highp = 197; // "'highp'"
            /// <summary>
            /// 'mediump'
            /// </summary>
            public const int @mediump = 198; // "'mediump'"
            /// <summary>
            /// 'lowp'
            /// </summary>
            public const int @lowp = 199; // "'lowp'"
            /// <summary>
            /// 'struct'
            /// </summary>
            public const int @struct = 200; // "'struct'"
            /// <summary>
            /// 'if'
            /// </summary>
            public const int @if = 201; // "'if'"
            /// <summary>
            /// 'else'
            /// </summary>
            public const int @else = 202; // "'else'"
            /// <summary>
            /// 'switch'
            /// </summary>
            public const int @switch = 203; // "'switch'"
            /// <summary>
            /// 'case'
            /// </summary>
            public const int @case = 204; // "'case'"
            /// <summary>
            /// 'default'
            /// </summary>
            public const int @default = 205; // "'default'"
            /// <summary>
            /// 'while'
            /// </summary>
            public const int @while = 206; // "'while'"
            /// <summary>
            /// 'do'
            /// </summary>
            public const int @do = 207; // "'do'"
            /// <summary>
            /// 'for'
            /// </summary>
            public const int @for = 208; // "'for'"
            /// <summary>
            /// 'continue'
            /// </summary>
            public const int @continue = 209; // "'continue'"
            /// <summary>
            /// 'break'
            /// </summary>
            public const int @break = 210; // "'break'"
            /// <summary>
            /// 'return'
            /// </summary>
            public const int @return = 211; // "'return'"
            /// <summary>
            /// 'discard'
            /// </summary>
            public const int @discard = 212; // "'discard'"

            /// <summary>
            /// kinds of ('¥' + user-defined Vt)
            /// </summary>
            public const int eVtKinds = 213;


            // Vn
            /// <summary>
            /// translation_unit
            /// </summary>
            public const int translation_unit枝 = 213; // "translation_unit"
            /// <summary>
            /// external_declaration
            /// </summary>
            public const int external_declaration枝 = 214; // "external_declaration"
            /// <summary>
            /// function_definition
            /// </summary>
            public const int function_definition枝 = 215; // "function_definition"
            /// <summary>
            /// variable_identifier
            /// </summary>
            public const int variable_identifier枝 = 216; // "variable_identifier"
            /// <summary>
            /// primary_expression
            /// </summary>
            public const int primary_expression枝 = 217; // "primary_expression"
            /// <summary>
            /// postfix_expression
            /// </summary>
            public const int postfix_expression枝 = 218; // "postfix_expression"
            /// <summary>
            /// integer_expression
            /// </summary>
            public const int integer_expression枝 = 219; // "integer_expression"
            /// <summary>
            /// function_call
            /// </summary>
            public const int function_call枝 = 220; // "function_call"
            /// <summary>
            /// function_call_or_method
            /// </summary>
            public const int function_call_or_method枝 = 221; // "function_call_or_method"
            /// <summary>
            /// function_call_generic
            /// </summary>
            public const int function_call_generic枝 = 222; // "function_call_generic"
            /// <summary>
            /// function_call_header_no_parameters
            /// </summary>
            public const int function_call_header_no_parameters枝 = 223; // "function_call_header_no_parameters"
            /// <summary>
            /// function_call_header_with_parameters
            /// </summary>
            public const int function_call_header_with_parameters枝 = 224; // "function_call_header_with_parameters"
            /// <summary>
            /// function_call_header
            /// </summary>
            public const int function_call_header枝 = 225; // "function_call_header"
            /// <summary>
            /// function_identifier
            /// </summary>
            public const int function_identifier枝 = 226; // "function_identifier"
            /// <summary>
            /// unary_expression
            /// </summary>
            public const int unary_expression枝 = 227; // "unary_expression"
            /// <summary>
            /// unary_operator
            /// </summary>
            public const int unary_operator枝 = 228; // "unary_operator"
            /// <summary>
            /// multiplicative_expression
            /// </summary>
            public const int multiplicative_expression枝 = 229; // "multiplicative_expression"
            /// <summary>
            /// additive_expression
            /// </summary>
            public const int additive_expression枝 = 230; // "additive_expression"
            /// <summary>
            /// shift_expression
            /// </summary>
            public const int shift_expression枝 = 231; // "shift_expression"
            /// <summary>
            /// relational_expression
            /// </summary>
            public const int relational_expression枝 = 232; // "relational_expression"
            /// <summary>
            /// equality_expression
            /// </summary>
            public const int equality_expression枝 = 233; // "equality_expression"
            /// <summary>
            /// and_expression
            /// </summary>
            public const int and_expression枝 = 234; // "and_expression"
            /// <summary>
            /// exclusive_or_expression
            /// </summary>
            public const int exclusive_or_expression枝 = 235; // "exclusive_or_expression"
            /// <summary>
            /// inclusive_or_expression
            /// </summary>
            public const int inclusive_or_expression枝 = 236; // "inclusive_or_expression"
            /// <summary>
            /// logical_and_expression
            /// </summary>
            public const int logical_and_expression枝 = 237; // "logical_and_expression"
            /// <summary>
            /// logical_xor_expression
            /// </summary>
            public const int logical_xor_expression枝 = 238; // "logical_xor_expression"
            /// <summary>
            /// logical_or_expression
            /// </summary>
            public const int logical_or_expression枝 = 239; // "logical_or_expression"
            /// <summary>
            /// conditional_expression
            /// </summary>
            public const int conditional_expression枝 = 240; // "conditional_expression"
            /// <summary>
            /// assignment_expression
            /// </summary>
            public const int assignment_expression枝 = 241; // "assignment_expression"
            /// <summary>
            /// assignment_operator
            /// </summary>
            public const int assignment_operator枝 = 242; // "assignment_operator"
            /// <summary>
            /// expression
            /// </summary>
            public const int expression枝 = 243; // "expression"
            /// <summary>
            /// constant_expression
            /// </summary>
            public const int constant_expression枝 = 244; // "constant_expression"
            /// <summary>
            /// declaration
            /// </summary>
            public const int declaration枝 = 245; // "declaration"
            /// <summary>
            /// identifier_list
            /// </summary>
            public const int identifier_list枝 = 246; // "identifier_list"
            /// <summary>
            /// function_prototype
            /// </summary>
            public const int function_prototype枝 = 247; // "function_prototype"
            /// <summary>
            /// function_declarator
            /// </summary>
            public const int function_declarator枝 = 248; // "function_declarator"
            /// <summary>
            /// function_header_with_parameters
            /// </summary>
            public const int function_header_with_parameters枝 = 249; // "function_header_with_parameters"
            /// <summary>
            /// function_header
            /// </summary>
            public const int function_header枝 = 250; // "function_header"
            /// <summary>
            /// parameter_declarator
            /// </summary>
            public const int parameter_declarator枝 = 251; // "parameter_declarator"
            /// <summary>
            /// parameter_declaration
            /// </summary>
            public const int parameter_declaration枝 = 252; // "parameter_declaration"
            /// <summary>
            /// parameter_type_specifier
            /// </summary>
            public const int parameter_type_specifier枝 = 253; // "parameter_type_specifier"
            /// <summary>
            /// init_declarator_list
            /// </summary>
            public const int init_declarator_list枝 = 254; // "init_declarator_list"
            /// <summary>
            /// single_declaration
            /// </summary>
            public const int single_declaration枝 = 255; // "single_declaration"
            /// <summary>
            /// fully_specified_type
            /// </summary>
            public const int fully_specified_type枝 = 256; // "fully_specified_type"
            /// <summary>
            /// invariant_qualifier
            /// </summary>
            public const int invariant_qualifier枝 = 257; // "invariant_qualifier"
            /// <summary>
            /// interpolation_qualifier
            /// </summary>
            public const int interpolation_qualifier枝 = 258; // "interpolation_qualifier"
            /// <summary>
            /// layout_qualifier
            /// </summary>
            public const int layout_qualifier枝 = 259; // "layout_qualifier"
            /// <summary>
            /// layout_qualifier_id_list
            /// </summary>
            public const int layout_qualifier_id_list枝 = 260; // "layout_qualifier_id_list"
            /// <summary>
            /// layout_qualifier_id
            /// </summary>
            public const int layout_qualifier_id枝 = 261; // "layout_qualifier_id"
            /// <summary>
            /// precise_qualifier
            /// </summary>
            public const int precise_qualifier枝 = 262; // "precise_qualifier"
            /// <summary>
            /// type_qualifier
            /// </summary>
            public const int type_qualifier枝 = 263; // "type_qualifier"
            /// <summary>
            /// single_type_qualifier
            /// </summary>
            public const int single_type_qualifier枝 = 264; // "single_type_qualifier"
            /// <summary>
            /// storage_qualifier
            /// </summary>
            public const int storage_qualifier枝 = 265; // "storage_qualifier"
            /// <summary>
            /// type_name_list
            /// </summary>
            public const int type_name_list枝 = 266; // "type_name_list"
            /// <summary>
            /// type_specifier
            /// </summary>
            public const int type_specifier枝 = 267; // "type_specifier"
            /// <summary>
            /// array_specifier
            /// </summary>
            public const int array_specifier枝 = 268; // "array_specifier"
            /// <summary>
            /// type_specifier_nonarray
            /// </summary>
            public const int type_specifier_nonarray枝 = 269; // "type_specifier_nonarray"
            /// <summary>
            /// precision_qualifier
            /// </summary>
            public const int precision_qualifier枝 = 270; // "precision_qualifier"
            /// <summary>
            /// struct_specifier
            /// </summary>
            public const int struct_specifier枝 = 271; // "struct_specifier"
            /// <summary>
            /// struct_declaration_list
            /// </summary>
            public const int struct_declaration_list枝 = 272; // "struct_declaration_list"
            /// <summary>
            /// struct_declaration
            /// </summary>
            public const int struct_declaration枝 = 273; // "struct_declaration"
            /// <summary>
            /// struct_declarator_list
            /// </summary>
            public const int struct_declarator_list枝 = 274; // "struct_declarator_list"
            /// <summary>
            /// struct_declarator
            /// </summary>
            public const int struct_declarator枝 = 275; // "struct_declarator"
            /// <summary>
            /// initializer
            /// </summary>
            public const int initializer枝 = 276; // "initializer"
            /// <summary>
            /// initializer_list
            /// </summary>
            public const int initializer_list枝 = 277; // "initializer_list"
            /// <summary>
            /// declaration_statement
            /// </summary>
            public const int declaration_statement枝 = 278; // "declaration_statement"
            /// <summary>
            /// statement
            /// </summary>
            public const int statement枝 = 279; // "statement"
            /// <summary>
            /// simple_statement
            /// </summary>
            public const int simple_statement枝 = 280; // "simple_statement"
            /// <summary>
            /// compound_statement
            /// </summary>
            public const int compound_statement枝 = 281; // "compound_statement"
            /// <summary>
            /// statement_list
            /// </summary>
            public const int statement_list枝 = 282; // "statement_list"
            /// <summary>
            /// expression_statement
            /// </summary>
            public const int expression_statement枝 = 283; // "expression_statement"
            /// <summary>
            /// selection_statement
            /// </summary>
            public const int selection_statement枝 = 284; // "selection_statement"
            /// <summary>
            /// selection_rest_statement
            /// </summary>
            public const int selection_rest_statement枝 = 285; // "selection_rest_statement"
            /// <summary>
            /// condition
            /// </summary>
            public const int condition枝 = 286; // "condition"
            /// <summary>
            /// switch_statement
            /// </summary>
            public const int switch_statement枝 = 287; // "switch_statement"
            /// <summary>
            /// switch_statement_list
            /// </summary>
            public const int switch_statement_list枝 = 288; // "switch_statement_list"
            /// <summary>
            /// case_label
            /// </summary>
            public const int case_label枝 = 289; // "case_label"
            /// <summary>
            /// iteration_statement
            /// </summary>
            public const int iteration_statement枝 = 290; // "iteration_statement"
            /// <summary>
            /// for_init_statement
            /// </summary>
            public const int for_init_statement枝 = 291; // "for_init_statement"
            /// <summary>
            /// conditionopt
            /// </summary>
            public const int conditionopt枝 = 292; // "conditionopt"
            /// <summary>
            /// for_rest_statement
            /// </summary>
            public const int for_rest_statement枝 = 293; // "for_rest_statement"
            /// <summary>
            /// jump_statement
            /// </summary>
            public const int jump_statement枝 = 294; // "jump_statement"

        }
    }
}
