using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
        private static GLDelegates.void_uint_uint_uint_uint_int glFramebufferTexture2D;

        static PBRNode()
        {
            glFramebufferTexture2D = GL.Instance.GetDelegateFor("glFramebufferTexture2D", GLDelegates.typeof_void_uint_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_uint_int;

        }
        protected override void DoInitialize()
        {
            // init textures.
            this.envCubeMap = LoadEnvCubeMap();
            this.irradianceMap = LoadIrradianceMap();
            this.prefliterMap = LoadPrefliterMap();
            this.brdfLUTTexture = LoadBRDFTexture();
            this.hdrTexture = LoadHdrEnvironmentMap(@"Texture\hdr\newport_loft.hdr");

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

            //设置投影矩阵
            mat4 captureProjection = glm.perspective((float)(Math.PI / 2), 1.0f, 0.1f, 20.0f);
            mat4[] captureView =
	        {
				glm.lookAt(new vec3(0, 0, 0), new vec3(1.0f, 0.0f, 0.0f), new vec3(0.0f, -1.0f, 0.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(-1.0f, 0.0f, 0.0f), new vec3(0.0f, -1.0f, 0.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, 1.0f, 0.0f), new vec3(0.0f, 0.0f, 1.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, -1.0f, 0.0f), new vec3(0.0f, 0.0f, -1.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, 0.0f, 1.0f), new vec3(0.0f, -1.0f, 0.0f)),
				glm.lookAt(new vec3(0, 0, 0), new vec3(0.0f, 0.0f, -1.0f), new vec3(0.0f, -1.0f, 0.0f)),
	        };

            ViewportSwitch viewportSwitch = new ViewportSwitch(0, 0, 512, 512);
            //转换HDR Equirectangular environmentMap 为 HDR cubeMap
            {
                //创建渲染到CubeMap的FBO
                var fbo = new Framebuffer(512, 512);
                fbo.Bind();
                var rbo = new Renderbuffer(512, 512, GL.GL_DEPTH_COMPONENT24);
                fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                fbo.CheckCompleteness();
                fbo.Unbind();

                viewportSwitch.On();
                ShaderProgram program = this.equiRectangular2CubemapProgram;
                program.SetUniform("equirectangularMap", this.hdrTexture);
                program.SetUniform("ProjMatrix", captureProjection);
                for (uint i = 0; i < 6; ++i)
                {
                    fbo.Bind();
                    uint location = 0;
                    int level = 0;
                    fbo.Attach(FramebufferTarget.Framebuffer, location, (CubemapFace)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + i), envCubeMap, level);
                    fbo.CheckCompleteness();
                    fbo.Unbind();

                    fbo.Bind();
                    program.Bind();
                    program.SetUniform("ViewMatrix", captureView[i]);
                    program.PushUniforms();
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    renderCube();
                    program.Unbind();
                    fbo.Unbind();
                }
                viewportSwitch.Off();
                fbo.Dispose();
            }
            //创建一个irradianceMap
            {
                var fbo = new Framebuffer(32, 32);
                fbo.Bind();
                var rbo = new Renderbuffer(32, 32, GL.GL_DEPTH_COMPONENT24);
                fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                fbo.CheckCompleteness();
                fbo.Unbind();


                //pbr:通过卷积来创建一张irradianceMap来解决diffueIntegral
                viewportSwitch.Width = 32; viewportSwitch.Height = 32;
                viewportSwitch.On();
                ShaderProgram program = this.irradianceProgram;
                program.SetUniform("environmentMap", envCubeMap);
                program.SetUniform("ProjMatrix", captureProjection);
                for (uint i = 0; i < 6; ++i)
                {
                    program.SetUniform("ViewMatrix", captureView[i]);
                    fbo.Bind();
                    uint location = 0;
                    int level = 0;
                    fbo.Attach(FramebufferTarget.Framebuffer, location, (CubemapFace)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + i), irradianceMap, level);
                    fbo.CheckCompleteness();
                    fbo.Unbind();

                    fbo.Bind();
                    program.Bind();
                    program.PushUniforms();
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    renderCube();
                    program.Unbind();
                    fbo.Unbind();
                }
                viewportSwitch.Off();
                fbo.Dispose();
            }
            //对环境光用蒙特卡洛积分来创建一个prefliterMap贴图
            {
                ShaderProgram program = this.prefliterProgram;
                program.SetUniform("environmentMap", envCubeMap);
                program.SetUniform("ProjMatrix", captureProjection);
                const int maxMipLevels = 5;
                for (int level = 0; level < maxMipLevels; level++)
                {
                    int mipWidth = (int)(128 * Math.Pow(0.5, level));
                    int mipHeight = (int)(128 * Math.Pow(0.5, level));
                    var fbo = new Framebuffer(mipWidth, mipHeight);
                    fbo.Bind();
                    var rbo = new Renderbuffer(mipWidth, mipHeight, GL.GL_DEPTH_COMPONENT24);
                    fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                    fbo.CheckCompleteness();
                    fbo.Unbind();

                    viewportSwitch.Width = mipWidth; viewportSwitch.Height = mipHeight;
                    viewportSwitch.On();
                    float roughness = (float)level / (float)(maxMipLevels - 1);
                    program.SetUniform("roughness", roughness);
                    for (uint j = 0; j < 6; j++)
                    {
                        program.SetUniform("ViewMatrix", captureView[level]);

                        fbo.Bind();
                        uint location = 0;
                        fbo.Attach(FramebufferTarget.Framebuffer, location, (CubemapFace)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + j), prefliterMap, level);
                        fbo.CheckCompleteness();
                        fbo.Unbind();

                        fbo.Bind();
                        program.Bind();
                        program.PushUniforms();
                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                        renderCube();
                        program.Unbind();
                        fbo.Unbind();
                    }
                    viewportSwitch.Off();
                    fbo.Dispose();
                }
                program.Unbind();
            }
            {
                var fbo = new Framebuffer(512, 512);
                fbo.Bind();
                var rbo = new Renderbuffer(512, 512, GL.GL_DEPTH_COMPONENT24);
                fbo.Attach(FramebufferTarget.Framebuffer, rbo, AttachmentLocation.Depth);
                fbo.Attach(FramebufferTarget.Framebuffer, brdfLUTTexture, 0u);
                fbo.CheckCompleteness();
                fbo.Unbind();

                fbo.Bind();
                viewportSwitch.Width = 512; viewportSwitch.Height = 512;
                viewportSwitch.On();
                ShaderProgram program = this.brdfProgram;
                program.Bind();
                program.PushUniforms();
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                renderQuad();
                program.Unbind();
                viewportSwitch.Off();
                fbo.Unbind();
                fbo.Dispose();
            }
        }

        private Texture LoadBRDFTexture()
        {
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RG16F, 512, 512, GL.GL_RG, GL.GL_FLOAT);
            var brdfLUTTexture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            brdfLUTTexture.Initialize();
            return brdfLUTTexture;
        }

        private Texture LoadPrefliterMap()
        {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 128, 128, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var prefliterMap = new Texture(storage, new MipmapBuilder(),
               new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
               new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            prefliterMap.Initialize();
            return prefliterMap;
        }

        private Texture LoadIrradianceMap()
        {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 32, 32, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var irradianceMap = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            irradianceMap.Initialize();
            return irradianceMap;
        }

        private Texture LoadEnvCubeMap()
        {
            var dataProvider = new CubemapDataProvider(null, null, null, null, null, null);
            var storage = new CubemapTexImage2D(GL.GL_RGB16F, 512, 512, GL.GL_RGB, GL.GL_FLOAT, dataProvider);
            var envCubeMap = new Texture(storage,
               new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
               new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
               new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            envCubeMap.Initialize();
            return envCubeMap;
        }

        private void renderSphere()
        {
            if (this.sphereBuffers == null)
            {
                this.sphereBuffers = new SphereBuffers();
            }

            this.sphereBuffers.Render();
        }

        private void renderQuad()
        {
            if (this.quadBuffers == null)
            {
                this.quadBuffers = new QuadBuffers();
            }

            this.quadBuffers.Render();
        }

        private void renderCube()
        {
            if (this.cubemapBuffers == null)
            {
                this.cubemapBuffers = new CubemapBuffers();
            }

            this.cubemapBuffers.Render();
        }


        private Texture LoadHdrEnvironmentMap(string filename)
        {
            HdrFile hdrFile = HdrAssetImporter.ReadHdrFile(filename);
            Pixel[] pixels = hdrFile.Colors;
            var storage = new TexImage2D(TexImage2D.Target.Texture2D, GL.GL_RGB16F, hdrFile.Width, hdrFile.Height, GL.GL_RGBA, GL.GL_BYTE, new ArrayDataProvider<Pixel>(pixels));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();

            return texture;
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
            texture.Initialize();

            return texture;
        }
    }
}
