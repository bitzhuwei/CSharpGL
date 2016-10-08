using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CSharpGL
{
    public static class OpenGLHelper
    {
        public static void Dump()
        {
            Type type = typeof(OpenGL);
            var builder = new StringBuilder();
            builder.Append(string.Format("OpenGL constants:"));
            builder.AppendLine();
            FieldInfo[] fieldsInfo = type.GetFields(System.Reflection.BindingFlags.Public | BindingFlags.Static);
            var orderedList = from item in fieldsInfo
                              orderby uint.Parse(item.GetValue(null).ToString())
                              select item;
            foreach (var item in orderedList)
            {
                builder.AppendLine(string.Format("{0} = 0x{1:X};", item.Name, item.GetValue(null)));
            }
            builder.AppendLine("================END================");
            System.IO.File.WriteAllText("OpenGL.txt", builder.ToString());
        }
    }
}