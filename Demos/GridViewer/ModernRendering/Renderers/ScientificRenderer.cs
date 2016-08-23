using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public partial class ScientificRenderer : Renderer
    {

        //private vec3 scale;

        //public vec3 Scale
        //{
        //    get { return scale; }
        //    set
        //    {
        //        if (value != scale)
        //        {
        //            scale = value;
        //            if (this.initialized)
        //            {
        //                this.SetUniform("modelMatrix",
        //                    glm.scale(glm.translate(mat4.identity(), this.translate), this.scale));
        //            }
        //        }
        //    }
        //}

        //private vec3 translate;

        //public vec3 Translate
        //{
        //    get { return translate; }
        //    set
        //    {
        //        if (value != translate)
        //        {
        //            translate = value;
        //            if (this.initialized)
        //            {
        //                this.SetUniform("modelMatrix",
        //           glm.scale(glm.translate(mat4.identity(), this.translate), this.scale));
        //            }
        //        }
        //    }
        //}

        public ScientificRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        { }

    }
}
