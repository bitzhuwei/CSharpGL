using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.ToLegacyOpenGL.ChunkDumpers
{
    public static partial class ChunkDumper
    {
        public static void Dump(this FacesDescriptionChunk chunk, ThreeDSModel4LegacyOpenGL model, ThreeDSMesh4LegacyOpenGL mesh)
        {
            mesh.indices = chunk.triangleIndexes;

            foreach (var item in chunk.Children)
            {
                if (item is FacesMaterialChunk)
                {
                    (item as FacesMaterialChunk).Dump(model, mesh);
                }
                else if (item is SmoothingGroupListChunk)
                {
                    (item as SmoothingGroupListChunk).Dump(model, mesh);
                }
            }
        }
    }
}
