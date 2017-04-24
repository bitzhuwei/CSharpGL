namespace CSharpGL
{
    /// <summary>
    /// QueryTarget
    /// </summary>
    public enum QueryTarget : uint
    {
        /// <summary>
        /// id must be an unused name, or the name of an existing occlusion query object. When glBeginQuery is executed, the query object's samples-passed counter is reset to 0. Subsequent rendering will increment the counter for every sample that passes the depth test. If the value of GL_SAMPLE_BUFFERS is 0, then the samples-passed count is incremented by 1 for each fragment. If the value of GL_SAMPLE_BUFFERS is 1, then the samples-passed count is incremented by the number of samples whose coverage bit is set. However, implementations, at their discression may instead increase the samples-passed count by the value of GL_SAMPLES if any sample in the fragment is covered. When glEndQuery is executed, the samples-passed counter is assigned to the query object's result value. This value can be queried by calling glGetQueryObject with pname GL_QUERY_RESULT.
        /// </summary>
        SamplesPassed = OpenGL.GL_SAMPLES_PASSED,

        /// <summary>
        /// id must be an unused name, or the name of an existing boolean occlusion query object. When glBeginQuery is executed, the query object's samples-passed flag is reset to GL_FALSE. Subsequent rendering causes the flag to be set to GL_TRUE if any sample passes the depth test in the case of GL_ANY_SAMPLES_PASSED, or if the implementation determines that any sample might pass the depth test in the case of GL_ANY_SAMPLES_PASSED_CONSERVATIVE. The implementation may be able to provide a more efficient test in the case of GL_ANY_SAMPLES_PASSED_CONSERVATIVE if some false positives are acceptable to the application. When glEndQuery is executed, the samples-passed flag is assigned to the query object's result value. This value can be queried by calling glGetQueryObject with pname GL_QUERY_RESULT.
        /// </summary>
        AnySamplesPassed = OpenGL.GL_ANY_SAMPLES_PASSED,

        /// <summary>
        /// id must be an unused name, or the name of an existing boolean occlusion query object. When glBeginQuery is executed, the query object's samples-passed flag is reset to GL_FALSE. Subsequent rendering causes the flag to be set to GL_TRUE if any sample passes the depth test in the case of GL_ANY_SAMPLES_PASSED, or if the implementation determines that any sample might pass the depth test in the case of GL_ANY_SAMPLES_PASSED_CONSERVATIVE. The implementation may be able to provide a more efficient test in the case of GL_ANY_SAMPLES_PASSED_CONSERVATIVE if some false positives are acceptable to the application. When glEndQuery is executed, the samples-passed flag is assigned to the query object's result value. This value can be queried by calling glGetQueryObject with pname GL_QUERY_RESULT.
        /// </summary>
        AnySamplesPassedConservative = OpenGL.GL_ANY_SAMPLES_PASSED_CONSERVATIVE,

        /// <summary>
        /// id must be an unused name, or the name of an existing primitive query object previously bound to the GL_PRIMITIVES_GENERATED query binding. When glBeginQuery is executed, the query object's primitives-generated counter is reset to 0. Subsequent rendering will increment the counter once for every vertex that is emitted from the geometry shader, or from the vertex shader if no geometry shader is present. When glEndQuery is executed, the primitives-generated counter is assigned to the query object's result value. This value can be queried by calling glGetQueryObject with pname GL_QUERY_RESULT.
        /// </summary>
        PrimitivesGenerated = OpenGL.GL_PRIMITIVES_GENERATED,

        /// <summary>
        /// id must be an unused name, or the name of an existing primitive query object previously bound to the GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN query binding. When glBeginQuery is executed, the query object's primitives-written counter is reset to 0. Subsequent rendering will increment the counter once for every vertex that is written into the bound transform feedback buffer(s). If transform feedback mode is not activated between the call to glBeginQuery and glEndQuery, the counter will not be incremented. When glEndQuery is executed, the primitives-written counter is assigned to the query object's result value. This value can be queried by calling glGetQueryObject with pname GL_QUERY_RESULT.
        /// </summary>
        TransformFeedbackPrimitivesWritten = OpenGL.GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN,

        /// <summary>
        /// id must be an unused name, or the name of an existing timer query object previously bound to the GL_TIME_ELAPSED query binding. When glBeginQuery is executed, the query object's time counter is reset to 0. When glEndQuery is executed, the elapsed server time that has passed since the call to glBeginQuery is written into the query object's time counter. This value can be queried by calling glGetQueryObject with pname GL_QUERY_RESULT.
        /// </summary>
        TimeElapsed = OpenGL.GL_TIME_ELAPSED,
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