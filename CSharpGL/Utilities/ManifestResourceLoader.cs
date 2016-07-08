using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace System
{
    /// <summary>
    /// A small helper class to load manifest resource files.
    /// </summary>
    public static class ManifestResourceLoader
    {
        /// <summary>
        /// Loads the named manifest resource and returns each line in order.
        /// </summary>
        /// <param name="textFileName"></param>
        /// <returns></returns>
        public static Stream GetStream(string textFileName, int stackIndex = 2)
        {
            Assembly executingAssembly;
            string location;
            GetLocation(textFileName, stackIndex, out executingAssembly, out location);

            var stream = executingAssembly.GetManifestResourceStream(location);

            return stream;
        }
        /// <summary>
        /// Loads the named manifest resource and returns each line in order.
        /// </summary>
        /// <param name="textFileName"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetLines(string textFileName, int stackIndex = 2)
        {
            Assembly executingAssembly;
            string location;
            GetLocation(textFileName, stackIndex, out executingAssembly, out location);

            using (var stream = executingAssembly.GetManifestResourceStream(location))
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        yield return reader.ReadLine();
                    }
                }
            }
        }

        /// <summary>
        /// Loads the named manifest resource as a text string.
        /// </summary>
        /// <param name="textFileName">Name of the text file.</param>
        /// <returns>The contents of the manifest resource.</returns>
        public static string LoadTextFile(string textFileName, int stackIndex = 2)
        {
            Assembly executingAssembly;
            string location;
            GetLocation(textFileName, stackIndex, out executingAssembly, out location);

            using (var stream = executingAssembly.GetManifestResourceStream(location))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        internal static void GetLocation(string textFileName, int stackIndex, out Assembly executingAssembly, out string location)
        {
            StackTrace stack = new StackTrace();
            StackFrame frame = stack.GetFrame(stackIndex);
            MethodBase method = frame.GetMethod();
            Type type = method.ReflectedType;
            executingAssembly = type.Assembly; //Assembly.GetExecutingAssembly();
            string pathToDots = textFileName.Replace("\\", ".");
            location = string.Format("{0}.{1}", executingAssembly.GetName().Name, pathToDots);
        }

        /// <summary>
        /// Loads bitmap in the manifest resource.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="stackIndex"></param>
        /// <returns></returns>
        public static Bitmap LoadBitmap(string filename, int stackIndex = 2)
        {
            Assembly executingAssembly;
            string location;
            GetLocation(filename, stackIndex, out executingAssembly, out location);

            using (Stream stream = executingAssembly.GetManifestResourceStream(location))
            {
                Image image = Bitmap.FromStream(stream);
                Bitmap bmp = image as Bitmap;
                return bmp;
            }
        }
    }
}
