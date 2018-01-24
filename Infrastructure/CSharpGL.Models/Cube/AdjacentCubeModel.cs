using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class AdjacentCubeModel : IBufferSource
    {
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(1,-1,-1),
            new vec3(1,-1,1),
            new vec3(-1,-1,1),
            new vec3(-1,-1,-1),
            new vec3(1,1,-1),
            new vec3(1,1,1),
            new vec3(-1,1,1),
            new vec3(-1,1,-1),
        };

        private static readonly Face[] indexes = new Face[] { new Face(0, 1, 2), new Face(0, 2, 3), new Face(4, 7, 6), new Face(4, 6, 5), new Face(0, 4, 5), new Face(0, 5, 1), new Face(1, 5, 6), new Face(1, 6, 2), new Face(2, 6, 7), new Face(2, 7, 3), new Face(4, 0, 3), new Face(4, 3, 7), };

        private static readonly AdjacentFace[] adjacentIndexes;

        static AdjacentCubeModel()
        {
            adjacentIndexes = FaceHelper.CalculateAdjacentFaces(indexes);
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
