using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CSharpGL.EZM;

namespace CSharpGL
{
    public class EZMFile
    {
        public static EZMFile Load(string filename)
        {
            EZMFile file = null;
            if (File.Exists(filename))
            {
                XElement xElement = XElement.Load(filename);
                EZMMeshSystem meshSystem = EZMMeshSystem.Parse(xElement);
                file = new EZMFile();
                file.MeshSystem = meshSystem;
                file.Fullname = filename;
            }

            return file;
        }

        public EZMMeshSystem MeshSystem { get; private set; }

        public string Fullname { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.Fullname, this.MeshSystem);
        }

    }
}
