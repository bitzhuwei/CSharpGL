using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class AiScene
    {
        public string Fullname { get; internal set; }

        public AiNode RootNode { get; internal set; }

        public AiMesh[] Meshes { get; internal set; }

        public AiMaterial[] Materials { get; internal set; }

        public AiAnimation[] Animations { get; internal set; }

        internal AiScene() { }

    }
}
