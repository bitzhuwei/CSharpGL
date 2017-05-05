using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// complex node. commonly used shape.
    /// </summary>
    public class GLPositionColorNode : GLShapeNode
    {
        private static readonly Type type = typeof(GLPositionColorNode);
        internal override Type SelfTypeCache { get { return type; } }

        private VertexArrayObject vertexArrayObject;
        private ShaderProgram program;
        private static ShaderCode[] shaderCodes;

        static GLPositionColorNode()
        {
            shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Position.Color.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Position.Color.frag"), ShaderType.FragmentShader);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ShaderProgram GetProgram()
        {
            if (this.program == null)
            {
                this.program = ShaderCodesHelper.CreateProgram(shaderCodes);
            }

            return this.program;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="vertexBuffers"></param>
        /// <returns></returns>
        public VertexArrayObject GetVertexArrayObject(IndexBuffer indexBuffer, VertexBuffer[] vertexBuffers)
        {
            if (this.vertexArrayObject == null)
            {
                if (this.program == null)
                {
                    this.program = ShaderCodesHelper.CreateProgram(shaderCodes);
                }
                this.vertexArrayObject = new VertexArrayObject(indexBuffer, vertexBuffers);
                this.vertexArrayObject.Initialize(this.program);
            }

            return this.vertexArrayObject;
        }

    }
}
