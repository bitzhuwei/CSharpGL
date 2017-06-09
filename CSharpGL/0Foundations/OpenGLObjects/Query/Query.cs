using System;

namespace CSharpGL
{
    /// <summary>
    /// A query object.
    /// <para>Occlusion Querys enable you to determine if a representative set of geometry will be visible after depth testing.</para>
    /// <para>Conditional rendering is for a single object that takes a lot of rendering resources. That means you only want to render it if it is absolutely necessary.</para>
    /// </summary>
    public partial class Query : IDisposable
    {
        private static GLDelegates.void_int_uintN glGenQueries;
        private static GLDelegates.void_uint glIsQuery;
        private static GLDelegates.void_uint_uint glBeginQuery;
        private static GLDelegates.void_uint glEndQuery;
        private static GLDelegates.void_uint_uint_intN glGetQueryiv;
        private static GLDelegates.void_uint_uint_intN glGetQueryObjectiv;
        private static GLDelegates.void_uint_uint_uintN glGetQueryObjectuiv;
        private static GLDelegates.void_uint_uint glBeginConditionalRender;
        private static GLDelegates.void_void glEndConditionalRender;
        private static GLDelegates.void_int_uintN glDeleteQueries;

        /// <summary>
        /// texture's id/name.
        /// </summary>
        protected uint[] ids = new uint[1];

        /// <summary>
        /// query object's id/name.
        /// </summary>
        public uint Id { get { return this.ids[0]; } }

        static Query()
        {
            glGenQueries = OpenGL.GetDelegateFor("glGenQueries", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glIsQuery = OpenGL.GetDelegateFor("glIsQuery", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glBeginQuery = OpenGL.GetDelegateFor("glBeginQuery", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glEndQuery = OpenGL.GetDelegateFor("glEndQuery", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glGetQueryiv = OpenGL.GetDelegateFor("glGetQueryiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN;
            glBeginConditionalRender = OpenGL.GetDelegateFor("glBeginConditionalRender", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glEndConditionalRender = OpenGL.GetDelegateFor("glEndConditionalRender", GLDelegates.typeof_void_void) as GLDelegates.void_void;
            glGetQueryObjectiv = OpenGL.GetDelegateFor("glGetQueryObjectiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN;
            glGetQueryObjectuiv = OpenGL.GetDelegateFor("glGetQueryObjectuiv", GLDelegates.typeof_void_uint_uint_uintN) as GLDelegates.void_uint_uint_uintN;
            glDeleteQueries = OpenGL.GetDelegateFor("glDeleteQueries", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        }
        /// <summary>
        /// Begin query.
        /// <para>delimit the boundaries of a query object.</para>
        /// </summary>
        /// <param name="target">Specifies the target type of query object established between glBeginQuery and the subsequent glEndQuery.</param>
        public void BeginQuery(QueryTarget target)
        {
            if (!this.initialized) { this.Initialize(); }

            glBeginQuery((uint)target, this.Id);
        }

        /// <summary>
        /// Een query.
        /// </summary>
        /// <param name="target">Specifies the target type of query object to be concluded.s</param>
        public void EndQuery(QueryTarget target)
        {
            glEndQuery((uint)target);
        }

        /// <summary>
        /// Begin query.
        /// <para>delimit the boundaries of a query object.</para>
        /// </summary>
        /// <param name="target">Specifies the target type of query object established between glBeginQuery and the subsequent glEndQuery. The symbolic constant must be one of GL_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED_CONSERVATIVE, GL_PRIMITIVES_GENERATED, GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or GL_TIME_ELAPSED.</param>
        public void BeginQuery(uint target)
        {
            if (!this.initialized) { this.Initialize(); }

            glBeginQuery(target, this.Id);
        }

        /// <summary>
        /// Een query.
        /// </summary>
        /// <param name="target">Specifies the target type of query object to be concluded. The symbolic constant must be one of GL_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED_CONSERVATIVE, GL_PRIMITIVES_GENERATED, GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or GL_TIME_ELAPSED.</param>
        public void EndQuery(uint target)
        {
            glEndQuery(target);
        }

        // TODO: need demo!
        /// <summary>
        /// Begin conditional rendering.
        /// </summary>
        public void BeginConditionalRender(ConditionalRenderMode mode)
        {
            glBeginConditionalRender(this.Id, (uint)mode);
        }

        /// <summary>
        /// Begin conditional rendering.
        /// </summary>
        public void BeginConditionalRender(uint mode)
        {
            glBeginConditionalRender(this.Id, mode);
        }

        /// <summary>
        /// End conditional rendering.
        /// </summary>
        public void EndConditionalRender()
        {
            glEndConditionalRender();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool SampleRendered()
        {
            var result = new int[1];
            int count = 1000;
            while (result[0] == 0 && count-- > 0)
            {
                glGetQueryObjectiv(this.Id, OpenGL.GL_QUERY_RESULT_AVAILABLE, result);
            }

            if (result[0] != 0)
            {
                glGetQueryObjectiv(this.Id, OpenGL.GL_QUERY_RESULT, result);
            }
            else
            {
                result[0] = 1;
            }

            return result[0] != 0;
        }

        private bool initialized = false;

        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize()
        {
            if (!this.initialized)
            {
                glGenQueries(1, this.ids);

                this.initialized = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Query, Id:{0}", this.Id);
        }
    }
}