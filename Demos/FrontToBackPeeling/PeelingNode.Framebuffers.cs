using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    partial class PeelingNode
    {


    }

    class PeelingResource
    {
        public readonly Framebuffer[] framebuffers = new Framebuffer[2];
        public readonly Texture[] colorAttachments = new Texture[2];
        public readonly Texture[] depthAttachments = new Texture[2];

        public readonly Framebuffer colorBlenderFramebuffer;
        public readonly Texture colorBlenderColorAttachment;

        public readonly Query query;

        public PeelingResource()
        {

        }
    }
}
