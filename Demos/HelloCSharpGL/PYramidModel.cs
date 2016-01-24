using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharpGL
{
    class PyramidModel
    {
        public readonly vec3[] positions;
        public readonly vec3[] colors;

        public PyramidModel()
        {
            var positions = new vec3[12];
            positions[0] = new vec3(0.0f, 1.0f, 0.0f);
            positions[1] = new vec3(-1.0f, -1.0f, 1.0f);
            positions[2] = new vec3(1.0f, -1.0f, 1.0f);
            positions[3] = new vec3(0.0f, 1.0f, 0.0f);
            positions[4] = new vec3(1.0f, -1.0f, 1.0f);
            positions[5] = new vec3(1.0f, -1.0f, -1.0f);
            positions[6] = new vec3(0.0f, 1.0f, 0.0f);
            positions[7] = new vec3(1.0f, -1.0f, -1.0f);
            positions[8] = new vec3(-1.0f, -1.0f, -1.0f);
            positions[9] = new vec3(0.0f, 1.0f, 0.0f);
            positions[10] = new vec3(-1.0f, -1.0f, -1.0f);
            positions[11] = new vec3(-1.0f, -1.0f, 1.0f);
            this.positions = positions;

            var colors = new vec3[12];
            colors[0] = new vec3(1.0f, 0.0f, 0.0f);
            colors[1] = new vec3(0.0f, 1.0f, 0.0f);
            colors[2] = new vec3(0.0f, 0.0f, 1.0f);
            colors[3] = new vec3(1.0f, 0.0f, 0.0f);
            colors[4] = new vec3(0.0f, 0.0f, 1.0f);
            colors[5] = new vec3(0.0f, 1.0f, 0.0f);
            colors[6] = new vec3(1.0f, 0.0f, 0.0f);
            colors[7] = new vec3(0.0f, 1.0f, 0.0f);
            colors[8] = new vec3(0.0f, 0.0f, 1.0f);
            colors[9] = new vec3(1.0f, 0.0f, 0.0f);
            colors[10] = new vec3(0.0f, 0.0f, 1.0f);
            colors[11] = new vec3(0.0f, 1.0f, 0.0f);
            this.colors = colors;
        }
    }
}
