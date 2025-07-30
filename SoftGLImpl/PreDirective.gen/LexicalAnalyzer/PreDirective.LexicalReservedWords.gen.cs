using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    partial class CompilerPreDirective {

        public static class reservedWord {
            /// <summary>
            /// #define
            /// </summary>
            public const string @Pound符define = "#define";
            /// <summary>
            /// (
            /// </summary>
            public const string @LeftParenthesis符 = "(";
            /// <summary>
            /// )
            /// </summary>
            public const string @RightParenthesis符 = ")";
            /// <summary>
            /// #undef
            /// </summary>
            public const string @Pound符undef = "#undef";
            /// <summary>
            /// ,
            /// </summary>
            public const string @Comma符 = ",";
            /// <summary>
            /// ;
            /// </summary>
            public const string @Semicolon符 = ";";
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
            /// {
            /// </summary>
            public const string @LeftBrace符 = "{";
            /// <summary>
            /// }
            /// </summary>
            public const string @RightBrace符 = "}";
            /// <summary>
            /// ##
            /// </summary>
            public const string @Pound符Pound符 = "##";
            /// <summary>
            /// #if
            /// </summary>
            public const string @Pound符if = "#if";
            /// <summary>
            /// #ifdef
            /// </summary>
            public const string @Pound符ifdef = "#ifdef";
            /// <summary>
            /// #ifndef
            /// </summary>
            public const string @Pound符ifndef = "#ifndef";
            /// <summary>
            /// #else
            /// </summary>
            public const string @Pound符else = "#else";
            /// <summary>
            /// #elif
            /// </summary>
            public const string @Pound符elif = "#elif";
            /// <summary>
            /// #endif
            /// </summary>
            public const string @Pound符endif = "#endif";
            /// <summary>
            /// #error
            /// </summary>
            public const string @Pound符error = "#error";
            /// <summary>
            /// #pragma
            /// </summary>
            public const string @Pound符pragma = "#pragma";
            /// <summary>
            /// #extension
            /// </summary>
            public const string @Pound符extension = "#extension";
            /// <summary>
            /// #version
            /// </summary>
            public const string @Pound符version = "#version";
            /// <summary>
            /// #line
            /// </summary>
            public const string @Pound符line = "#line";
            /// <summary>
            /// defined
            /// </summary>
            public const string @defined = "defined";

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
            case reservedWord.@Pound符define: token.kind = st.@Pound符define; break;
            case reservedWord.@LeftParenthesis符: token.kind = st.@LeftParenthesis符; break;
            case reservedWord.@RightParenthesis符: token.kind = st.@RightParenthesis符; break;
            case reservedWord.@Pound符undef: token.kind = st.@Pound符undef; break;
            case reservedWord.@Comma符: token.kind = st.@Comma符; break;
            case reservedWord.@Semicolon符: token.kind = st.@Semicolon符; break;
            case reservedWord.@LeftBracket符: token.kind = st.@LeftBracket符; break;
            case reservedWord.@RightBracket符: token.kind = st.@RightBracket符; break;
            case reservedWord.@Dot符: token.kind = st.@Dot符; break;
            case reservedWord.@Plus符Plus符: token.kind = st.@Plus符Plus符; break;
            case reservedWord.@Dash符Dash符: token.kind = st.@Dash符Dash符; break;
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
            case reservedWord.@LeftBrace符: token.kind = st.@LeftBrace符; break;
            case reservedWord.@RightBrace符: token.kind = st.@RightBrace符; break;
            case reservedWord.@Pound符Pound符: token.kind = st.@Pound符Pound符; break;
            case reservedWord.@Pound符if: token.kind = st.@Pound符if; break;
            case reservedWord.@Pound符ifdef: token.kind = st.@Pound符ifdef; break;
            case reservedWord.@Pound符ifndef: token.kind = st.@Pound符ifndef; break;
            case reservedWord.@Pound符else: token.kind = st.@Pound符else; break;
            case reservedWord.@Pound符elif: token.kind = st.@Pound符elif; break;
            case reservedWord.@Pound符endif: token.kind = st.@Pound符endif; break;
            case reservedWord.@Pound符error: token.kind = st.@Pound符error; break;
            case reservedWord.@Pound符pragma: token.kind = st.@Pound符pragma; break;
            case reservedWord.@Pound符extension: token.kind = st.@Pound符extension; break;
            case reservedWord.@Pound符version: token.kind = st.@Pound符version; break;
            case reservedWord.@Pound符line: token.kind = st.@Pound符line; break;
            case reservedWord.@defined: token.kind = st.@defined; break;

            default: isReservedWord = false; break;
            }

            return isReservedWord;
        }
    }
}
