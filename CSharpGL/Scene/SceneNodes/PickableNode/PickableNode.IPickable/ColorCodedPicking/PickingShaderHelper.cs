using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class PickingShaderHelper //: IDisposable
    {
        /// <summary>
        /// vertex's 
        /// </summary>
        internal const string in_Position = "in_Position";

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static IShaderProgramProvider GetPickingShaderProgramProvider()
        {
            var vs = new VertexShader(pickVertexShader);
            var fs = new FragmentShader(pickFragmentShader);
            var provider = new ShaderArray(vs, fs);
            return provider;
        }

        private static readonly string pickVertexShader =
@"#version 150 core

uniform mat4 MVP;
uniform int pickingBaseId; // how many vertices have been coded so far?

in vec3 " + in_Position + @";

flat out vec4 pass_Color; // glShadeMode(GL_FLAT); in legacy opengl.

void main(void) {
	gl_Position = MVP * vec4(in_Position, 1.0);

	int objectID = pickingBaseId + gl_VertexID;
	pass_Color = vec4(
		float(objectID & 0xFF) / 255.0, 
		float((objectID >> 8) & 0xFF) / 255.0, 
		float((objectID >> 16) & 0xFF) / 255.0, 
		float((objectID >> 24) & 0xFF) / 255.0);
}
";

        private static readonly string pickFragmentShader =
@"#version 150 core

flat in vec4 pass_Color; // glShadeMode(GL_FLAT); in legacy opengl.

out vec4 outColor;

void main(void) {
	outColor = pass_Color;
}
";

    }
}