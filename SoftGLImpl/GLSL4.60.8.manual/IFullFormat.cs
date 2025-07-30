using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    public interface IFullFormat {
        ///// <summary>
        ///// format exclude (block/inline comment) tokens.
        ///// </summary>
        ///// <param name="writer"></param>
        ///// <param name="context"></param>
        //public void Format(TextWriter writer, FormatContext context);

        ///// <summary>
        ///// dumb implementation of format include (block/inline comment) tokens.
        ///// </summary>
        ///// <param name="writer"></param>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);

        public TokenRange Scope { get; }
        /// <summary>
        /// format include (block/inline comment) tokens.
        /// </summary>
        /// <param name="preConfig">if null, it means to print this <paramref name="formatter"/> directly(without any pre-space-char)</param>
        /// <param name="writer"></param>
        /// <param name="context"></param>
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }

    /// <summary>
    /// deal with blanks(space and newline) in formatting source code.
    /// </summary>
    public struct BlankConfig {
        ///// <summary>
        ///// ignore other parameters and write no space-char at all.
        ///// </summary>
        //public bool noBlank = false;

        /// <summary>
        /// how many space-chars?(1 by default).
        /// <para>-1 means same with source code.</para>
        /// </summary>
        public int inlineBlank;

        /// <summary>
        /// there must be a newline before this token.
        /// </summary>
        public bool forceNewline;


        ///// <summary>
        ///// deal with blanks(space and newline) in formatting source code.
        ///// </summary>
        ///// <param name="source">copy from this <paramref name="source"/></param>
        //public BlankConfig(BlankConfig source) {
        //    this.inlineBlank = source.inlineBlank;
        //    this.forceNewline = source.forceNewline;
        //}

        /// <summary>
        /// deal with blanks(space and newline) in formatting source code.
        /// </summary>
        /// <param name="inlineBlank">how many space-chars?(1 by default).
        /// <para>-1 means same with source code.</para></param>
        /// <param name="forceNewline">there must be a newline before this token.</param>
        public BlankConfig(int inlineBlank = 1, bool forceNewline = false) {
            this.inlineBlank = inlineBlank;
            this.forceNewline = forceNewline;
        }

        public override string ToString() => $"b:{inlineBlank}, f:{forceNewline}";
    }

    /// <summary>
    /// <see cref="Token"/>s[<see cref="start"/>] -> <see cref="Token"/>s[<see cref="end"/>]
    /// </summary>
    public class TokenRange {
        /// <summary>
        /// <see cref="Token"/>s[<see cref="start"/>]
        /// </summary>
        public int start;
        /// <summary>
        ///  <see cref="Token"/>s[<see cref="end"/>]
        /// </summary>
        public int end;

        /// <summary>
        /// use this for S : empty ;
        /// </summary>
        /// <returns></returns>
        public static TokenRange empty() {
            return new TokenRange(start: int.MaxValue, end: int.MinValue);
        }

        /// <summary>
        /// <see cref="Token"/>s[<see cref="start"/>] -> <see cref="Token"/>s[<see cref="end"/>]
        /// </summary>
        /// <param name="singleton"></param>
        public TokenRange(Token singleton) {
            this.start = singleton.index;
            this.end = singleton.index;
        }
        public TokenRange(Token first, Token last) {
            this.start = first.index;
            this.end = last.index;
        }

        public TokenRange(IFullFormat singleton) {
            this.start = singleton.Scope.start;
            this.end = singleton.Scope.end;
        }
        public TokenRange(IFullFormat first, IFullFormat last) {
            this.start = first.Scope.start;
            this.end = last.Scope.end;
        }

        public TokenRange(Token first, IFullFormat last) {
            this.start = first.index;
            this.end = last.Scope.end;
        }
        public TokenRange(IFullFormat first, Token last) {
            this.start = first.Scope.start;
            this.end = last.index;
        }

        private TokenRange(int start, int end) {
            this.start = start;
            this.end = end;
        }

        public override string ToString() => $"{start} -> {end}";
    }

}
