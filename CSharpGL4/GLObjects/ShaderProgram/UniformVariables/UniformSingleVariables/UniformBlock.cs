using System;

namespace CSharpGL
{
    // uniform Uniforms {
    //     vec3 vPos;
    //     float scale;
    //     ...
    // } someUniformBlock;
    // block name is 'Uniforms'.
    /// <summary>
    /// A uiform block in shader.
    /// <para>https://www.opengl.org/registry/specs/ARB/uniform_buffer_object.txt</para>
    /// <para>http://blog.csdn.net/csxiaoshui/article/details/32101977</para>
    /// </summary>
    public class UniformBlock<T> : UniformSingleVariable<T> where T : struct, IEquatable<T>
    {
        internal static GLDelegates.uint_uint_string glGetUniformBlockIndex;
        internal static GLDelegates.uint_uint_uint_uint_uintN glGetActiveUniformBlockiv;
        //internal static OpenGL.glUniformBlockBinding glUniformBlockBinding;
        //internal static OpenGL.glBindBufferRange glBindBufferRange;
        //internal static OpenGL.glBindBufferBase glBindBufferBase;

        /// <summary>
        /// A uiform block in shader.
        /// </summary>
        /// <param name="blockName"></param>
        public UniformBlock(string blockName) : base(blockName) { }

        /// <summary>
        /// A uiform block in shader.
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="value"></param>
        public UniformBlock(string blockName, T value) : base(blockName) { this.Value = value; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            if (uniformBuffer == null)
            {
                uniformBuffer = Initialize(program);
            }
            else
            {
                IntPtr pointer = uniformBuffer.MapBuffer(MapBufferAccess.WriteOnly, bind: true);
                unsafe
                {
                    var array = (byte*)pointer.ToPointer();
                    byte[] bytes = this.value.ToBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        array[i] = bytes[i];
                    }
                }
                uniformBuffer.UnmapBuffer(unbind: true);
            }

            this.Updated = false;
        }

        /// <summary>
        /// Initialize and setup uniform block's value.
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        private UniformBuffer Initialize(ShaderProgram program)
        {
            if (glGetUniformBlockIndex == null)
            {
                glGetUniformBlockIndex = GL.Instance.GetDelegateFor("glGetUniformBlockIndex", GLDelegates.typeof_uint_uint_string) as GLDelegates.uint_uint_string;
                glGetActiveUniformBlockiv = GL.Instance.GetDelegateFor("glGetActiveUniformBlockiv", GLDelegates.typeof_uint_uint_uint_uint_uintN) as GLDelegates.uint_uint_uint_uint_uintN;
            }

            uint uboIndex = glGetUniformBlockIndex(program.ProgramId, this.VarName);
            var uboSize = new uint[1];
            glGetActiveUniformBlockiv(program.ProgramId, uboIndex, GL.GL_UNIFORM_BLOCK_DATA_SIZE, uboSize);
            byte[] bytes = this.value.ToBytes();
            UniformBuffer result = bytes.GenUniformBuffer(BufferUsage.StaticDraw);
            // another way to do this:
            //UniformBuffer result = UniformBuffer.Create(typeof(byte), bytes.Length, BufferUsage.StaticDraw);
            //unsafe
            //{
            //    var array = (byte*)result.MapBuffer(MapBufferAccess.WriteOnly);
            //    for (int i = 0; i < bytes.Length; i++)
            //    {
            //        array[i] = bytes[i];
            //    }
            //    result.UnmapBuffer();
            //}

            //glBindBufferBase(GL.GL_UNIFORM_BUFFER, uboIndex, result.BufferId);
            //glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, result.BufferId);
            //glUniformBlockBinding(program.ProgramId, uboIndex, 0);
            result.Binding(program, uboIndex, 0);
            result.Unbind();

            return result;
        }

        private UniformBuffer uniformBuffer = null;
    }
}