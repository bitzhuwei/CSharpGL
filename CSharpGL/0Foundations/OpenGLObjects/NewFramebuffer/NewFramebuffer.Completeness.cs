using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class NewFramebuffer
    {
        /// <summary>
        /// check completeness.
        /// </summary>
        /// <returns></returns>
        public bool CheckCompleteness()
        {
            uint result = glCheckFramebufferStatus(OpenGL.GL_FRAMEBUFFER);

            if (result != OpenGL.GL_FRAMEBUFFER_COMPLETE)
            {
                string message = string.Empty;
                switch (result)
                {
                    case OpenGL.GL_FRAMEBUFFER_UNDEFINED:
                        message = "GL_FRAMEBUFFER_UNDEFINED is returned if target is the default framebuffer, but the default framebuffer does not exist.";
                        break;
                    case OpenGL.GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT:
                        message = "GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT is returned if any of the framebuffer attachment points are framebuffer incomplete.";
                        break;
                    case OpenGL.GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT:
                        message = "GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT is returned if the framebuffer does not have at least one image attached to it.";
                        break;
                    case OpenGL.GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER:
                        message = "GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER is returned if the value of GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE is GL_NONE for any color attachment point(s) named by GL_DRAW_BUFFERi.";
                        break;
                    case OpenGL.GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER:
                        message = "GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER is returned if GL_READ_BUFFER is not GL_NONE and the value of GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE is GL_NONE for the color attachment point named by GL_READ_BUFFER.";
                        break;
                    case OpenGL.GL_FRAMEBUFFER_UNSUPPORTED:
                        message = "GL_FRAMEBUFFER_UNSUPPORTED is returned if the combination of internal formats of the attached images violates an implementation-dependent set of restrictions.";
                        break;
                    case OpenGL.GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE:
                        message = "GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE is returned if the value of GL_RENDERBUFFER_SAMPLES is not the same for all attached renderbuffers; if the value of GL_TEXTURE_SAMPLES is the not same for all attached textures; or, if the attached images are a mix of renderbuffers and textures, the value of GL_RENDERBUFFER_SAMPLES does not match the value of GL_TEXTURE_SAMPLES.\r\nGL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE is also returned if the value of GL_TEXTURE_FIXED_SAMPLE_LOCATIONS is not the same for all attached textures; or, if the attached images are a mix of renderbuffers and textures, the value of GL_TEXTURE_FIXED_SAMPLE_LOCATIONS is not GL_TRUE for all attached textures.";
                        break;
                    case OpenGL.GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS:
                        message = "GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS is returned if any framebuffer attachment is layered, and any populated attachment is not layered, or if all populated color attachments are not from textures of the same target.";
                        break;
                    default:
                        break;
                }

                throw new Exception(message);
            }

            return true;
        }

    }
}
