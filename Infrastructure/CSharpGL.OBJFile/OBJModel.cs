using System.Collections.Generic;

namespace CSharpGL.OBJFile
{
    public class OBJModel
    {
        public List<vec3> positionList = new List<vec3>();

        public List<vec2> uvList = new List<vec2>();

        public List<vec3> normalList = new List<vec3>();

        public List<Tuple<int, int, int>> faceList = new List<Tuple<int, int, int>>();

        internal List<Triangle> innerFaceList = new List<Triangle>();
    }
}