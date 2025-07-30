using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Set up texture's content with 'glTexImage3DMultisample()'.
    /// </summary>
    public unsafe class TexImage3DMultisample : TexStorageBase {
        private int samples;
        private int width;
        private int height;
        private int depth;
        private bool fixedSampleLocations;

        //internal static readonly GLDelegates.void_uint_uint_uint_uint_uint_uint_bool glTexImage3DMultisample;
        //static TexImage3DMultisample() {
        //    glTexImage3DMultisample = gl.glGetDelegateFor("glTexImage3DMultisample", GLDelegates.typeof_void_uint_uint_uint_uint_uint_uint_bool) as GLDelegates.void_uint_uint_uint_uint_uint_uint_bool;
        //}

        /// <summary>
        /// Set up texture's content with 'glTexImage3DMultisample()'.
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="fixedSampleLocations"></param>
        public TexImage3DMultisample(int samples, uint internalFormat, int width, int height, int depth, bool fixedSampleLocations)
            : base(TextureTarget.Texture2DMultisampleArray, internalFormat) {
            this.samples = samples;
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.fixedSampleLocations = fixedSampleLocations;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glTexImage3DMultisample(GL.GL_TEXTURE_2D_MULTISAMPLE_ARRAY, samples, internalFormat, width, height, depth, fixedSampleLocations);
        }

    }
}
