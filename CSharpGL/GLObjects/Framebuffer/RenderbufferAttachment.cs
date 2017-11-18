//using System;
//using System.Collections.Generic;

//namespace CSharpGL
//{
//    /// <summary>
//    /// COLOR_ATTACHMENTi —— 附着到这里的纹理将接收来自片元着色器的颜色。‘i’ 后缀意味着可以有多个纹理同时被附着为颜色附着点。在片元着色器中有一个机制可以确保同时将颜色输出到多个缓冲区中。
//    /// DEPTH_ATTACHMENT —— 附着在上面的纹理将收到深度测试的结果。
//    /// STENCIL_ATTACHMENT —— 附着在上面的纹理将充当模板缓冲区。模板缓冲区限制了光栅化的区域，可被用于不同的技术。
//    /// DEPTH_STENCIL_ATTACHMENT —— 这仅是一个深度和模板缓冲区的结合，因为它俩经常被一起使用。
//    /// </summary>
//    public enum RenderbufferAttachment : uint
//    {
//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment0 = GL.GL_COLOR_ATTACHMENT0,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment1 = GL.GL_COLOR_ATTACHMENT1,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment2 = GL.GL_COLOR_ATTACHMENT2,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment3 = GL.GL_COLOR_ATTACHMENT3,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment4 = GL.GL_COLOR_ATTACHMENT4,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment5 = GL.GL_COLOR_ATTACHMENT5,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment6 = GL.GL_COLOR_ATTACHMENT6,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment7 = GL.GL_COLOR_ATTACHMENT7,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment8 = GL.GL_COLOR_ATTACHMENT8,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment9 = GL.GL_COLOR_ATTACHMENT9,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment10 = GL.GL_COLOR_ATTACHMENT10,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment11 = GL.GL_COLOR_ATTACHMENT11,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment12 = GL.GL_COLOR_ATTACHMENT12,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment13 = GL.GL_COLOR_ATTACHMENT13,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment14 = GL.GL_COLOR_ATTACHMENT14,

//        /// <summary>
//        ///
//        /// </summary>
//        ColorAttachment15 = GL.GL_COLOR_ATTACHMENT15,

//        /// <summary>
//        ///
//        /// </summary>
//        DepthAttachment = GL.GL_DEPTH_ATTACHMENT,

//        /// <summary>
//        ///
//        /// </summary>
//        StencilAttachment = GL.GL_STENCIL_ATTACHMENT,

//        /// <summary>
//        ///
//        /// </summary>
//        DepthStencilAttachment = GL.GL_DEPTH_STENCIL_ATTACHMENT,
//    }
//}
