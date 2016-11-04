namespace CSharpGL
{
    public abstract partial class RendererBase
    {
        /// <summary>
        /// model matrix that transform this renderer in world space coordinate.
        /// </summary>
        private MarkableStruct<mat4> modelMatrix = new MarkableStruct<mat4>(mat4.identity());

        ///// <summary>
        ///// Should this model matrix be updated?
        ///// </summary>
        ///// <returns></returns>
        //public bool IsModelMatrixMarked()
        //{
        //    return this.modelMatrixRecord.IsMarked();
        //}

        private long parentMatrixTicks;

        /// <summary>
        /// Get model matrix that transform this renderer from model space to world space.
        /// </summary>
        /// <returns></returns>
        public MarkableStruct<mat4> GetModelMatrix()
        {
            if (this.modelMatrixRecord.IsMarked())// this model matrix is updated.
            {
                // get matrix representing transform relative to parent node.
                mat4 matrix = IModelSpaceHelper.GetModelMatrix(this);
                this.modelMatrixRecord.CancelMark();
                // cascade parent's model matrix.
                SceneObject obj = this.BindingSceneObject;
                if (obj != null)
                {
                    SceneObject parent = obj.Parent;
                    if (parent != null)
                    {
                        RendererBase parentRenderer = parent.Renderer;
                        if (parentRenderer != null)
                        {
                            // get parent's matrix representing transform relative to world space coordinate.
                            MarkableStruct<mat4> parentMatrix = parentRenderer.GetModelMatrix();
                            // get matrix means transform relative to world space coordinate for this renderer.
                            matrix = parentMatrix.Value * matrix;
                        }
                    }
                }
                // update this renderer's transform matrix relative to world space coordinate.
                this.modelMatrix.Value = matrix;
            }
            else // this model matrix is not updated.
            {
                SceneObject obj = this.BindingSceneObject;
                if (obj != null)
                {
                    SceneObject parent = obj.Parent;
                    if (parent != null)
                    {
                        RendererBase parentRenderer = parent.Renderer;
                        if (parentRenderer != null)
                        {
                            // get parent's matrix representing transform relative to world space coordinate.
                            MarkableStruct<mat4> parentMatrix = parentRenderer.GetModelMatrix();
                            long ticks = parentMatrix.UpdateTicks;
                            if (this.parentMatrixTicks != ticks) // parent's model matrix is updated.
                            {
                                mat4 matrix = IModelSpaceHelper.GetModelMatrix(this);
                                this.modelMatrix.Value = parentMatrix.Value * matrix;
                                this.parentMatrixTicks = ticks;
                            }
                        }
                    }
                }
            }

            return this.modelMatrix;
        }
    }

    ///// <summary>
    /////
    ///// </summary>
    //[Flags]
    //public enum ModelSpaceFactor
    //{
    //    /// <summary>
    //    ///
    //    /// </summary>
    //    WorldPosition,
    //    /// <summary>
    //    ///
    //    /// </summary>
    //    Scale,
    //    /// <summary>
    //    ///
    //    /// </summary>
    //    RotationAngle,
    //    /// <summary>
    //    ///
    //    /// </summary>
    //    RotationAxis,
    //}
}