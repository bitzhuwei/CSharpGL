using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CSharpGL.EZM;

namespace CSharpGL
{
    class EZMFile
    {
        public static EZMFile Load(string filename)
        {
            EZMFile file = null;
            if (File.Exists(filename))
            {
                XElement xElement = XElement.Load(filename);
                EZMMeshSystem meshSystem = EZMMeshSystem.Parse(xElement);
                file = new EZMFile() { MeshSystem = meshSystem };
            }

            return file;
        }

        public EZMMeshSystem MeshSystem { get; private set; }

    }
}
