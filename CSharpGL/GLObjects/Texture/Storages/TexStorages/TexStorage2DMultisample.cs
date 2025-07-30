using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe class TexStorage2DMultisample : TexStorageBase {
        private int samples;
        private int width;
        private int height;
        private bool fixedSampleLocations;

        //internal static readonly GLDelegates.void_uint_uint_uint_uint_uint_bool glTexStorage2DMultisample;
        //static TexStorage2DMultisample() {
        //    glTexStorage2DMultisample = gl.glGetDelegateFor("glTexStorage2DMultisample", GLDelegates.typeof_void_uint_uint_uint_uint_uint_bool) as GLDelegates.void_uint_uint_uint_uint_uint_bool;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fixedSampleLocations"></param>
        public TexStorage2DMultisample(int samples, uint internalFormat, int width, int height, bool fixedSampleLocations)
            : base(TextureTarget.Texture2DMultisample, internalFormat) {
            this.samples = samples;
            this.width = width;
            this.height = height;
            this.fixedSampleLocations = fixedSampleLocations;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glTexStorage2DMultisample(GL.GL_TEXTURE_2D_MULTISAMPLE, samples, internalFormat, width, height, fixedSampleLocations);
        }

    }
}
