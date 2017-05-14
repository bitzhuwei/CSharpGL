using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DumpGLDelegates
{
    class Item : IComparable
    {
        public string returnType;
        public List<string> parameters;

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj.ToString());
        }

        public string ToTypeField()
        {
            var builder = new StringBuilder();

            builder.Append("public static readonly Type typeof_");

            builder.Append(this.returnType); builder.Append("_");
            if (this.parameters.Count > 0)
            {
                for (int i = 0; i < this.parameters.Count - 1; i++)
                {
                    builder.Append(this.parameters[i].Replace("[]", "N"));
                    builder.Append("_");
                }
                builder.Append(this.parameters[this.parameters.Count - 1].Replace("[]", "N"));
            }
            else
            {
                builder.Append("void");
            }
            builder.Append(" = typeof(");
            builder.Append(this.returnType); builder.Append("_");
            if (this.parameters.Count > 0)
            {
                for (int i = 0; i < this.parameters.Count - 1; i++)
                {
                    builder.Append(this.parameters[i].Replace("[]", "N"));
                    builder.Append("_");
                }
                builder.Append(this.parameters[this.parameters.Count - 1].Replace("[]", "N"));
            }
            else
            {
                builder.Append("void");
            }
            builder.Append(");");

            return builder.ToString();
        }

        public string ToDelegateDefiniation()
        {
            var builder = new StringBuilder();

            builder.Append("public delegate ");
            builder.Append(this.returnType); builder.Append(" ");

            builder.Append(this.returnType); builder.Append("_");
            if (this.parameters.Count > 0)
            {
                for (int i = 0; i < this.parameters.Count - 1; i++)
                {
                    builder.Append(this.parameters[i].Replace("[]", "N"));
                    builder.Append("_");
                }
                builder.Append(this.parameters[this.parameters.Count - 1].Replace("[]", "N"));
            }
            else
            {
                builder.Append("void");
            }
            builder.Append("(");
            if (this.parameters.Count > 0)
            {
                for (int i = 0; i < this.parameters.Count - 1; i++)
                {
                    if (this.parameters[i].StartsWith("ref") || this.parameters[i].StartsWith("out"))
                    {
                        builder.Append(this.parameters[i].Substring(0, 3));
                        builder.Append(" ");
                        builder.Append(this.parameters[i].Substring(3));
                    }
                    else
                    {
                        builder.Append(this.parameters[i]);
                    }
                    builder.Append(string.Format(" _{0}, ", i));
                }

                if (this.parameters[this.parameters.Count - 1].StartsWith("ref") || this.parameters[this.parameters.Count - 1].StartsWith("out"))
                {
                    builder.Append(this.parameters[this.parameters.Count - 1].Substring(0, 3));
                    builder.Append(" ");
                    builder.Append(this.parameters[this.parameters.Count - 1].Substring(3));
                }
                else
                {
                    builder.Append(this.parameters[this.parameters.Count - 1]);
                }
                builder.Append(string.Format(" _{0}", this.parameters.Count - 1));
            }
            builder.Append(");");

            return builder.ToString();
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(this.returnType); builder.Append(" ");

            builder.Append("xxx(");
            if (this.parameters.Count > 0)
            {
                for (int i = 0; i < this.parameters.Count - 1; i++)
                {
                    builder.Append(this.parameters[i]);
                    builder.Append(string.Format(" _{0}, ", i));
                }
                builder.Append(this.parameters[this.parameters.Count - 1]);
                builder.Append(string.Format(" {0}", this.parameters.Count - 1));
            }
            builder.Append(");");

            return builder.ToString();
        }
        public bool SameWith(Item other)
        {
            if (this.returnType != other.returnType) { return false; }
            if (this.parameters.Count != other.parameters.Count) { return false; }

            for (int i = 0; i < this.parameters.Count; i++)
            {
                if (this.parameters[i] != other.parameters[i])
                {
                    return false;
                }
            }

            return true;
        }

        #region IComparable 成员

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }

        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Item>();

            foreach (var file in System.IO.Directory.GetFiles(".", "*.cs", System.IO.SearchOption.AllDirectories))
            {
                ProcessFile(file, list);
            }

            list.Sort();

            DumpList("GLDelegates.c", list);
        }

        private static void DumpList(string filename, List<Item> list)
        {
            using (var writer = new System.IO.StreamWriter(filename))
            {
                foreach (var item in list)
                {
                    //public delegate void void_uint(uint a);
                    //public static readonly Type typeof_void_uint = typeof(void_uint);
                    writer.WriteLine(item.ToDelegateDefiniation());
                    writer.WriteLine(item.ToTypeField());
                    writer.WriteLine();
                }
            }
        }

        private static void ProcessFile(string file, List<Item> list)
        {
            using (var reader = new System.IO.StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    //if (line.StartsWith("//")) { continue; }

                    int index = line.IndexOf(" delegate ");
                    if (index >= 0)
                    {
                        ProcessLine(line, list);
                    }
                }
            }
        }

        private static void ProcessLine(string line, List<Item> list)
        {
            //try
            {
                string returnType = GetReturnType(line);
                List<string> parameters = GetParameters(line);
                var item = new Item(); item.returnType = returnType; item.parameters = parameters;
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error:");
            //    Console.WriteLine(e);
            //}
        }

        static readonly char[] separator = new char[] { ',' };
        static readonly char[] separator2 = new char[] { ' ' };
        private static List<string> GetParameters(string line)
        {
            List<string> result = new List<string>();
            int leftIndex = line.IndexOf('(');
            int rightIndex = line.IndexOf(')');
            if (leftIndex + 1 < rightIndex)
            {
                string[] parts = line.Substring(leftIndex + 1, rightIndex - leftIndex - 1).Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var parameter in parts)
                {
                    string[] parts2 = parameter.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
                    if (parts2.Length == 2)
                    {
                        result.Add(parts2[0]);
                    }
                    else
                    {
                        result.Add(string.Format("{0}{1}", parts2[0], parts2[1]));
                    }
                }
            }

            return result;
        }

        private static string GetReturnType(string line)
        {
            string result = "[return type not found]";

            string[] parts = line.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "delegate")
                {
                    result = parts[i + 1];
                }
            }

            return result;
        }

    }

    delegate float void_uint(uint a);
}
