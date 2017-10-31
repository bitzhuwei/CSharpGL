using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexStorage2DMultisample : TexStorageBase
    {
        private uint samples;
        private uint width;
        private uint height;
        private bool fixedSampleLocations;

        internal static readonly GLDelegates.void_uint_uint_uint_uint_uint_bool glTexStorage2DMultisample;
        static TexStorage2DMultisample()
        {
            glTexStorage2DMultisample = GL.Instance.GetDelegateFor("glTexStorage2DMultisample", GLDelegates.typeof_void_uint_uint_uint_uint_uint_bool) as GLDelegates.void_uint_uint_uint_uint_uint_bool;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fixedSampleLocations"></param>
        public TexStorage2DMultisample(uint samples, uint internalFormat, uint width, uint height, bool fixedSampleLocations)
            : base(TextureTarget.Texture2DMultisample, internalFormat)
        {
            this.samples = samples;
            this.width = width;
            this.height = height;
            this.fixedSampleLocations = fixedSampleLocations;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            glTexStorage2DMultisample(GL.GL_TEXTURE_2D_MULTISAMPLE, samples, internalFormat, width, height, fixedSampleLocations);
        }

    }
}
