namespace CSharpGL
{
    /// <summary>
    /// fill texture's content with a buffer.
    /// </summary>
    public class TexBufferImageFiller : ImageFiller
    {
        private uint internalformat;
        private BufferPtr bufferPtr;
        private bool autoDispose;

        /// <summary>
        ///
        /// </summary>
        /// <param name="internalformat"></param>
        /// <param name="bufferPtr"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when this filler is disposed.</param>
        public TexBufferImageFiller(uint internalformat, BufferPtr bufferPtr, bool autoDispose)
        {
            this.internalformat = internalformat;
            this.bufferPtr = bufferPtr;
            this.autoDispose = autoDispose;
        }

        /// <summary>
        ///
        /// </summary>
        public override void Fill()
        {
            OpenGL.GetDelegateFor<OpenGL.glTexBuffer>()(OpenGL.GL_TEXTURE_BUFFER, internalformat, bufferPtr.BufferId);
            if (this.autoDispose)
            {
                bufferPtr.Dispose();
                bufferPtr = null;
            }
        }
    }
}