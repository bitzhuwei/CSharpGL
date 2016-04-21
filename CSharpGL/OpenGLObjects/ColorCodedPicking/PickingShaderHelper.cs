using System;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// Description of PickingShaderProgram
    /// </summary>
    public static class PickingShaderHelper //: IDisposable
    {

        public static ShaderProgram GetPickingShaderProgram()
        {
            ShaderCode[] shaders = new ShaderCode[2];
            shaders[0] = new ShaderCode(GetShaderSource(ShaderType.VertexShader), ShaderType.VertexShader);
            shaders[1] = new ShaderCode(GetShaderSource(ShaderType.FragmentShader), ShaderType.FragmentShader);

            var shaderProgram = new ShaderProgram();
            shaderProgram.Create((from item in shaders select item.CreateShader()).ToArray());

            return shaderProgram;
        }

        /// <summary>
        /// vertex shader's cache.
        /// </summary>
        static string vertexShader = null;

        /// <summary>
        /// fragmente shader's cache.
        /// </summary>
        static string fragmentShader = null;

        /// <summary>
        /// Gets shader's source code for color coded picking.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <returns></returns>
        private static string GetShaderSource(ShaderType shaderType)
        {
            string result = string.Empty;

            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    if (vertexShader == null)
                    {
                        vertexShader = ManifestResourceLoader.LoadTextFile(
                            @"OpenGLObjects.ColorCodedPicking.PickingShader.vert");
                    }
                    result = vertexShader;
                    break;
                case ShaderType.FragmentShader:
                    if (fragmentShader == null)
                    {
                        fragmentShader = ManifestResourceLoader.LoadTextFile(
                            @"OpenGLObjects.ColorCodedPicking.PickingShader.frag");
                    }
                    result = fragmentShader;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

    }
}
