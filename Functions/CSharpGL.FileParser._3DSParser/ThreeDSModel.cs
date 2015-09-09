using System;
using System.Collections.Generic;

namespace CSharpGL.FileParser._3DSParser
{
    public class ThreeDSModel
    {
        public List<ThreeDSMesh> Entities = new List<ThreeDSMesh>();

        public void Render()
        {
            foreach (ThreeDSMesh e in Entities)
                e.Render();
        }
    }
}
