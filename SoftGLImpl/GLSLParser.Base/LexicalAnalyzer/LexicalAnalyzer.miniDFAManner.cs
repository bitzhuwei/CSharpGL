using System;

namespace bitzhuwei.Compiler {

    public class CurrentStateWrap {
        public Action<LexicalContext, char, CurrentStateWrap> currentState;
        public CurrentStateWrap(Action<LexicalContext, char, CurrentStateWrap> currentState) {
            this.currentState = currentState;
        }

        public override string ToString() => $"{currentState}";
    }

    /// <summary>
    /// Lexically analyze source code and return a list of <see cref="Token"/>.
    /// </summary>
    partial class LexicalAnalyzer {

        /// <summary>
        /// Lexically analyze source code and return a list of <see cref="Token"/>.
        /// </summary>
        /// <param name="initialState">The initial state.</param>
        /// <param name="eVtKinds">1('¥') + kinds of Vt</param>
        /// <exception cref="ArgumentNullException">The <paramref name="initialState"/> cannot be null.<exception>
        public LexicalAnalyzer(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            Action<LexicalContext, char, CurrentStateWrap> initialState, int eVtKinds) {

            this._analyzer = new miniDFAManner(
#if DEBUG
                stArray,
#endif
                eVtKinds, initialState);
        }

        class miniDFAManner : IAnalyzer {
#if DEBUG
            private readonly IReadOnlyList<string> stArray;
#endif
            /// <summary>
            /// 1('¥') + kinds of Vt
            /// </summary>
            private readonly int eVtKinds;
            /// <summary>
            /// the initial state of lexical analyzer.
            /// </summary>
            private readonly Action<LexicalContext, char, CurrentStateWrap> initialState;
            /// <summary>
            /// Lexically analyze source code and return a list of <see cref="Token"/>.
            /// </summary>
            /// <param name="initialState">The initial state.</param>
            /// <param name="eVtKinds">1('¥') + kinds of Vt</param>
            /// <exception cref="ArgumentNullException">The <paramref name="initialState"/> cannot be null.<exception>
            public miniDFAManner(
#if DEBUG
                IReadOnlyList<string> stArray,
#endif
                int eVtKinds,
                Action<LexicalContext, char, CurrentStateWrap> initialState) {
                ArgumentNullException.ThrowIfNull(initialState);
#if DEBUG
                this.stArray = stArray;
#endif
                this.initialState = initialState;
                this.eVtKinds = eVtKinds;
            }
            /// <summary>
            /// analyze the specified <paramref name="sourceCode"/> and return a list of <see cref="Token"/>.
            /// </summary>
            /// <param name="sourceCode">source code in string.</param>
            /// <returns></returns>
            public TokenList Analyze(ISourceCode sourceCode) {
                var context = new LexicalContext(
#if DEBUG
                    this.stArray,
#endif
                    sourceCode, this.eVtKinds);
                var wrap = new CurrentStateWrap(this.initialState);
                //var end = false;
                do {
                    char currentChar = context.MoveForward();
                    // current state:
                    //     read current char,
                    //     construct current token,
                    //     point to next state.
                    wrap.currentState(context, currentChar, wrap);
                } while (!context.EOF);

                return context.result;
            }

            private BCFminiDFAContext? bcfContext = null;

            public TokenList Begin() {
                if (this.bcfContext != null) { throw new Exception("last Begin/Continue/Finish() not finished!"); }

                this.bcfContext = new BCFminiDFAContext(
#if DEBUG
                    this.stArray,
#endif
                    this.eVtKinds,
                    this.initialState);
                return this.bcfContext.context.result;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="lines"></param>
            /// <param name="firstLines"></param>
            /// <returns></returns>
            public TokenList Continue(string lines) {
                var bcfContext = this.bcfContext;
                if (bcfContext == null) { throw new Exception("call Begin() first!"); }

                if (bcfContext.firstLines) { bcfContext.firstLines = false; }
                else { bcfContext.context.sourceCode.Append("\r\n"); }
                bcfContext.context.sourceCode.Append(lines);

                do {
                    char currentChar = bcfContext.context.MoveForward();
                    if (currentChar != '\0') {
                        // current state:
                        //     read current char,
                        //     construct current token,
                        //     point to next state.
                        bcfContext.wrap.currentState(bcfContext.context, currentChar, bcfContext.wrap);
                    }
                } while (!bcfContext.context.EOF);

                //bcfContext.accuTokens.Append(lines, bcfContext.context.result);

                return bcfContext.context.result;
            }
            public TokenList Finish() {
                var bcfContext = this.bcfContext;
                if (bcfContext == null) { throw new Exception("call Begin() first!"); }

                // deal with '\0'
                const string codeSegment = "";
                bcfContext.context.sourceCode.Append(codeSegment);
                do {
                    char currentChar = bcfContext.context.MoveForward();
                    // current state:
                    //     read current char,
                    //     construct current token,
                    //     point to next state.
                    bcfContext.wrap.currentState(bcfContext.context, currentChar, bcfContext.wrap);
                } while (!bcfContext.context.EOF);

                //bcfContext.accuTokens.Append(codeSegment, bcfContext.context.result);

                this.bcfContext = null;

                return bcfContext.context.result;
            }
        }
    }
}
