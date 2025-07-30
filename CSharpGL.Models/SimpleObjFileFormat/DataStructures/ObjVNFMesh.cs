﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public unsafe class ObjVNFMesh {
        public vec3[] vertexes;
        public vec3[] normals;
        public vec2[] texCoords;
        public vec4[] tangents;
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
