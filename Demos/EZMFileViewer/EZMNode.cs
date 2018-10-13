using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    class EZMNode : ModernNode
    {
        public static EZMNode Create(EZMFile file)
        {
            IBufferSource bufferSource = new EZModel(file);

            throw new NotImplementedException();
        }

        private EZMNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }
    }
}
