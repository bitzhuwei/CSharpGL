using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Bind a <see cref="Sampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
    /// </summary>
    public partial class Sampler : List<SamplerParameter>, IDisposable
    {
        internal static readonly GLDelegates.void_int_uintN glGenSamplers;
        internal static readonly GLDelegates.void_uint_uint glBindSampler;
        internal static readonly GLDelegates.void_int_uintN glDeleteSamplers;
        static Sampler()
        {
            glGenSamplers = GL.Instance.GetDelegateFor("glGenSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindSampler = GL.Instance.GetDelegateFor("glBindSampler", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glDeleteSamplers = GL.Instance.GetDelegateFor("glDeleteSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        }

        private uint[] ids = new uint[1];

        /// <summary>
        /// 
        /// </summary>
        public uint Id { get { return this.ids[0]; } }

        /// <summary>
        /// Bind a <see cref="Sampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
        /// </summary>
        public Sampler()
        {
            glGenSamplers(this.ids.Length, this.ids);
        }

        /// <summary>
        /// Bind a <see cref="Sampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
        /// </summary>
        /// <param name="textureUnitIndex">texture's unit's index.[0, 1, 2, ..)</param>
        public void Bind(uint textureUnitIndex)
        {
            glBindSampler(textureUnitIndex, this.ids[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textureUnitIndex">texture's unit's index.[0, 1, 2, ..)</param>
        public void Unbind(uint textureUnitIndex)
        {
            glBindSampler(textureUnitIndex, 0);
        }

        /// <summary>
        /// Commit all sampler parameters of this <see cref="Sampler"/> object.
        /// </summary>
        public void Commit()
        {
            foreach (var item in this)
            {
                item.Apply(this.Id);
            }
        }
    }
}
