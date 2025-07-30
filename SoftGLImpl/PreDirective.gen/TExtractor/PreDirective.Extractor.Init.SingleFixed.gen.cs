using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    partial class CompilerPreDirective {
        /// <summary>
        /// <see cref="LRNode.type"/> -&gt; <see cref="Action{LRNode, TContext{PreDirective}}"/>
        /// </summary>
        private static readonly Action<LRNode, TContext<PreDirective>>?[]
            @preDirectiveExtractorItems = new Action<LRNode, TContext<PreDirective>>[1/*'¥'*/ + 29/*Vn*/];

        /// <summary>
        /// initialize dict for extractor.
        /// </summary>
        private static void InitializeExtractorItems() {
            var extractorItems = @preDirectiveExtractorItems;

            #region obsolete
            //extractorDict.Add(st.NotYet,
            //(node, context) => {
            // not needed.
            //});
            //extractorDict.Add(st.Error,
            //(node, context) => {
            // nothing to do.
            //});
            //extractorDict.Add(st.blockComment,
            //(node, context) => {
            // not needed.
            //});
            //extractorDict.Add(st.inlineComment,
            //(node, context) => {
            // not needed.
            //});
            #endregion obsolete

            extractorItems[st.@终/*0*/] = static (node, context) => {
                // [-1] PreDirective' = PreDirective ;
                // dumped by ExternalExtractor
                var @final = (VnPreDirective)context.rightStack.Pop();
                var left = new PreDirective(@final);
                context.result = left; // final step, no need to push into stack.
            }; // end of extractorItems[st.@终/*0*/] = (node, context) => { ... };
            const int lexiVtCount = 69;
            extractorItems[st.PreDirective枝/*70*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 0: { // [0] PreDirective = MicroDefinition ;
                    // dumped by DefaultExtractor
                    var r0 = (VnMicroDefinition)context.rightStack.Pop();
                    var left = new VnPreDirective(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 1: { // [1] PreDirective = ConditionalCompilation ;
                    // dumped by DefaultExtractor
                    var r0 = (VnConditionalCompilation)context.rightStack.Pop();
                    var left = new VnPreDirective(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 2: { // [2] PreDirective = ErrorDirective ;
                    // dumped by DefaultExtractor
                    var r0 = (VnErrorDirective)context.rightStack.Pop();
                    var left = new VnPreDirective(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 3: { // [3] PreDirective = PragmaDirective ;
                    // dumped by DefaultExtractor
                    var r0 = (VnPragmaDirective)context.rightStack.Pop();
                    var left = new VnPreDirective(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 4: { // [4] PreDirective = ExtensionDirective ;
                    // dumped by DefaultExtractor
                    var r0 = (VnExtensionDirective)context.rightStack.Pop();
                    var left = new VnPreDirective(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 5: { // [5] PreDirective = VersionDirective ;
                    // dumped by DefaultExtractor
                    var r0 = (VnVersionDirective)context.rightStack.Pop();
                    var left = new VnPreDirective(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 6: { // [6] PreDirective = LineDirective ;
                    // dumped by DefaultExtractor
                    var r0 = (VnLineDirective)context.rightStack.Pop();
                    var left = new VnPreDirective(r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.PreDirective枝/*70*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.MicroDefinition枝/*71*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 7: { // [7] MicroDefinition = '#define' 'identifier' '(' ParameterList ')' RandomTokens ;
                    // dumped by DefaultExtractor
                    var r0 = (VnRandomTokens)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnParameterList)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r4 = (Token)context.rightStack.Pop();
                    var r5 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnMicroDefinition(r5, r4, r3, r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 8: { // [8] MicroDefinition = '#define' 'identifier' '(' ')' RandomTokens ;
                    // dumped by DefaultExtractor
                    var r0 = (VnRandomTokens)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r3 = (Token)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnMicroDefinition(r4, r3, r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 9: { // [9] MicroDefinition = '#define' 'identifier' RandomTokens ;
                    // dumped by DefaultExtractor
                    var r0 = (VnRandomTokens)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnMicroDefinition(r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 10: { // [10] MicroDefinition = '#undef' 'identifier' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnMicroDefinition(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.MicroDefinition枝/*71*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ParameterList枝/*72*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 11: { // [11] ParameterList = 'identifier' ;
                    // dumped by ListExtractor 1
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnParameterList(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 12: { // [12] ParameterList = ParameterList ',' 'identifier' ;
                    // dumped by ListExtractor 2
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnParameterList)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ParameterList枝/*72*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.RandomTokens枝/*73*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 13: { // [13] RandomTokens = RandomTokens RandomToken ;
                    // dumped by ListExtractor 2
                    var r0 = (VnRandomToken)context.rightStack.Pop();
                    var r1 = (VnRandomTokens)context.rightStack.Pop();
                    var left = r1;
                    left.Add(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 14: { // [14] RandomTokens = RandomToken ;
                    // dumped by ListExtractor 1
                    var r0 = (VnRandomToken)context.rightStack.Pop();
                    var left = new VnRandomTokens(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 15: { // [15] RandomTokens = null ;
                    // dumped by ListExtractor 1
                    var left = new VnRandomTokens();
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.RandomTokens枝/*73*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.RandomToken枝/*74*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 16: { // [16] RandomToken = 'identifier' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 17: { // [17] RandomToken = 'intConstant' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 18: { // [18] RandomToken = 'uintConstant' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 19: { // [19] RandomToken = 'floatConstant' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 20: { // [20] RandomToken = 'boolConstant' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 21: { // [21] RandomToken = 'doubleConstant' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 22: { // [22] RandomToken = ';' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 23: { // [23] RandomToken = '(' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 24: { // [24] RandomToken = ')' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 25: { // [25] RandomToken = '[' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 26: { // [26] RandomToken = ']' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 27: { // [27] RandomToken = '.' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 28: { // [28] RandomToken = '++' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 29: { // [29] RandomToken = '--' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 30: { // [30] RandomToken = ',' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 31: { // [31] RandomToken = '+' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 32: { // [32] RandomToken = '-' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 33: { // [33] RandomToken = '!' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 34: { // [34] RandomToken = '~' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 35: { // [35] RandomToken = '*' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 36: { // [36] RandomToken = '/' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 37: { // [37] RandomToken = '%' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 38: { // [38] RandomToken = '<<' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 39: { // [39] RandomToken = '>>' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 40: { // [40] RandomToken = '<' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 41: { // [41] RandomToken = '>' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 42: { // [42] RandomToken = '<=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 43: { // [43] RandomToken = '>=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 44: { // [44] RandomToken = '==' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 45: { // [45] RandomToken = '!=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 46: { // [46] RandomToken = '&' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 47: { // [47] RandomToken = '^' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 48: { // [48] RandomToken = '|' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 49: { // [49] RandomToken = '&&' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 50: { // [50] RandomToken = '^^' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 51: { // [51] RandomToken = '||' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 52: { // [52] RandomToken = '?' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 53: { // [53] RandomToken = ':' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 54: { // [54] RandomToken = '=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 55: { // [55] RandomToken = '*=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 56: { // [56] RandomToken = '/=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 57: { // [57] RandomToken = '%=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 58: { // [58] RandomToken = '+=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 59: { // [59] RandomToken = '-=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 60: { // [60] RandomToken = '<<=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 61: { // [61] RandomToken = '>>=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 62: { // [62] RandomToken = '&=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 63: { // [63] RandomToken = '^=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 64: { // [64] RandomToken = '|=' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 65: { // [65] RandomToken = '{' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 66: { // [66] RandomToken = '}' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 67: { // [67] RandomToken = '##' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnRandomToken(r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.RandomToken枝/*74*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ConditionalCompilation枝/*75*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 68: { // [68] ConditionalCompilation = IfGroup ;
                    // dumped by DefaultExtractor
                    var r0 = (VnIfGroup)context.rightStack.Pop();
                    var left = new VnConditionalCompilation(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 69: { // [69] ConditionalCompilation = ElseGroup ;
                    // dumped by DefaultExtractor
                    var r0 = (VnElseGroup)context.rightStack.Pop();
                    var left = new VnConditionalCompilation(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 70: { // [70] ConditionalCompilation = ElifGroup ;
                    // dumped by DefaultExtractor
                    var r0 = (VnElifGroup)context.rightStack.Pop();
                    var left = new VnConditionalCompilation(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 71: { // [71] ConditionalCompilation = EndifGroup ;
                    // dumped by DefaultExtractor
                    var r0 = (VnEndifGroup)context.rightStack.Pop();
                    var left = new VnConditionalCompilation(r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ConditionalCompilation枝/*75*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.IfGroup枝/*76*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 72: { // [72] IfGroup = '#if' ConstExp ;
                    // dumped by DefaultExtractor
                    var r0 = (VnConstExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnIfGroup(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 73: { // [73] IfGroup = '#ifdef' ConstExp ;
                    // dumped by DefaultExtractor
                    var r0 = (VnConstExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnIfGroup(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 74: { // [74] IfGroup = '#ifndef' ConstExp ;
                    // dumped by DefaultExtractor
                    var r0 = (VnConstExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnIfGroup(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.IfGroup枝/*76*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ElseGroup枝/*77*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 75: { // [75] ElseGroup = '#else' ;
                    // dumped by ConstsExtractor
                    var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
                    var left = new VnElseGroup(r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ElseGroup枝/*77*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ElifGroup枝/*78*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 76: { // [76] ElifGroup = '#elif' ConstExp ;
                    // dumped by DefaultExtractor
                    var r0 = (VnConstExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnElifGroup(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ElifGroup枝/*78*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.EndifGroup枝/*79*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 77: { // [77] EndifGroup = '#endif' ;
                    // dumped by ConstsExtractor
                    var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
                    var left = new VnEndifGroup(r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.EndifGroup枝/*79*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ErrorDirective枝/*80*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 78: { // [78] ErrorDirective = '#error' 'literalString' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnErrorDirective(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ErrorDirective枝/*80*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.PragmaDirective枝/*81*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 79: { // [79] PragmaDirective = '#pragma' 'identifier' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnPragmaDirective(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 80: { // [80] PragmaDirective = '#pragma' 'identifier' '(' ParameterList ')' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r1 = (VnParameterList)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r3 = (Token)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnPragmaDirective(r4, r3, r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 81: { // [81] PragmaDirective = '#pragma' 'identifier' '(' ')' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnPragmaDirective(r3, r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.PragmaDirective枝/*81*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ExtensionDirective枝/*82*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 82: { // [82] ExtensionDirective = '#extension' 'literalString' ':' 'literalString' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnExtensionDirective(r3, r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ExtensionDirective枝/*82*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.VersionDirective枝/*83*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 83: { // [83] VersionDirective = '#version' 'number' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnVersionDirective(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 84: { // [84] VersionDirective = '#version' 'number' 'identifier' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnVersionDirective(r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.VersionDirective枝/*83*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.LineDirective枝/*84*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 85: { // [85] LineDirective = '#line' 'number' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnLineDirective(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 86: { // [86] LineDirective = '#line' 'number' 'number' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnLineDirective(r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.LineDirective枝/*84*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ConstExp枝/*85*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 87: { // [87] ConstExp = OrOrExp ;
                    // dumped by DefaultExtractor
                    var r0 = (VnOrOrExp)context.rightStack.Pop();
                    var left = new VnConstExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ConstExp枝/*85*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.OrOrExp枝/*86*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 88: { // [88] OrOrExp = AndAndExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnAndAndExp)context.rightStack.Pop();
                    var left = new VnOrOrExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 89: { // [89] OrOrExp = OrOrExp '||' AndAndExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnAndAndExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnOrOrExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.OrOrExp枝/*86*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.AndAndExp枝/*87*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 90: { // [90] AndAndExp = OrExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnOrExp)context.rightStack.Pop();
                    var left = new VnAndAndExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 91: { // [91] AndAndExp = AndAndExp '&&' OrExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnOrExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnAndAndExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.AndAndExp枝/*87*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.OrExp枝/*88*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 92: { // [92] OrExp = XorExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnXorExp)context.rightStack.Pop();
                    var left = new VnOrExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 93: { // [93] OrExp = OrExp '|' XorExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnXorExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnOrExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.OrExp枝/*88*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.XorExp枝/*89*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 94: { // [94] XorExp = AndExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnAndExp)context.rightStack.Pop();
                    var left = new VnXorExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 95: { // [95] XorExp = XorExp '^' AndExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnAndExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnXorExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.XorExp枝/*89*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.AndExp枝/*90*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 96: { // [96] AndExp = EqualExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnEqualExp)context.rightStack.Pop();
                    var left = new VnAndExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 97: { // [97] AndExp = AndExp '&' EqualExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnEqualExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnAndExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.AndExp枝/*90*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.EqualExp枝/*91*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 98: { // [98] EqualExp = RelationExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnRelationExp)context.rightStack.Pop();
                    var left = new VnEqualExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 99: { // [99] EqualExp = EqualExp '==' RelationExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnRelationExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnEqualExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 100: { // [100] EqualExp = EqualExp '!=' RelationExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnRelationExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnEqualExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.EqualExp枝/*91*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.RelationExp枝/*92*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 101: { // [101] RelationExp = ShiftExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnShiftExp)context.rightStack.Pop();
                    var left = new VnRelationExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 102: { // [102] RelationExp = RelationExp '<' ShiftExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnShiftExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnRelationExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 103: { // [103] RelationExp = RelationExp '>' ShiftExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnShiftExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnRelationExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 104: { // [104] RelationExp = RelationExp '<=' ShiftExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnShiftExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnRelationExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 105: { // [105] RelationExp = RelationExp '>=' ShiftExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnShiftExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnRelationExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.RelationExp枝/*92*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.ShiftExp枝/*93*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 106: { // [106] ShiftExp = AddExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnAddExp)context.rightStack.Pop();
                    var left = new VnShiftExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 107: { // [107] ShiftExp = ShiftExp '<<' AddExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnAddExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnShiftExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 108: { // [108] ShiftExp = ShiftExp '>>' AddExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnAddExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnShiftExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.ShiftExp枝/*93*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.AddExp枝/*94*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 109: { // [109] AddExp = MultiExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnMultiExp)context.rightStack.Pop();
                    var left = new VnAddExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 110: { // [110] AddExp = AddExp '+' MultiExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnMultiExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnAddExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 111: { // [111] AddExp = AddExp '-' MultiExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnMultiExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnAddExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.AddExp枝/*94*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.MultiExp枝/*95*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 112: { // [112] MultiExp = UnaryExp ;
                    // dumped by ListExtractor 1
                    var r0 = (VnUnaryExp)context.rightStack.Pop();
                    var left = new VnMultiExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 113: { // [113] MultiExp = MultiExp '*' UnaryExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnUnaryExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnMultiExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 114: { // [114] MultiExp = MultiExp '/' UnaryExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnUnaryExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnMultiExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                case 115: { // [115] MultiExp = MultiExp '%' UnaryExp ;
                    // dumped by ListExtractor 2
                    var r0 = (VnUnaryExp)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r2 = (VnMultiExp)context.rightStack.Pop();
                    var left = r2;
                    left.Add(r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.MultiExp枝/*95*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.UnaryExp枝/*96*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 116: { // [116] UnaryExp = PrimaryExp ;
                    // dumped by ReversedListExtractor 1
                    var r0 = (VnPrimaryExp)context.rightStack.Pop();
                    var left = new VnUnaryExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 117: { // [117] UnaryExp = UnaryOp UnaryExp ;
                    // dumped by ReversedListExtractor 2
                    var r0 = (VnUnaryExp)context.rightStack.Pop();
                    var r1 = (VnUnaryOp)context.rightStack.Pop();
                    var left = r0;
                    left.Insert(r1);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.UnaryExp枝/*96*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.UnaryOp枝/*97*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 118: { // [118] UnaryOp = 'defined' ;
                    // dumped by ConstsExtractor
                    var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
                    var left = new VnUnaryOp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 119: { // [119] UnaryOp = '+' ;
                    // dumped by ConstsExtractor
                    var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
                    var left = new VnUnaryOp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 120: { // [120] UnaryOp = '-' ;
                    // dumped by ConstsExtractor
                    var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
                    var left = new VnUnaryOp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 121: { // [121] UnaryOp = '~' ;
                    // dumped by ConstsExtractor
                    var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
                    var left = new VnUnaryOp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 122: { // [122] UnaryOp = '!' ;
                    // dumped by ConstsExtractor
                    var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
                    var left = new VnUnaryOp(r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.UnaryOp枝/*97*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.PrimaryExp枝/*98*/ - lexiVtCount] = static (node, context) => {
                System.Diagnostics.Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 123: { // [123] PrimaryExp = 'number' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnPrimaryExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 124: { // [124] PrimaryExp = 'identifier' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();
                    var left = new VnPrimaryExp(r0);
                    context.rightStack.Push(left);
                }
                break;
                case 125: { // [125] PrimaryExp = '(' ConstExp ')' ;
                    // dumped by DefaultExtractor
                    var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var r1 = (VnConstExp)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();// reserved word is omissible
                    var left = new VnPrimaryExp(r2, r1, r0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.PrimaryExp枝/*98*/ - lexiVtCount] = (node, context) => { ... };

        }
    }
}