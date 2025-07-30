using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    public interface IFullFormat {

        public TokenRange Scope { get; }
        /// <summary>
        /// format with (block/inline comment) tokens inside this node.
        /// </summary>
        /// <param name="preConfig">if null, it means to print this oject directly(without any pre-space-char)</param>
        /// <param name="writer"></param>
        /// <param name="context"></param>
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }

    /// <summary>
    /// deal with blanks(space and newline) in formatting source code.
    /// </summary>
    public struct BlankConfig {
        /// <summary>
        /// how many space-chars?(1 by default).
        /// <para>-1 means same with source code.</para>
        /// </summary>
        public int inlineBlank;

        /// <summary>
        /// there must be a newline before this token.
        /// </summary>
        public bool forceNewline;

        /// <summary>
        /// default: inlineBlank = 1, forceNewline = false.
        /// </summary>
        public BlankConfig() : this(1, false) { }

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

        public override string ToString() {
            if (start < end) {
                return $"{start}->{end}";
            }
            else if (start == end) {
                return $"{start}";
            }
            else {
                return $"{start}<-{end}";
            }
        }
    }

}
