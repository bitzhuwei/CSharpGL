using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// COLOR_ATTACHMENTi —— 附着到这里的纹理将接收来自片元着色器的颜色。‘i’ 后缀意味着可以有多个纹理同时被附着为颜色附着点。在片元着色器中有一个机制可以确保同时将颜色输出到多个缓冲区中。
    /// DEPTH_ATTACHMENT —— 附着在上面的纹理将收到深度测试的结果。
    /// STENCIL_ATTACHMENT —— 附着在上面的纹理将充当模板缓冲区。模板缓冲区限制了光栅化的区域，可被用于不同的技术。
    /// DEPTH_STENCIL_ATTACHMENT —— 这仅是一个深度和模板缓冲区的结合，因为它俩经常被一起使用。
    /// </summary>
    public enum RenderbufferAttachment : uint
    {
        /// <summary>
        ///
        /// </summary>
        ColorAttachment0 = GL.GL_COLOR_ATTACHMENT0,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment1 = GL.GL_COLOR_ATTACHMENT1,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment2 = GL.GL_COLOR_ATTACHMENT2,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment3 = GL.GL_COLOR_ATTACHMENT3,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment4 = GL.GL_COLOR_ATTACHMENT4,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment5 = GL.GL_COLOR_ATTACHMENT5,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment6 = GL.GL_COLOR_ATTACHMENT6,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment7 = GL.GL_COLOR_ATTACHMENT7,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment8 = GL.GL_COLOR_ATTACHMENT8,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment9 = GL.GL_COLOR_ATTACHMENT9,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment10 = GL.GL_COLOR_ATTACHMENT10,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment11 = GL.GL_COLOR_ATTACHMENT11,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment12 = GL.GL_COLOR_ATTACHMENT12,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment13 = GL.GL_COLOR_ATTACHMENT13,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment14 = GL.GL_COLOR_ATTACHMENT14,

        /// <summary>
        ///
        /// </summary>
        ColorAttachment15 = GL.GL_COLOR_ATTACHMENT15,

        /// <summary>
        ///
        /// </summary>
        DepthAttachment = GL.GL_DEPTH_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        StencilAttachment = GL.GL_STENCIL_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        DepthStencilAttachment = GL.GL_DEPTH_STENCIL_ATTACHMENT,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TextureAttachment : uint
    {
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment = GL.GL_COLOR_ATTACHMENT0,

        /// <summary>
        ///
        /// </summary>
        DepthAttachment = GL.GL_DEPTH_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        StencilAttachment = GL.GL_STENCIL_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        DepthStencilAttachment = GL.GL_DEPTH_STENCIL_ATTACHMENT,
    }
    public partial class Framebuffer
    {
        private static readonly uint[] attachment_id =
        {
			GL.GL_COLOR_ATTACHMENT0,
			GL.GL_COLOR_ATTACHMENT1,
			GL.GL_COLOR_ATTACHMENT2,
			GL.GL_COLOR_ATTACHMENT3,
			GL.GL_COLOR_ATTACHMENT4,
			GL.GL_COLOR_ATTACHMENT5,
			GL.GL_COLOR_ATTACHMENT6,
			GL.GL_COLOR_ATTACHMENT7,
			GL.GL_COLOR_ATTACHMENT8,
			GL.GL_COLOR_ATTACHMENT9,
			GL.GL_COLOR_ATTACHMENT10,
			GL.GL_COLOR_ATTACHMENT11,
			GL.GL_COLOR_ATTACHMENT12,
			GL.GL_COLOR_ATTACHMENT13,
			GL.GL_COLOR_ATTACHMENT14,
			GL.GL_COLOR_ATTACHMENT15,
        };

        private List<Renderbuffer> colorBufferList = new List<Renderbuffer>();
        private Renderbuffer depthBuffer;
        private int nextColorAttachmentIndex = 0;

        /// <summary>
        /// Attach a texture.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public void Attach(Texture texture)
        {
            if (nextColorAttachmentIndex >= attachment_id.Length)
            { throw new IndexOutOfRangeException("Not enough color attach points!"); }

            glFramebufferTexture(GL.GL_FRAMEBUFFER, attachment_id[nextColorAttachmentIndex++], texture.Id, 0);
        }

        /// <summary>
        /// Attach a texture.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="depthAttachment">true for depth attachment; otherwise, color attachment.</param>
        /// <returns></returns>
        public void Attach(Texture texture, bool depthAttachment)
        {
            if (depthAttachment)
            {
                glFramebufferTexture2D(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, (uint)texture.Target, texture.Id, 0);
            }
            else
            {
                if (nextColorAttachmentIndex >= attachment_id.Length)
                { throw new IndexOutOfRangeException("Not enough color attach points!"); }

                glFramebufferTexture2D(GL.GL_FRAMEBUFFER, attachment_id[nextColorAttachmentIndex++], (uint)texture.Target, texture.Id, 0);
            }
        }

        /// <summary>
        /// Attach a texture.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Texture Attach(TextureAttachment type)
        {
            const int level = 0;
            Texture result = null;
            switch (type)
            {
                case TextureAttachment.ColorAttachment:
                    result = new Texture(TextureTarget.Texture2D,
                        new TexImage2D(TexImage2D.Target.Texture2D, 0, (int)GL.GL_RGBA, this.Width, this.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                    result.Initialize();
                    glFramebufferTexture(GL.GL_FRAMEBUFFER, attachment_id[nextColorAttachmentIndex++], result.Id, level);
                    break;
                case TextureAttachment.DepthAttachment:
                    result = new Texture(TextureTarget.Texture2D,
                    new TexImage2D(TexImage2D.Target.Texture2D, 0, (int)GL.GL_DEPTH_COMPONENT32, this.Width, this.Height, 0, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT));
                    // 设置默认滤波模式
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                    // 设置深度比较模式
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureCompareMode, (int)GL.GL_COMPARE_REF_TO_TEXTURE));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureCompareFunc, (int)GL.GL_LEQUAL));
                    // 设置边界截取模式
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
                    result.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
                    result.Initialize();
                    glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, result.Id, level);
                    //glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_STENCIL_ATTACHMENT, result.Id, level);
                    //glFramebufferTexture2D(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, GL.GL_TEXTURE_2D, result.Id, level);
                    //glFramebufferTexture2D(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_STENCIL_ATTACHMENT, GL.GL_TEXTURE_2D, result.Id, level);// error 
                    break;
                case TextureAttachment.StencilAttachment:
                    throw new NotImplementedException();
                    break;
                case TextureAttachment.DepthStencilAttachment:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        /// <summary>
        /// Attach a renderbuffer.
        /// </summary>
        /// <param name="renderbuffer"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public Renderbuffer Attach(RenderbufferType renderbuffer, FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            Renderbuffer result = null;
            switch (renderbuffer)
            {
                case RenderbufferType.DepthBuffer:
                    result = AttachDepthbuffer(target);
                    break;

                case RenderbufferType.ColorBuffer:
                    result = AttachColorbuffer(target);
                    break;

                default:
                    throw new Exception("Unexpected RenderbufferType!");
            }

            return result;
        }

        private Renderbuffer AttachColorbuffer(FramebufferTarget target)
        {
            if (nextColorAttachmentIndex >= attachment_id.Length)
            { throw new IndexOutOfRangeException("Not enough attach points!"); }

            Renderbuffer colorBuffer = Renderbuffer.CreateColorbuffer(this.Width, this.Height, GL.GL_RGBA);
            glFramebufferRenderbuffer((uint)target, attachment_id[nextColorAttachmentIndex++], GL.GL_RENDERBUFFER, colorBuffer.Id);

            this.colorBufferList.Add(colorBuffer);

            return colorBuffer;
        }

        private Renderbuffer AttachDepthbuffer(FramebufferTarget target)
        {
            if (this.depthBuffer != null)
            { throw new Exception("Depth buffer already exists!"); }

            Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(this.Width, this.Height, DepthComponentType.DepthComponent24);
            glFramebufferRenderbuffer((uint)target, (uint)RenderbufferAttachment.DepthAttachment, GL.GL_RENDERBUFFER, depthBuffer.Id);

            this.depthBuffer = depthBuffer;

            return depthBuffer;
        }

        /// <summary>
        /// et the list of draw buffers.
        /// </summary>
        /// <param name="drawBuffers">GL.GL_COLOR_ATTACHMENT0 + [0, 15] etc.</param>
        public void SetDrawBuffers(params uint[] drawBuffers)
        {
            glDrawBuffers(drawBuffers.Length, drawBuffers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="drawBuffer">GL.GL_COLOR_ATTACHMENT0 + [0, 15] etc.</param>
        public void SetDrawBuffer(uint drawBuffer)
        {
            glDrawBuffer(drawBuffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readBuffer">GL.GL_COLOR_ATTACHMENT0 + [0, 15] etc.</param>
        public void SetReadBuffer(uint readBuffer)
        {
            glReadBuffer(readBuffer);
        }
        //  TODO: We should be able to just use the code below - however we
        //  get invalid dimension issues at the moment, so recreate for now.
        ///// <summary>
        ///// resize this framebuffer.
        ///// </summary>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public void Resize(int width, int height)
        //{
        //    //glBindRenderbuffer(GL.GL_RENDERBUFFER, colourRenderBufferId);
        //    //glRenderbufferStorage(GL.GL_RENDERBUFFER, GL.GL_RGBA, width, height);
        //    //glBindRenderbuffer(GL.GL_RENDERBUFFER, depthRenderBufferId);
        //    //glRenderbufferStorage(GL.GL_RENDERBUFFER, GL.GL_DEPTH_ATTACHMENT, width, height);
        //    //var complete = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>()(GL.GL_FRAMEBUFFER);
        //    this.depthBuffer.Resize(GL.GL_DEPTH_ATTACHMENT, width, height);
        //    faoreach (var item in this.colorBufferList)
        //    {
        //        item.Resize(GL.GL_RGBA, width, height);
        //    }
        //    this.CheckCompleteness();
        //}
    }
}