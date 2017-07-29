using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class LocationParser : ObjParserBase
    {
        /// <summary>
        /// move mesh to center of model space.
        /// </summary>
        /// <param name="context"></param>
        public override void Parse(ObjVNFContext context)
        {
            if (context.vertexCount <= 0) { return; }

            vec3[] vertexes = context.Mesh.vertexes;
            vec3 min = vertexes[0];
            vec3 max = min;
            for (int i = 1; i < vertexes.Length; i++)
            {
                vec3 position = vertexes[i];
                if (position.x < min.x) { min.x = position.x; }
                if (position.y < min.y) { min.y = position.y; }
                if (position.z < min.z) { min.z = position.z; }
                if (max.x < position.x) { max.x = position.x; }
                if (max.y < position.y) { max.y = position.y; }
                if (max.z < position.z) { max.z = position.z; }
            }

            vec3 center = min / 2 + max / 2;
            vec3 size = max - min;

            context.Mesh.Position = center;// position in world space.
            context.Mesh.Size = size;
            // move vertexes to center of model space.
            for (int i = 0; i < vertexes.Length; i++)
            {
                vertexes[i] = vertexes[i] - center;
            }
        }
    }
}
