using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public class BoudingBoxRenderer : Renderer
    {

        private vec3 scale;

        public vec3 Scale
        {
            get { return scale; }
            set
            {
                if (value != scale)
                {
                    scale = value;
                    if (this.initialized)
                    {
                        this.SetUniform("modelMatrix",
                            glm.scale(glm.translate(mat4.identity(), this.translate), this.scale));
                    }
                }
            }
        }

        private vec3 translate;

        public vec3 Translate
        {
            get { return translate; }
            set
            {
                if (value != translate)
                {
                    translate = value;
                    if (this.initialized)
                    {
                        this.SetUniform("modelMatrix",
                   glm.scale(glm.translate(mat4.identity(), this.translate), this.scale));
                    }
                }
            }
        }

        public BoudingBoxRenderer()
            : base(null, null, null)
        {
            this.bufferable = new BoundingBox();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(
                @"shaders\BoundingBox.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(
                @"shaders\BoundingBox.frag"), ShaderType.FragmentShader);
            this.shaderCodes = shaderCodes;
            var map = new PropertyNameMap();
            map.Add("in_Position", BoundingBox.strPosition);
            this.propertyNameMap = map;
            this.switchList.Add(new PolygonModeSwitch(PolygonModes.Lines));
        }

    }
}
