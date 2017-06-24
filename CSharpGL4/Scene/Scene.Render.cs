using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            RenderAction.Render(true, this.clearColor, this.RootElement, this.Camera);
        }

    }
}