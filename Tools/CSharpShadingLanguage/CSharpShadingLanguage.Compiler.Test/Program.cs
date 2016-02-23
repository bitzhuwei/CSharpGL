using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.CompilerBase;

namespace CSharpShadingLanguage.Compiler.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in System.IO.Directory.GetFiles("./", "*.cs"))
            {
                using (var sw = new System.IO.StreamWriter(item + ".txt"))
                {
                    string sourceCode = System.IO.File.ReadAllText(item);
                    var lexi = new CSharpShadingLanguage.Compiler.LexicalAnalyzerCSSLCompiler(sourceCode);
                    var tokenList = lexi.Analyze();
                    foreach (var token in tokenList)
                    {
                        //Console.WriteLine(token);
                        sw.WriteLine(token);

                        if (token.TokenType == EnumTokenTypeCSSLCompiler.unknown)
                        {
                            Console.ReadKey(true);
                        }
                    }
                    // find public override void main() { }
                    List<Token<EnumTokenTypeCSSLCompiler>> target = new List<Token<EnumTokenTypeCSSLCompiler>>();
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "public", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "override", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "void", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "main", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_LeftParentheses_, Detail = "(", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_RightParentheses_, Detail = ")", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_LeftBrace_, Detail = "{", });
                    int index = tokenList.KMP(target,0, new TokenComparer());
                    if (index < 0) { throw new Exception(); }
                    int rightBraceIndex = index + 7; int leftBraceCount = 1;
                    for (; rightBraceIndex < tokenList.Count; rightBraceIndex++)
                    {
                        if (tokenList[rightBraceIndex].TokenType == EnumTokenTypeCSSLCompiler.token_LeftBrace_)
                        {
                            leftBraceCount++;
                        }
                        else if (tokenList[rightBraceIndex].TokenType == EnumTokenTypeCSSLCompiler.token_RightBrace_)
                        {
                            leftBraceCount--;
                            if (leftBraceCount == 0)
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine("right brace '}}' for public override void main() {{ is {0}", tokenList[rightBraceIndex]);

                }

     
            }

        }

        class TokenComparer : IComparer<Token<EnumTokenTypeCSSLCompiler>>
        {

            int IComparer<Token<EnumTokenTypeCSSLCompiler>>.Compare(Token<EnumTokenTypeCSSLCompiler> x, Token<EnumTokenTypeCSSLCompiler> y)
            {
                if (x == null && y == null) { return 0; }
                if (x == null || y == null) { return 1; }

                if (x.Detail == y.Detail
                    && x.TokenType == y.TokenType) { return 0; }

                return 1;
            }
        }
    }
}
