using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL.EZM.Assimp;

namespace CSharpGL
{
    public class AiScene
    {
        public AiNode RootNode { get; private set; }

        public AiMesh[] Meshes { get; private set; }

        public AiMaterial[] Materials { get; private set; }

        public AiAnimation[] Animations { get; private set; }


        /// <summary>
        /// from ezm file to AiScene.
        /// </summary>
        /// <param name="ezmFile"></param>
        /// <returns></returns>
        public static AiScene Parse(EZMFile ezmFile)
        {
            throw new NotImplementedException();
        }
    }
}
