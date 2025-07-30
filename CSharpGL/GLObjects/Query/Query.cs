using System;

namespace CSharpGL {
    /// <summary>
    /// A query object.
    /// <para>Occlusion Querys enable you to determine if a representative set of geometry will be visible after depth testing.</para>
    /// <para>Conditional rendering is for a single object that takes a lot of rendering resources. That means you only want to render it if it is absolutely necessary.</para>
    /// </summary>
    public unsafe partial class Query : IDisposable {
        //private static GLDelegates.void_int_uintN glGenQueries;
        //private static GLDelegates.void_uint glIsQuery;
        //private static GLDelegates.void_uint_uint glBeginQuery;
        //private static GLDelegates.void_uint glEndQuery;
        //private static GLDelegates.void_uint_uint_intN glGetQueryiv;
        //private static GLDelegates.void_uint_uint_intN glGetQueryObjectiv;
        //private static GLDelegates.void_uint_uint_uintN glGetQueryObjectuiv;
        //private static GLDelegates.void_uint_uint glBeginConditionalRender;
        //private static GLDelegates.void_void glEndConditionalRender;
        //private static GLDelegates.void_int_uintN glDeleteQueries;

        /// <summary>
        /// query object's id/name.
        /// </summary>
        public GLuint id;

        //static Query() {
        //    glGenQueries = gl.glGetDelegateFor("glGenQueries", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glIsQuery = gl.glGetDelegateFor("glIsQuery", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glBeginQuery = gl.glGetDelegateFor("glBeginQuery", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //    glEndQuery = gl.glGetDelegateFor("glEndQuery", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glGetQueryiv = gl.glGetDelegateFor("glGetQueryiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN;
        //    glBeginConditionalRender = gl.glGetDelegateFor("glBeginConditionalRender", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //    glEndConditionalRender = gl.glGetDelegateFor("glEndConditionalRender", GLDelegates.typeof_void_void) as GLDelegates.void_void;
        //    glGetQueryObjectiv = gl.glGetDelegateFor("glGetQueryObjectiv", GLDelegates.typeof_void_uint_uint_intN) as GLDelegates.void_uint_uint_intN;
        //    glGetQueryObjectuiv = gl.glGetDelegateFor("glGetQueryObjectuiv", GLDelegates.typeof_void_uint_uint_uintN) as GLDelegates.void_uint_uint_uintN;
        //    glDeleteQueries = gl.glGetDelegateFor("glDeleteQueries", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //}

        /// <summary>
        /// A query object.
        /// <para>Occlusion Querys enable you to determine if a representative set of geometry will be visible after depth testing.</para>
        /// <para>Conditional rendering is for a single object that takes a lot of rendering resources. That means you only want to render it if it is absolutely necessary.</para>
        /// </summary>
        public Query() {
            var gl = GL.current; if (gl == null) { return; }
            var ids = stackalloc GLuint[1];
            gl.glGenQueries(1, ids);
            this.id = ids[0];
        }

        /// <summary>
        /// Begin query.
        /// <para>delimit the boundaries of a query object.</para>
        /// </summary>
        /// <param name="target">Specifies the target type of query object established between glBeginQuery and the subsequent glEndQuery.</param>
        public void BeginQuery(QueryTarget target) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBeginQuery((GLenum)target, this.id);
        }

        /// <summary>
        /// Een query.
        /// </summary>
        /// <param name="target">Specifies the target type of query object to be concluded.s</param>
        public void EndQuery(QueryTarget target) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glEndQuery((GLenum)target);
        }

        /// <summary>
        /// Begin query.
        /// <para>delimit the boundaries of a query object.</para>
        /// </summary>
        /// <param name="target">Specifies the target type of query object established between glBeginQuery and the subsequent glEndQuery. The symbolic constant must be one of GL_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED_CONSERVATIVE, GL_PRIMITIVES_GENERATED, GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or GL_TIME_ELAPSED.</param>
        public void BeginQuery(GLenum target) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBeginQuery(target, this.id);
        }

        /// <summary>
        /// Een query.
        /// </summary>
        /// <param name="target">Specifies the target type of query object to be concluded. The symbolic constant must be one of GL_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED, GL_ANY_SAMPLES_PASSED_CONSERVATIVE, GL_PRIMITIVES_GENERATED, GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or GL_TIME_ELAPSED.</param>
        public void EndQuery(GLenum target) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glEndQuery(target);
        }

        // TODO: need demo!
        /// <summary>
        /// Begin conditional rendering.
        /// </summary>
        public void BeginConditionalRender(ConditionalRenderMode mode) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBeginConditionalRender(this.id, (GLenum)mode);
        }

        /// End conditional rendering.
        /// </summary>
        public void EndConditionalRender() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glEndConditionalRender();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public int SampleCount() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetQueryObjectiv(this.id, GL.GL_QUERY_RESULT, result);

            return result[0];
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool SampleRendered() {
            var gl = GL.current; if (gl == null) { return false; }
            var result = stackalloc int[1];
            int count = 1000;
            while (result[0] == 0 && count-- > 0) {
                gl.glGetQueryObjectiv(this.id, GL.GL_QUERY_RESULT_AVAILABLE, result);
            }

            if (result[0] != 0) {
                gl.glGetQueryObjectiv(this.id, GL.GL_QUERY_RESULT, result);
            }
            else {
                result[0] = 1;
            }

            return result[0] != 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Query, Id:{0}", this.id);
        }
    }
}