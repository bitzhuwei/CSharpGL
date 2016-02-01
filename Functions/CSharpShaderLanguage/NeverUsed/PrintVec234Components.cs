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
    class PrintVec234Components
    {

        /// <summary>
        /// 给出vec2 vec3 vec4内部所有可能的组合形式。运行一下看结果就明白了，不用啃这个代码。
        /// </summary>
        public static void PrintComponents()
        {
            List<char[]> list = new List<char[]>();
            list.Add(new char[] { 'x', 'y', 'z', 'w' });
            list.Add(new char[] { 'r', 'g', 'b', 'a' });
            list.Add(new char[] { 's', 't', 'p', 'q' });
            for (int vLength = 2; vLength < 5; vLength++)
            {
                StringBuilder builder = new StringBuilder();

                foreach (var components in list)
                {
                    for (int i = 0; i < vLength; i++)
                    {
                        builder.AppendFormat("public float {0} {{ get {{ return 0.0f; }} }}", components[i], vLength);
                        builder.AppendLine();
                    }
                    builder.AppendLine();

                    for (int i = 0; i < vLength; i++)
                    {
                        for (int j = 0; j < vLength; j++)
                        {
                            builder.AppendFormat("public vec2 {0}{1} {{ get {{ return default(vec2); }} }}", components[i], components[j], vLength);
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
                                builder.AppendFormat("public vec3 {0}{1}{2} {{ get {{ return default(vec3); }} }}", components[i], components[j], components[k], vLength);
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
                                    builder.AppendFormat("public vec4 {0}{1}{2}{3} {{ get {{ return default(vec4); }} }}", components[i], components[j], components[k], components[m], vLength);
                                    builder.AppendLine();
                                }
                            }
                        }
                    }

                }

                builder.AppendLine();

                System.IO.File.WriteAllText("vec" + vLength + ".txt", builder.ToString());
            }
        }
    }
#endif
}
