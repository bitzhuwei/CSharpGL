using System;

namespace CSharpGL
{
    public partial class Texture
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="bufferPtr"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when disposing returned texture.</param>
        /// <returns></returns>
        public static Texture CreateBufferTexture(uint internalFormat, BufferPtr bufferPtr, bool autoDispose)
        {
            var texture = new Texture(BindTextureTarget.TextureBuffer,
                new TexBufferImageFiller(internalFormat, bufferPtr, autoDispose),
                new NullSampler());
            texture.Initialize();
            return texture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="internalFormat"></param>
        /// <param name="elementCount"></param>
        /// <param name="usage"></param>
        /// <param name="noDataCopyed"></param>
        /// <returns></returns>
        public static Texture CreateBufferTexture<T>(uint internalFormat, int elementCount, BufferUsage usage, bool noDataCopyed = false) where T : struct
        {
            var buffer = new TextureBuffer<T>(usage, noDataCopyed);
            buffer.Create(elementCount);
            var bufferPtr = buffer.GetBufferPtr() as IndependentBufferPtr;

            const bool autoDispose = true;
            var texture = new Texture(BindTextureTarget.TextureBuffer,
                new TexBufferImageFiller(internalFormat, bufferPtr, autoDispose),
                new NullSampler());
            texture.Initialize();
            return texture;
        }
    }
}