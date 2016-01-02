using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class DumpTreeToText
    {
        /// <summary>
        /// 像DOS的树状展示文件夹结构一样展示树结构。
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        public static string DumpToText(this ITreeNode chunk)
        {
            StringBuilder builder = new StringBuilder();
            int tabSpace = 0;
            GetBuilder(builder, chunk, ref tabSpace);
            return builder.ToString();
        }

        private static void GetBuilder(StringBuilder builder, ITreeNode tree, ref int tabSpace)
        {
            builder.AppendLine(GetPreMarks(tree) + tree.ToString());
            tabSpace++;
            foreach (var item in tree.Children)
            {
                GetBuilder(builder, item, ref tabSpace);
            }
            tabSpace--;
        }

        private static string GetPreMarks(ITreeNode tree)
        {
            var parent = tree.Parent;
            if (parent == null) return string.Empty;
            List<bool> lstline = new List<bool>();
            while (parent != null)
            {
                var pp = parent.Parent;
                if (pp != null)
                {
                    lstline.Add(pp.Children.IndexOf(parent) < pp.Children.Count - 1);
                }
                parent = pp;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = lstline.Count - 1; i >= 0; i--)
            {
                if (lstline[i])
                    builder.Append("│  ");
                else
                    builder.Append("    ");
            }
            parent = tree.Parent;
            if (parent.Children.IndexOf(tree) < parent.Children.Count - 1)
                builder.Append("├─");
            else
                builder.Append("└─");
            return builder.ToString();
        }

        private static List<string> spaces = new List<string>()
        {
            "",
            "    ",
        };
    }
}
