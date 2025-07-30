
using bitzhuwei.Compiler;
using bitzhuwei.GLSLFormat;
using bitzhuwei.PreDirectiveFormat;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// preprocess a complete shader code.
    /// </summary>
    public class Preprocessor {

        private static readonly CompilerPreDirective predirectiveParser = new();
        private static readonly CompilerGLSL glslParser = new();

        /// <summary>
        /// each <paramref name="codeSegments"/>[i] is a collection of 1/more complete lines of source code.
        /// </summary>
        /// <param name="codeSegments"></param>
        /// <returns></returns>
        public static List<Token> Preprocess(params string[] codeSegments) {
            if (codeSegments.Length == 0) { return new(); }

            var ppContext = new PpContext();// preprocess context
            var expandedTokenLists = new List<List<Token>>();// original tokens =(macro expand)=> expanded tokens
            var glslStepParser = new CompilerGLSL();// parse one line each time
            var accuTokens = glslStepParser.Begin();
            //var continues = new List<Token>(accTokens); 
            var startPoint = 0;
            for (int i = 0; i < codeSegments.Length; i++) {
                using (var reader = new StringReader(codeSegments[i])) {
                    while (true) {
                        var line = reader.ReadLine(); // no suppport for line-continuation character like '\'
                        if (line == null) { break; } // end of current segment

                        ppContext.currentLine++;

                        var isValid = ppContext.isActive;
                        var cursor = 0;
                        while (cursor < line.Length && (line[cursor] == ' ' || line[cursor] == '\t')) {
                            cursor++;
                        }
                        var isMacro = (cursor < line.Length && line[cursor] == '#');

                        if (isValid && isMacro) {// line is a directive in valid scope, we parse it and update the preprocess context
                            if (startPoint < accuTokens.Count) {// some new tokens were appended, try to expand them
                                var expanded = MacroExpand(accuTokens, startPoint, ppContext);
                                expandedTokenLists.Add(expanded);
                                startPoint = accuTokens.Count;
                            }
                            {// update ppContext's state
                                SyntaxTree? tree = null; PreDirective? preDirective = null;
                                var tokens = predirectiveParser.Analyze(line);
                                if (tokens != null && !tokens.Error) {
                                    tree = predirectiveParser.Parse(tokens);
                                }
                                if (tokens != null && tree != null && tree.root != null) {
                                    preDirective = predirectiveParser.Extract(tree, tokens, line);
                                }
                                if (preDirective != null) {
                                    preDirective.Update(ppContext);
                                }
                            }
                        }

                        {
                            var lines = (isValid && !isMacro) ? line : "";
                            var tokens = glslStepParser.Continue(lines);
                            //continues.AddRange(tokens);
                        }
                    }
                }
            }
            {
                var tokens = glslStepParser.Finish();// deal with '\0'
                //continues.AddRange(tokens);
            }
            if (startPoint < accuTokens.Count/*continues.Count > 0*/) {// some new tokens were appended, try to expand them
                var expanded = MacroExpand(accuTokens, startPoint, ppContext);
                expandedTokenLists.Add(expanded);
                //continues.Clear();
                startPoint = accuTokens.Count;
            }

            var result = new List<Token>();
            {// deal with Token.(index/start/end)
                var tokenIndex = 0; var preCodeLength = 0; var line = 0;
                foreach (var list in expandedTokenLists) {
                    var endIndex = 0; var endLine = 0;
                    foreach (var token in list) {
                        var codeIndex = preCodeLength + token.start.index;
                        var start = new LexicalCursor(codeIndex, line + token.start.line, token.start.column);
                        var end = new LexicalCursor(token.end.index - token.start.index + codeIndex, line + token.end.line, token.end.column);
                        var copy = new Token(tokenIndex, token.kind, token.stArray, start, end, token.value);
                        result.Add(copy);
                        tokenIndex++;
                        endIndex = token.end.index; endLine = token.end.line;
                    }
                    preCodeLength += endIndex; line += endLine;
                }
            }
            return result;
        }

        /// <summary>
        /// try to macro-expand <paramref name="accuTokens"/> according to <paramref name="ppContext"/>. The returned result is the expanded tokens.
        /// </summary>
        /// <param name="accuTokens"></param>
        /// <param name="startPoint"></param>
        /// <param name="ppContext"></param>
        private static List<Token> MacroExpand(IReadOnlyList<Token> accuTokens, int startPoint, PpContext ppContext) {
            var patient = accuTokens;
            var result = new List<Token>();
            var expanding = true;
            while (expanding) {
                var searchResult = SearchDefine(patient, startPoint, ppContext);
                expanding = searchResult.preDefine != null;// found macro, let's expand it.
                if (searchResult.preDefine != null) {
                    for (int i = startPoint; i < searchResult.definedName; i++) {// [cursor - pre-definedName]
                        result.Add(patient[i]);
                    }
                    var followingTokenPastingOp = false;// token pasting operator (##)
                    for (int i = 0; i < searchResult.preDefine.postTokens.Count; i++) {// try to expand #define
                        var token = searchResult.preDefine.postTokens[i];
                        if (followingTokenPastingOp) {// token pasting operator (##)
                            if (searchResult.preDefine.formalParam2Index.TryGetValue(token.value, out var index)) {// this token is a formal-param
                                if (index < searchResult.paramsList.Count) {
                                    var actualParams = searchResult.paramsList[index];
                                    if (actualParams.start <= actualParams.end) {// try to past 2 tokens into 1.
                                        if (actualParams.start > 0) {
                                            var str = patient[actualParams.start - 1].value + patient[actualParams.start].value;
                                            var ts = glslParser.Analyze(str);
                                            result.RemoveAt(actualParams.start - 1);
                                            result.AddRange(ts);
                                        }
                                        else {// no previous token, so no paste.
                                            result.Add(patient[actualParams.start]);
                                        }
                                    }
                                    // deal with other actual param tokens.
                                    for (int t = actualParams.start + 1; t <= actualParams.end; t++) {
                                        result.Add(patient[t]);
                                    }
                                }
                                else { /* no token for actual param exists, whatever~ */ }
                            }
                            else { // this token is a regular token
                                TransformRegularToken(result, token);
                            }
                            followingTokenPastingOp = false;
                        }
                        else if (token.kind == CompilerPreDirective.st.Pound符Pound符) {// token pasting operator (##)
                            followingTokenPastingOp = true;
                        }
                        else if (searchResult.preDefine.formalParam2Index.TryGetValue(token.value, out var index)) {// this token is a formal-param
                            if (index < searchResult.paramsList.Count) {
                                var actualParams = searchResult.paramsList[index];
                                for (int t = actualParams.start; t <= actualParams.end; t++) {
                                    result.Add(patient[t]);
                                }
                            }
                            else { /* no token for actual param exists, whatever~ */ }
                        }
                        else { // this token is a regular token
                            TransformRegularToken(result, token);
                        }
                    }
                    for (int i = searchResult.lastToken + 1; i < patient.Count; i++) {// [post-lastToken - end of patient]
                        result.Add(patient[i]);
                    }
                    {// when preDefine is system-predefine
                        var str = "";
                        switch (searchResult.preDefine.name) {
                        case "__LINE__": str = $"{ppContext.currentLine}"; break;
                        case "__FILE__": str = "0"; break;
                        case "__VERSION__": str = $"{ppContext.version.number}"; break;
                        default:
                        break;
                        }
                        if (str != "") {// preDefine is really a system-predefine
                            var ts = glslParser.Analyze(str);
                            result.AddRange(ts);
                        }
                    }

                    patient = result; startPoint = searchResult.definedName/*0*/; result = new();
                }
                else {// no need to expand
                    for (int i = startPoint; i < patient.Count; i++) {
                        result.Add(patient[i]);
                    }
                }
            }

            return result;
        }

        private static void TransformRegularToken(List<Token> result, Token token) {
            // transform from predirectiveParser's token to glslParser's token
            var ts = glslParser.Analyze(token.value);
            if (ts.Error || ts.Count != 1) { throw new NotImplementedException(); }// bug. fix it.
            var t0 = ts[0]; var last = result[result.Count - 1];
            // let's put it that there is a ' ' between <last> and <transformed>
            var start = new LexicalCursor(last.end.index + 2, last.end.line, last.end.column + 2);
            var end = new LexicalCursor(start.index - 1 + t0.value.Length, t0.end.line - t0.start.line + start.line, start.column - 1 + t0.value.Length);
            var transformed = new Token(result.Count, t0.kind, t0.stArray, start, end, t0.value);
            result.Add(transformed);
        }

        /*
        #define minus2(a, b) ((a) - (b) - (b))
        #define connect(a, b) a##b

        original: double x = minus2(3.14, connect(1.2, 3), 4);

        Search result: (3, { (5, 5), (7, 12) }, 15) // ("minus2", { ("3.14", "3.14"), ("connect", ")"), ")" })
        expanded: double x = ((3.14) - (connect(1.2, 3)) - (connect(1.2, 3)));

        Search result: (8, { (10, 10), (11, 11) }, 12) // ("connect", { ("1.2", "1.2"), ("3", "3"), ")" })
        expanded: double x = ((3.14) - (1.23) - (1.23));
         */
        private static SearchResult SearchDefine(IReadOnlyList<Token> patient, int startPoint, PpContext ppContext) {
            PreDefine? preDefine = null; var definedName = -1; var paramsList = new List<(int start, int end)>(); var lastToken = -1;
            for (int index = startPoint; index < patient.Count; index++) {
                // TryGetValue("minus2", out var preDefine) in origial
                if (ppContext.name2Define.TryGetValue(patient[index].value, out preDefine)) {// accTokens[i].value is a #define name
                    definedName = index; // 3
                    if (preDefine.hasParentheses) {// search '(' param-list ')'
                        var stack = new Stack<string>();// () [] {} <> inside a '...' in the define-name( ... , ... , ... )
                        int? start = null;
                        // search param-list from '('
                        for (int t = definedName + 1; t < patient.Count; t++) {
                            lastToken = t;
                            var token = patient[t];
                            if (token.kind == Token.Kinds.blockComment || token.kind == Token.Kinds.inlineComment) {
                                continue; // ignore comment tokens
                            }

                            var value = token.value;
                            if (false) { }
                            else if (value == "(") {
                                stack.Push(value);
                                if (start == null && stack.Count == 1) { start = t + 1; } // the first param's start
                            }
                            else if (value == ")") {
                                if (stack.Count > 0 && stack.Peek() == "(") {
                                    stack.Pop();
                                    if (stack.Count == 0) { // poped the first '('
                                        lastToken = t;
                                        var end = t - 1;
                                        //Debug.Assert(start != null);
                                        if (start != null) { // good. no bug.
                                            paramsList.Add((start.Value, end));
                                            break; // end of collecting param-list and lastToken
                                        }
                                        else { throw new NotImplementedException(); } // bug. fix it.
                                    }
                                }
                                else { break; } // syntax error
                            }
                            else if (value == "[" || value == "{" || value == "<") {
                                stack.Push(value);
                            }
                            else if (value == "]") {
                                if (stack.Count > 0 && stack.Peek() == "[") { stack.Pop(); }
                                else { break; } // syntax error
                            }
                            else if (value == "}") {
                                if (stack.Count > 0 && stack.Peek() == "{") { stack.Pop(); }
                                else { break; } // syntax error
                            }
                            else if (value == ">") {
                                if (stack.Count > 0 && stack.Peek() == "<") { stack.Pop(); }
                                else { break; } // syntax error
                            }
                            else if (value == ",") {
                                if (stack.Count == 1 && stack.Peek() == "(") { // only the first '('
                                    var end = t - 1;
                                    if (start == null) { start = t; }// the first param is empty
                                    paramsList.Add((start.Value, end));
                                    start = t + 1; // the next param's start
                                }
                                else { break; } // syntax error
                            }
                            else { /* nothing to do */ }
                        }
                    }
                    else { // preDefine.hasParentheses is false
                        lastToken = index;
                    }
                    break;// only search the first #define name
                }
            }
            return new(preDefine, definedName, paramsList, lastToken);
        }

        class SearchResult {
            /// <summary>
            /// we found a pre-define in source-code-line.
            /// </summary>
            public readonly PreDefine? preDefine;
            /// <summary>
            /// index of the token whose value is the define-name.
            /// </summary>
            public readonly int definedName;
            /// <summary>
            /// (start, end) index of each params(...) in define-name( ... , ... , ... )
            /// </summary>
            public readonly List<(int start, int end)> paramsList;
            /// <summary>
            /// index of ')' in define-name( ... , ... , ... )
            /// or index of define-name in define-name
            /// </summary>
            public readonly int lastToken;

            public SearchResult(PreDefine? preDefine, int definedName, List<(int start, int end)> paramsList, int lastToken) {
                this.preDefine = preDefine;
                this.definedName = definedName;
                this.paramsList = paramsList;
                this.lastToken = lastToken;
            }

        }
    }
}
