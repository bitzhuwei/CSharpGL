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
        public static void Dump(this TriangularMeshChunk chunk, ThreeDSModel4ModernOpengl model)
        {
            ThreeDSMesh4ModernOpenGL mesh = new ThreeDSMesh4ModernOpenGL();

            foreach (var item in chunk.Children)
            {
                if (item is VerticesListChunk)
                {
                    (item as VerticesListChunk).Dump(model, mesh);
                }
                else if (item is FacesDescriptionChunk)
                {
                    (item as FacesDescriptionChunk).Dump(model, mesh);
                }
                else if (item is MappingCoordinatesListChunk)
                {
                    (item as MappingCoordinatesListChunk).Dump(model, mesh);
                }
                else if (item is LocalCoordinatesSystemChunk)
                {
                    (item as LocalCoordinatesSystemChunk).Dump(model, mesh);
                }
                else if (!(item is UndefinedChunk))
                {
                    throw new NotImplementedException(string.Format(
                        "not dumper implemented for {0}", item.GetType()));
                }
            }

            model.Entities.Add(mesh);
        }
    }
}
