using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public class LocationParsing : ParsingActionBase
    {
        public override void Parse(ObjParsingContext context)
        {
            if (context.ObjFile.MeshList.Count <= 0) { return; }

            vec3 min, max;
            foreach (var item in context.ObjFile.MeshList)
            {
                item.CalculateSizePosition();
            }

            min = context.ObjFile.MeshList[0].position - context.ObjFile.MeshList[0].size / 2;
            max = context.ObjFile.MeshList[0].position + context.ObjFile.MeshList[0].size / 2;

            for (int i = 1; i < context.ObjFile.MeshList.Count; i++)
            {
                ObjMesh mesh = context.ObjFile.MeshList[i];
                vec3 _min = mesh.position - mesh.size / 2;
                vec3 _max = mesh.position + mesh.size / 2;
                if (_min.x < min.x) { min.x = _min.x; }
                if (_min.y < min.y) { min.y = _min.y; }
                if (_min.z < min.z) { min.z = _min.z; }
                if (max.x < _max.x) { max.x = _max.x; }
                if (max.y < _max.y) { max.y = _max.y; }
                if (max.z < _max.z) { max.z = _max.z; }
            }

            vec3 position = min / 2 + max / 2;
            context.ObjFile.Size = max - min;
            context.ObjFile.Position = position;

            foreach (var item in context.ObjFile.MeshList)
            {
                item.position = item.position - position;
            }
        }

    }
}
