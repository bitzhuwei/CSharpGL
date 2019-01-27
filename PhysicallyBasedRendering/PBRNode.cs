using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace PhysicallyBasedRendering
{
    partial class PBRNode : SceneNodeBase, IRenderable
    {
        private Texture hdrTexture;
        private Texture aoMap;
        private Texture roughnessMap;
        private Texture metallicMap;
        private Texture normalMap;
        private Texture albedoMap;
        private ShaderProgram backgroundProgram;
        private ShaderProgram pbrProgram;
        private ShaderProgram irradianceProgram;
        private ShaderProgram equiRectangular2CubemapProgram;
        private ShaderProgram brdfProgram;
        private ShaderProgram prefliterProgram;
        private ShaderProgram debugProgram;
        private CubemapBuffers cubemapBuffers;
        private QuadBuffers quadBuffers;
        private SphereBuffers sphereBuffers;

        private int nrRows = 7;
        private int nrColumns = 7;
        private float spacing = 2.3f;

        //public static PBRNode Create()
        //{
        //    var model = new SphereModel();
        //    RenderMethodBuilder background, pbr, irradiance, equiRectangular2Cubemap, brdf, prefliter, debug;
        //    {
        //        var vs = new VertexShader(backgroundVertexCode);
        //        var fs = new FragmentShader(backgroundFragmentCode);
        //        var map = new AttributeMap();
        //        map.Add("vPosition", SphereModel.strPosition);
        //        background = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
        //    }
        //    {
        //        var vs = new VertexShader(PBRVertexCode);
        //        var fs = new FragmentShader(PBRFragmentCode);
        //        var map = new AttributeMap();
        //        map.Add("vPosition", SphereModel.strPosition);
        //        map.Add("vTexCoords", SphereModel.strTexCoord);
        //        map.Add("vNormal", SphereModel.strNormal);
        //        pbr = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
        //    }
        //    {
        //        var vs = new VertexShader(irradianceVertexCode);
        //        var fs = new FragmentShader(irradianceFragmentCode);
        //        var map = new AttributeMap();
        //        map.Add("vPosition", SphereModel.strPosition);
        //        irradiance = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
        //    }
        //    {
        //        var vs = new VertexShader(equiRectangularVertexCode);
        //        var fs = new FragmentShader(equiRectangularFragmentCode);
        //        var map = new AttributeMap();
        //        map.Add("vPosition", SphereModel.strPosition);
        //        equiRectangular2Cubemap = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
        //    }
        //    {
        //        var vs = new VertexShader(BRDFVertexCode);
        //        var fs = new FragmentShader(BRDFFragmentCode);
        //        var map = new AttributeMap();
        //        map.Add("vPosition", SphereModel.strPosition);
        //        map.Add("vTexCoords", SphereModel.strTexCoord);
        //        brdf = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
        //    }
        //    {
        //        var vs = new VertexShader(prefliterVertexCode);
        //        var fs = new FragmentShader(prefliterFragmentCode);
        //        var map = new AttributeMap();
        //        map.Add("vPosition", SphereModel.strPosition);
        //        prefliter = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
        //    }
        //    {
        //        var vs = new VertexShader(debugWindowVertexCode);
        //        var fs = new FragmentShader(debugWindowFragmentCode);
        //        var map = new AttributeMap();
        //        map.Add("vPosition", SphereModel.strPosition);
        //        map.Add("vTexcoord", SphereModel.strTexCoord);
        //        debug = new RenderMethodBuilder(new ShaderArray(vs, fs), map);
        //    }

        //    var node = new PBRNode(model, background, pbr, irradiance, equiRectangular2Cubemap, brdf, prefliter, debug);

        //    node.Initialize();

        //    return node;
        //}

        public PBRNode()
        {
            var model = new SphereModel();
            RenderMethodBuilder background, pbr, irradiance, equiRectangular2Cubemap, brdf, prefliter, debug;
            {
                var vs = new VertexShader(backgroundVertexCode);
                var fs = new FragmentShader(backgroundFragmentCode);
                var array = new ShaderArray(vs, fs);
                this.backgroundProgram = array.GetShaderProgram();
            }
            {
                var vs = new VertexShader(PBRVertexCode);
                var fs = new FragmentShader(PBRFragmentCode);
                var array = new ShaderArray(vs, fs);
                this.pbrProgram = array.GetShaderProgram();
            }
            {
                var vs = new VertexShader(irradianceVertexCode);
                var fs = new FragmentShader(irradianceFragmentCode);
                var array = new ShaderArray(vs, fs);
                this.irradianceProgram = array.GetShaderProgram();
            }
            {
                var vs = new VertexShader(equiRectangularVertexCode);
                var fs = new FragmentShader(equiRectangularFragmentCode);
                var array = new ShaderArray(vs, fs);
                this.equiRectangular2CubemapProgram = array.GetShaderProgram();
            }
            {
                var vs = new VertexShader(BRDFVertexCode);
                var fs = new FragmentShader(BRDFFragmentCode);
                var array = new ShaderArray(vs, fs);
                this.brdfProgram = array.GetShaderProgram();
            }
            {
                var vs = new VertexShader(prefliterVertexCode);
                var fs = new FragmentShader(prefliterFragmentCode);
                var array = new ShaderArray(vs, fs);
                this.prefliterProgram = array.GetShaderProgram();
            }
            {
                var vs = new VertexShader(debugWindowVertexCode);
                var fs = new FragmentShader(debugWindowFragmentCode);
                var array = new ShaderArray(vs, fs);
                this.debugProgram = array.GetShaderProgram();
            }

            this.Initialize();
        }


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

        private Texture irradianceMap;
        private Texture prefliterMap;
        private Texture brdfLUTTexture;
        private Texture envCubeMap;

    }
}
