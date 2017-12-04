using System;
using System.IO;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for logging.
    /// </summary>
    public static class Log// : IDisposable
    {
        private static StreamWriter writer;
        private static readonly object synObj = new object();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public static void Write(object obj)
        {
            if (writer == null)
            {
                lock (synObj)
                {
                    if (writer == null)
                    {
                        string filename = string.Format("CSharpGL.{0:yyyy-MM-dd--HH-mm-ss}.log", DateTime.Now);
                        writer = new StreamWriter(filename);
                        writer.AutoFlush = true;
                    }
                }
            }

            writer.Write(DateTime.Now);
            writer.WriteLine(":");
            writer.WriteLine(obj);
        }
    }
}
