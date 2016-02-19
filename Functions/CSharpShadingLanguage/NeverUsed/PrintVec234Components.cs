using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShadingLanguage.NeverUsed
{
#if DEBUG
    /// <summary>
    /// 在release版中不需要这个类型。这是为生成代码而写的。
    /// </summary>
    public class PrintVec234Components
    {

        /// <summary>
        /// 给出vec2 vec3 vec4内部所有可能的组合形式。运行一下看结果就明白了，不用啃这个代码。
        /// </summary>
        public static void PrintComponents()
        {
            List<string[]> vector = new List<string[]>();
            vector.Add(new string[] { "a0", "a1", "a2", "a3", });
            List<char[]> list = new List<char[]>();
            list.Add(new char[] { 'x', 'y', 'z', 'w' });
            list.Add(new char[] { 'r', 'g', 'b', 'a' });
            list.Add(new char[] { 's', 't', 'p', 'q' });

            for (int vLength = 2; vLength < 5; vLength++)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < vLength; i++)
                {
                    builder.AppendFormat("internal float {0};", vector[0][i]);
                    builder.AppendLine();
                }
                builder.AppendLine();
                builder.AppendFormat("#region compositions");
                builder.AppendLine();
                builder.AppendLine();

                foreach (var components in list)
                {
                    for (int i = 0; i < vLength; i++)
                    {
                        builder.AppendFormat("public float {0} {{ get {{ return {1}; }} set {{ {1} = {0}; }} }}", components[i], vector[0][i]);
                        builder.AppendLine();
                    }
                    builder.AppendLine();

                    for (int i = 0; i < vLength; i++)
                    {
                        for (int j = 0; j < vLength; j++)
                        {
                            builder.AppendFormat("public vec2 {0}{1} {{ get {{ return new vec2({0}, {1}); }} set {{ this.{0} = value.a0; this.{1} = value.a1; }} }}", components[i], components[j]);
                            builder.AppendLine();
                        }
                    }
                    builder.AppendLine();

                    if (vLength < 3) { continue; }

                    for (int i = 0; i < vLength; i++)
                    {
                        for (int j = 0; j < vLength; j++)
                        {
                            for (int k = 0; k < vLength; k++)
                            {
                                builder.AppendFormat("public vec3 {0}{1}{2} {{ get {{ return new vec3({0}, {1}, {2}); }} set {{ this.{0} = value.a0; this.{1} = value.a1; this.{2} = value.a2; }} }}", components[i], components[j], components[k]);
                                builder.AppendLine();
                            }
                        }
                    }
                    builder.AppendLine();

                    if (vLength < 4) { continue; }

                    for (int i = 0; i < vLength; i++)
                    {
                        for (int j = 0; j < vLength; j++)
                        {
                            for (int k = 0; k < vLength; k++)
                            {
                                for (int m = 0; m < vLength; m++)
                                {
                                    builder.AppendFormat("public vec4 {0}{1}{2}{3} {{ get {{ return new vec4({0}, {1}, {2}, {3}); }} set {{ this.{0} = value.a0; this.{1} = value.a1; this.{2} = value.a2; this.{3} = value.a3; }} }}", components[i], components[j], components[k], components[m], vLength);
                                    builder.AppendLine();
                                }
                            }
                        }
                    }
                    builder.AppendLine();

                }

                builder.AppendFormat("#endregion compositions");
                builder.AppendLine();

                System.IO.File.WriteAllText("vec" + vLength + ".txt", builder.ToString());
            }
        }
    }
#endif
}
