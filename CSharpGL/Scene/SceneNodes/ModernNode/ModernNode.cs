using System.Collections.Generic;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public abstract partial class ModernNode : SceneNodeBase, IRenderable
    {
        // data structure for rendering.
        protected readonly RenderUnitBuilder[] builders;
        protected readonly IBufferSource model;

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        ///<param name="builders">OpenGL switches.</param>
        public ModernNode(IBufferSource model, params RenderUnitBuilder[] builders)
        {
            this.model = model;
            this.builders = builders;
        }
    }
}