using CSharpGL.Objects.RenderContexts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.GLInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            string time = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            string logName = string.Format("CSharpGL.GLInformation.txt");
            string logFullname = Path.Combine(Environment.CurrentDirectory, logName);

            // Initialises OpenGL.
            var renderContext = new FBORenderContext();

            //  Create the render context.
            renderContext.Create(GLVersion.OpenGL2_1, 1, 1, 32, null);

            renderContext.MakeCurrent();

            using (StreamWriter sw = new StreamWriter(logFullname, false))
            {
                sw.WriteLine(string.Format("GL version:  {0}", GL.GetString(GL.GL_VERSION)));
                sw.WriteLine(string.Format("GL vendor:   {0}", GL.GetString(GL.GL_VENDOR)));
                sw.WriteLine(string.Format("GL renderer: {0}", GL.GetString(GL.GL_RENDERER)));
                sw.WriteLine();

                //  Set the extensions info.
                var extensions = GL.GetString(GL.GL_EXTENSIONS).Split(
                    new[] { " " }, StringSplitOptions.RemoveEmptyEntries).OrderBy(s => s);
                sw.WriteLine("extensions:");
                sw.WriteLine(string.Join(System.Environment.NewLine, extensions));
                sw.WriteLine();

                //  Set the arb extensions info.
                try
                {
                    sw.WriteLine("ARB extensions:");
                    var arbExtensions = GL.GetExtensionsStringARB(renderContext.DeviceContextHandle).Split(
                        new[] { " " }, StringSplitOptions.RemoveEmptyEntries).OrderBy(s => s);
                    sw.WriteLine(string.Join(System.Environment.NewLine, arbExtensions));
                    sw.WriteLine();
                }
                catch (Exception e)
                {
                    sw.WriteLine("The ARB Extensions cannot be loaded.");
                }

                //  Get each member of the OpenGL object.
                var members = typeof(GL).GetMembers(BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance|  BindingFlags.Static);

                //  Go through each member.
                foreach (var member in members)
                {
                    if (member.Name.Substring(0, 2) == "gl" && member.MemberType == MemberTypes.NestedType)
                    {
                        string name = member.Name;
                        bool supported = IsExtensionFunctionSupported(name);

                        sw.WriteLine("function: {0} {1}", member.Name, supported ? "Supported" : "Not Supported");
                    }
                }
            }
            //{
            //    builder.AppendFormat("*********************Error occurred!*********************"); builder.AppendLine();
            //    builder.AppendFormat(e.ToString()); builder.AppendLine();
            //}

            //File.WriteAllText(logFullname, builder.ToString());
            Process.Start("explorer", logFullname);
        }

        /// <summary>
        /// Determines whether a named extension function is supported.
        /// </summary>
        /// <param name="extensionFunctionName">Name of the extension function.</param>
        /// <returns>
        /// 	<c>true</c> if the extension function is supported; otherwise, <c>false</c>.
        /// </returns>
        static bool IsExtensionFunctionSupported(string extensionFunctionName)
        {
            //  Try and get the proc address for the function.
            IntPtr procAddress = Win32.wglGetProcAddress(extensionFunctionName);

            //  As long as the pointer is non-zero, we can invoke the extension function.
            return procAddress != IntPtr.Zero;
        }
    }
}
