using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Lexically analyze source code and return a list of <see cref="Token"/>.
    /// </summary>
    partial class LexicalAnalyzer {

        /// <summary>
        /// Lexically analyze source code and return a list of <see cref="Token"/>.
        /// </summary>
        /// <param name="eVtKinds">1('¥') + kinds of Vt</param>
        /// <param name="lexiStates">table for lexical analyze.</param>
        /// <param name="omitChars"></param>
        /// <param name="lexicalScripts"></param>
        public LexicalAnalyzer(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            int eVtKinds, ElseIf[][] lexiStates, ElseIf[] omitChars,
                LexicalScripts lexicalScripts) {

            this._analyzer = new TableManner(
#if DEBUG
                stArray,
#endif
                eVtKinds, lexiStates, omitChars, lexicalScripts);
        }

        class TableManner : IAnalyzer {
#if DEBUG
            private readonly IReadOnlyList<string> stArray;
#endif
            /// <summary>
            /// 1('¥') + kinds of Vt
            /// </summary>
            private readonly int eVtKinds;
            private readonly ElseIf[][] lexiStates;
            private readonly ElseIf[] omitChars;
            private readonly LexicalScripts lexicalScripts;
            /// <summary>
            /// skip '\0' at lexi-state 0
            /// </summary>
            private static readonly ElseIf skipZero = new(
                char.MinValue, char.MaxValue, nextStateId: 0,
                Acts.None, Vt: 0/*'¥'*/);
            /// <summary>
            /// construct a error token at lexi-state 0
            /// </summary>
            private static readonly ElseIf unexpectedChar = new(
                char.MinValue, char.MaxValue, nextStateId: 0,
                Acts.Begin | Acts.Extend | Acts.Accept, Vt: Token.Kinds.error/*'×'*/);
            /// <summary>
            /// construct a error token at other lexi-states
            /// </summary>
            private static readonly ElseIf errorToken = new(
                char.MinValue, char.MaxValue, nextStateId: 0,
                Acts.Extend | Acts.Accept, Vt: Token.Kinds.error/*'×'*/);

            /// <summary>
            /// Lexically analyze source code and return a list of <see cref="Token"/>.
            /// </summary>
            /// <param name="eVtKinds">1('¥') + kinds of Vt</param>
            /// <param name="lexiStates">table for lexical analyze.</param>
            /// <param name="omitChars"></param>
            /// <param name="lexicalScripts"></param>
            public TableManner(
#if DEBUG
                IReadOnlyList<string> stArray,
#endif
                int eVtKinds, ElseIf[][] lexiStates, ElseIf[] omitChars,
                LexicalScripts lexicalScripts) {
                ArgumentNullException.ThrowIfNull(lexiStates);
                ArgumentNullException.ThrowIfNull(omitChars);
                ArgumentNullException.ThrowIfNull(lexicalScripts);
#if DEBUG
                this.stArray = stArray;
#endif
                this.eVtKinds = eVtKinds;
                this.lexiStates = lexiStates;
                this.omitChars = omitChars;
                this.lexicalScripts = lexicalScripts;
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
                var currentStateId = 0;
                do {
                    // read current char,
                    char currentChar = context.MoveForward();
                    var segment = AnalyzeStep(context, currentStateId, currentChar);
                    // point to next state.
                    currentStateId = segment.nextStateId;
                } while (!context.EOF);

                return context.result;
            }
            private ElseIf AnalyzeStep(LexicalContext context, int currentStateId, char currentChar) {
                ElseIf[] lexiState = lexiStates[currentStateId];
                // binary search for the segment( else if (left <= c && c <= right) { ... } )
                // TODO: can it be that lexi-state-0 has a ElseIf('0', '\uFFFF', ..) ?
                var segment = BinarySearch(currentChar, lexiState, currentStateId != 0);
                if (segment is null) {
                    if (currentStateId == 0) { // the initial state of lexical analyzing.
                        segment = BinarySearch(currentChar, this.omitChars, currentStateId != 0);
                        if (segment is null) {
                            // '\0' must be skipped.
                            if (currentChar == '\0') { segment = skipZero; }
                            else { segment = unexpectedChar; }
                        }
                    }
                    else { // token with error kind
                        segment = errorToken;
                    }
                }
                // construct the next token,
                //if (!acts2Refered.TryAdd(segment.scripts, 1)) {
                //    acts2Refered[segment.scripts]++;
                //}
                var scripts = segment.scripts;
                if (scripts != 0) { // it is 0 in most cases.
                    const Acts ea23 = Acts.Extend2 | Acts.Extend3 | Acts.Accept2 | Acts.Accept3;
                    if ((scripts & ea23) != 0) { throw new Exception($"{scripts} should not have flags in ({ea23})"); }

                    if ((scripts & Acts.Begin) != 0) { this.lexicalScripts.begin(context); }
                    if ((scripts & Acts.Extend) != 0) { this.lexicalScripts.extend(context, segment.Vt); }
                    if ((scripts & Acts.Accept) != 0) { this.lexicalScripts.accept(context, segment.Vt); }
                }
                return segment;
            }

            private ElseIf? BinarySearch(char currentChar, ElseIf[] lexiState, bool specialLast) {
                var left = 0; var right = lexiState.Length - (specialLast ? 2 : 1);
                if (right < 0) { }
                else {
                    var result = -1;
                    while (left < right) {
                        var mid = (left + right) / 2;
                        var current = lexiState[mid];
                        if (currentChar < current.min) { result = -1; }
                        else if (current.max < currentChar) { result = 1; }
                        else { return current; }

                        if (result < 0) { right = mid; }
                        else { left = mid + 1; }
                    }
                    {
                        var current = lexiState[left];
                        if (current.min <= currentChar && currentChar <= current.max) {
                            return current;
                        }
                    }
                }
                if (specialLast) {
                    var last = lexiState[lexiState.Length - 1];
                    return last;
                    // no need to compare, because it's ['\0', '\uFFFF']
                    //if (last.min <= currentChar && currentChar <= last.max) {
                    //    return last;
                    //}
                }

                return null;
            }

            private BCFTableContext? bcfContext = null;

            public TokenList Begin() {
                if (this.bcfContext != null) { throw new Exception("last Begin/Continue/Finish() not finished!"); }

                this.bcfContext = new BCFTableContext(
#if DEBUG
                    this.stArray,
#endif
                    this.eVtKinds);
                return this.bcfContext.context.result;
            }
            public TokenList Continue(string lines) {
                var bcfContext = this.bcfContext;
                if (bcfContext == null) { throw new Exception("call Begin() first!"); }

                if (bcfContext.firstLines) { bcfContext.firstLines = false; }
                else { bcfContext.context.sourceCode.Append("\r\n"); }
                bcfContext.context.sourceCode.Append(lines);

                var end = false;
                do {
                    // read current char,
                    char currentChar = bcfContext.context.MoveForward();
                    if (currentChar != '\0') {
                        var segment = AnalyzeStep(bcfContext.context, bcfContext.currentStateId, currentChar);
                        // point to next state.
                        bcfContext.currentStateId = segment.nextStateId;
                    }
                    else {
                        bcfContext.context.MoveBack(1);
                        end = true;
                    }
                } while (!end);

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
                    // read current char,
                    char currentChar = bcfContext.context.MoveForward();
                    var segment = AnalyzeStep(bcfContext.context, bcfContext.currentStateId, currentChar);
                    // point to next state.
                    bcfContext.currentStateId = segment.nextStateId;
                } while (!bcfContext.context.EOF);

                //bcfContext.accuTokens.Append(codeSegment, bcfContext.context.result);

                this.bcfContext = null;

                return bcfContext.context.result;
            }
        }
    }
}
