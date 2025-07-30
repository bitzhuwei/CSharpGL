using System;
using System.Diagnostics;
using System.Text;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Input: a list of <see cref="Token"/>.
    /// Output: a <see cref="SyntaxTree"/>.
    /// </summary>
    partial class LRSyntaxParser {

        private BCFLRParseContext? bcfContext = null;
        /// <summary>
        /// Begin/Continue/Finish
        /// <para>call <see cref="Continue"/> after the returned <see cref="List{Token}"/> were appended.</para>
        /// </summary>
        /// <param name="tokenList">add tokens to this list and then call <see cref="Continue"/></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void Begin(List<Token> tokenList) {
            if (this.bcfContext != null) { throw new Exception("last Begin/Continue/FinishParse() not finished!"); }

            var context = new LRParseContext(tokenList, this.initialState, this.EOT, this.stArray);
            this.bcfContext = new BCFLRParseContext(context);
        }
        /// <summary>
        /// continue to parse the <see cref="List{Token}"/> returned by <see cref="Begin"/> after it were appended.
        /// <para>if syntex error occurs, the token will be skipped.</para>
        /// </summary>
        /// <returns></returns>
        public SyntaxTree Continue() {
            var bcfContext = this.bcfContext;
            if (bcfContext == null) { throw new Exception("call Begin() before Continue()"); }

            var stop = false; var accept = false;
            do {
                Token token = bcfContext.context.CurrentToken;
                stop = (token == bcfContext.context.EOT);
                if (!stop) {
                    int nodeType = token.kind;// no-need-convert from int to int.
                    while (nodeType == blockComment || nodeType == inlineComment) {
                        // skip comment token
                        bcfContext.context.cursor++;
                        token = bcfContext.context.CurrentToken;
                        nodeType = token.kind;// no-need-convert from int to int.
                    }

                    LRParseState currentState = bcfContext.context.stateStack.Peek();
                    if (currentState.TryGetAction(nodeType, out var parseAction)) {
                        parseAction.Execute(bcfContext.context);
                        if (parseAction.kind == LRParseAction.Kind.Accept) { accept = true; }
                    }
                    else { // syntax error happened.
                        // simply skip current token.
                        bcfContext.context.cursor++;
                        //return new SyntaxTree(bcfContext.context);
                    }
                }
            } while (!stop && !accept);

            return new SyntaxTree(bcfContext.context);
        }
        /// <summary>
        /// deal with the <see cref="LRParseContext.EOT"/> token.
        /// </summary>
        /// <returns></returns>
        public SyntaxTree Finish() {
            var bcfContext = this.bcfContext;
            if (bcfContext == null) { throw new Exception("call Begin() before Finish()"); }

            var accept = false;
            do {
                Token token = bcfContext.context.CurrentToken;
                int nodeType = token.kind;// no-need-convert from int to int.
                while (nodeType == blockComment || nodeType == inlineComment) {
                    // skip comment token
                    bcfContext.context.cursor++;
                    token = bcfContext.context.CurrentToken;
                    nodeType = token.kind;// no-need-convert from int to int.
                }

                LRParseState currentState = bcfContext.context.stateStack.Peek();
                if (currentState.TryGetAction(nodeType, out var parseAction)) {
                    parseAction.Execute(bcfContext.context);
                    if (parseAction.kind == LRParseAction.Kind.Accept) { accept = true; }
                }
                else { // syntax error happened.
                    return new SyntaxTree(bcfContext.context);
                }
            } while (!accept);

            this.bcfContext = null;

            return new SyntaxTree(bcfContext.context);
        }
    }
}
