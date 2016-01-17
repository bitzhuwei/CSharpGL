using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.OBJParser
{
    public class ObjModel
    {
        List<vec3> positionList = new List<vec3>();

        public List<vec3> PositionList
        {
            get { return positionList; }
            set { positionList = value; }
        }
        List<vec2> uvList = new List<vec2>();

        public List<vec2> UVList
        {
            get { return uvList; }
            set { uvList = value; }
        }
        List<vec3> normalList = new List<vec3>();

        public List<vec3> NormalList
        {
            get { return normalList; }
            set { normalList = value; }
        }
        List<Triangle> triangleList = new List<Triangle>();

        public List<Triangle> TriangleList
        {
            get { return triangleList; }
            set { triangleList = value; }
        }
    }
}
