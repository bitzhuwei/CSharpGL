using System;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class PickingShaderHelper //: IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static ShaderProgram GetPickingShaderProgram()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(GetShaderSource(ShaderType.VertexShader), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(GetShaderSource(ShaderType.FragmentShader), ShaderType.FragmentShader);

            ShaderProgram program = new ShaderProgram();
            var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
            program.Initialize(shaders);
            foreach (var item in shaders) { item.Delete(); }

            return program;
        }

        /// <summary>
        /// vertex shader's cache.
        /// </summary>
        private static string vertexShader = null;

        /// <summary>
        /// fragmente shader's cache.
        /// </summary>
        private static string fragmentShader = null;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static ShaderCode[] GetShaderCodes()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(GetShaderSource(ShaderType.VertexShader), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(GetShaderSource(ShaderType.FragmentShader), ShaderType.FragmentShader);

            return shaderCodes;
        }

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
                            @"Resources.Picking.vert");
                    }
                    result = vertexShader;
                    break;

                case ShaderType.FragmentShader:
                    if (fragmentShader == null)
                    {
                        fragmentShader = ManifestResourceLoader.LoadTextFile(
                            @"Resources.Picking.frag");
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