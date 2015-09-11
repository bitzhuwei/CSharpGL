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
        public static void Dump(this FramesChunk chunk, ThreeDSModel model)
        {
            foreach (var item in chunk.Children)
            {
                if (item is ObjectNameChunk)
                {
                    (item as ObjectNameChunk).Dump(model);
                }
                else if (item is ObjectPivotPointChunk)
                {
                    (item as ObjectPivotPointChunk).Dump(model);
                }
                else if (item is PositionTrackChunk)
                {
                    (item as PositionTrackChunk).Dump(model);
                }
                else if (item is RotationTrackChunk)
                {
                    (item as RotationTrackChunk).Dump(model);
                }
                else if (item is ScaleTrackChunk)
                {
                    (item as ScaleTrackChunk).Dump(model);
                }
                else if (item is HierarchyPositionChunk)
                {
                    (item as HierarchyPositionChunk).Dump(model);
                }
            }
        }
    }
}
