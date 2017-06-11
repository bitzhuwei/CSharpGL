using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class PickingShaderHelper //: IDisposable
    {
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
        public static IShaderProgramProvider GetPickingShaderProgramProvider()
        {
            var vertexShader = new VertexShader(GetShaderSource(ShaderType.VertexShader), "in_Position");
            var fragmentShader = new FragmentShader(GetShaderSource(ShaderType.FragmentShader));
            var provider = new ShaderArray(vertexShader, fragmentShader);
            return provider;
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