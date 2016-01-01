using CSharpGL.Objects.Shaders;
using System;

namespace CSharpGL.ColorCodedPicking
{
    /// <summary>
    /// Description of PickingShaderProgram
    /// </summary>
    public static class PickingShaderHelper //: IDisposable
    {

        public static ShaderProgram GetPickingShaderProgram()
        {
            var vertexShaderSource = GetShaderSource(ShaderTypes.VertexShader);
            string fragmentShaderSource = GetShaderSource(ShaderTypes.FragmentShader);

            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            return shaderProgram;
        }

        //static readonly object synObj = new object();
        //private static ShaderProgram shaderProgram = null;

        //static PickingShaderProgram()
        //{
        //if (shaderProgram == null)
        //{
        //    lock (synObj)
        //    {
        //        if (shaderProgram == null)
        //        {
        //            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"PickingShader.vert");
        //            string fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"PickingShader.frag");

        //            shaderProgram = new ShaderProgram();
        //            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        //            shaderProgram.AssertValid();
        //        }
        //    }
        //}
        //}

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
        public static string GetShaderSource(ShaderTypes shaderType)
        {
            string result = string.Empty;

            switch (shaderType)
            {
                case ShaderTypes.VertexShader:
                    if (vertexShader == null)
                    {
                        vertexShader = ManifestResourceLoader.LoadTextFile(@"PickingShader.vert");
                    }
                    result = vertexShader;
                    break;
                case ShaderTypes.FragmentShader:
                    if (fragmentShader == null)
                    {
                        fragmentShader = ManifestResourceLoader.LoadTextFile(@"PickingShader.frag");
                    }
                    result = fragmentShader;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public enum ShaderTypes
        {
            VertexShader,
            FragmentShader,
        }
    }
}
