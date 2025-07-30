using System;
using System.Diagnostics;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class CompilerGLSL {
        /// <summary>
        /// <see cref="LRNode.type"/> -&gt; <see cref="Action{LRNode, TContext{translation_unit}}"/>
        /// </summary>
        private static readonly Action<LRNode, TContext<translation_unit>>?[]
            @translation_unitExtractorItems = new Action<LRNode, TContext<translation_unit>>[1/*'¥'*/ + 82/*Vn*/];

        /// <summary>
        /// initialize dict for extractor.
        /// </summary>
        private static void InitializeExtractorItems() {
            var extractorItems = @translation_unitExtractorItems;

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
                // [-1] translation_unit' = translation_unit ;
                // dumped by ExternalExtractor
                var @final = (Vntranslation_unit)context.rightStack.Pop();
                var left = new translation_unit(@final);
                context.result = left; // final step, no need to push into stack.
            }; // end of extractorItems[st.@终/*0*/] = (node, context) => { ... };
            const int lexiVtCount = 212;
            extractorItems[st.translation_unit枝/*213*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 0: { // [0] translation_unit = external_declaration ;
                    // dumped by user-defined extractor
                    var @external_declaration0 = (Vnexternal_declaration)context.rightStack.Pop();
                    var @translation_unit0 = new Vntranslation_unit(external_declaration0);
                    context.rightStack.Push(@translation_unit0);
                }
                break;
                case 1: { // [1] translation_unit = translation_unit external_declaration ;
                    // dumped by user-defined extractor
                    var @external_declaration0 = (Vnexternal_declaration)context.rightStack.Pop();
                    var @translation_unit1 = (Vntranslation_unit)context.rightStack.Pop();
                    translation_unit1.Add(external_declaration0);
                    context.rightStack.Push(@translation_unit1);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.translation_unit枝/*213*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.external_declaration枝/*214*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 2: { // [2] external_declaration = function_definition ;
                    // dumped by DefaultExtractor
                    // var r0 = (Vnfunction_definition)context.rightStack.Pop();
                    // var left = new Vnexternal_declaration(r0);
                    // context.rightStack.Push(left);
                }
                break;
                case 3: { // [3] external_declaration = declaration ;
                    // dumped by DefaultExtractor
                    // var r0 = (Vndeclaration)context.rightStack.Pop();
                    // var left = new Vnexternal_declaration(r0);
                    // context.rightStack.Push(left);
                }
                break;
                case 4: { // [4] external_declaration = ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @external_declaration0 = new empty_declaration(r0);
                    context.rightStack.Push(@external_declaration0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.external_declaration枝/*214*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_definition枝/*215*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 5: { // [5] function_definition = function_prototype compound_statement ;
                    // dumped by user-defined extractor
                    var @compound_statement0 = (Vncompound_statement)context.rightStack.Pop();
                    var @function_prototype1 = (Vnfunction_prototype)context.rightStack.Pop();
                    var @function_definition = new Vnfunction_definition(@function_prototype1, @compound_statement0);
                    context.rightStack.Push(@function_definition);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_definition枝/*215*/ - lexiVtCount] = (node, context) => { ... };
            /*
            extractorItems[st.variable_identifier枝(216) - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 6: { // [6] variable_identifier = 'identifier' ;
                    // dumped by DefaultExtractor
                    // var r0 = (Token)context.rightStack.Pop();
                    // var left = new Vnvariable_identifier(r0);
                    // context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.variable_identifier枝(216) - lexiVtCount] = (node, context) => { ... };
            */
            extractorItems[st.primary_expression枝/*217*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 7: { // [7] primary_expression = variable_identifier ;
                    // dumped by user-defined extractor
                    var @r0 = (Token)context.rightStack.Pop(); // optimized for variable_identifier
                    var @primary_expression0 = new Vnprimary_expression(@r0);
                    context.rightStack.Push(@primary_expression0);
                }
                break;
                case 8: { // [8] primary_expression = 'intConstant' ;
                    // dumped by user-defined extractor
                    var @r0 = (Token)context.rightStack.Pop();
                    var @primary_expression0 = new Vnprimary_expression(@r0);
                    context.rightStack.Push(@primary_expression0);
                }
                break;
                case 9: { // [9] primary_expression = 'uintConstant' ;
                    // dumped by user-defined extractor
                    var @r0 = (Token)context.rightStack.Pop();
                    var @primary_expression0 = new Vnprimary_expression(@r0);
                    context.rightStack.Push(@primary_expression0);
                }
                break;
                case 10: { // [10] primary_expression = 'floatConstant' ;
                    // dumped by user-defined extractor
                    var @r0 = (Token)context.rightStack.Pop();
                    var @primary_expression0 = new Vnprimary_expression(@r0);
                    context.rightStack.Push(@primary_expression0);
                }
                break;
                case 11: { // [11] primary_expression = 'boolConstant' ;
                    // dumped by user-defined extractor
                    var @r0 = (Token)context.rightStack.Pop();
                    var @primary_expression0 = new Vnprimary_expression(@r0);
                    context.rightStack.Push(@primary_expression0);
                }
                break;
                case 12: { // [12] primary_expression = 'doubleConstant' ;
                    // dumped by user-defined extractor
                    var @r0 = (Token)context.rightStack.Pop();
                    var @primary_expression0 = new Vnprimary_expression(@r0);
                    context.rightStack.Push(@primary_expression0);
                }
                break;
                case 13: { // [13] primary_expression = '(' expression ')' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @r1 = (Vnexpression)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @primary_expression0 = new Vnprimary_expression(r2, r1, r0);
                    context.rightStack.Push(@primary_expression0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.primary_expression枝/*217*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.postfix_expression枝/*218*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 14: { // [14] postfix_expression = primary_expression ;
                    // dumped by user-defined extractor
                    var @primary_expression0 = (Vnprimary_expression)context.rightStack.Pop();
                    var @postfix_expression = new Vnpostfix_expression(@primary_expression0);
                    context.rightStack.Push(@postfix_expression);
                }
                break;
                case 15: { // [15] postfix_expression = postfix_expression '[' integer_expression ']' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @integer_expression1 = (Vninteger_expression)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @postfix_expression3 = (Vnpostfix_expression)context.rightStack.Pop();
                    postfix_expression3.Add(r2, integer_expression1, r0);
                    context.rightStack.Push(@postfix_expression3);
                }
                break;
                case 16: { // [16] postfix_expression = function_call ;
                    // dumped by user-defined extractor
                    var @function_call0 = (Vnfunction_call)context.rightStack.Pop();
                    var @postfix_expression = new Vnpostfix_expression(@function_call0);
                    context.rightStack.Push(@postfix_expression);
                }
                break;
                case 17: { // [17] postfix_expression = postfix_expression '.' 'identifier' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @postfix_expression2 = (Vnpostfix_expression)context.rightStack.Pop();
                    postfix_expression2.Add(r1, r0);
                    context.rightStack.Push(@postfix_expression2);
                }
                break;
                case 18: { // [18] postfix_expression = postfix_expression '++' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @postfix_expression1 = (Vnpostfix_expression)context.rightStack.Pop();
                    postfix_expression1.Add(r0);
                    context.rightStack.Push(@postfix_expression1);
                }
                break;
                case 19: { // [19] postfix_expression = postfix_expression '--' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @postfix_expression1 = (Vnpostfix_expression)context.rightStack.Pop();
                    postfix_expression1.Add(r0);
                    context.rightStack.Push(@postfix_expression1);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.postfix_expression枝/*218*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.integer_expression枝/*219*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 20: { // [20] integer_expression = expression ;
                    // dumped by user-defined extractor
                    var @expression0 = (Vnexpression)context.rightStack.Pop();
                    var @integer_expression = new Vninteger_expression(@expression0);
                    context.rightStack.Push(@integer_expression);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.integer_expression枝/*219*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_call枝/*220*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 21: { // [21] function_call = function_call_or_method ;
                    // dumped by user-defined extractor
                    var @function_call_or_method0 = (Vnfunction_call_or_method)context.rightStack.Pop();
                    var @function_call = new Vnfunction_call(@function_call_or_method0);
                    context.rightStack.Push(@function_call);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_call枝/*220*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_call_or_method枝/*221*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 22: { // [22] function_call_or_method = function_call_generic ;
                    // dumped by user-defined extractor
                    var @function_call_generic0 = (Vnfunction_call_generic)context.rightStack.Pop();
                    var @function_call_or_method = new Vnfunction_call_or_method(@function_call_generic0);
                    context.rightStack.Push(@function_call_or_method);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_call_or_method枝/*221*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_call_generic枝/*222*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 23: { // [23] function_call_generic = function_call_header_with_parameters ')' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @r1 = (Vnfunction_call_header_with_parameters)context.rightStack.Pop();
                    var @function_call_generic = new function_call_with_parameters(r1, r0);
                    context.rightStack.Push(@function_call_generic);
                }
                break;
                case 24: { // [24] function_call_generic = function_call_header_no_parameters ')' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @r1 = (Vnfunction_call_header_no_parameters)context.rightStack.Pop();
                    var @function_call_generic = new function_call_no_parameters(@r1, r0);
                    context.rightStack.Push(@function_call_generic);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_call_generic枝/*222*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_call_header_no_parameters枝/*223*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 25: { // [25] function_call_header_no_parameters = function_call_header 'void' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @function_call_header1 = (Vnfunction_call_header)context.rightStack.Pop();
                    var r2 = new Vnfunction_call_header_no_parameters(@function_call_header1, r0);
                    context.rightStack.Push(@r2);
                }
                break;
                case 26: { // [26] function_call_header_no_parameters = function_call_header ;
                    // dumped by user-defined extractor
                    var @function_call_header1 = (Vnfunction_call_header)context.rightStack.Pop();
                    var r2 = new Vnfunction_call_header_no_parameters(@function_call_header1, null);
                    context.rightStack.Push(@r2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_call_header_no_parameters枝/*223*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_call_header_with_parameters枝/*224*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 27: { // [27] function_call_header_with_parameters = function_call_header assignment_expression ;
                    // dumped by user-defined extractor
                    var @assignment_expression0 = (Vnassignment_expression)context.rightStack.Pop();
                    var @function_call_header1 = (Vnfunction_call_header)context.rightStack.Pop();
                    var left = new Vnfunction_call_header_with_parameters(@function_call_header1, @assignment_expression0);
                    context.rightStack.Push(left);
                }
                break;
                case 28: { // [28] function_call_header_with_parameters = function_call_header_with_parameters ',' assignment_expression ;
                    // dumped by user-defined extractor
                    var @assignment_expression0 = (Vnassignment_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var left = (Vnfunction_call_header_with_parameters)context.rightStack.Pop();
                    left.Add(r1, assignment_expression0);
                    context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_call_header_with_parameters枝/*224*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_call_header枝/*225*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 29: { // [29] function_call_header = function_identifier '(' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @function_identifier1 = (Vnfunction_identifier)context.rightStack.Pop();
                    var @function_call_header = new Vnfunction_call_header(@function_identifier1, r0);
                    context.rightStack.Push(@function_call_header);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_call_header枝/*225*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_identifier枝/*226*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 30: { // [30] function_identifier = type_specifier ;
                    // dumped by user-defined extractor
                    var @type_specifier0 = (Vntype_specifier)context.rightStack.Pop();
                    var @function_identifier0 = new function_identifier_type_specifier(@type_specifier0);
                    context.rightStack.Push(@function_identifier0);
                }
                break;
                case 31: { // [31] function_identifier = postfix_expression ;
                    // dumped by user-defined extractor
                    var @postfix_expression0 = (Vnpostfix_expression)context.rightStack.Pop();
                    var @function_identifier0 = new function_identifier_postfix_expression(@postfix_expression0);
                    context.rightStack.Push(@function_identifier0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_identifier枝/*226*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.unary_expression枝/*227*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 32: { // [32] unary_expression = postfix_expression ;
                    // dumped by user-defined extractor
                    var @postfix_expression0 = (Vnpostfix_expression)context.rightStack.Pop();
                    var @unary_expression = new Vnunary_expression(@postfix_expression0);
                    context.rightStack.Push(@unary_expression);
                }
                break;
                case 33: { // [33] unary_expression = '++' unary_expression ;
                    // dumped by user-defined extractor
                    var @unary_expression0 = (Vnunary_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    unary_expression0.Insert(r1);
                    context.rightStack.Push(@unary_expression0);
                }
                break;
                case 34: { // [34] unary_expression = '--' unary_expression ;
                    // dumped by user-defined extractor
                    var @unary_expression0 = (Vnunary_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    unary_expression0.Insert(r1);
                    context.rightStack.Push(@unary_expression0);
                }
                break;
                case 35: { // [35] unary_expression = unary_operator unary_expression ;
                    // dumped by user-defined extractor
                    var @unary_expression0 = (Vnunary_expression)context.rightStack.Pop();
                    var @unary_operator1 = (Vnunary_operator)context.rightStack.Pop();
                    unary_expression0.Insert(unary_operator1);
                    context.rightStack.Push(@unary_expression0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.unary_expression枝/*227*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.unary_operator枝/*228*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 36: { // [36] unary_operator = '+' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @unary_operator0 = new Vnunary_operator(r0);
                    context.rightStack.Push(@unary_operator0);
                }
                break;
                case 37: { // [37] unary_operator = '-' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @unary_operator0 = new Vnunary_operator(r0);
                    context.rightStack.Push(@unary_operator0);
                }
                break;
                case 38: { // [38] unary_operator = '!' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @unary_operator0 = new Vnunary_operator(r0);
                    context.rightStack.Push(@unary_operator0);
                }
                break;
                case 39: { // [39] unary_operator = '~' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @unary_operator0 = new Vnunary_operator(r0);
                    context.rightStack.Push(@unary_operator0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.unary_operator枝/*228*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.multiplicative_expression枝/*229*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 40: { // [40] multiplicative_expression = unary_expression ;
                    // dumped by user-defined extractor
                    var @unary_expression0 = (Vnunary_expression)context.rightStack.Pop();
                    var @multiplicative_expression0 = new Vnmultiplicative_expression(@unary_expression0);
                    context.rightStack.Push(@multiplicative_expression0);
                }
                break;
                case 41: { // [41] multiplicative_expression = multiplicative_expression '*' unary_expression ;
                    // dumped by user-defined extractor
                    var r0 = (Vnunary_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var r2 = (Vnmultiplicative_expression)context.rightStack.Pop();
                    r2.Add(r1, r0);
                    context.rightStack.Push(r2);
                }
                break;
                case 42: { // [42] multiplicative_expression = multiplicative_expression '/' unary_expression ;
                    // dumped by user-defined extractor
                    var r0 = (Vnunary_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @r2 = (Vnmultiplicative_expression)context.rightStack.Pop();
                    r2.Add(r1, r0);
                    context.rightStack.Push(@r2);
                }
                break;
                case 43: { // [43] multiplicative_expression = multiplicative_expression '%' unary_expression ;
                    // dumped by user-defined extractor
                    var @r0 = (Vnunary_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @r2 = (Vnmultiplicative_expression)context.rightStack.Pop();
                    r2.Add(r1, r0);
                    context.rightStack.Push(@r2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.multiplicative_expression枝/*229*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.additive_expression枝/*230*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 44: { // [44] additive_expression = multiplicative_expression ;
                    // dumped by user-defined extractor
                    var @multiplicative_expression0 = (Vnmultiplicative_expression)context.rightStack.Pop();
                    var @additive_expression0 = new Vnadditive_expression(@multiplicative_expression0);
                    context.rightStack.Push(@additive_expression0);
                }
                break;
                case 45: { // [45] additive_expression = additive_expression '+' multiplicative_expression ;
                    // dumped by user-defined extractor
                    var @multiplicative_expression0 = (Vnmultiplicative_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @additive_expression2 = (Vnadditive_expression)context.rightStack.Pop();
                    additive_expression2.Add(r1, multiplicative_expression0);
                    context.rightStack.Push(@additive_expression2);
                }
                break;
                case 46: { // [46] additive_expression = additive_expression '-' multiplicative_expression ;
                    // dumped by user-defined extractor
                    var @multiplicative_expression0 = (Vnmultiplicative_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @additive_expression2 = (Vnadditive_expression)context.rightStack.Pop();
                    additive_expression2.Add(r1, multiplicative_expression0);
                    context.rightStack.Push(@additive_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.additive_expression枝/*230*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.shift_expression枝/*231*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 47: { // [47] shift_expression = additive_expression ;
                    // dumped by user-defined extractor
                    var @additive_expression0 = (Vnadditive_expression)context.rightStack.Pop();
                    var @shift_expression0 = new Vnshift_expression(@additive_expression0);
                    context.rightStack.Push(@shift_expression0);
                }
                break;
                case 48: { // [48] shift_expression = shift_expression '<<' additive_expression ;
                    // dumped by user-defined extractor
                    var @additive_expression0 = (Vnadditive_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @shift_expression2 = (Vnshift_expression)context.rightStack.Pop();
                    shift_expression2.Add(r1, additive_expression0);
                    context.rightStack.Push(@shift_expression2);
                }
                break;
                case 49: { // [49] shift_expression = shift_expression '>>' additive_expression ;
                    // dumped by user-defined extractor
                    var @additive_expression0 = (Vnadditive_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @shift_expression2 = (Vnshift_expression)context.rightStack.Pop();
                    shift_expression2.Add(r1, additive_expression0);
                    context.rightStack.Push(@shift_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.shift_expression枝/*231*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.relational_expression枝/*232*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 50: { // [50] relational_expression = shift_expression ;
                    // dumped by user-defined extractor
                    var @shift_expression0 = (Vnshift_expression)context.rightStack.Pop();
                    var @relational_expression = new Vnrelational_expression(@shift_expression0);
                    context.rightStack.Push(@relational_expression);
                }
                break;
                case 51: { // [51] relational_expression = relational_expression '<' shift_expression ;
                    // dumped by user-defined extractor
                    var @shift_expression0 = (Vnshift_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @relational_expression2 = (Vnrelational_expression)context.rightStack.Pop();
                    relational_expression2.Add(r1, shift_expression0);
                    context.rightStack.Push(@relational_expression2);
                }
                break;
                case 52: { // [52] relational_expression = relational_expression '>' shift_expression ;
                    // dumped by user-defined extractor
                    var @shift_expression0 = (Vnshift_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @relational_expression2 = (Vnrelational_expression)context.rightStack.Pop();
                    relational_expression2.Add(r1, shift_expression0);
                    context.rightStack.Push(@relational_expression2);
                }
                break;
                case 53: { // [53] relational_expression = relational_expression '<=' shift_expression ;
                    // dumped by user-defined extractor
                    var @shift_expression0 = (Vnshift_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @relational_expression2 = (Vnrelational_expression)context.rightStack.Pop();
                    relational_expression2.Add(r1, shift_expression0);
                    context.rightStack.Push(@relational_expression2);
                }
                break;
                case 54: { // [54] relational_expression = relational_expression '>=' shift_expression ;
                    // dumped by user-defined extractor
                    var @shift_expression0 = (Vnshift_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @relational_expression2 = (Vnrelational_expression)context.rightStack.Pop();
                    relational_expression2.Add(r1, shift_expression0);
                    context.rightStack.Push(@relational_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.relational_expression枝/*232*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.equality_expression枝/*233*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 55: { // [55] equality_expression = relational_expression ;
                    // dumped by user-defined extractor
                    var @relational_expression0 = (Vnrelational_expression)context.rightStack.Pop();
                    var @equality_expression0 = new Vnequality_expression(relational_expression0);
                    context.rightStack.Push(@equality_expression0);
                }
                break;
                case 56: { // [56] equality_expression = equality_expression '==' relational_expression ;
                    // dumped by user-defined extractor
                    var @relational_expression0 = (Vnrelational_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @equality_expression2 = (Vnequality_expression)context.rightStack.Pop();
                    equality_expression2.Add(r1, relational_expression0);
                    context.rightStack.Push(@equality_expression2);
                }
                break;
                case 57: { // [57] equality_expression = equality_expression '!=' relational_expression ;
                    // dumped by user-defined extractor
                    var @relational_expression0 = (Vnrelational_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @equality_expression2 = (Vnequality_expression)context.rightStack.Pop();
                    equality_expression2.Add(r1, relational_expression0);
                    context.rightStack.Push(@equality_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.equality_expression枝/*233*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.and_expression枝/*234*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 58: { // [58] and_expression = equality_expression ;
                    // dumped by user-defined extractor
                    var @equality_expression0 = (Vnequality_expression)context.rightStack.Pop();
                    var @and_expression0 = new Vnand_expression(equality_expression0);
                    context.rightStack.Push(@and_expression0);
                }
                break;
                case 59: { // [59] and_expression = and_expression '&' equality_expression ;
                    // dumped by user-defined extractor
                    var @equality_expression0 = (Vnequality_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @and_expression2 = (Vnand_expression)context.rightStack.Pop();
                    and_expression2.Add(r1, equality_expression0);
                    context.rightStack.Push(@and_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.and_expression枝/*234*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.exclusive_or_expression枝/*235*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 60: { // [60] exclusive_or_expression = and_expression ;
                    // dumped by user-defined extractor
                    var @and_expression0 = (Vnand_expression)context.rightStack.Pop();
                    var @exclusive_or_expression0 = new Vnexclusive_or_expression(and_expression0);
                    context.rightStack.Push(@exclusive_or_expression0);
                }
                break;
                case 61: { // [61] exclusive_or_expression = exclusive_or_expression '^' and_expression ;
                    // dumped by user-defined extractor
                    var @and_expression0 = (Vnand_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @exclusive_or_expression2 = (Vnexclusive_or_expression)context.rightStack.Pop();
                    exclusive_or_expression2.Add(r1, and_expression0);
                    context.rightStack.Push(@exclusive_or_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.exclusive_or_expression枝/*235*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.inclusive_or_expression枝/*236*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 62: { // [62] inclusive_or_expression = exclusive_or_expression ;
                    // dumped by user-defined extractor
                    var @exclusive_or_expression0 = (Vnexclusive_or_expression)context.rightStack.Pop();
                    var @inclusive_or_expression0 = new Vninclusive_or_expression(exclusive_or_expression0);
                    context.rightStack.Push(@inclusive_or_expression0);
                }
                break;
                case 63: { // [63] inclusive_or_expression = inclusive_or_expression '|' exclusive_or_expression ;
                    // dumped by user-defined extractor
                    var @exclusive_or_expression0 = (Vnexclusive_or_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @inclusive_or_expression2 = (Vninclusive_or_expression)context.rightStack.Pop();
                    inclusive_or_expression2.Add(r1, exclusive_or_expression0);
                    context.rightStack.Push(@inclusive_or_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.inclusive_or_expression枝/*236*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.logical_and_expression枝/*237*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 64: { // [64] logical_and_expression = inclusive_or_expression ;
                    // dumped by user-defined extractor
                    var @inclusive_or_expression0 = (Vninclusive_or_expression)context.rightStack.Pop();
                    var @logical_and_expression0 = new Vnlogical_and_expression(inclusive_or_expression0);
                    context.rightStack.Push(@logical_and_expression0);
                }
                break;
                case 65: { // [65] logical_and_expression = logical_and_expression '&&' inclusive_or_expression ;
                    // dumped by user-defined extractor
                    var @inclusive_or_expression0 = (Vninclusive_or_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @logical_and_expression2 = (Vnlogical_and_expression)context.rightStack.Pop();
                    logical_and_expression2.Add(r1, inclusive_or_expression0);
                    context.rightStack.Push(@logical_and_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.logical_and_expression枝/*237*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.logical_xor_expression枝/*238*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 66: { // [66] logical_xor_expression = logical_and_expression ;
                    // dumped by user-defined extractor
                    var @logical_and_expression0 = (Vnlogical_and_expression)context.rightStack.Pop();
                    var @logical_xor_expression0 = new Vnlogical_xor_expression(logical_and_expression0);
                    context.rightStack.Push(@logical_xor_expression0);
                }
                break;
                case 67: { // [67] logical_xor_expression = logical_xor_expression '^^' logical_and_expression ;
                    // dumped by user-defined extractor
                    var @logical_and_expression0 = (Vnlogical_and_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @logical_xor_expression2 = (Vnlogical_xor_expression)context.rightStack.Pop();
                    logical_xor_expression2.Add(r1, logical_and_expression0);
                    context.rightStack.Push(@logical_xor_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.logical_xor_expression枝/*238*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.logical_or_expression枝/*239*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 68: { // [68] logical_or_expression = logical_xor_expression ;
                    // dumped by user-defined extractor
                    var @logical_xor_expression0 = (Vnlogical_xor_expression)context.rightStack.Pop();
                    var @logical_or_expression0 = new Vnlogical_or_expression(logical_xor_expression0);
                    context.rightStack.Push(@logical_or_expression0);
                }
                break;
                case 69: { // [69] logical_or_expression = logical_or_expression '||' logical_xor_expression ;
                    // dumped by user-defined extractor
                    var @logical_xor_expression0 = (Vnlogical_xor_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @logical_or_expression2 = (Vnlogical_or_expression)context.rightStack.Pop();
                    logical_or_expression2.Add(r1, logical_xor_expression0);
                    context.rightStack.Push(@logical_or_expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.logical_or_expression枝/*239*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.conditional_expression枝/*240*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 70: { // [70] conditional_expression = logical_or_expression ;
                    // dumped by user-defined extractor
                    var @logical_or_expression0 = (Vnlogical_or_expression)context.rightStack.Pop();
                    var @conditional_expression0 = new Vnconditional_expression(
                        @logical_or_expression0, null, null, null, null);
                    context.rightStack.Push(@conditional_expression0);
                }
                break;
                case 71: { // [71] conditional_expression = logical_or_expression '?' expression ':' assignment_expression ;
                    // dumped by user-defined extractor
                    var @assignment_expression0 = (Vnassignment_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @expression2 = (Vnexpression)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @logical_or_expression4 = (Vnlogical_or_expression)context.rightStack.Pop();
                    var @conditional_expression0 = new Vnconditional_expression(
                        @logical_or_expression4, r3, @expression2, r1, @assignment_expression0);
                    context.rightStack.Push(@conditional_expression0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.conditional_expression枝/*240*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.assignment_expression枝/*241*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 72: { // [72] assignment_expression = conditional_expression ;
                    // dumped by user-defined extractor
                    var @conditional_expression0 = (Vnconditional_expression)context.rightStack.Pop();
                    var @assignment_expression0 = new Vnassignment_expression(@conditional_expression0);
                    context.rightStack.Push(@assignment_expression0);
                }
                break;
                case 73: { // [73] assignment_expression = unary_expression assignment_operator assignment_expression ;
                    // dumped by user-defined extractor
                    var @assignment_expression0 = (Vnassignment_expression)context.rightStack.Pop();
                    var @r1 = (Vnassignment_operator)context.rightStack.Pop();
                    var @unary_expression2 = (Vnunary_expression)context.rightStack.Pop();
                    assignment_expression0.Insert(unary_expression2, r1);
                    context.rightStack.Push(@assignment_expression0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.assignment_expression枝/*241*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.assignment_operator枝/*242*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 74: { // [74] assignment_operator = '=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 75: { // [75] assignment_operator = '*=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 76: { // [76] assignment_operator = '/=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 77: { // [77] assignment_operator = '%=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 78: { // [78] assignment_operator = '+=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 79: { // [79] assignment_operator = '-=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 80: { // [80] assignment_operator = '<<=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 81: { // [81] assignment_operator = '>>=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 82: { // [82] assignment_operator = '&=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 83: { // [83] assignment_operator = '^=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                case 84: { // [84] assignment_operator = '|=' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @assignment_operator0 = new Vnassignment_operator(r0);
                    context.rightStack.Push(@assignment_operator0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.assignment_operator枝/*242*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.expression枝/*243*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 85: { // [85] expression = assignment_expression ;
                    // dumped by user-defined extractor
                    var @assignment_expression0 = (Vnassignment_expression)context.rightStack.Pop();
                    var @expression0 = new Vnexpression(assignment_expression0);
                    context.rightStack.Push(@expression0);
                }
                break;
                case 86: { // [86] expression = expression ',' assignment_expression ;
                    // dumped by user-defined extractor
                    var @assignment_expression0 = (Vnassignment_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @expression2 = (Vnexpression)context.rightStack.Pop();
                    expression2.Add(r1, assignment_expression0);
                    context.rightStack.Push(@expression2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.expression枝/*243*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.constant_expression枝/*244*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 87: { // [87] constant_expression = conditional_expression ;
                    // dumped by user-defined extractor
                    var @conditional_expression0 = (Vnconditional_expression)context.rightStack.Pop();
                    var @constant_expression = new Vnconstant_expression(@conditional_expression0);
                    context.rightStack.Push(@constant_expression);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.constant_expression枝/*244*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.declaration枝/*245*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 88: { // [88] declaration = function_prototype ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @function_prototype1 = (Vnfunction_prototype)context.rightStack.Pop();
                    var @declaration = new declaration_function_prototype(@function_prototype1, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 89: { // [89] declaration = init_declarator_list ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @init_declarator_list1 = (Vninit_declarator_list)context.rightStack.Pop();
                    var @declaration = new declaration_init_declarator_list(@init_declarator_list1, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 90: { // [90] declaration = 'precision' precision_qualifier type_specifier ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier1 = (Vntype_specifier)context.rightStack.Pop();
                    var @precision_qualifier2 = (Vnprecision_qualifier)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @declaration = new declaration_precision(r3, @precision_qualifier2, @type_specifier1, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 91: { // [91] declaration = type_qualifier 'identifier' '{' struct_declaration_list '}' ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @struct_declaration_list2 = (Vnstruct_declaration_list)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @identifier4 = (Token)context.rightStack.Pop();
                    var @type_qualifier5 = (Vntype_qualifier)context.rightStack.Pop();
                    var @declaration = new declaration_type_qualifier(
                        @type_qualifier5, @identifier4, r3, @struct_declaration_list2, r1, null, null, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 92: { // [92] declaration = type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @identifier1 = (Token)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @struct_declaration_list3 = (Vnstruct_declaration_list)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();
                    var @identifier5 = (Token)context.rightStack.Pop();
                    var @type_qualifier6 = (Vntype_qualifier)context.rightStack.Pop();
                    var @declaration = new declaration_type_qualifier(
                        @type_qualifier6, @identifier5, r4, @struct_declaration_list3, r2, @identifier1, null, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 93: { // [93] declaration = type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' array_specifier ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @array_specifier1 = (Vnarray_specifier)context.rightStack.Pop();
                    var @identifier2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @struct_declaration_list4 = (Vnstruct_declaration_list)context.rightStack.Pop();
                    var r5 = (Token)context.rightStack.Pop();
                    var @identifier6 = (Token)context.rightStack.Pop();
                    var @type_qualifier7 = (Vntype_qualifier)context.rightStack.Pop();
                    var @declaration = new declaration_type_qualifier(
                        @type_qualifier7, @identifier6, r5, @struct_declaration_list4, r3, @identifier2, @array_specifier1, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 94: { // [94] declaration = type_qualifier ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_qualifier1 = (Vntype_qualifier)context.rightStack.Pop();
                    var @declaration = new declaration_identifiers(
                        @type_qualifier1, null, null, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 95: { // [95] declaration = type_qualifier 'identifier' ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @identifier1 = (Token)context.rightStack.Pop();
                    var @type_qualifier2 = (Vntype_qualifier)context.rightStack.Pop();
                    var @declaration = new declaration_identifiers(
                        @type_qualifier2, @identifier1, null, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                case 96: { // [96] declaration = type_qualifier 'identifier' identifier_list ';' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @identifier_list1 = (Vnidentifier_list)context.rightStack.Pop();
                    var @identifier2 = (Token)context.rightStack.Pop();
                    var @type_qualifier3 = (Vntype_qualifier)context.rightStack.Pop();
                    var @declaration = new declaration_identifiers(
                        @type_qualifier3, @identifier2, @identifier_list1, r0);
                    context.rightStack.Push(@declaration);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.declaration枝/*245*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.identifier_list枝/*246*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 97: { // [97] identifier_list = ',' 'identifier' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @identifier_list0 = new Vnidentifier_list(r1, r0);
                    context.rightStack.Push(@identifier_list0);
                }
                break;
                case 98: { // [98] identifier_list = identifier_list ',' 'identifier' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var r2 = (Vnidentifier_list)context.rightStack.Pop();
                    r2.Add(r1, r0);
                    context.rightStack.Push(r2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.identifier_list枝/*246*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_prototype枝/*247*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 99: { // [99] function_prototype = function_declarator ')' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @function_declarator1 = (Vnfunction_declarator)context.rightStack.Pop();
                    var @function_prototype = new Vnfunction_prototype(@function_declarator1, r0);
                    context.rightStack.Push(@function_prototype);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_prototype枝/*247*/ - lexiVtCount] = (node, context) => { ... };
            /*
            extractorItems[st.function_declarator枝(248) - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 100: { // [100] function_declarator = function_header ;
                    // dumped by InheritExtractor
                    // // class Vnfunction_header : Vnfunction_declarator
                    // var r0 = (Vnfunction_header)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 101: { // [101] function_declarator = function_header_with_parameters ;
                    // dumped by InheritExtractor
                    // // class Vnfunction_header_with_parameters : Vnfunction_declarator
                    // var r0 = (Vnfunction_header_with_parameters)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_declarator枝(248) - lexiVtCount] = (node, context) => { ... };
            */
            extractorItems[st.function_header_with_parameters枝/*249*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 102: { // [102] function_header_with_parameters = function_header parameter_declaration ;
                    // dumped by user-defined extractor
                    var @parameter_declaration0 = (Vnparameter_declaration)context.rightStack.Pop();
                    var @function_header1 = (Vnfunction_header)context.rightStack.Pop();
                    var @function_header_with_parameters0 = new Vnfunction_header_with_parameters(@function_header1, @parameter_declaration0);
                    context.rightStack.Push(@function_header_with_parameters0);
                }
                break;
                case 103: { // [103] function_header_with_parameters = function_header_with_parameters ',' parameter_declaration ;
                    // dumped by user-defined extractor
                    var r0 = (Vnparameter_declaration)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var r2 = (Vnfunction_header_with_parameters)context.rightStack.Pop();
                    r2.Add(r1, r0);
                    context.rightStack.Push(r2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_header_with_parameters枝/*249*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.function_header枝/*250*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 104: { // [104] function_header = fully_specified_type 'identifier' '(' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @identifier1 = (Token)context.rightStack.Pop();
                    var @fully_specified_type2 = (Vnfully_specified_type)context.rightStack.Pop();
                    var @function_header = new Vnfunction_header(@fully_specified_type2, @identifier1, r0);
                    context.rightStack.Push(@function_header);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.function_header枝/*250*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.parameter_declarator枝/*251*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 105: { // [105] parameter_declarator = type_specifier 'identifier' ;
                    // dumped by user-defined extractor
                    var @identifier0 = (Token)context.rightStack.Pop();
                    var @type_specifier1 = (Vntype_specifier)context.rightStack.Pop();
                    var @parameter_declarator = new Vnparameter_declarator(@type_specifier1, @identifier0, null);
                    context.rightStack.Push(@parameter_declarator);
                }
                break;
                case 106: { // [106] parameter_declarator = type_specifier 'identifier' array_specifier ;
                    // dumped by user-defined extractor
                    var @array_specifier0 = (Vnarray_specifier)context.rightStack.Pop();
                    var @identifier1 = (Token)context.rightStack.Pop();
                    var @type_specifier2 = (Vntype_specifier)context.rightStack.Pop();
                    var @parameter_declarator = new Vnparameter_declarator(@type_specifier2, @identifier1, @array_specifier0);
                    context.rightStack.Push(@parameter_declarator);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.parameter_declarator枝/*251*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.parameter_declaration枝/*252*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 107: { // [107] parameter_declaration = type_qualifier parameter_declarator ;
                    // dumped by user-defined extractor
                    var @parameter_declarator0 = (Vnparameter_declarator)context.rightStack.Pop();
                    var @type_qualifier1 = (Vntype_qualifier)context.rightStack.Pop();
                    var @parameter_declaration = new parameter_declaration_parameter_declarator(@type_qualifier1, @parameter_declarator0);
                    context.rightStack.Push(@parameter_declaration);
                }
                break;
                case 108: { // [108] parameter_declaration = parameter_declarator ;
                    // dumped by user-defined extractor
                    var @parameter_declarator0 = (Vnparameter_declarator)context.rightStack.Pop();
                    var @parameter_declaration = new parameter_declaration_parameter_declarator(null, @parameter_declarator0);
                    context.rightStack.Push(@parameter_declaration);
                }
                break;
                case 109: { // [109] parameter_declaration = type_qualifier parameter_type_specifier ;
                    // dumped by user-defined extractor
                    var @parameter_type_specifier0 = (Vnparameter_type_specifier)context.rightStack.Pop();
                    var @type_qualifier1 = (Vntype_qualifier)context.rightStack.Pop();
                    var @parameter_declaration = new parameter_declaration_type_specifier(@type_qualifier1, @parameter_type_specifier0);
                    context.rightStack.Push(@parameter_declaration);
                }
                break;
                case 110: { // [110] parameter_declaration = parameter_type_specifier ;
                    // dumped by user-defined extractor
                    var @parameter_type_specifier0 = (Vnparameter_type_specifier)context.rightStack.Pop();
                    var @parameter_declaration = new parameter_declaration_type_specifier(null, @parameter_type_specifier0);
                    context.rightStack.Push(@parameter_declaration);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.parameter_declaration枝/*252*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.parameter_type_specifier枝/*253*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 111: { // [111] parameter_type_specifier = type_specifier ;
                    // dumped by user-defined extractor
                    var @type_specifier0 = (Vntype_specifier)context.rightStack.Pop();
                    var @parameter_type_specifier = new Vnparameter_type_specifier(@type_specifier0);
                    context.rightStack.Push(@parameter_type_specifier);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.parameter_type_specifier枝/*253*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.init_declarator_list枝/*254*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 112: { // [112] init_declarator_list = single_declaration ;
                    // dumped by user-defined extractor
                    var @single_declaration0 = (Vnsingle_declaration)context.rightStack.Pop();
                    var @init_declarator_list = new Vninit_declarator_list(single_declaration0);
                    context.rightStack.Push(@init_declarator_list);
                }
                break;
                case 113: { // [113] init_declarator_list = init_declarator_list ',' 'identifier' ;
                    // dumped by user-defined extractor
                    var @identifier0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @init_declarator_list2 = (Vninit_declarator_list)context.rightStack.Pop();
                    init_declarator_list2.Add(r1, identifier0, null, null, null);
                    context.rightStack.Push(@init_declarator_list2);
                }
                break;
                case 114: { // [114] init_declarator_list = init_declarator_list ',' 'identifier' array_specifier ;
                    // dumped by user-defined extractor
                    var @array_specifier0 = (Vnarray_specifier)context.rightStack.Pop();
                    var @identifier1 = (Token)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @init_declarator_list3 = (Vninit_declarator_list)context.rightStack.Pop();
                    init_declarator_list3.Add(r2, identifier1, array_specifier0, null, null);
                    context.rightStack.Push(@init_declarator_list3);
                }
                break;
                case 115: { // [115] init_declarator_list = init_declarator_list ',' 'identifier' array_specifier '=' initializer ;
                    // dumped by user-defined extractor
                    var @initializer0 = (Vninitializer)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @array_specifier2 = (Vnarray_specifier)context.rightStack.Pop();
                    var @identifier3 = (Token)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();
                    var @init_declarator_list5 = (Vninit_declarator_list)context.rightStack.Pop();
                    init_declarator_list5.Add(r4, identifier3, array_specifier2, r1, initializer0);
                    context.rightStack.Push(@init_declarator_list5);
                }
                break;
                case 116: { // [116] init_declarator_list = init_declarator_list ',' 'identifier' '=' initializer ;
                    // dumped by user-defined extractor
                    var @initializer0 = (Vninitializer)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @identifier2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @init_declarator_list4 = (Vninit_declarator_list)context.rightStack.Pop();
                    init_declarator_list4.Add(r3, identifier2, null, r1, initializer0);
                    context.rightStack.Push(@init_declarator_list4);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.init_declarator_list枝/*254*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.single_declaration枝/*255*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 117: { // [117] single_declaration = fully_specified_type ;
                    // dumped by user-defined extractor
                    var @fully_specified_type0 = (Vnfully_specified_type)context.rightStack.Pop();
                    var @single_declaration0 = new Vnsingle_declaration(@fully_specified_type0, null, null, null, null);
                    context.rightStack.Push(@single_declaration0);
                }
                break;
                case 118: { // [118] single_declaration = fully_specified_type 'identifier' ;
                    // dumped by user-defined extractor
                    var @identifier0 = (Token)context.rightStack.Pop();
                    var @fully_specified_type1 = (Vnfully_specified_type)context.rightStack.Pop();
                    var @single_declaration0 = new Vnsingle_declaration(@fully_specified_type1, @identifier0, null, null, null);
                    context.rightStack.Push(@single_declaration0);
                }
                break;
                case 119: { // [119] single_declaration = fully_specified_type 'identifier' array_specifier ;
                    // dumped by user-defined extractor
                    var @array_specifier0 = (Vnarray_specifier)context.rightStack.Pop();
                    var @identifier1 = (Token)context.rightStack.Pop();
                    var @fully_specified_type2 = (Vnfully_specified_type)context.rightStack.Pop();
                    var @single_declaration0 = new Vnsingle_declaration(@fully_specified_type2, @identifier1, @array_specifier0, null, null);
                    context.rightStack.Push(@single_declaration0);
                }
                break;
                case 120: { // [120] single_declaration = fully_specified_type 'identifier' array_specifier '=' initializer ;
                    // dumped by user-defined extractor
                    var @initializer0 = (Vninitializer)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @array_specifier2 = (Vnarray_specifier)context.rightStack.Pop();
                    var @identifier3 = (Token)context.rightStack.Pop();
                    var @fully_specified_type4 = (Vnfully_specified_type)context.rightStack.Pop();
                    var @single_declaration0 = new Vnsingle_declaration(@fully_specified_type4, @identifier3, @array_specifier2, r1, @initializer0);
                    context.rightStack.Push(@single_declaration0);
                }
                break;
                case 121: { // [121] single_declaration = fully_specified_type 'identifier' '=' initializer ;
                    // dumped by user-defined extractor
                    var @initializer0 = (Vninitializer)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @identifier2 = (Token)context.rightStack.Pop();
                    var @fully_specified_type3 = (Vnfully_specified_type)context.rightStack.Pop();
                    var @single_declaration0 = new Vnsingle_declaration(@fully_specified_type3, @identifier2, null, r1, @initializer0);
                    context.rightStack.Push(@single_declaration0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.single_declaration枝/*255*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.fully_specified_type枝/*256*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 122: { // [122] fully_specified_type = type_specifier ;
                    // dumped by user-defined extractor
                    var @type_specifier0 = (Vntype_specifier)context.rightStack.Pop();
                    var @fully_specified_type = new Vnfully_specified_type(null, @type_specifier0);
                    context.rightStack.Push(@fully_specified_type);
                }
                break;
                case 123: { // [123] fully_specified_type = type_qualifier type_specifier ;
                    // dumped by user-defined extractor
                    var @type_specifier0 = (Vntype_specifier)context.rightStack.Pop();
                    var @type_qualifier1 = (Vntype_qualifier)context.rightStack.Pop();
                    var @fully_specified_type = new Vnfully_specified_type(@type_qualifier1, @type_specifier0);
                    context.rightStack.Push(@fully_specified_type);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.fully_specified_type枝/*256*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.invariant_qualifier枝/*257*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 124: { // [124] invariant_qualifier = 'invariant' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @invariant_qualifier0 = new Vninvariant_qualifier(r0);
                    context.rightStack.Push(@invariant_qualifier0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.invariant_qualifier枝/*257*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.interpolation_qualifier枝/*258*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 125: { // [125] interpolation_qualifier = 'smooth' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @interpolation_qualifier0 = new Vninterpolation_qualifier(r0);
                    context.rightStack.Push(@interpolation_qualifier0);
                }
                break;
                case 126: { // [126] interpolation_qualifier = 'flat' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @interpolation_qualifier0 = new Vninterpolation_qualifier(r0);
                    context.rightStack.Push(@interpolation_qualifier0);
                }
                break;
                case 127: { // [127] interpolation_qualifier = 'noperspective' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @interpolation_qualifier0 = new Vninterpolation_qualifier(r0);
                    context.rightStack.Push(@interpolation_qualifier0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.interpolation_qualifier枝/*258*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.layout_qualifier枝/*259*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 128: { // [128] layout_qualifier = 'layout' '(' layout_qualifier_id_list ')' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @layout_qualifier_id_list1 = (Vnlayout_qualifier_id_list)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @layout_qualifier = new Vnlayout_qualifier(r3, r2, @layout_qualifier_id_list1, r0);
                    context.rightStack.Push(@layout_qualifier);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.layout_qualifier枝/*259*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.layout_qualifier_id_list枝/*260*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 129: { // [129] layout_qualifier_id_list = layout_qualifier_id ;
                    // dumped by user-defined extractor
                    var @layout_qualifier_id0 = (Vnlayout_qualifier_id)context.rightStack.Pop();
                    var @layout_qualifier_id_list0 = new Vnlayout_qualifier_id_list(layout_qualifier_id0);
                    context.rightStack.Push(@layout_qualifier_id_list0);
                }
                break;
                case 130: { // [130] layout_qualifier_id_list = layout_qualifier_id_list ',' layout_qualifier_id ;
                    // dumped by user-defined extractor
                    var @layout_qualifier_id0 = (Vnlayout_qualifier_id)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @layout_qualifier_id_list2 = (Vnlayout_qualifier_id_list)context.rightStack.Pop();
                    layout_qualifier_id_list2.Add(r1, layout_qualifier_id0);
                    context.rightStack.Push(@layout_qualifier_id_list2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.layout_qualifier_id_list枝/*260*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.layout_qualifier_id枝/*261*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 131: { // [131] layout_qualifier_id = 'identifier' ;
                    // dumped by user-defined extractor
                    var @identifier0 = (Token)context.rightStack.Pop();
                    var @layout_qualifier_id0 = new Vnlayout_qualifier_id(@identifier0, null, null);
                    context.rightStack.Push(@layout_qualifier_id0);
                }
                break;
                case 132: { // [132] layout_qualifier_id = 'identifier' '=' constant_expression ;
                    // dumped by user-defined extractor
                    var @constant_expression0 = (Vnconstant_expression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @identifier2 = (Token)context.rightStack.Pop();
                    var @layout_qualifier_id0 = new Vnlayout_qualifier_id(@identifier2, r1, @constant_expression0);
                    context.rightStack.Push(@layout_qualifier_id0);
                }
                break;
                case 133: { // [133] layout_qualifier_id = 'shared' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @layout_qualifier_id0 = new Vnlayout_qualifier_id(r0, null, null);
                    context.rightStack.Push(@layout_qualifier_id0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.layout_qualifier_id枝/*261*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.precise_qualifier枝/*262*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 134: { // [134] precise_qualifier = 'precise' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @precise_qualifier0 = new Vnprecise_qualifier(r0);
                    context.rightStack.Push(@precise_qualifier0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.precise_qualifier枝/*262*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.type_qualifier枝/*263*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 135: { // [135] type_qualifier = single_type_qualifier ;
                    // dumped by user-defined extractor
                    var @single_type_qualifier0 = (Vnsingle_type_qualifier)context.rightStack.Pop();
                    var @type_qualifier0 = new Vntype_qualifier(single_type_qualifier0);
                    context.rightStack.Push(@type_qualifier0);
                }
                break;
                case 136: { // [136] type_qualifier = type_qualifier single_type_qualifier ;
                    // dumped by user-defined extractor
                    var @single_type_qualifier0 = (Vnsingle_type_qualifier)context.rightStack.Pop();
                    var @type_qualifier1 = (Vntype_qualifier)context.rightStack.Pop();
                    type_qualifier1.Add(single_type_qualifier0);
                    context.rightStack.Push(@type_qualifier1);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.type_qualifier枝/*263*/ - lexiVtCount] = (node, context) => { ... };
            /*
            extractorItems[st.single_type_qualifier枝(264) - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 137: { // [137] single_type_qualifier = storage_qualifier ;
                    // dumped by InheritExtractor
                    // // class Vnstorage_qualifier : Vnsingle_type_qualifier
                    // var r0 = (Vnstorage_qualifier)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 138: { // [138] single_type_qualifier = layout_qualifier ;
                    // dumped by InheritExtractor
                    // // class Vnlayout_qualifier : Vnsingle_type_qualifier
                    // var r0 = (Vnlayout_qualifier)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 139: { // [139] single_type_qualifier = precision_qualifier ;
                    // dumped by InheritExtractor
                    // // class Vnprecision_qualifier : Vnsingle_type_qualifier
                    // var r0 = (Vnprecision_qualifier)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 140: { // [140] single_type_qualifier = interpolation_qualifier ;
                    // dumped by InheritExtractor
                    // // class Vninterpolation_qualifier : Vnsingle_type_qualifier
                    // var r0 = (Vninterpolation_qualifier)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 141: { // [141] single_type_qualifier = invariant_qualifier ;
                    // dumped by InheritExtractor
                    // // class Vninvariant_qualifier : Vnsingle_type_qualifier
                    // var r0 = (Vninvariant_qualifier)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 142: { // [142] single_type_qualifier = precise_qualifier ;
                    // dumped by InheritExtractor
                    // // class Vnprecise_qualifier : Vnsingle_type_qualifier
                    // var r0 = (Vnprecise_qualifier)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.single_type_qualifier枝(264) - lexiVtCount] = (node, context) => { ... };
            */
            extractorItems[st.storage_qualifier枝/*265*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 143: { // [143] storage_qualifier = 'const' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 144: { // [144] storage_qualifier = 'in' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 145: { // [145] storage_qualifier = 'out' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 146: { // [146] storage_qualifier = 'inout' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 147: { // [147] storage_qualifier = 'centroid' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 148: { // [148] storage_qualifier = 'patch' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 149: { // [149] storage_qualifier = 'sample' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 150: { // [150] storage_qualifier = 'uniform' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 151: { // [151] storage_qualifier = 'buffer' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 152: { // [152] storage_qualifier = 'shared' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 153: { // [153] storage_qualifier = 'coherent' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 154: { // [154] storage_qualifier = 'volatile' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 155: { // [155] storage_qualifier = 'restrict' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 156: { // [156] storage_qualifier = 'readonly' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 157: { // [157] storage_qualifier = 'writeonly' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 158: { // [158] storage_qualifier = 'subroutine' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @storage_qualifier0 = new Vnstorage_qualifier(r0);
                    context.rightStack.Push(@storage_qualifier0);
                }
                break;
                case 159: { // [159] storage_qualifier = 'subroutine' '(' type_name_list ')' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_name_list1 = (Vntype_name_list)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @storage_qualifier = new storage_qualifier_subroutine(
                        r3, r2, @type_name_list1, r0);
                    context.rightStack.Push(@storage_qualifier);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.storage_qualifier枝/*265*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.type_name_list枝/*266*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 160: { // [160] type_name_list = 'type_name' ;
                    // dumped by user-defined extractor
                    var @type_name0 = (Token)context.rightStack.Pop();
                    var @type_name_list0 = new Vntype_name_list(type_name0);
                    context.rightStack.Push(@type_name_list0);
                }
                break;
                case 161: { // [161] type_name_list = type_name_list ',' 'type_name' ;
                    // dumped by user-defined extractor
                    var @type_name0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @type_name_list2 = (Vntype_name_list)context.rightStack.Pop();
                    type_name_list2.Add(r1, type_name0);
                    context.rightStack.Push(@type_name_list2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.type_name_list枝/*266*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.type_specifier枝/*267*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 162: { // [162] type_specifier = type_specifier_nonarray ;
                    // dumped by user-defined extractor
                    var @type_specifier_nonarray0 = (Vntype_specifier_nonarray)context.rightStack.Pop();
                    var @type_specifier = new Vntype_specifier(@type_specifier_nonarray0, null);
                    context.rightStack.Push(@type_specifier);
                }
                break;
                case 163: { // [163] type_specifier = type_specifier_nonarray array_specifier ;
                    // dumped by user-defined extractor
                    var @array_specifier0 = (Vnarray_specifier)context.rightStack.Pop();
                    var @type_specifier_nonarray1 = (Vntype_specifier_nonarray)context.rightStack.Pop();
                    var @type_specifier = new Vntype_specifier(@type_specifier_nonarray1, @array_specifier0);
                    context.rightStack.Push(@type_specifier);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.type_specifier枝/*267*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.array_specifier枝/*268*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 164: { // [164] array_specifier = '[' ']' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @array_specifier0 = new Vnarray_specifier(r1, null, r0);
                    context.rightStack.Push(@array_specifier0);
                }
                break;
                case 165: { // [165] array_specifier = '[' conditional_expression ']' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @conditional_expression1 = (Vnconditional_expression)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @array_specifier0 = new Vnarray_specifier(r2, conditional_expression1, r0);
                    context.rightStack.Push(@array_specifier0);
                }
                break;
                case 166: { // [166] array_specifier = array_specifier '[' ']' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @array_specifier2 = (Vnarray_specifier)context.rightStack.Pop();
                    array_specifier2.Add(r1, null, r0);
                    context.rightStack.Push(@array_specifier2);
                }
                break;
                case 167: { // [167] array_specifier = array_specifier '[' conditional_expression ']' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @conditional_expression1 = (Vnconditional_expression)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @array_specifier3 = (Vnarray_specifier)context.rightStack.Pop();
                    array_specifier3.Add(r2, conditional_expression1, r0);
                    context.rightStack.Push(@array_specifier3);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.array_specifier枝/*268*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.type_specifier_nonarray枝/*269*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 168: { // [168] type_specifier_nonarray = 'void' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 169: { // [169] type_specifier_nonarray = 'float' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 170: { // [170] type_specifier_nonarray = 'double' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 171: { // [171] type_specifier_nonarray = 'int' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 172: { // [172] type_specifier_nonarray = 'uint' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 173: { // [173] type_specifier_nonarray = 'bool' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 174: { // [174] type_specifier_nonarray = 'vec2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 175: { // [175] type_specifier_nonarray = 'vec3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 176: { // [176] type_specifier_nonarray = 'vec4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 177: { // [177] type_specifier_nonarray = 'dvec2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 178: { // [178] type_specifier_nonarray = 'dvec3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 179: { // [179] type_specifier_nonarray = 'dvec4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 180: { // [180] type_specifier_nonarray = 'bvec2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 181: { // [181] type_specifier_nonarray = 'bvec3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 182: { // [182] type_specifier_nonarray = 'bvec4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 183: { // [183] type_specifier_nonarray = 'ivec2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 184: { // [184] type_specifier_nonarray = 'ivec3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 185: { // [185] type_specifier_nonarray = 'ivec4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 186: { // [186] type_specifier_nonarray = 'uvec2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 187: { // [187] type_specifier_nonarray = 'uvec3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 188: { // [188] type_specifier_nonarray = 'uvec4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 189: { // [189] type_specifier_nonarray = 'mat2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 190: { // [190] type_specifier_nonarray = 'mat3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 191: { // [191] type_specifier_nonarray = 'mat4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 192: { // [192] type_specifier_nonarray = 'mat2x2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 193: { // [193] type_specifier_nonarray = 'mat2x3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 194: { // [194] type_specifier_nonarray = 'mat2x4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 195: { // [195] type_specifier_nonarray = 'mat3x2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 196: { // [196] type_specifier_nonarray = 'mat3x3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 197: { // [197] type_specifier_nonarray = 'mat3x4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 198: { // [198] type_specifier_nonarray = 'mat4x2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 199: { // [199] type_specifier_nonarray = 'mat4x3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 200: { // [200] type_specifier_nonarray = 'mat4x4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 201: { // [201] type_specifier_nonarray = 'dmat2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 202: { // [202] type_specifier_nonarray = 'dmat3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 203: { // [203] type_specifier_nonarray = 'dmat4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 204: { // [204] type_specifier_nonarray = 'dmat2x2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 205: { // [205] type_specifier_nonarray = 'dmat2x3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 206: { // [206] type_specifier_nonarray = 'dmat2x4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 207: { // [207] type_specifier_nonarray = 'dmat3x2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 208: { // [208] type_specifier_nonarray = 'dmat3x3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 209: { // [209] type_specifier_nonarray = 'dmat3x4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 210: { // [210] type_specifier_nonarray = 'dmat4x2' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 211: { // [211] type_specifier_nonarray = 'dmat4x3' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 212: { // [212] type_specifier_nonarray = 'dmat4x4' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 213: { // [213] type_specifier_nonarray = 'atomic_uint' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 214: { // [214] type_specifier_nonarray = 'sampler2D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 215: { // [215] type_specifier_nonarray = 'sampler3D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 216: { // [216] type_specifier_nonarray = 'samplerCube' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 217: { // [217] type_specifier_nonarray = 'sampler2DShadow' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 218: { // [218] type_specifier_nonarray = 'samplerCubeShadow' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 219: { // [219] type_specifier_nonarray = 'sampler2DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 220: { // [220] type_specifier_nonarray = 'sampler2DArrayShadow' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 221: { // [221] type_specifier_nonarray = 'samplerCubeArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 222: { // [222] type_specifier_nonarray = 'samplerCubeArrayShadow' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 223: { // [223] type_specifier_nonarray = 'isampler2D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 224: { // [224] type_specifier_nonarray = 'isampler3D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 225: { // [225] type_specifier_nonarray = 'isamplerCube' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 226: { // [226] type_specifier_nonarray = 'isampler2DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 227: { // [227] type_specifier_nonarray = 'isamplerCubeArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 228: { // [228] type_specifier_nonarray = 'usampler2D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 229: { // [229] type_specifier_nonarray = 'usampler3D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 230: { // [230] type_specifier_nonarray = 'usamplerCube' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 231: { // [231] type_specifier_nonarray = 'usampler2DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 232: { // [232] type_specifier_nonarray = 'usamplerCubeArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 233: { // [233] type_specifier_nonarray = 'sampler1D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 234: { // [234] type_specifier_nonarray = 'sampler1DShadow' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 235: { // [235] type_specifier_nonarray = 'sampler1DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 236: { // [236] type_specifier_nonarray = 'sampler1DArrayShadow' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 237: { // [237] type_specifier_nonarray = 'isampler1D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 238: { // [238] type_specifier_nonarray = 'isampler1DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 239: { // [239] type_specifier_nonarray = 'usampler1D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 240: { // [240] type_specifier_nonarray = 'usampler1DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 241: { // [241] type_specifier_nonarray = 'sampler2DRect' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 242: { // [242] type_specifier_nonarray = 'sampler2DRectShadow' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 243: { // [243] type_specifier_nonarray = 'isampler2DRect' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 244: { // [244] type_specifier_nonarray = 'usampler2DRect' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 245: { // [245] type_specifier_nonarray = 'samplerBuffer' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 246: { // [246] type_specifier_nonarray = 'isamplerBuffer' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 247: { // [247] type_specifier_nonarray = 'usamplerBuffer' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 248: { // [248] type_specifier_nonarray = 'sampler2DMS' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 249: { // [249] type_specifier_nonarray = 'isampler2DMS' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 250: { // [250] type_specifier_nonarray = 'usampler2DMS' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 251: { // [251] type_specifier_nonarray = 'sampler2DMSArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 252: { // [252] type_specifier_nonarray = 'isampler2DMSArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 253: { // [253] type_specifier_nonarray = 'usampler2DMSArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 254: { // [254] type_specifier_nonarray = 'image2D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 255: { // [255] type_specifier_nonarray = 'iimage2D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 256: { // [256] type_specifier_nonarray = 'uimage2D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 257: { // [257] type_specifier_nonarray = 'image3D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 258: { // [258] type_specifier_nonarray = 'iimage3D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 259: { // [259] type_specifier_nonarray = 'uimage3D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 260: { // [260] type_specifier_nonarray = 'imageCube' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 261: { // [261] type_specifier_nonarray = 'iimageCube' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 262: { // [262] type_specifier_nonarray = 'uimageCube' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 263: { // [263] type_specifier_nonarray = 'imageBuffer' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 264: { // [264] type_specifier_nonarray = 'iimageBuffer' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 265: { // [265] type_specifier_nonarray = 'uimageBuffer' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 266: { // [266] type_specifier_nonarray = 'image1D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 267: { // [267] type_specifier_nonarray = 'iimage1D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 268: { // [268] type_specifier_nonarray = 'uimage1D' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 269: { // [269] type_specifier_nonarray = 'image1DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 270: { // [270] type_specifier_nonarray = 'iimage1DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 271: { // [271] type_specifier_nonarray = 'uimage1DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 272: { // [272] type_specifier_nonarray = 'image2DRect' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 273: { // [273] type_specifier_nonarray = 'iimage2DRect' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 274: { // [274] type_specifier_nonarray = 'uimage2DRect' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 275: { // [275] type_specifier_nonarray = 'image2DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 276: { // [276] type_specifier_nonarray = 'iimage2DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 277: { // [277] type_specifier_nonarray = 'uimage2DArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 278: { // [278] type_specifier_nonarray = 'imageCubeArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 279: { // [279] type_specifier_nonarray = 'iimageCubeArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 280: { // [280] type_specifier_nonarray = 'uimageCubeArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 281: { // [281] type_specifier_nonarray = 'image2DMS' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 282: { // [282] type_specifier_nonarray = 'iimage2DMS' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 283: { // [283] type_specifier_nonarray = 'uimage2DMS' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 284: { // [284] type_specifier_nonarray = 'image2DMSArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 285: { // [285] type_specifier_nonarray = 'iimage2DMSArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 286: { // [286] type_specifier_nonarray = 'uimage2DMSArray' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(r0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 287: { // [287] type_specifier_nonarray = struct_specifier ;
                    // dumped by user-defined extractor
                    var @struct_specifier0 = (Vnstruct_specifier)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_struct_specifier(@struct_specifier0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                case 288: { // [288] type_specifier_nonarray = 'type_name' ;
                    // dumped by user-defined extractor
                    var @type_name0 = (Token)context.rightStack.Pop();
                    var @type_specifier_nonarray = new type_specifier_nonarray_string(@type_name0);
                    context.rightStack.Push(@type_specifier_nonarray);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.type_specifier_nonarray枝/*269*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.precision_qualifier枝/*270*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 289: { // [289] precision_qualifier = 'highp' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @precision_qualifier0 = new Vnprecision_qualifier(r0);
                    context.rightStack.Push(@precision_qualifier0);
                }
                break;
                case 290: { // [290] precision_qualifier = 'mediump' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @precision_qualifier0 = new Vnprecision_qualifier(r0);
                    context.rightStack.Push(@precision_qualifier0);
                }
                break;
                case 291: { // [291] precision_qualifier = 'lowp' ;
                    // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @precision_qualifier0 = new Vnprecision_qualifier(r0);
                    context.rightStack.Push(@precision_qualifier0);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.precision_qualifier枝/*270*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.struct_specifier枝/*271*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 292: { // [292] struct_specifier = 'struct' 'type_name' '{' struct_declaration_list '}' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @struct_declaration_list1 = (Vnstruct_declaration_list)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @type_name3 = (Token)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();
                    var @struct_specifier = new Vnstruct_specifier(r4, @type_name3, r2, @struct_declaration_list1, r0);
                    context.rightStack.Push(@struct_specifier);
                }
                break;
                case 293: { // [293] struct_specifier = 'struct' '{' struct_declaration_list '}' ;
                            // dumped by user-defined extractor

                    var r0 = (Token)context.rightStack.Pop();
                    var @struct_declaration_list1 = (Vnstruct_declaration_list)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var nextId = 0; const string key = "structName";
                    if (!context.tagDict.TryGetValue(key, out var value)) {
                        context.tagDict.Add(key, nextId + 1);
                    }
                    else {
                        nextId = (int)value;
                        context.tagDict[key] = (nextId + 1);
                    }
                    var @struct_specifier = new Vnstruct_specifier(r3, nextId, r2, @struct_declaration_list1, r0);
                    context.rightStack.Push(@struct_specifier);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.struct_specifier枝/*271*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.struct_declaration_list枝/*272*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 294: { // [294] struct_declaration_list = struct_declaration ;
                            // dumped by user-defined extractor
                    var @struct_declaration0 = (Vnstruct_declaration)context.rightStack.Pop();
                    var @struct_declaration_list0 = new Vnstruct_declaration_list(struct_declaration0);
                    context.rightStack.Push(@struct_declaration_list0);
                }
                break;
                case 295: { // [295] struct_declaration_list = struct_declaration_list struct_declaration ;
                            // dumped by user-defined extractor
                    var @struct_declaration0 = (Vnstruct_declaration)context.rightStack.Pop();
                    var @struct_declaration_list1 = (Vnstruct_declaration_list)context.rightStack.Pop();
                    struct_declaration_list1.Add(struct_declaration0);
                    context.rightStack.Push(@struct_declaration_list1);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.struct_declaration_list枝/*272*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.struct_declaration枝/*273*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 296: { // [296] struct_declaration = type_specifier struct_declarator_list ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @struct_declarator_list1 = (Vnstruct_declarator_list)context.rightStack.Pop();
                    var @type_specifier2 = (Vntype_specifier)context.rightStack.Pop();
                    var @struct_declaration = new Vnstruct_declaration(
                        null, @type_specifier2, @struct_declarator_list1, r0);
                    context.rightStack.Push(@struct_declaration);
                }
                break;
                case 297: { // [297] struct_declaration = type_qualifier type_specifier struct_declarator_list ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @struct_declarator_list1 = (Vnstruct_declarator_list)context.rightStack.Pop();
                    var @type_specifier2 = (Vntype_specifier)context.rightStack.Pop();
                    var @type_qualifier3 = (Vntype_qualifier)context.rightStack.Pop();
                    var @struct_declaration = new Vnstruct_declaration(
                        @type_qualifier3, @type_specifier2, @struct_declarator_list1, r0);
                    context.rightStack.Push(@struct_declaration);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.struct_declaration枝/*273*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.struct_declarator_list枝/*274*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 298: { // [298] struct_declarator_list = struct_declarator ;
                            // dumped by user-defined extractor
                    var @struct_declarator0 = (Vnstruct_declarator)context.rightStack.Pop();
                    var @struct_declarator_list0 = new Vnstruct_declarator_list(struct_declarator0);
                    context.rightStack.Push(@struct_declarator_list0);
                }
                break;
                case 299: { // [299] struct_declarator_list = struct_declarator_list ',' struct_declarator ;
                            // dumped by user-defined extractor
                    var @struct_declarator0 = (Vnstruct_declarator)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @struct_declarator_list2 = (Vnstruct_declarator_list)context.rightStack.Pop();
                    struct_declarator_list2.Add(r1, struct_declarator0);
                    context.rightStack.Push(@struct_declarator_list2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.struct_declarator_list枝/*274*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.struct_declarator枝/*275*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 300: { // [300] struct_declarator = 'identifier' ;
                            // dumped by user-defined extractor
                    var @identifier0 = (Token)context.rightStack.Pop();
                    var @struct_declarator = new Vnstruct_declarator(@identifier0, null);
                    context.rightStack.Push(@struct_declarator);
                }
                break;
                case 301: { // [301] struct_declarator = 'identifier' array_specifier ;
                            // dumped by user-defined extractor
                    var @array_specifier0 = (Vnarray_specifier)context.rightStack.Pop();
                    var @identifier1 = (Token)context.rightStack.Pop();
                    var @struct_declarator = new Vnstruct_declarator(@identifier1, @array_specifier0);
                    context.rightStack.Push(@struct_declarator);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.struct_declarator枝/*275*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.initializer枝/*276*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 302: { // [302] initializer = assignment_expression ;
                            // dumped by user-defined extractor
                    var @assignment_expression0 = (Vnassignment_expression)context.rightStack.Pop();
                    var @initializer = new Vninitializer(@assignment_expression0);
                    context.rightStack.Push(@initializer);
                }
                break;
                case 303: { // [303] initializer = '{' initializer_list '}' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @initializer_list1 = (Vninitializer_list)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @initializer = new Vninitializer(r2, @initializer_list1, null, r0);
                    context.rightStack.Push(@initializer);
                }
                break;
                case 304: { // [304] initializer = '{' initializer_list ',' '}' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @initializer_list2 = (Vninitializer_list)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @initializer = new Vninitializer(r3, @initializer_list2, r1, r0);
                    context.rightStack.Push(@initializer);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.initializer枝/*276*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.initializer_list枝/*277*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 305: { // [305] initializer_list = initializer ;
                            // dumped by user-defined extractor
                    var @initializer0 = (Vninitializer)context.rightStack.Pop();
                    var @initializer_list = new Vninitializer_list(initializer0);
                    context.rightStack.Push(@initializer_list);
                }
                break;
                case 306: { // [306] initializer_list = initializer_list ',' initializer ;
                            // dumped by user-defined extractor
                    var @initializer0 = (Vninitializer)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @initializer_list2 = (Vninitializer_list)context.rightStack.Pop();
                    initializer_list2.Add(r1, initializer0);
                    context.rightStack.Push(@initializer_list2);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.initializer_list枝/*277*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.declaration_statement枝/*278*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 307: { // [307] declaration_statement = declaration ;
                            // dumped by user-defined extractor
                    var @declaration0 = (Vndeclaration)context.rightStack.Pop();
                    var @declaration_statement = new Vndeclaration_statement(@declaration0);
                    context.rightStack.Push(@declaration_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.declaration_statement枝/*278*/ - lexiVtCount] = (node, context) => { ... };
            /*
            extractorItems[st.statement枝(279) - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 308: { // [308] statement = compound_statement ;
                    // dumped by InheritExtractor
                    // // class Vncompound_statement : Vnstatement
                    // var r0 = (Vncompound_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 309: { // [309] statement = simple_statement ;
                    // dumped by InheritExtractor
                    // // class Vnsimple_statement : Vnstatement
                    // var r0 = (Vnsimple_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.statement枝(279) - lexiVtCount] = (node, context) => { ... };
            */
            /*
            extractorItems[st.simple_statement枝(280) - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 310: { // [310] simple_statement = declaration_statement ;
                    // dumped by InheritExtractor
                    // // class Vndeclaration_statement : Vnsimple_statement
                    // var r0 = (Vndeclaration_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 311: { // [311] simple_statement = expression_statement ;
                    // dumped by InheritExtractor
                    // // class Vnexpression_statement : Vnsimple_statement
                    // var r0 = (Vnexpression_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 312: { // [312] simple_statement = selection_statement ;
                    // dumped by InheritExtractor
                    // // class Vnselection_statement : Vnsimple_statement
                    // var r0 = (Vnselection_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 313: { // [313] simple_statement = switch_statement ;
                    // dumped by InheritExtractor
                    // // class Vnswitch_statement : Vnsimple_statement
                    // var r0 = (Vnswitch_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 314: { // [314] simple_statement = case_label ;
                    // dumped by InheritExtractor
                    // // class Vncase_label : Vnsimple_statement
                    // var r0 = (Vncase_label)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 315: { // [315] simple_statement = iteration_statement ;
                    // dumped by InheritExtractor
                    // // class Vniteration_statement : Vnsimple_statement
                    // var r0 = (Vniteration_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                case 316: { // [316] simple_statement = jump_statement ;
                    // dumped by InheritExtractor
                    // // class Vnjump_statement : Vnsimple_statement
                    // var r0 = (Vnjump_statement)context.rightStack.Pop();
                    // var left = r0;
                    // context.rightStack.Push(left);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.simple_statement枝(280) - lexiVtCount] = (node, context) => { ... };
            */
            extractorItems[st.compound_statement枝/*281*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 317: { // [317] compound_statement = '{' '}' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @compound_statement = new Vncompound_statement(r1, null, r0);
                    context.rightStack.Push(@compound_statement);
                }
                break;
                case 318: { // [318] compound_statement = '{' statement_list '}' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @statement_list1 = (Vnstatement_list)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @compound_statement = new Vncompound_statement(r2, @statement_list1, r0);
                    context.rightStack.Push(@compound_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.compound_statement枝/*281*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.statement_list枝/*282*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 319: { // [319] statement_list = statement ;
                            // dumped by user-defined extractor
                    var @statement0 = (Vnstatement)context.rightStack.Pop();
                    var @statement_list = new Vnstatement_list(statement0);
                    context.rightStack.Push(@statement_list);
                }
                break;
                case 320: { // [320] statement_list = statement_list statement ;
                            // dumped by user-defined extractor
                    var @statement0 = (Vnstatement)context.rightStack.Pop();
                    var @statement_list1 = (Vnstatement_list)context.rightStack.Pop();
                    statement_list1.Add(statement0);
                    context.rightStack.Push(@statement_list1);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.statement_list枝/*282*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.expression_statement枝/*283*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 321: { // [321] expression_statement = ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @expression_statement = new Vnexpression_statement(null, r0);
                    context.rightStack.Push(@expression_statement);
                }
                break;
                case 322: { // [322] expression_statement = expression ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @expression1 = (Vnexpression)context.rightStack.Pop();
                    var @expression_statement = new Vnexpression_statement(@expression1, r0);
                    context.rightStack.Push(@expression_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.expression_statement枝/*283*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.selection_statement枝/*284*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 323: { // [323] selection_statement = 'if' '(' expression ')' selection_rest_statement ;
                            // dumped by user-defined extractor
                    var @selection_rest_statement0 = (Vnselection_rest_statement)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @expression2 = (Vnexpression)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();
                    var @selection_statement = new Vnselection_statement(r4, r3, @expression2, r1, @selection_rest_statement0);
                    context.rightStack.Push(@selection_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.selection_statement枝/*284*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.selection_rest_statement枝/*285*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 324: { // [324] selection_rest_statement = statement 'else' statement ;
                            // dumped by user-defined extractor
                    var @statement0 = (Vnstatement)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @statement2 = (Vnstatement)context.rightStack.Pop();
                    var @selection_rest_statement = new Vnselection_rest_statement(@statement2, r1, @statement0);
                    context.rightStack.Push(@selection_rest_statement);
                }
                break;
                case 325: { // [325] selection_rest_statement = statement ;
                            // dumped by user-defined extractor
                    var @statement0 = (Vnstatement)context.rightStack.Pop();
                    var @selection_rest_statement = new Vnselection_rest_statement(@statement0, null, null);
                    context.rightStack.Push(@selection_rest_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.selection_rest_statement枝/*285*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.condition枝/*286*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 326: { // [326] condition = expression ;
                            // dumped by user-defined extractor
                    var @expression0 = (Vnexpression)context.rightStack.Pop();
                    var @condition = new condition_1(@expression0);
                    context.rightStack.Push(@condition);
                }
                break;
                case 327: { // [327] condition = fully_specified_type 'identifier' '=' initializer ;
                            // dumped by user-defined extractor
                    var @initializer0 = (Vninitializer)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @identifier2 = (Token)context.rightStack.Pop();
                    var @fully_specified_type3 = (Vnfully_specified_type)context.rightStack.Pop();
                    var @condition = new condition_2(@fully_specified_type3, @identifier2, r1, @initializer0);
                    context.rightStack.Push(@condition);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.condition枝/*286*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.switch_statement枝/*287*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 328: { // [328] switch_statement = 'switch' '(' expression ')' '{' switch_statement_list '}' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @switch_statement_list1 = (Vnswitch_statement_list)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var @expression4 = (Vnexpression)context.rightStack.Pop();
                    var r5 = (Token)context.rightStack.Pop();
                    var r6 = (Token)context.rightStack.Pop();
                    var @switch_statement = new Vnswitch_statement(r6, r5, @expression4, r3, r2, @switch_statement_list1, r0);
                    context.rightStack.Push(@switch_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.switch_statement枝/*287*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.switch_statement_list枝/*288*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 329: { // [329] switch_statement_list = null ;
                            // dumped by user-defined extractor
                    var @switch_statement_list = new Vnswitch_statement_list(null);
                    context.rightStack.Push(@switch_statement_list);
                }
                break;
                case 330: { // [330] switch_statement_list = statement_list ;
                            // dumped by user-defined extractor
                    var @statement_list0 = (Vnstatement_list)context.rightStack.Pop();
                    var @switch_statement_list = new Vnswitch_statement_list(@statement_list0);
                    context.rightStack.Push(@switch_statement_list);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.switch_statement_list枝/*288*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.case_label枝/*289*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 331: { // [331] case_label = 'case' expression ':' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @expression1 = (Vnexpression)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @case_label = new case_label_expression(r2, @expression1, r0);
                    context.rightStack.Push(@case_label);
                }
                break;
                case 332: { // [332] case_label = 'default' ':' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @case_label = new case_label_default(r1, r0);
                    context.rightStack.Push(@case_label);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.case_label枝/*289*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.iteration_statement枝/*290*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 333: { // [333] iteration_statement = 'while' '(' condition ')' statement ;
                            // dumped by user-defined extractor
                    var @statement_no_new_scope0 = (Vnstatement)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @condition2 = (Vncondition)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();
                    var @iteration_statement = new iteration_while(
                        r4, r3, @condition2, r1, @statement_no_new_scope0);
                    context.rightStack.Push(@iteration_statement);
                }
                break;
                case 334: { // [334] iteration_statement = 'do' statement 'while' '(' expression ')' ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @expression2 = (Vnexpression)context.rightStack.Pop();
                    var r3 = (Token)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();
                    var @statement5 = (Vnstatement)context.rightStack.Pop();
                    var r6 = (Token)context.rightStack.Pop();
                    var @iteration_statement = new iteration_do_while(
                        r6, @statement5, r4, r3, @expression2, r1, r0);
                    context.rightStack.Push(@iteration_statement);
                }
                break;
                case 335: { // [335] iteration_statement = 'for' '(' for_init_statement for_rest_statement ')' statement ;
                            // dumped by user-defined extractor
                    var @statement_no_new_scope0 = (Vnstatement)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @for_rest_statement2 = (Vnfor_rest_statement)context.rightStack.Pop();
                    var @for_init_statement3 = (Vnfor_init_statement)context.rightStack.Pop();
                    var r4 = (Token)context.rightStack.Pop();
                    var r5 = (Token)context.rightStack.Pop();
                    var @iteration_statement = new iteration_for(
                        r5, r4, @for_init_statement3, @for_rest_statement2, r1, @statement_no_new_scope0);
                    context.rightStack.Push(@iteration_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.iteration_statement枝/*290*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.for_init_statement枝/*291*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 336: { // [336] for_init_statement = expression_statement ;
                            // dumped by user-defined extractor
                    var @expression_statement0 = (Vnexpression_statement)context.rightStack.Pop();
                    var @for_init_statement = new Vnfor_init_statement(@expression_statement0);
                    context.rightStack.Push(@for_init_statement);
                }
                break;
                case 337: { // [337] for_init_statement = declaration_statement ;
                            // dumped by user-defined extractor
                    var @declaration_statement0 = (Vndeclaration_statement)context.rightStack.Pop();
                    var @for_init_statement = new Vnfor_init_statement(@declaration_statement0);
                    context.rightStack.Push(@for_init_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.for_init_statement枝/*291*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.conditionopt枝/*292*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 338: { // [338] conditionopt = condition ;
                            // dumped by user-defined extractor
                    var @condition0 = (Vncondition)context.rightStack.Pop();
                    var @conditionopt = new Vnconditionopt(@condition0);
                    context.rightStack.Push(@conditionopt);
                }
                break;
                case 339: { // [339] conditionopt = null ;
                            // dumped by user-defined extractor
                    var @conditionopt = new Vnconditionopt(null);
                    context.rightStack.Push(@conditionopt);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.conditionopt枝/*292*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.for_rest_statement枝/*293*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 340: { // [340] for_rest_statement = conditionopt ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @conditionopt1 = (Vnconditionopt)context.rightStack.Pop();
                    var @for_rest_statement = new Vnfor_rest_statement(@conditionopt1, r0, null);
                    context.rightStack.Push(@for_rest_statement);
                }
                break;
                case 341: { // [341] for_rest_statement = conditionopt ';' expression ;
                            // dumped by user-defined extractor
                    var @expression0 = (Vnexpression)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @conditionopt2 = (Vnconditionopt)context.rightStack.Pop();
                    var @for_rest_statement = new Vnfor_rest_statement(@conditionopt2, r1, @expression0);
                    context.rightStack.Push(@for_rest_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.for_rest_statement枝/*293*/ - lexiVtCount] = (node, context) => { ... };
            extractorItems[st.jump_statement枝/*294*/ - lexiVtCount] = static (node, context) => {
                Debug.Assert(node.regulation != null);
                switch (node.regulation.index) {
                case 342: { // [342] jump_statement = 'continue' ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @jump_statement = new continue_(r1, r0);
                    context.rightStack.Push(@jump_statement);
                }
                break;
                case 343: { // [343] jump_statement = 'break' ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @jump_statement = new break_(r1, r0);
                    context.rightStack.Push(@jump_statement);
                }
                break;
                case 344: { // [344] jump_statement = 'return' ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @jump_statement = new return_(r1, null, r0);
                    context.rightStack.Push(@jump_statement);
                }
                break;
                case 345: { // [345] jump_statement = 'return' expression ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var @expression1 = (Vnexpression)context.rightStack.Pop();
                    var r2 = (Token)context.rightStack.Pop();
                    var @jump_statement = new return_(r2, @expression1, r0);
                    context.rightStack.Push(@jump_statement);
                }
                break;
                case 346: { // [346] jump_statement = 'discard' ';' ;
                            // dumped by user-defined extractor
                    var r0 = (Token)context.rightStack.Pop();
                    var r1 = (Token)context.rightStack.Pop();
                    var @jump_statement = new discard(r1, r0);
                    context.rightStack.Push(@jump_statement);
                }
                break;
                default: throw new NotImplementedException();
                }
            }; // end of extractorItems[st.jump_statement枝/*294*/ - lexiVtCount] = (node, context) => { ... };

        }
    }
}