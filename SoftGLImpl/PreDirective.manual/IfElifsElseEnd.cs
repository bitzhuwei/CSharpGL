using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// #if #elif #else #endif
    /// </summary>
    public partial class IfElifsElseEnd {
        public readonly If_ if_;

        public readonly List<Elif_> elifs = new();

        public Else_? else_;

        /// <summary>
        /// got #endif ?
        /// </summary>
        public bool endif;

        public IfElifsElseEnd(If_.Kind kind, string ifExp, bool endif = false) {
            this.if_ = new If_(kind, ifExp);
            this.endif = endif;
        }

        public bool IsActive(PpContext context) {
            if (endif) { return true; }

            if (this.if_.IsActive(context)) {
                return (this.elifs.Count == 0 && this.else_ == null);
            }
            else {
                var activeIndex = -1;
                for (var i = 0; i < this.elifs.Count; i++) {
                    if (this.elifs[i].IsActive(context)) {
                        activeIndex = i;
                        break;
                    }
                }
                if (activeIndex == -1) {// no active #elif
                    if (this.else_ != null) {
                        return this.else_.IsActive(context);
                    }
                    else { return false; }
                }
                else {
                    //return (the active one is the last one);
                    return (activeIndex + 1 == this.elifs.Count && this.else_ == null);
                }
            }
        }

        public bool Append(IfElifsElseEnd line) {
            if (this.endif) { return false; }

            if (this.else_ != null) {
                var last = this.else_.sub1.LastOne();
                if (last == null || !last.Append(line)) {
                    this.else_.sub1.Add(line);
                }
            }
            else if (this.elifs.Count > 0) {
                var elif = this.elifs[this.elifs.Count - 1];
                var last = elif.sub1.LastOne();
                if (last == null || !last.Append(line)) {
                    elif.sub1.Add(line);
                }
            }
            else {
                var last = this.if_.sub1.LastOne();
                if (last == null || !last.Append(line)) {
                    this.if_.sub1.Add(line);
                }
            }
            return true;
        }

        internal bool Append(Elif_ line) {
            if (this.endif) { return false; }

            if (this.else_ != null) {
                var last = this.else_.sub1.LastOne();
                return (last != null && last.Append(line));
            }
            else if (this.elifs.Count > 0) {
                var elif = this.elifs[this.elifs.Count - 1];
                var last = elif.sub1.LastOne();
                if (last == null || !last.Append(line)) {
                    this.elifs.Add(line);
                }
                return true;
            }
            else {
                var last = this.if_.sub1.LastOne();
                if (last == null || !last.Append(line)) {
                    this.elifs.Add(line);
                }
                return true;
            }
        }

        internal bool Append(Else_ line) {
            if (this.endif) { return false; }

            if (this.else_ != null) {
                var last = this.else_.sub1.LastOne();
                return (last != null && last.Append(line));
            }
            else if (this.elifs.Count > 0) {
                var elif = this.elifs[this.elifs.Count - 1];
                var last = elif.sub1.LastOne();
                if (last == null || !last.Append(line)) {
                    this.else_ = line;
                }
                return true;
            }
            else {
                var last = this.if_.sub1.LastOne();
                if (last == null || !last.Append(line)) {
                    this.else_ = line;
                }
                return true;
            }
        }

        public bool AppendEndif() {
            if (this.endif) { return false; }

            if (this.else_ != null) {
                var last = this.else_.sub1.LastOne();
                if (last == null || !last.AppendEndif()) {
                    this.endif = true;
                }
            }
            else if (this.elifs.Count > 0) {
                var elif = this.elifs[this.elifs.Count - 1];
                var last = elif.sub1.LastOne();
                if (last == null || !last.AppendEndif()) {
                    this.endif = true;
                }
            }
            else {
                var last = this.if_.sub1.LastOne();
                if (last == null || !last.AppendEndif()) {
                    this.endif = true;
                }
            }

            return true;
        }
    }

    public class If_ {
        /// <summary>
        /// #if/#ifdef/#ifndef
        /// </summary>
        public enum Kind { IF, IFDEF, IFNDEF };
        /// <summary>
        /// #if/#ifdef/#ifndef
        /// </summary>
        public readonly Kind kind;
        /// <summary>
        /// ConstExp in
        /// #if ConstExp
        /// </summary>
        public readonly string exp;

        public readonly List<IfElifsElseEnd> sub1 = new();

        public If_(Kind kind, string exp) {
            this.kind = kind;
            this.exp = exp;
        }

        public bool IsActive(PpContext context) {
            switch (this.kind) {
            case Kind.IF: {
                int final = 0;
                if (int.TryParse(exp, out int value)) {
                    final = value;
                }
                if (final == 0) { return false; }

                var last = this.sub1.LastOne();
                if (last != null) { return last.IsActive(context); }
                return true;
            }
            case Kind.IFDEF: {
                if (!context.name2Define.ContainsKey(this.exp)) { return false; }

                var last = this.sub1.LastOne();
                if (last != null) { return last.IsActive(context); }
                return true;
            }
            case Kind.IFNDEF: {
                if (context.name2Define.ContainsKey(this.exp)) { return false; }

                var last = this.sub1.LastOne();
                if (last != null) { return last.IsActive(context); }
                return true;
            }
            default: throw new NotImplementedException();
            }
        }
    }
    public class Elif_ {
        /// <summary>
        /// ConstExp in
        /// #elif ConstExp
        /// </summary>
        public readonly string exp;

        public readonly List<IfElifsElseEnd> sub1 = new();

        public Elif_(string exp) {
            this.exp = exp;
        }
        public bool IsActive(PpContext context) {
            int final = 0;
            if (int.TryParse(exp, out int value)) {
                final = value;
            }
            if (final == 0) { return false; }

            var last = this.sub1.LastOne();
            if (last != null) { return last.IsActive(context); }
            return true;
        }
    }

    public class Else_ {

        public readonly List<IfElifsElseEnd> sub1 = new();
        public bool IsActive(PpContext context) {
            var last = this.sub1.LastOne();
            if (last != null) { return last.IsActive(context); }
            return true;
        }
    }
}
