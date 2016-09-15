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
        private static OpenGL.glGenQueries glGenQueries;
        private static OpenGL.glDeleteQueries glDeleteQueries;
        private static OpenGL.glIsQuery glIsQuery;
        private static OpenGL.glBeginQuery glBeginQuery;
        private static OpenGL.glEndQuery glEndQuery;
        private static OpenGL.glGetQueryiv glGetQueryiv;
        private static OpenGL.glGetQueryObjectiv glGetQueryObjectiv;
        private static OpenGL.glGetQueryObjectuiv glGetQueryObjectuiv;
        private static OpenGL.glBeginConditionalRender glBeginConditionalRender;
        private static OpenGL.glEndConditionalRender glEndConditionalRender;

        /// <summary>
        /// texture's id/name.
        /// </summary>
        protected uint[] ids = new uint[1];

        /// <summary>
        /// query object's id/name.
        /// </summary>
        public uint Id { get { return this.ids[0]; } }

        /// <summary>
        /// Begin query.
        /// <para>delimit the boundaries of a query object.</para>
        /// </summary>
        /// <param name="target">Specifies the target type of query object established between glBeginQuery and the subsequent glEndQuery.</param>
        public void BeginQuery(QueryTarget target)
        {
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
                if (glGenQueries == null)
                {
                    glGenQueries = OpenGL.GetDelegateFor<OpenGL.glGenQueries>();
                    glDeleteQueries = OpenGL.GetDelegateFor<OpenGL.glDeleteQueries>();
                    glIsQuery = OpenGL.GetDelegateFor<OpenGL.glIsQuery>();
                    glBeginQuery = OpenGL.GetDelegateFor<OpenGL.glBeginQuery>();
                    glEndQuery = OpenGL.GetDelegateFor<OpenGL.glEndQuery>();
                    glGetQueryiv = OpenGL.GetDelegateFor<OpenGL.glGetQueryiv>();
                    glGetQueryObjectiv = OpenGL.GetDelegateFor<OpenGL.glGetQueryObjectiv>();
                    glGetQueryObjectuiv = OpenGL.GetDelegateFor<OpenGL.glGetQueryObjectuiv>();
                    glBeginConditionalRender = OpenGL.GetDelegateFor<OpenGL.glBeginConditionalRender>();
                    glEndConditionalRender = OpenGL.GetDelegateFor<OpenGL.glEndConditionalRender>();
                }

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