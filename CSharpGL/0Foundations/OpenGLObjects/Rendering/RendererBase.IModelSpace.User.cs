namespace CSharpGL
{
    public abstract partial class RendererBase
    {
        private MarkableStruct<mat4> modelMatrix = new MarkableStruct<mat4>(mat4.identity());
        //private mat4 cascadeModelMatrix = mat4.identity();

        ///// <summary>
        ///// Should this model matrix be updated?
        ///// </summary>
        ///// <returns></returns>
        //public bool IsModelMatrixMarked()
        //{
        //    return this.modelMatrixRecord.IsMarked();
        //}

        private long parentModelMatrixTicks;

        // TODO: cascade model matrix not tested yet!
        /// <summary>
        /// Get model matrix that transform model from model space to world space.
        /// Note: this method requires that parent scene object be rendered first, then chidren.
        /// </summary>
        /// <returns></returns>
        public MarkableStruct<mat4> GetModelMatrix()
        {
            //return new MarkableStruct<mat4>(IModelSpaceHelper.GetModelMatrix(this));
            if (this.modelMatrixRecord.IsMarked())// this model matrix is updated.
            {
                mat4 thisModel = IModelSpaceHelper.GetModelMatrix(this);
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
                            MarkableStruct<mat4> parentMatrix = parentRenderer.GetModelMatrix();
                            // this requires that parent scene object be rendered first, then chidren.
                            thisModel = parentMatrix.Value * thisModel;
                        }
                    }
                }
                // total model matrix.
                this.modelMatrix.Value = thisModel;
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
                            MarkableStruct<mat4> parentMatrix = parentRenderer.GetModelMatrix();
                            long ticks = parentMatrix.UpdateTicks;
                            if (this.parentModelMatrixTicks != ticks) // parent's model matrix is updated.
                            {
                                mat4 thisModel = IModelSpaceHelper.GetModelMatrix(this);
                                this.modelMatrix.Value = parentMatrix.Value * thisModel;
                                this.parentModelMatrixTicks = ticks;
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