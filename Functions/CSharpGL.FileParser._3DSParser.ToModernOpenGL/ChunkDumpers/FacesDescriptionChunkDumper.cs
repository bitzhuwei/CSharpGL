using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.ToModernOpenGL.ChunkDumpers
{
    public static partial class ChunkDumper
    {
        public static void Dump(this FacesDescriptionChunk chunk, ThreeDSModel4ModernOpengl model, ThreeDSMesh4ModernOpenGL mesh)
        {
            mesh.TriangleIndexes = chunk.triangleIndexes;

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
                else if (!(item is UndefinedChunk))
                {
                    throw new NotImplementedException(string.Format(
                        "not dumper implemented for {0}", item.GetType()));
                }
            }
        }
    }
}
