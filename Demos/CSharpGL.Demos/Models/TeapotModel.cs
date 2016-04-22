using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Models
{
    public partial class TeapotModel
    {
        public List<vec3> positions = new List<vec3>();
        public List<vec3> normals = new List<vec3>();
        public List<Tuple<ushort, ushort, ushort>> faces = new List<Tuple<ushort, ushort, ushort>>();

        private TeapotModel() { }

        public static TeapotModel GetModel(float radius = 1.0f)
        {
            TeapotModel model = TeapotLoader.GetModel();

            if (radius != 1.0f)
            {
                for (int i = 0; i < model.positions.Count; i++)
                {
                    model.positions[i] *= radius;
                }
            }
            model.positions = model.positions.Move2Center();

            return model;
        }


    }

}
