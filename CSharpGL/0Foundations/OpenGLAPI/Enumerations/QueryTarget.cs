namespace CSharpGL
{
    /// <summary>
    /// QueryTarget
    /// </summary>
    public enum QueryTarget : uint
    {
        /// <summary>
        ///
        /// </summary>
        SamplesPassed = OpenGL.GL_SAMPLES_PASSED,

        /// <summary>
        ///
        /// </summary>
        AnySamplesPassed = OpenGL.GL_ANY_SAMPLES_PASSED,

        /// <summary>
        ///
        /// </summary>
        AnySamplesPassedConservative = OpenGL.GL_ANY_SAMPLES_PASSED_CONSERVATIVE,
    }

    /// <summary>
    /// Conditional rendering mode.
    /// </summary>
    public enum ConditionalRenderMode : uint
    {
        /// <summary>
        ///
        /// </summary>
        QueryWait = OpenGL.GL_QUERY_WAIT,

        /// <summary>
        ///
        /// </summary>
        QueryNoWait = OpenGL.GL_QUERY_NO_WAIT,

        /// <summary>
        ///
        /// </summary>
        QueryByRegionWait = OpenGL.GL_QUERY_BY_REGION_WAIT,

        /// <summary>
        ///
        /// </summary>
        QueryByRegionNoWait = OpenGL.GL_QUERY_BY_REGION_NO_WAIT,
    }
}