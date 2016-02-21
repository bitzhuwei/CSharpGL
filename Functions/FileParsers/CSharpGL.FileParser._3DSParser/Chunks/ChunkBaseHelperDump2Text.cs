using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public static partial class ChunkBaseHelper
    {

        public static string DumpToText(this ChunkBase chunk)
        {
            StringBuilder builder = new StringBuilder();
            int tabSpace = 0;
            GetBuilder(builder, chunk, ref tabSpace);
            return builder.ToString();
        }

        private static void GetBuilder(StringBuilder builder, ChunkBase tree, ref int tabSpace)
        {
            //builder.AppendLine(GetSpace(tabSpace) + tree.NodeValue.ToString());
            //builder.AppendLine(GetBrantch(tabSpace)/*GetSpace(tabSpace)*/ + tree.NodeValue.ToString());
            //builder.AppendLine(GetPreMarks(tree)/*GetSpace(tabSpace)*/ + tree.NodeValue.ToString());
            builder.AppendLine(GetPreMarks(tree)/*GetSpace(tabSpace)*/ + tree.ToString());
            tabSpace++;
            foreach (var item in tree.Children)
            {
                GetBuilder(builder, item, ref tabSpace);
            }
            tabSpace--;
        }

        private static string GetPreMarks(ChunkBase tree)
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

        private static string GetBrantch(int tabspace)
        {
            if (tabspace < 1)
                return string.Empty;
            return (GetSpace(tabspace - 1) + "└─"/*"|-"*/);
        }

        private static string GetSpace(int tabspace)
        {
            lock (spaces)
            {
                if (tabspace < 0)
                    tabspace = 0;
                if (tabspace >= spaces.Count)
                {
                    StringBuilder builder = new StringBuilder(spaces[spaces.Count - 1]);
                    for (int i = spaces.Count - 1; i < tabspace; i++)
                    {
                        builder.Append("    ");
                        spaces.Add(builder.ToString());
                    }
                }
            }
            return spaces[tabspace];
        }

        private static List<string> spaces = new List<string>()
        {
            "",
            "    ",
        };
    }
}
