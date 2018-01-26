using System.Collections.Generic;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public abstract partial class ModernNode : SceneNodeBase//, IRenderable
    {
        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        ///<param name="builders">OpenGL switches.</param>
        public ModernNode(IBufferSource model, params RenderMethodBuilder[] builders)
        {
            this.RenderUnit = new ModernRenderUnit(model, builders);
        }
    }
}