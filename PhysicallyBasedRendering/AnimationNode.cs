using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace PhysicallyBasedRendering
{
    partial class PBRNode : ModernNode, IRenderable
    {
        private PBRModel model;
        public static PBRNode Create(PBRModel model)
        {
            throw new NotImplementedException();
            //var vs = new VertexShader(vertexCode);
            //var fs = new FragmentShader(fragmentCode);
            //var array = new ShaderArray(vs, fs);
            //var map = new AttributeMap();
            //map.Add("inPosition", PBRModel.strPosition);
            //map.Add("inNormal", PBRModel.strNormal);
            //map.Add("inTexCoord", PBRModel.strTexCoord);
            //var builder = new RenderMethodBuilder(array, map);
            //var node = new PBRNode(model, builder);
            //node.Initialize();

            //return node;
        }

        private PBRNode(PBRModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.model = model; }

        private Texture LoadTexture(string filename)
        {
            var bitmap = new Bitmap(filename);
            var storage = new TexImageBitmap(bitmap, GL.GL_RGB);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            return texture;
        }
    }
}
