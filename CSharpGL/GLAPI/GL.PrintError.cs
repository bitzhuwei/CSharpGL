using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GL
    {
        /// <summary>
        /// 
        /// </summary>
        public void PrintError()
        {
            var error = (ErrorCode)GL.Instance.GetError();
            if (error != ErrorCode.NoError)
            {
                Console.WriteLine(error);
                Log.Write(error);
            }
        }
    }
}
