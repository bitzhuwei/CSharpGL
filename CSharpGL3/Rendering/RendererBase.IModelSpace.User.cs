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