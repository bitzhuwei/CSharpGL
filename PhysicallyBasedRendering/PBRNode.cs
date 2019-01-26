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
        private SphereModel model;
        private Texture aoMap;
        private Texture roughnessMap;
        private Texture metallicMap;
        private Texture normalMap;
        private Texture albedoMap;
        private ShaderProgram backgroundProgram;
        private ShaderProgram pbrProgram;
        private ShaderProgram debugProgram;
        public static PBRNode Create()
        {
            var model = new SphereModel();
            RenderMethodBuilder background, pbr, irradiance, equiRectangular2Cubemap, brdf, prefliter, debug;
            {
                var vs = new VertexShader(backgroundVertexCode);
                var fs = new FragmentShader(backgroundFragmentCode);
                var map = new AttributeMap();
                map.Add("vPosition", SphereModel.strPosition);
                background = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
            }
            {
                var vs = new VertexShader(PBRVertexCode);
                var fs = new FragmentShader(PBRFragmentCode);
                var map = new AttributeMap();
                map.Add("vPosition", SphereModel.strPosition);
                map.Add("vTexCoords", SphereModel.strTexCoord);
                map.Add("vNormal", SphereModel.strNormal);
                pbr = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
            }
            {
                var vs = new VertexShader(irradianceVertexCode);
                var fs = new FragmentShader(irradianceFragmentCode);
                var map = new AttributeMap();
                map.Add("vPosition", SphereModel.strPosition);
                irradiance = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
            }
            {
                var vs = new VertexShader(equiRectangularVertexCode);
                var fs = new FragmentShader(equiRectangularFragmentCode);
                var map = new AttributeMap();
                map.Add("vPosition", SphereModel.strPosition);
                equiRectangular2Cubemap = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
            }
            {
                var vs = new VertexShader(BRDFVertexCode);
                var fs = new FragmentShader(BRDFFragmentCode);
                var map = new AttributeMap();
                map.Add("vPosition", SphereModel.strPosition);
                map.Add("vTexCoords", SphereModel.strTexCoord);
                brdf = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
            }
            {
                var vs = new VertexShader(prefliterVertexCode);
                var fs = new FragmentShader(prefliterFragmentCode);
                var map = new AttributeMap();
                map.Add("vPosition", SphereModel.strPosition);
                prefliter = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
            }
            {
                var vs = new VertexShader(debugWindowVertexCode);
                var fs = new FragmentShader(debugWindowFragmentCode);
                var map = new AttributeMap();
                map.Add("vPosition", SphereModel.strPosition);
                map.Add("vTexcoord", SphereModel.strTexCoord);
                debug = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
            }

            var node = new PBRNode(model, background, pbr, irradiance, equiRectangular2Cubemap, brdf, prefliter, debug);

            node.Initialize();

            return node;
        }

        private PBRNode(SphereModel model, params RenderMethodBuilder[] builders) : base(model, builders) { this.model = model; }


        //lights
        vec3[] lightPositions =
	    {
	    	new vec3(-10.0f, 10.0f, 10.0f),
	    	new vec3(10.0f, 10.0f, 10.0f),
	    	new vec3(-10.0f, -10.0f, 10.0f),
	    	new vec3(10.0f, -10.0f, 10.0f)
	    };
        vec3[] lightColors =
	    {
	    	new vec3(300.0f, 300.0f, 300.0f),
	    	new vec3(300.0f, 300.0f, 300.0f),
	    	new vec3(300.0f, 300.0f, 300.0f),
	    	new vec3(300.0f, 300.0f, 300.0f),
	    };

        int nrRows = 7;
        int nrColumns = 7;
        float spacing = 2.3f;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            // get references of shader programs.
            this.backgroundProgram = this.RenderUnit.Methods[0].Program;
            this.pbrProgram = this.RenderUnit.Methods[1].Program;
            this.debugProgram = this.RenderUnit.Methods[6].Program;

            // init textures.
            this.albedoMap = LoadTexture(@"Texture\agedplanks1-albedo.png");
            this.albedoMap.TextureUnitIndex = 3;
            this.normalMap = LoadTexture(@"Texture\agedplanks1-normal4-ue.png");
            this.normalMap.TextureUnitIndex = 4;
            this.metallicMap = LoadTexture(@"Texture\agedplanks1-ao.png");
            this.metallicMap.TextureUnitIndex = 5;
            this.roughnessMap = LoadTexture(@"Texture\agedplanks1-roughness.png");
            this.roughnessMap.TextureUnitIndex = 6;
            this.aoMap = LoadTexture(@"Texture\agedplanks1-ao.png");
            this.aoMap.TextureUnitIndex = 7;

            this.pbrProgram.SetUniform("albedoMap", this.albedoMap);
            this.pbrProgram.SetUniform("normalMap", this.normalMap);
            this.pbrProgram.SetUniform("metallicMap", this.metallicMap);
            this.pbrProgram.SetUniform("roughnessMap", this.roughnessMap);
            this.pbrProgram.SetUniform("aoMap", this.aoMap);


        }

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
