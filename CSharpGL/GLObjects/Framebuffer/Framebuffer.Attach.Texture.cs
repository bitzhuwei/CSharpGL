using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Framebuffer
    {
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
                    result = new Texture(TextureTarget.Texture2D, new TexImageBitmap(this.Width, this.Height));
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
                    new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_DEPTH_COMPONENT32, this.Width, this.Height, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT));
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
                //break;
                case TextureAttachment.DepthStencilAttachment:
                    throw new NotImplementedException();
                //break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}
