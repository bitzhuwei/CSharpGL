namespace CSharpGL
{
    /// <summary>
    /// Use this for perspective projection * view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface IPerspectiveCamera
    {
        /// <summary>
        /// Gets or sets the field of view.
        /// <value>
        /// The field of view in degrees.
        /// </value>
        /// </summary>
        double FieldOfView { get; set; }

        /// <summary>
        /// Gets or sets the aspect(width / height).
        /// </summary>
        /// <value>
        /// The aspect.
        /// </value>
        double AspectRatio { get; set; }

        /// <summary>
        /// Gets or sets the near.
        /// </summary>
        /// <value>
        /// The near.
        /// </value>
        double Near { get; set; }

        /// <summary>
        /// Gets or sets the far.
        /// </summary>
        /// <value>
        /// The far.
        /// </value>
        double Far { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        mat4 GetPerspectiveProjectionMatrix();
    }
}