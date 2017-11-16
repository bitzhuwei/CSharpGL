using System;
using System.IO;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for logging.
    /// </summary>
    public partial class Log// : IDisposable
    {
        /// <summary>
        /// Single instance.
        /// </summary>
        public static readonly Log instance = new Log();
        private StreamWriter writer;

        private Log()
        {
            string filename = string.Format("{0:yyyy-MM-dd.HH-mm-ss}.log", DateTime.Now);
            var writer = new StreamWriter(filename);
            writer.AutoFlush = true;
            this.writer = writer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Write(object obj)
        {
            this.writer.Write(DateTime.Now);
            this.writer.WriteLine(":");
            this.writer.WriteLine(obj);
        }
    }
}
