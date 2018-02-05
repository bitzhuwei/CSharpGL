using System.ComponentModel;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public abstract partial class PickableNode : ModernNode, IPickable
    {
        // data structure for rendering.
        //private readonly RenderMethodBuilder[] builders;
        private readonly IPickableRenderMethodBuilder pickingRenderMethodBuilder;
        //private readonly IBufferSource model;

        /// <summary>
        /// Scene node that supports 'Color-Coded-Picking'.
        /// </summary>
        ///<param name="model">Only <see cref="DrawArraysCmd"/> and <see cref="DrawElementsCmd"/> are supported as <see cref="IDrawCommand"/>.</param>
        /// <param name="positionNameInIBufferSource">The 'in' variable name which represents position buffer vertex shader.</param>
        ///<param name="builders"></param>
        public PickableNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            var pickingProgramProvider = PickingShaderHelper.GetPickingShaderProgramProvider();
            this.pickingRenderMethodBuilder = new IPickableRenderMethodBuilder(pickingProgramProvider, positionNameInIBufferSource);
        }
    }
}