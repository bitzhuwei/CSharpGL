
using bitzhuwei.Compiler;
using bitzhuwei.PreDirectiveFormat;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// preprocessor context.
    /// </summary>
    public partial class PpContext {
        //private readonly CompilerConditional conditionalParser = new();
        //private readonly List<Token> conditionalTokens = new();
        //private readonly Dictionary<LRNode, bool> node2Active = new();
        ///// <summary>
        ///// push children from left to right, then pop them(from right to left) to parent node,
        ///// so that I can construct object in upper node and for the upper node.
        ///// <para>works in post-order traversing environment.</para>
        ///// </summary>
        //private readonly Stack<object> rightStack = new();
        // TODO: I don't know if there's any difference between Stack and Stack<object>.
        //public readonly Stack rightStack = new();

        //internal void AppendConditionalTokens(IReadOnlyList<Token> tokens) {
        //    this.conditionalTokens.AddRange(tokens);
        //}
        //internal void AppendConditionalTokens(bitzhuwei.PreDirectiveFormat.VnConstExp constExp) {
        //    foreach (var token in constExp.EnumTokens()) {
        //        this.conditionalTokens.Add(token);
        //    }
        //}

        //internal void RefreshConditionalState() {
        //    var tokens = (from item in this.conditionalTokens select item).ToList();
        //    this.conditionalParser.BeginParse(tokens);
        //    SyntaxTree? syntaxTree = null; var appendCount = 0;
        //    do {
        //        if (syntaxTree != null) {
        //            tokens.Add(new Token(tokens.Count, CompilerConditional.st.Pound符endif, CompilerConditional.stArray,
        //                new LexicalCursor(int.MaxValue, int.MaxValue, 1),
        //                new LexicalCursor(int.MaxValue, int.MaxValue, "#endif".Length), "#endif"));
        //            appendCount++;
        //        }
        //        syntaxTree = this.conditionalParser.ContinueParse();
        //    }
        //    while (syntaxTree == null || syntaxTree.context.nodeStack.Count != 1);
        //    Debug.Assert(syntaxTree.root != null);
        //    RefreshNodeState(syntaxTree.root);

        //    //// update this.isActive
        //    //foreach (var root in syntaxTree.context.nodeStack.Reverse()) {
        //    //    RefreshNodeState(syntaxTree.root);
        //    //}
        //    //// when syntax tree is not complete, there would be multiple nodes in nodeStack.
        //    //foreach (var root in syntaxTree.context.nodeStack.Reverse()) {
        //    //    if (root.regulation == null) {
        //    //    }
        //    //    else {
        //    //        RefreshRootState(root, syntaxTree);
        //    //    }
        //    //}
        //}

        //private void RefreshNodeState(LRNode root) {
        //    var context = this; context.node2Active.Clear();
        //    var nodeStack = new Stack<LRNode>(); var indexStack = new Stack<int>();
        //    // init stack.
        //    {
        //        // push nextLeft and its next pending children.
        //        var nextLeft = root; var index = 0;
        //        nodeStack.Push(nextLeft); indexStack.Push(index);
        //        while (nextLeft.children.Count > 0) {
        //            nextLeft = nextLeft.children[0];
        //            nodeStack.Push(nextLeft); indexStack.Push(0);
        //        }
        //    }

        //    while (nodeStack.Count > 0) {
        //        var current = nodeStack.Pop(); var index = indexStack.Pop() + 1;
        //        if (index < current.children.Count) {
        //            // push this node back again.
        //            nodeStack.Push(current); indexStack.Push(index);

        //            // push nextLeft and its next pending children.
        //            var nextLeft = current.children[index];
        //            nodeStack.Push(nextLeft); indexStack.Push(0);
        //            while (nextLeft.children.Count > 0) {
        //                nextLeft = nextLeft.children[0];
        //                nodeStack.Push(nextLeft); indexStack.Push(0);
        //            }
        //        }
        //        else {
        //            Visit(current, context);
        //        }
        //    }

        //    //Visit(this.EOT, context);
        //}

        //private static void Visit(LRNode node, PpContext context) {
        //    if (node.type == 0) { // 0 means Symbol.EOF('¥')
        //        VisitVn(node, context);
        //    }
        //    else if (node.regulation != null/*Regulation.noRegulation*/) { // Vn
        //        VisitVn(node, context);
        //    }
        //    else { // single fixed action for Vt symbols
        //        Debug.Assert(node.tokenRange != null);
        //        context.rightStack.Push(node.tokenRange.start);
        //        //if (!context.node2Active.ContainsKey(node)) {
        //        //    context.node2Active.Add(node, true);
        //        //}
        //        context.node2Active.Set(node, true);
        //    }
        //}

        //private static void VisitVn(LRNode node, PpContext context) {
        //    Debug.Assert(node.regulation != null);
        //    switch (node.regulation.index) {

        //    case -1: { // [-1] PackList' = PackList ;
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 0: { // [0] PackList = PackList Pack ;
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 1: { // [1] PackList = Pack ;
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 2: { // [2] Pack = IfEnd ;
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 3: { // [3] Pack = IfElseEnd ;
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 4: { // [4] Pack = IfElifsEnd ;
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 5: { // [5] Pack = IfElifsElseEnd ;
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 6: { // [6] IfEnd = IFLine Primary EndLine ;
        //        var r0 = (Token)context.rightStack.Pop();
        //        var r4 = (List<LRNode>)context.rightStack.Pop();
        //        var r5 = ((LRNode node, string if_, string exp))context.rightStack.Pop();
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 7: { // [7] IfElseEnd = IFLine Primary ElseLine Primary EndLine ;
        //        var r0 = (Token)context.rightStack.Pop();
        //        var r1 = (List<LRNode>)context.rightStack.Pop();
        //        var r2 = (LRNode)context.rightStack.Pop();
        //        var r4 = (List<LRNode>)context.rightStack.Pop();
        //        var r5 = ((LRNode node, string if_, string exp))context.rightStack.Pop();
        //        if (context.node2Active[r5.node]) {// disable all '#elif' and '#else'
        //            // disable '#else'
        //            context.node2Active.Set(r2, false);
        //        }
        //        else {
        //            // enable '#else'
        //            context.node2Active.Set(r2, true);
        //        }
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 8: { // [8] IfElifsEnd = IFLine Primary Elifs EndLine ;
        //        var r0 = (Token)context.rightStack.Pop();
        //        var r3 = (List<(LRNode elifLine, List<LRNode> primary)>)context.rightStack.Pop();
        //        var r4 = (List<LRNode>)context.rightStack.Pop();
        //        var r5 = ((LRNode node, string if_, string exp))context.rightStack.Pop();
        //        if (context.node2Active[r5.node]) {// disable all '#elif' and '#else'
        //            for (var i = 0; i < r3.Count; i++) {
        //                var elifLine = r3[i].Item1;
        //                context.node2Active[elifLine] = false;
        //            }
        //        }
        //        else {
        //            var foundTrue = false;// which '#elif' should be true ?
        //            for (var i = 0; i < r3.Count; i++) {
        //                var elifLine = r3[i].Item1;
        //                if (foundTrue) { context.node2Active[elifLine] = false; }
        //                else if (context.node2Active[elifLine]) { foundTrue = true; }
        //            }
        //        }
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 9: { // [9] IfElifsElseEnd = IFLine Primary Elifs ElseLine Primary EndLine ;
        //        var r0 = (Token)context.rightStack.Pop();
        //        var r1 = (List<LRNode>)context.rightStack.Pop();
        //        var r2 = (LRNode)context.rightStack.Pop();
        //        var r3 = (List<(LRNode elifLine, List<LRNode> primary)>)context.rightStack.Pop();
        //        var r4 = (List<LRNode>)context.rightStack.Pop();
        //        var r5 = ((LRNode node, string if_, string exp))context.rightStack.Pop();
        //        if (context.node2Active[r5.node]) {// disable all '#elif' and '#else'
        //            for (var i = 0; i < r3.Count; i++) {
        //                var elifLine = r3[i].Item1;
        //                context.node2Active[elifLine] = false;
        //            }
        //            // disable '#else'
        //            context.node2Active.Set(r2, false);
        //        }
        //        else {
        //            var foundTrue = false;// which '#elif' should be true ?
        //            for (var i = 0; i < r3.Count; i++) {
        //                var elifLine = r3[i].Item1;
        //                if (foundTrue) { context.node2Active[elifLine] = false; }
        //                else if (context.node2Active[elifLine]) { foundTrue = true; }
        //            }
        //            // enable/disable '#else'
        //            context.node2Active.Set(r2, !foundTrue);
        //        }
        //        context.node2Active.Set(node, true);
        //    }
        //    break;
        //    case 10: { // [10] IFLine = '#if' ConstExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        context.rightStack.Push((node, r1.value, r0));
        //        int final = 0; if (int.TryParse(r0, out var value)) { final = value; }
        //        context.node2Active.Set(node, final != 0);
        //    }
        //    break;
        //    case 11: { // [11] IFLine = '#ifdef' ConstExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        context.rightStack.Push((node, r1.value, r0));
        //        var def = context.name2Define.ContainsKey(r0);
        //        context.node2Active.Set(node, def);
        //    }
        //    break;
        //    case 12: { // [12] IFLine = '#ifndef' ConstExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        context.rightStack.Push((node, r1.value, r0));
        //        var ndef = !context.name2Define.ContainsKey(r0);
        //        context.node2Active.Set(node, ndef);
        //    }
        //    break;
        //    case 13: { // [13] Elifs = Elifs ElifLine Primary ;
        //        var r0 = (List<LRNode>)context.rightStack.Pop();
        //        var r1 = (LRNode)context.rightStack.Pop();
        //        var r2 = (List<(LRNode elifLine, List<LRNode> primary)>)context.rightStack.Pop();
        //        var left = r2;
        //        left.Add((r1, r0));
        //        context.rightStack.Push(left);
        //    }
        //    break;
        //    case 14: { // [14] Elifs = ElifLine Primary ;
        //        var r0 = (List<LRNode>)context.rightStack.Pop();
        //        var r1 = (LRNode)context.rightStack.Pop();
        //        var list = new List<(LRNode elifLine, List<LRNode> primary)>();
        //        list.Add((r1, r0));
        //        context.rightStack.Push(list);
        //    }
        //    break;
        //    case 15: { // [15] ElifLine = '#elif' ConstExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        int final = 0;
        //        if (int.TryParse(r0, out var value)) { final = value; }
        //        context.node2Active.Set(node, final != 0);// only means active according to this ConstExp
        //        context.rightStack.Push(node);
        //    }
        //    break;
        //    case 16: { // [16] ElseLine = '#else' ;
        //        context.node2Active.Set(node, true);// true or false for default value ?
        //        context.rightStack.Push(node);
        //    }
        //    break;
        //    case 17: { // [17] EndLine = '#endif' ;
        //        context.node2Active.Set(node, true);
        //        context.rightStack.Push(node);
        //    }
        //    break;
        //    case 18: { // [18] Primary = PackList ;
        //               //var r0 = (List<LRNode>)context.rightStack.Pop();
        //               //context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 19: { // [19] Primary = null ;
        //        context.rightStack.Push(new List<LRNode>());
        //    }
        //    break;
        //    case 20: { // [20] ConstExp = OrOrExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 21: { // [21] OrOrExp = AndAndExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 22: { // [22] OrOrExp = OrOrExp '||' AndAndExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = ((a != 0) || (b != 0)) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 23: { // [23] AndAndExp = OrExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 24: { // [24] AndAndExp = AndAndExp '&&' OrExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = ((a != 0) && (b != 0)) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 25: { // [25] OrExp = XorExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 26: { // [26] OrExp = OrExp '|' XorExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a | b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 27: { // [27] XorExp = AndExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 28: { // [28] XorExp = XorExp '^' AndExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a ^ b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 29: { // [29] AndExp = EqualExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 30: { // [30] AndExp = AndExp '&' EqualExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a & b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 31: { // [31] EqualExp = RelationExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 32: { // [32] EqualExp = EqualExp '==' RelationExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = (a == b) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 33: { // [33] EqualExp = EqualExp '!=' RelationExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = (a != b) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 34: { // [34] RelationExp = ShiftExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 35: { // [35] RelationExp = RelationExp '<' ShiftExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = (a < b) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 36: { // [36] RelationExp = RelationExp '>' ShiftExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = (a > b) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 37: { // [37] RelationExp = RelationExp '<=' ShiftExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = (a <= b) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 38: { // [38] RelationExp = RelationExp '>=' ShiftExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = (a >= b) ? 1 : 0;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 39: { // [39] ShiftExp = AddExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 40: { // [40] ShiftExp = ShiftExp '<<' AddExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a << b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 41: { // [41] ShiftExp = ShiftExp '>>' AddExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a >> b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 42: { // [42] AddExp = MultiExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 43: { // [43] AddExp = AddExp '+' MultiExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a + b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 44: { // [44] AddExp = AddExp '-' MultiExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a - b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 45: { // [45] MultiExp = UnaryExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 46: { // [46] MultiExp = MultiExp '*' UnaryExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a / b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 47: { // [47] MultiExp = MultiExp '/' UnaryExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a / b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 48: { // [48] MultiExp = MultiExp '%' UnaryExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r2 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (int.TryParse(r2, out var a) && int.TryParse(r0, out var b)) {
        //            final = a % b;
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 49: { // [49] UnaryExp = PrimaryExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        context.rightStack.Push(r0);
        //    }
        //    break;
        //    case 50: { // [50] UnaryExp = UnaryOp UnaryExp ;
        //        var r0 = (string)context.rightStack.Pop();
        //        var r1 = (string)context.rightStack.Pop();
        //        int final = 0;
        //        if (r1 == "defined") { final = context.name2Define.ContainsKey(r0) ? 1 : 0; }
        //        else {
        //            if (int.TryParse(r0, out var ir0)) {
        //                final = ir0;
        //                if (false) { }
        //                else if (r1 == "+") { final = +final; }
        //                else if (r1 == "-") { final = -final; }
        //                else if (r1 == "~") { final = ~final; }
        //                else if (r1 == "!") { if (final != 0) { final = 0; } }
        //                else { throw new NotImplementedException(); }
        //            }
        //        }
        //        context.rightStack.Push(final.ToString());
        //    }
        //    break;
        //    case 51: { // [51] UnaryOp = 'defined' ;
        //        var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
        //        context.rightStack.Push(r0.value);
        //    }
        //    break;
        //    case 52: { // [52] UnaryOp = '+' ;
        //        var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
        //        context.rightStack.Push(r0.value);
        //    }
        //    break;
        //    case 53: { // [53] UnaryOp = '-' ;
        //        var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
        //        context.rightStack.Push(r0.value);
        //    }
        //    break;
        //    case 54: { // [54] UnaryOp = '~' ;
        //        var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
        //        context.rightStack.Push(r0.value);
        //    }
        //    break;
        //    case 55: { // [55] UnaryOp = '!' ;
        //        var r0 = (Token)context.rightStack.Pop();/* reserved word is omissible */
        //        context.rightStack.Push(r0.value);
        //    }
        //    break;
        //    case 56: { // [56] PrimaryExp = 'number' ;
        //        var r0 = (Token)context.rightStack.Pop();
        //        context.rightStack.Push(r0.value);
        //    }
        //    break;
        //    case 57: { // [57] PrimaryExp = 'identifier' ;
        //        var r0 = (Token)context.rightStack.Pop();
        //        context.rightStack.Push(r0.value);
        //    }
        //    break;
        //    case 58: { // [58] PrimaryExp = '(' ConstExp ')' ;
        //        var r0 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        var r1 = (string)context.rightStack.Pop();
        //        var r2 = (Token)context.rightStack.Pop();// reserved word is omissible
        //        context.rightStack.Push(r1);
        //    }
        //    break;
        //    default: { throw new NotImplementedException(); }
        //    }
        //}
    }
}
