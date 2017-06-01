using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// Render model with the 'NoLight' shader.
    /// </summary>
    public class NoLightNode : LightModelNode
    {
        private ShaderProgram shaderProgram;
        private static readonly string[] attributeNames = new string[] { "inPosition", "inColor" };

        /// <summary>
        /// 
        /// </summary>
        public NoLightNode()
        {
        }

        public ShaderProgram GetShaderProgram()
        {
            if (this.shaderProgram == null)
            {
                var vertexShader = new VertexShader(ManifestResourceLoader.LoadTextFile(@"Shaders\NoLight.vert"), attributeNames);
                vertexShader.Initialize();
                var fragmentShader = new FragmentShader(ManifestResourceLoader.LoadTextFile(@"Shaders\NoLight.frag"));
                fragmentShader.Initialize();
                this.shaderProgram = new ShaderProgram();
                this.shaderProgram.Initialize(vertexShader, fragmentShader);
                vertexShader.Dispose();
                fragmentShader.Dispose();
            }

            return this.shaderProgram;
        }

        /// <summary>
        /// Names of aLl attributes in vertex shader.
        /// </summary>
        /// <returns></returns>
        public string[] GetAttributeNames()
        {
            return attributeNames;
        }
    }

}
