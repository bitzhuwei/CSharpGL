using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class ObjVNFMesh
    {
        public vec3[] vertexes;
        public vec3[] normals;
        public ObjVNFFace[] faces;

        /// <summary>
        /// 
        /// </summary>
        public vec3 Position { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Size { get; internal set; }
    }
}
