using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Bind a <see cref="Sampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
    /// </summary>
    public unsafe partial class Sampler : List<SamplerParameter>, IDisposable {
        //internal static readonly GLDelegates.void_int_uintN glGenSamplers;
        //internal static readonly GLDelegates.void_uint_uint glBindSampler;
        //internal static readonly GLDelegates.void_int_uintN glDeleteSamplers;
        //static Sampler() {
        //    glGenSamplers = gl.glGetDelegateFor("glGenSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glBindSampler = gl.glGetDelegateFor("glBindSampler", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //    glDeleteSamplers = gl.glGetDelegateFor("glDeleteSamplers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //}

        /// <summary>
        /// 
        /// </summary>
        public readonly GLuint id;
        public GLuint lastBindIndex = 0;

        /// <summary>
        /// Bind a <see cref="Sampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
        /// </summary>
        public Sampler() {
            var gl = GL.current; if (gl != null) {
                var ids = stackalloc GLuint[1];
                gl.glGenSamplers(1, ids);
                this.id = ids[0];
            }
        }

        /// <summary>
        /// Bind a <see cref="Sampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
        /// </summary>
        /// <param name="textureUnitIndex">texture's unit's index.[0, 1, 2, ..)</param>
        public void Bind(uint textureUnitIndex) {
            var gl = GL.current; if (gl != null) {
                this.lastBindIndex = textureUnitIndex;
                gl.glBindSampler(textureUnitIndex, this.id);
            }
        }

        public void Unbind() {
            var gl = GL.current; if (gl != null) {
                gl.glBindSampler(this.lastBindIndex, 0);
            }
        }

        /// <summary>
        /// Commit all sampler parameters of this <see cref="Sampler"/> object.
        /// </summary>
        public void Commit() {
            foreach (var item in this) {
                item.Apply(this.id);
            }
        }
    }
}
