using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CSharpGL
{
    public static class OpenGLHelper
    {
        public static void DumpConstants()
        {
            Type type = typeof(OpenGL);
            var builder = new StringBuilder();
            builder.Append(string.Format("public static partial class OpenGL"));
            builder.Append(("{"));
            builder.AppendLine();
            FieldInfo[] fieldsInfo = type.GetFields(System.Reflection.BindingFlags.Public | BindingFlags.Static);
            var orderedList = from item in fieldsInfo
                              orderby uint.Parse(item.GetValue(null).ToString())
                              select item;
            foreach (var item in orderedList)
            {
                builder.AppendLine(string.Format("    {0} {1} = 0x{2:X};", item.FieldType.Name, item.Name, item.GetValue(null)));
            }
            builder.Append(("}"));
            System.IO.File.WriteAllText("OpenGL.constants.cs", builder.ToString());
        }

        public static void DumpMethods()
        {
            Type type = typeof(OpenGL);
            var builder = new StringBuilder();
            builder.Append(string.Format("public static partial class OpenGL"));
            builder.Append(("{"));
            builder.AppendLine();
            MethodInfo[] methodInfo = type.GetMethods();
            var orderedList = from item in methodInfo
                              orderby item.Name
                              select item;
            foreach (var item in orderedList)
            {
                builder.AppendLine(string.Format("    {0};",
                    item));
            }
            builder.Append(("}"));
            System.IO.File.WriteAllText("OpenGL.methods.cs", builder.ToString());
        }
    }
}