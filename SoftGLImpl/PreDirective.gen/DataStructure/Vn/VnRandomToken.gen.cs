using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// Correspond to the Vn node RandomToken in the grammar(PreDirective).
    /// </summary>
    internal partial class VnRandomToken : IFullFormat {
        // [016] RandomToken = 'identifier' ;
        // [017] RandomToken = 'intConstant' ;
        // [018] RandomToken = 'uintConstant' ;
        // [019] RandomToken = 'floatConstant' ;
        // [020] RandomToken = 'boolConstant' ;
        // [021] RandomToken = 'doubleConstant' ;
        // [022] RandomToken = ';' ;
        // [023] RandomToken = '(' ;
        // [024] RandomToken = ')' ;
        // [025] RandomToken = '[' ;
        // [026] RandomToken = ']' ;
        // [027] RandomToken = '.' ;
        // [028] RandomToken = '++' ;
        // [029] RandomToken = '--' ;
        // [030] RandomToken = ',' ;
        // [031] RandomToken = '+' ;
        // [032] RandomToken = '-' ;
        // [033] RandomToken = '!' ;
        // [034] RandomToken = '~' ;
        // [035] RandomToken = '*' ;
        // [036] RandomToken = '/' ;
        // [037] RandomToken = '%' ;
        // [038] RandomToken = '<<' ;
        // [039] RandomToken = '>>' ;
        // [040] RandomToken = '<' ;
        // [041] RandomToken = '>' ;
        // [042] RandomToken = '<=' ;
        // [043] RandomToken = '>=' ;
        // [044] RandomToken = '==' ;
        // [045] RandomToken = '!=' ;
        // [046] RandomToken = '&' ;
        // [047] RandomToken = '^' ;
        // [048] RandomToken = '|' ;
        // [049] RandomToken = '&&' ;
        // [050] RandomToken = '^^' ;
        // [051] RandomToken = '||' ;
        // [052] RandomToken = '?' ;
        // [053] RandomToken = ':' ;
        // [054] RandomToken = '=' ;
        // [055] RandomToken = '*=' ;
        // [056] RandomToken = '/=' ;
        // [057] RandomToken = '%=' ;
        // [058] RandomToken = '+=' ;
        // [059] RandomToken = '-=' ;
        // [060] RandomToken = '<<=' ;
        // [061] RandomToken = '>>=' ;
        // [062] RandomToken = '&=' ;
        // [063] RandomToken = '^=' ;
        // [064] RandomToken = '|=' ;
        // [065] RandomToken = '{' ;
        // [066] RandomToken = '}' ;
        // [067] RandomToken = '##' ;


        private readonly IFullFormat complex;

        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.complex, preConfig, writer);
        }


        // [016] RandomToken = 'identifier' ;
        public VnRandomToken(Token r0) {
            this.complex = new complex0(r0);
            this._scope = new TokenRange(r0);
        }
        class complex0 : IFullFormat {
            private readonly TokenRange _scope;
            public TokenRange Scope => _scope;
            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(r0, preConfig, writer);
            }
            public readonly Token r0;
            public complex0(Token r0) {
                this.r0 = r0;
                this._scope = new TokenRange(r0);
            }
        }

        // [017] RandomToken = 'intConstant' ;
        // complex1 repeated with complex0

        // [018] RandomToken = 'uintConstant' ;
        // complex2 repeated with complex0

        // [019] RandomToken = 'floatConstant' ;
        // complex3 repeated with complex0

        // [020] RandomToken = 'boolConstant' ;
        // complex4 repeated with complex0

        // [021] RandomToken = 'doubleConstant' ;
        // complex5 repeated with complex0

        // [022] RandomToken = ';' ;
        // complex6 repeated with complex0

        // [023] RandomToken = '(' ;
        // complex7 repeated with complex0

        // [024] RandomToken = ')' ;
        // complex8 repeated with complex0

        // [025] RandomToken = '[' ;
        // complex9 repeated with complex0

        // [026] RandomToken = ']' ;
        // complex10 repeated with complex0

        // [027] RandomToken = '.' ;
        // complex11 repeated with complex0

        // [028] RandomToken = '++' ;
        // complex12 repeated with complex0

        // [029] RandomToken = '--' ;
        // complex13 repeated with complex0

        // [030] RandomToken = ',' ;
        // complex14 repeated with complex0

        // [031] RandomToken = '+' ;
        // complex15 repeated with complex0

        // [032] RandomToken = '-' ;
        // complex16 repeated with complex0

        // [033] RandomToken = '!' ;
        // complex17 repeated with complex0

        // [034] RandomToken = '~' ;
        // complex18 repeated with complex0

        // [035] RandomToken = '*' ;
        // complex19 repeated with complex0

        // [036] RandomToken = '/' ;
        // complex20 repeated with complex0

        // [037] RandomToken = '%' ;
        // complex21 repeated with complex0

        // [038] RandomToken = '<<' ;
        // complex22 repeated with complex0

        // [039] RandomToken = '>>' ;
        // complex23 repeated with complex0

        // [040] RandomToken = '<' ;
        // complex24 repeated with complex0

        // [041] RandomToken = '>' ;
        // complex25 repeated with complex0

        // [042] RandomToken = '<=' ;
        // complex26 repeated with complex0

        // [043] RandomToken = '>=' ;
        // complex27 repeated with complex0

        // [044] RandomToken = '==' ;
        // complex28 repeated with complex0

        // [045] RandomToken = '!=' ;
        // complex29 repeated with complex0

        // [046] RandomToken = '&' ;
        // complex30 repeated with complex0

        // [047] RandomToken = '^' ;
        // complex31 repeated with complex0

        // [048] RandomToken = '|' ;
        // complex32 repeated with complex0

        // [049] RandomToken = '&&' ;
        // complex33 repeated with complex0

        // [050] RandomToken = '^^' ;
        // complex34 repeated with complex0

        // [051] RandomToken = '||' ;
        // complex35 repeated with complex0

        // [052] RandomToken = '?' ;
        // complex36 repeated with complex0

        // [053] RandomToken = ':' ;
        // complex37 repeated with complex0

        // [054] RandomToken = '=' ;
        // complex38 repeated with complex0

        // [055] RandomToken = '*=' ;
        // complex39 repeated with complex0

        // [056] RandomToken = '/=' ;
        // complex40 repeated with complex0

        // [057] RandomToken = '%=' ;
        // complex41 repeated with complex0

        // [058] RandomToken = '+=' ;
        // complex42 repeated with complex0

        // [059] RandomToken = '-=' ;
        // complex43 repeated with complex0

        // [060] RandomToken = '<<=' ;
        // complex44 repeated with complex0

        // [061] RandomToken = '>>=' ;
        // complex45 repeated with complex0

        // [062] RandomToken = '&=' ;
        // complex46 repeated with complex0

        // [063] RandomToken = '^=' ;
        // complex47 repeated with complex0

        // [064] RandomToken = '|=' ;
        // complex48 repeated with complex0

        // [065] RandomToken = '{' ;
        // complex49 repeated with complex0

        // [066] RandomToken = '}' ;
        // complex50 repeated with complex0

        // [067] RandomToken = '##' ;
        // complex51 repeated with complex0



    }
}
