using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser
{
    public struct TexCoord
    {
        public float U;
        public float V;

        public TexCoord(float u, float v)
        {
            U = u;
            V = v;
        }

        public override string ToString()
        {
            //return base.ToString();
            return string.Format("U: {0}, V: {1}", U, V);
        }
    }
}
