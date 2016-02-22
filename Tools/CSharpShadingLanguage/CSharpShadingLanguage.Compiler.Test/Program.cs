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
                        Console.WriteLine(token);
                        sw.WriteLine(token);

                        if (token.TokenType == EnumTokenTypeCSSLCompiler.unknown)
                        {
                            Console.ReadKey(true);
                        }
                    }
                }

                //Console.ReadKey(true);
                //System.Diagnostics.Process.Start("explorer", "/select," + item + ".txt");
            }
        }
    }
}
