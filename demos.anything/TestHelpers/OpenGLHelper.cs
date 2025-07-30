﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CSharpGL {
    public static class OpenGLHelper {
        public static void DumpConstants() {
            Type type = typeof(GL);
            var builder = new StringBuilder();
            builder.Append(string.Format("public static partial class GL"));
            builder.Append(("{"));
            builder.AppendLine();
            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            var list = from item in fieldsInfo
                       orderby item.Name
                       select item;
            foreach (var item in list) {
                builder.AppendLine(string.Format("    {0} {1} = 0x{2:X};", item.FieldType.Name, item.Name, item.GetValue(null)));
            }
            builder.Append(("}"));
            System.IO.File.WriteAllText("GL.constants.cs", builder.ToString());
        }

        public static void DumpMethods() {
            Type type = typeof(GL);
            var builder = new StringBuilder();
            builder.Append(string.Format("public static partial class GL"));
            builder.Append(("{"));
            builder.AppendLine();
            MethodInfo[] methodInfo = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            var list = from item in methodInfo
                       orderby item.Name
                       select item;
            foreach (var item in list) {
                builder.AppendLine(string.Format("    {0};", item));
            }
            builder.Append(("}"));
            System.IO.File.WriteAllText("GL.methods.cs", builder.ToString());
        }
        public static void DumpDelegates() {
            Type type = typeof(GL);
            var builder = new StringBuilder();
            builder.Append(string.Format("public static partial class GL"));
            builder.Append(("{"));
            builder.AppendLine();
            Type[] methodInfo = type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            var list = from item in methodInfo
                       orderby item.Name
                       select item;
            foreach (var item in list) {
                builder.AppendLine(string.Format("    {0};", item));
            }
            builder.Append(("}"));
            System.IO.File.WriteAllText("GL.delegates.cs", builder.ToString());
        }
    }
}
