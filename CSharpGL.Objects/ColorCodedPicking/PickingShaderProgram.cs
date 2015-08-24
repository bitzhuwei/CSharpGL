using CSharpGL.Objects.Shaders;
using System;

namespace CSharpGL.Objects.ColorCodedPicking
{
    /// <summary>
    /// Description of PickingShaderProgram
    /// </summary>
    public static class PickingShaderProgram //: IDisposable
    {
        //static readonly object synObj = new object();

        public static ShaderProgram GetPickingShaderProgram()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"ColorCodedPicking.PickingShader.vert");
            string fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"ColorCodedPicking.PickingShader.frag");

            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();

            return shaderProgram;
        }

        //private static ShaderProgram shaderProgram = null;

        //static PickingShaderProgram()
        //{
            //if (shaderProgram == null)
            //{
            //    lock (synObj)
            //    {
            //        if (shaderProgram == null)
            //        {
            //            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"ColorCodedPicking.PickingShader.vert");
            //            string fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"ColorCodedPicking.PickingShader.frag");

            //            shaderProgram = new ShaderProgram();
            //            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            //            shaderProgram.AssertValid();
            //        }
            //    }
            //}
        //}
    }
}
