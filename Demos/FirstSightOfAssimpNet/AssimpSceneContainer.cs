using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    public class AssimpSceneContainer
    {
        private Assimp.Scene aiScene;
        public AssimpSceneContainer(Assimp.Scene aiScene)
        {
            this.aiScene = aiScene;
        }

        private VertexBuffer positionBuffer;
        private VertexBuffer uvBuffer;
        private VertexBuffer weightsBuffer;
        private VertexBuffer boneIDsBuffer;

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {

        }

    }
}
