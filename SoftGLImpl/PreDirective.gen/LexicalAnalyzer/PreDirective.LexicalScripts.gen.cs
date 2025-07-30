using System;
using System.Collections.Generic;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    partial class CompilerPreDirective {
        // currentChar => true
        /// <summary>
        /// currentChar =&gt; true
        /// </summary>
        //private static readonly Func<char, bool> acceptAll = currentChar => true;

        ///// <summary>
        ///// this is where post-regex starts.
        ///// </summary>
        ///// <param name="Vt"></param>
        ///// <param name="context"></param>
        //private static void EnterPostRegex(LexicalContext context) {
        //    if (context.tokenEnd.index >= context.cursor.index) { throw new Exception("post-regex overlaps with regex!"); }
        //    context.tokenEnd = context.previousCursor;
        //}

        /// <summary>
        /// this is where new <see cref="Token"/> starts.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private static void BeginToken(LexicalContext context) {
            if (context.analyzingToken.kind != Token.Kinds.NotYet) {
                context.analyzingToken.Reset(index: context.result.Count, start: context.cursor);
            }
        }

        /// <summary>
        /// extend value of current token(<see cref="LexicalContext.analyzingToken"/>)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Vt"></param>
        private static void ExtendToken(LexicalContext context, int Vt) {
            context.analyzingToken.ends[Vt] = context.cursor;
        }
        /// <summary>
        /// extend value of current token(<see cref="LexicalContext.analyzingToken"/>)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Vts"></param>
        private static void ExtendToken2(LexicalContext context, params int[] Vts) {
            for (int i = 0; i < Vts.Length; i++) {
                var Vt = Vts[i];
                context.analyzingToken.ends[Vt] = context.cursor;
            }
        }

        /// <summary>
        /// extend value of current token(<see cref="LexicalContext.analyzingToken"/>)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ifVts"></param>
        private static void ExtendToken3(LexicalContext context, params IfVt[] ifVts) {
            /*if (context.marker.InRegex)*/
            for (int i = 0; i < ifVts.Length; i++) {
                var Vt = ifVts[i].Vt;
                context.analyzingToken.ends[Vt] = context.cursor;
            }
        }

        /// <summary>
        /// accept current <see cref="Token"/>(<see cref="LexicalContext.analyzingToken"/>)
        /// <para>set <see cref="Token.type"/> and neutralize the last LexicalContext.MoveForward()</para>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Vt"></param>
        private static void AcceptToken(LexicalContext context, int Vt) {
            var startIndex = context.analyzingToken.start.index;
            var end = context.analyzingToken.ends[Vt];
            context.analyzingToken.value = context.sourceCode.Substring(
                startIndex, end.index - startIndex + 1);
            //var typeSet = CheckReservedWord(context.analyzingToken);
            //if (!typeSet) { context.analyzingToken.type = VtType; }
            context.analyzingToken.kind = Vt;

            // cancel forward steps for post-regex
            var backStep = context.cursor.index - end.index;
            if (backStep > 0) { context.MoveBack(backStep); }
            // next operation: LexicalContext.MoveForward();

            var token = context.analyzingToken.Dump(
#if DEBUG
                context.stArray,
#endif
                end);
            context.result.Add(token);
            // 跳过单行注释 skip inline comment
            if (context.analyzingToken.kind != st.inlineComment行) {
                context.lastSyntaxValidToken = token;
            }
            if (token.kind == st.Error错) {
                context.result.token2ErrorInfo.Add(token,
                    new TokenErrorInfo(token, "token type unrecognized!"));
            }
        }
        /// <summary>
        /// accept current <see cref="Token"/>(<see cref="LexicalContext.analyzingToken"/>)
        /// <para>set <see cref="Token.type"/> and neutralize the last LexicalContext.MoveForward()</para>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Vts"></param>
        private static void AcceptToken2(LexicalContext context, params int[] Vts) {
            AcceptToken(context, Vts[0]);
        }
        /// <summary>
        /// accept current <see cref="Token"/>(<see cref="LexicalContext.analyzingToken"/>)
        /// <para>set <see cref="Token.type"/> and neutralize the last LexicalContext.MoveForward()</para>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ifVts"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void AcceptToken3(LexicalContext context, params IfVt[] ifVts) {
            var typeSet = false;
            //var typeSet = CheckReservedWord(context.analyzingToken);
            //if (!typeSet) {
            //}
            int lastType = st.@终;
            if (context.lastSyntaxValidToken != null) {
                lastType = context.lastSyntaxValidToken.kind;
            }
            for (var i = 0; i < ifVts.Length; i++) {
                var ifVt = ifVts[i];
                if (ifVt.signalCondition == context.signalCondition
                 // if preVt is string.Empty, let's use the first type.
                 // otherwise, preVt must be the lastType.
                 && (ifVt.preVt == st.@终 // default preVt
                  || ifVt.preVt == lastType)) { // <'Vt'>
                    context.analyzingToken.kind = ifVt.Vt;
                    if (ifVt.nextSignal != null) { context.signalCondition = ifVt.nextSignal; }
                    typeSet = true;
                    break;
                }
            }
            if (!typeSet) {
                for (var i = 0; i < ifVts.Length; i++) {
                    var ifVt = ifVts[i];
                    if (// ingnore signal condition and try to assgin a type.
                        // if preVt is string.Empty, let's use the first type.
                        // otherwise, preVt must be the lastType.
                        (ifVt.preVt == st.@终 // default preVt
                      || ifVt.preVt == lastType)) { // <'Vt'>
                        context.analyzingToken.kind = ifVt.Vt;
                        context.signalCondition = LexicalContext.defaultSignal;
                        typeSet = true;
                        break;
                    }
                }
            }

            var startIndex = context.analyzingToken.start.index;
            var end = context.analyzingToken.start;
            if (!typeSet) {
                // we failed to assign type according to lexi statements.
                // this indicates token error in source code or inappropriate lexi statements.
                //throw new Exception("Algorithm error: token type not set!");
                context.analyzingToken.kind = st.Error错;
                context.signalCondition = LexicalContext.defaultSignal;
                // choose longest value
                for (int i = 0; i < context.analyzingToken.ends.Length; i++) {
                    var item = context.analyzingToken.ends[i];
                    if (end.index < item.index) { end = item; }
                }
            }
            else { end = context.analyzingToken.ends[context.analyzingToken.kind]; }
            context.analyzingToken.value = context.sourceCode.Substring(startIndex, end.index - startIndex + 1);

            // cancel forward steps for post-regex
            var backStep = context.cursor.index - end.index;
            if (backStep > 0) { context.MoveBack(backStep); }
            // next operation: context.MoveForward();

            var token = context.analyzingToken.Dump(
#if DEBUG
                context.stArray,
#endif
                end);
            context.result.Add(token);
            // 跳过单行注释 skip inline comment
            if (context.analyzingToken.kind != st.inlineComment行) {
                context.lastSyntaxValidToken = token;
            }
            if (token.kind == st.Error错) {
                context.result.token2ErrorInfo.Add(token,
                    new TokenErrorInfo(token, "token type unrecognized!"));
            }
        }
    }
}
