using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.CSSL2GLSL
{
    public class CSSLFileGroup
    {
        private string csslFile;

        public string CsslFile
        {
            get { return csslFile; }
            set { csslFile = value; }
        }
        private string mainFile;

        public string MainFile
        {
            get { return mainFile; }
            set { mainFile = value; }
        }

        public CSSLFileGroup(string csslFile, string mainFile)
        {
            // TODO: Complete member initialization
            this.csslFile = csslFile;
            this.mainFile = mainFile;
        }

        public string[] ToArray()
        {
            return new string[] { csslFile, mainFile, };
        }

        public override string ToString()
        {
            return string.Format("{0}+main.cs", csslFile);
        }
    }
}
