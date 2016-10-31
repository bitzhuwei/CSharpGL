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
        internal static OpenGL.glGetUniformBlockIndex glGetUniformBlockIndex;
        internal static OpenGL.glGetActiveUniformBlockiv glGetActiveUniformBlockiv;
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
            if (uniformBufferPtr == null)
            {
                uniformBufferPtr = Initialize(program);
            }
            else
            {
                IntPtr pointer = uniformBufferPtr.MapBuffer(MapBufferAccess.WriteOnly, bind: true);
                unsafe
                {
                    var array = (byte*)pointer.ToPointer();
                    byte[] bytes = this.value.ToBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        array[i] = bytes[i];
                    }
                }
                uniformBufferPtr.UnmapBuffer(unbind: true);
            }

            this.Updated = false;
        }

        /// <summary>
        /// Initialize and setup uniform block's value.
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        private UniformBufferPtr Initialize(ShaderProgram program)
        {
            if (glGetUniformBlockIndex == null)
            {
                glGetUniformBlockIndex = OpenGL.GetDelegateFor<OpenGL.glGetUniformBlockIndex>();
                glGetActiveUniformBlockiv = OpenGL.GetDelegateFor<OpenGL.glGetActiveUniformBlockiv>();
            }

            uint uboIndex = glGetUniformBlockIndex(program.ProgramId, this.VarName);
            var uboSize = new uint[1];
            glGetActiveUniformBlockiv(program.ProgramId, uboIndex, OpenGL.GL_UNIFORM_BLOCK_DATA_SIZE, uboSize);
            UniformBufferPtr result = null;
            using (var buffer = new UniformBuffer<byte>(BufferUsage.StaticDraw))
            {
                byte[] bytes = this.value.ToBytes();
                buffer.Alloc(bytes.Length);
                unsafe
                {
                    var array = (byte*)buffer.Header.ToPointer();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        array[i] = bytes[i];
                    }
                }

                result = buffer.GetBufferPtr() as UniformBufferPtr;
            }

            //glBindBufferBase(OpenGL.GL_UNIFORM_BUFFER, uboIndex, result.BufferId);
            //glBindBufferBase(OpenGL.GL_UNIFORM_BUFFER, 0, result.BufferId);
            //glUniformBlockBinding(program.ProgramId, uboIndex, 0);
            result.Binding(program, uboIndex, 0);
            result.Unbind();

            return result;
        }

        private UniformBufferPtr uniformBufferPtr = null;
    }
}