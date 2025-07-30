using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    partial class CompilerPreDirective {
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
            /// 'inlineComment'
            /// </summary>
            public const int @inlineComment行 = 1; // "'inlineComment'"
            /// <summary>
            /// '#define'
            /// </summary>
            public const int @Pound符define = 2; // "'#define'"
            /// <summary>
            /// 'identifier'
            /// </summary>
            public const int @identifier = 3; // "'identifier'"
            /// <summary>
            /// '('
            /// </summary>
            public const int @LeftParenthesis符 = 4; // "'('"
            /// <summary>
            /// ')'
            /// </summary>
            public const int @RightParenthesis符 = 5; // "')'"
            /// <summary>
            /// '#undef'
            /// </summary>
            public const int @Pound符undef = 6; // "'#undef'"
            /// <summary>
            /// ','
            /// </summary>
            public const int @Comma符 = 7; // "','"
            /// <summary>
            /// 'intConstant'
            /// </summary>
            public const int @intConstant = 8; // "'intConstant'"
            /// <summary>
            /// 'uintConstant'
            /// </summary>
            public const int @uintConstant = 9; // "'uintConstant'"
            /// <summary>
            /// 'floatConstant'
            /// </summary>
            public const int @floatConstant = 10; // "'floatConstant'"
            /// <summary>
            /// 'boolConstant'
            /// </summary>
            public const int @boolConstant = 11; // "'boolConstant'"
            /// <summary>
            /// 'doubleConstant'
            /// </summary>
            public const int @doubleConstant = 12; // "'doubleConstant'"
            /// <summary>
            /// ';'
            /// </summary>
            public const int @Semicolon符 = 13; // "';'"
            /// <summary>
            /// '['
            /// </summary>
            public const int @LeftBracket符 = 14; // "'['"
            /// <summary>
            /// ']'
            /// </summary>
            public const int @RightBracket符 = 15; // "']'"
            /// <summary>
            /// '.'
            /// </summary>
            public const int @Dot符 = 16; // "'.'"
            /// <summary>
            /// '++'
            /// </summary>
            public const int @Plus符Plus符 = 17; // "'++'"
            /// <summary>
            /// '--'
            /// </summary>
            public const int @Dash符Dash符 = 18; // "'--'"
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
            /// '{'
            /// </summary>
            public const int @LeftBrace符 = 53; // "'{'"
            /// <summary>
            /// '}'
            /// </summary>
            public const int @RightBrace符 = 54; // "'}'"
            /// <summary>
            /// '##'
            /// </summary>
            public const int @Pound符Pound符 = 55; // "'##'"
            /// <summary>
            /// '#if'
            /// </summary>
            public const int @Pound符if = 56; // "'#if'"
            /// <summary>
            /// '#ifdef'
            /// </summary>
            public const int @Pound符ifdef = 57; // "'#ifdef'"
            /// <summary>
            /// '#ifndef'
            /// </summary>
            public const int @Pound符ifndef = 58; // "'#ifndef'"
            /// <summary>
            /// '#else'
            /// </summary>
            public const int @Pound符else = 59; // "'#else'"
            /// <summary>
            /// '#elif'
            /// </summary>
            public const int @Pound符elif = 60; // "'#elif'"
            /// <summary>
            /// '#endif'
            /// </summary>
            public const int @Pound符endif = 61; // "'#endif'"
            /// <summary>
            /// '#error'
            /// </summary>
            public const int @Pound符error = 62; // "'#error'"
            /// <summary>
            /// 'literalString'
            /// </summary>
            public const int @literalString = 63; // "'literalString'"
            /// <summary>
            /// '#pragma'
            /// </summary>
            public const int @Pound符pragma = 64; // "'#pragma'"
            /// <summary>
            /// '#extension'
            /// </summary>
            public const int @Pound符extension = 65; // "'#extension'"
            /// <summary>
            /// '#version'
            /// </summary>
            public const int @Pound符version = 66; // "'#version'"
            /// <summary>
            /// 'number'
            /// </summary>
            public const int @number = 67; // "'number'"
            /// <summary>
            /// '#line'
            /// </summary>
            public const int @Pound符line = 68; // "'#line'"
            /// <summary>
            /// 'defined'
            /// </summary>
            public const int @defined = 69; // "'defined'"

            /// <summary>
            /// kinds of ('¥' + user-defined Vt)
            /// </summary>
            public const int eVtKinds = 70;


            // Vn
            /// <summary>
            /// PreDirective
            /// </summary>
            public const int PreDirective枝 = 70; // "PreDirective"
            /// <summary>
            /// MicroDefinition
            /// </summary>
            public const int MicroDefinition枝 = 71; // "MicroDefinition"
            /// <summary>
            /// ParameterList
            /// </summary>
            public const int ParameterList枝 = 72; // "ParameterList"
            /// <summary>
            /// RandomTokens
            /// </summary>
            public const int RandomTokens枝 = 73; // "RandomTokens"
            /// <summary>
            /// RandomToken
            /// </summary>
            public const int RandomToken枝 = 74; // "RandomToken"
            /// <summary>
            /// ConditionalCompilation
            /// </summary>
            public const int ConditionalCompilation枝 = 75; // "ConditionalCompilation"
            /// <summary>
            /// IfGroup
            /// </summary>
            public const int IfGroup枝 = 76; // "IfGroup"
            /// <summary>
            /// ElseGroup
            /// </summary>
            public const int ElseGroup枝 = 77; // "ElseGroup"
            /// <summary>
            /// ElifGroup
            /// </summary>
            public const int ElifGroup枝 = 78; // "ElifGroup"
            /// <summary>
            /// EndifGroup
            /// </summary>
            public const int EndifGroup枝 = 79; // "EndifGroup"
            /// <summary>
            /// ErrorDirective
            /// </summary>
            public const int ErrorDirective枝 = 80; // "ErrorDirective"
            /// <summary>
            /// PragmaDirective
            /// </summary>
            public const int PragmaDirective枝 = 81; // "PragmaDirective"
            /// <summary>
            /// ExtensionDirective
            /// </summary>
            public const int ExtensionDirective枝 = 82; // "ExtensionDirective"
            /// <summary>
            /// VersionDirective
            /// </summary>
            public const int VersionDirective枝 = 83; // "VersionDirective"
            /// <summary>
            /// LineDirective
            /// </summary>
            public const int LineDirective枝 = 84; // "LineDirective"
            /// <summary>
            /// ConstExp
            /// </summary>
            public const int ConstExp枝 = 85; // "ConstExp"
            /// <summary>
            /// OrOrExp
            /// </summary>
            public const int OrOrExp枝 = 86; // "OrOrExp"
            /// <summary>
            /// AndAndExp
            /// </summary>
            public const int AndAndExp枝 = 87; // "AndAndExp"
            /// <summary>
            /// OrExp
            /// </summary>
            public const int OrExp枝 = 88; // "OrExp"
            /// <summary>
            /// XorExp
            /// </summary>
            public const int XorExp枝 = 89; // "XorExp"
            /// <summary>
            /// AndExp
            /// </summary>
            public const int AndExp枝 = 90; // "AndExp"
            /// <summary>
            /// EqualExp
            /// </summary>
            public const int EqualExp枝 = 91; // "EqualExp"
            /// <summary>
            /// RelationExp
            /// </summary>
            public const int RelationExp枝 = 92; // "RelationExp"
            /// <summary>
            /// ShiftExp
            /// </summary>
            public const int ShiftExp枝 = 93; // "ShiftExp"
            /// <summary>
            /// AddExp
            /// </summary>
            public const int AddExp枝 = 94; // "AddExp"
            /// <summary>
            /// MultiExp
            /// </summary>
            public const int MultiExp枝 = 95; // "MultiExp"
            /// <summary>
            /// UnaryExp
            /// </summary>
            public const int UnaryExp枝 = 96; // "UnaryExp"
            /// <summary>
            /// UnaryOp
            /// </summary>
            public const int UnaryOp枝 = 97; // "UnaryOp"
            /// <summary>
            /// PrimaryExp
            /// </summary>
            public const int PrimaryExp枝 = 98; // "PrimaryExp"

        }
    }
}
