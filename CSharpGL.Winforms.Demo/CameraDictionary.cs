using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;

namespace CSharpGL.Winforms.Demo
{
    /// <summary>
    /// Description of CameraDictionary
    /// </summary>
    public sealed class CameraDictionary : Dictionary<string, ScientificCamera>
    {
        private static CameraDictionary instance = new CameraDictionary();

        public static CameraDictionary Instance
        {
            get
            {
                return instance;
            }
        }

        private CameraDictionary()
        {
        }
    }
}
