using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    public class QuadModel
    {
        public static readonly float[] vertices = new float[]
        {
			// positions + texture Coords
			-1.0f, 1.0f, 0.0f, 0.0f, 1.0f,
			-1.0f, -1.0f, 0.0f, 0.0f, 0.0f,
			1.0f, 1.0f, 0.0f, 1.0f, 1.0f,
			1.0f, -1.0f, 0.0f, 1.0f, 0.0f, 
		};
    }
}
