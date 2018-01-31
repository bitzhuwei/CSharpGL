using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Cast shaow mapping textures for <see cref="ISupportShadowMapping"/>.
    /// </summary>
    public class ShadowMappingAction : ActionBase
    {
        private readonly ColorMaskState colorMask = new ColorMaskState(false, false, false, false);
        private readonly BlendState blend = new BlendState(BlendingSourceFactor.One, BlendingDestinationFactor.One);
        private LightEquipment lightEquipment = new LightEquipment();

        public LightEquipment LightEquipment
        {
            get { return lightEquipment; }
        }

        private Scene scene;

        /// <summary>
        /// 
        /// </summary>
        public BlendState Blend
        {
            get { return blend; }
        }

        /// <summary>
        /// Cast shaow mapping textures for <see cref="ISupportShadowMapping"/>.
        /// </summary>
        /// <param name="scene"></param>
        public ShadowMappingAction(Scene scene)
        {
            this.scene = scene;
        }

        /// <summary>
        /// Cast shadow.(Prepare shadow mapping texture)
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            Scene scene = this.scene;
            // Render ambient color.
            {
                var arg = new ShadowMappingAmbientEventArgs(param, scene.Camera, scene.AmbientColor);
                RenderAmbientColor(scene.RootNode, arg);
            }

            foreach (var light in scene.Lights)
            {
                // cast shadow from specified light.
                if (light is SpotLight || light is DirectionalLight)
                {
                    RenderWithShadow(param, scene, light);
                }
                else if (light is PointLight)
                {
                    var pointLight = light as PointLight;
                    vec3 position = pointLight.Position;
                    float cutOff = (float)(1.0 / Math.Sqrt(3));
                    Attenuation attenuation = pointLight.Attenuation;
                    var lightX = new SpotLight(position, position + new vec3(1, 0, 0), cutOff, attenuation) { Diffuse = pointLight.Diffuse, Specular = pointLight.Specular, };
                    var lightNX = new SpotLight(position, position + new vec3(-1, 0, 0), cutOff, attenuation) { Diffuse = pointLight.Diffuse, Specular = pointLight.Specular, };
                    var lightY = new SpotLight(position, position + new vec3(0, 1, 0), cutOff, attenuation) { Diffuse = pointLight.Diffuse, Specular = pointLight.Specular, };
                    var lightNY = new SpotLight(position, position + new vec3(0, -1, 0), cutOff, attenuation) { Diffuse = pointLight.Diffuse, Specular = pointLight.Specular, };
                    var lightZ = new SpotLight(position, position + new vec3(0, 0, 1), cutOff, attenuation) { Diffuse = pointLight.Diffuse, Specular = pointLight.Specular, };
                    var lightNZ = new SpotLight(position, position + new vec3(0, 0, -1), cutOff, attenuation) { Diffuse = pointLight.Diffuse, Specular = pointLight.Specular, };
                    var lights = new SpotLight[] { lightX, lightNX, lightY, lightNY, lightZ, lightNZ, };
                    foreach (var item in lights)
                    {
                        RenderWithShadow(param, scene, item);
                    }
                }
                else
                {
                    throw new Exception(string.Format("No expected light type:{0}", light.GetType()));
                }
            }
        }

        private void RenderWithShadow(ActionParams param, Scene scene, LightBase light)
        {
            {
                this.lightEquipment.Begin(param.Viewport);

                var arg = new ShadowMappingCastShadowEventArgs(light);
                //this.colorMask.On();
                CastShadow(scene.RootNode, arg);
                //this.colorMask.Off();
                this.lightEquipment.End();
            }

            // light up the scene with specified light.
            {
                var arg = new ShadowMappingUnderLightEventArgs(param, scene.Camera, this.lightEquipment.BindingTexture, light);
                this.blend.On();
                RenderUnderLight(this.scene.RootNode, arg);
                this.blend.Off();
            }
        }

        private void RenderAmbientColor(SceneNodeBase sceneNodeBase, ShadowMappingAmbientEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowMapping;
                TwoFlags flags = (node != null) ? node.EnableShadowMapping : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    node.RenderAmbientColor(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        RenderAmbientColor(item, arg);
                    }
                }
            }
        }

        private void CastShadow(SceneNodeBase sceneNodeBase, ShadowMappingCastShadowEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowMapping;
                TwoFlags flags = (node != null) ? node.EnableShadowMapping : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    flags = node.EnableCastShadow;
                    before = (flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren;
                }

                if (children)
                {
                    flags = (node != null) ? node.EnableCastShadow : TwoFlags.None;
                    children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);
                }

                if (before)
                {
                    node.CastShadow(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        CastShadow(item, arg);
                    }
                }
            }
        }

        private void RenderUnderLight(SceneNodeBase sceneNodeBase, ShadowMappingUnderLightEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowMapping;
                TwoFlags flags = (node != null) ? node.EnableShadowMapping : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    flags = node.EnableRenderUnderLight;
                    before = (flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren;
                }

                if (children)
                {
                    flags = (node != null) ? node.EnableRenderUnderLight : TwoFlags.None;
                    children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);
                }

                if (before)
                {
                    node.RenderUnderLight(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        RenderUnderLight(item, arg);
                    }
                }
            }
        }

    }
}