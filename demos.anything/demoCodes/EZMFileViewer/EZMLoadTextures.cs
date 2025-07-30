using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EZMFileViewer {
    public static class EZMLoadTextures {
        public static void LoadTextures(this EZMMaterial material, string ezmFullname) {
            if (material == null) { return; }
            var fileInfo = new FileInfo(ezmFullname);
            string filename = Path.Combine(fileInfo.DirectoryName, material.MetaData);

        }
    }
}
