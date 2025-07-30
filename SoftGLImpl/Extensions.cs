
namespace System.Collections.Generic {
    static class Extensions {

        /// <summary>
        /// get last element of <paramref name="array"/> if exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T? LastOne<T>(this IList<T> array) where T : class {
            if (array.Count == 0) { return null; }

            return array[array.Count - 1];
        }

        /// <summary>
        /// add or set dict's key -> value
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value) where TKey : notnull {
            if (!dict.TryAdd(key, value)) {
                dict[key] = value;
            }
        }
        //public static async void CompileAndRun(string code) {
        //    try {
        //        var script = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.Create<InnerVertexShaderCodeBase>(code);
        //        var result = await script.RunAsync();
        //        var result = await CSharpScript.RunAsync(code, ScriptOptions.Default); // 使用默认脚本选项运行代码字符串。
        //        Console.WriteLine("Output: " + result); // 输出结果（如果有的话）
        //    }
        //    catch (CompilationErrorException ex) // 处理编译错误。
        //    {
        //        Console.WriteLine("Compilation failed:");
        //        foreach (var diagnostic in ex.Diagnostics) // 打印所有诊断信息。
        //        {
        //            Console.WriteLine(diagnostic); // 输出错误信息。 例如：
        //        }
        //    }
        //}
    }
}
