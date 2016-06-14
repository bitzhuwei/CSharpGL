
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    class GLCanvasDesignModeRenderer : PickableRenderer
    {
        const string vertexShader = @"#version 150 core

in vec3 in_Position;
in vec3 in_Color;
out vec4 pass_Color;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	pass_Color = vec4(in_Color, 1.0);
}
";
        const string fragmentShader = @"#version 150 core

in vec4 pass_Color;
out vec4 out_Color;

void main(void) {
	out_Color = pass_Color;
}
";
        static IBufferable model;
        static ShaderCode[] shaderCodes;
        static PropertyNameMap map;
        static string positionNameInIBufferable;

        static GLCanvasDesignModeRenderer()
        {
            model = new Tetrahedron();
            shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(vertexShader, ShaderType.VertexShader);
            shaderCodes[0] = new ShaderCode(fragmentShader, ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("in_Position", Tetrahedron.strPosition);
            map.Add("in_Color", Tetrahedron.strColor);
            positionNameInIBufferable = Tetrahedron.strPosition;
        }

        private GLCanvasDesignModeRenderer()
            : base(model, shaderCodes, map, positionNameInIBufferable)
        { }

        private static readonly GLCanvasDesignModeRenderer instance = new GLCanvasDesignModeRenderer();

        public static GLCanvasDesignModeRenderer GetInstance()
        {
            return instance;
        }
    }
}
