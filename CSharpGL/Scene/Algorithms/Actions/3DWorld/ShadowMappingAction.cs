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
        private readonly ColorMaskSwitch colorMask = new ColorMaskSwitch(false, false, false, false);
        private readonly BlendFuncSwitch blend = new BlendFuncSwitch(BlendSrcFactor.One, BlendDestFactor.One);
        private LightEquipment lightEquipment = new LightEquipment();

        /// <summary>
        /// 
        /// </summary>
        public LightEquipment LightEquipment
        {
            get { return lightEquipment; }
        }

        private Scene scene;

        /// <summary>
        /// 
        /// </summary>
        public BlendFuncSwitch Blend
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
                if (light is SpotLight || light is DirectionalLight)
                {
                    LightTheScene(light, scene, param);
                }
                else if (light is PointLight)
                {
                    var xLight = new TSpotLight(light.Position, TSpotLightDirection.X, light.Attenuation) { Diffuse = light.Diffuse, Specular = light.Specular, };
                    var nxLight = new TSpotLight(light.Position, TSpotLightDirection.NX, light.Attenuation) { Diffuse = light.Diffuse, Specular = light.Specular, };
                    var yLight = new TSpotLight(light.Position, TSpotLightDirection.Y, light.Attenuation) { Diffuse = light.Diffuse, Specular = light.Specular, };
                    var nyLight = new TSpotLight(light.Position, TSpotLightDirection.NY, light.Attenuation) { Diffuse = light.Diffuse, Specular = light.Specular, };
                    var zLight = new TSpotLight(light.Position, TSpotLightDirection.Z, light.Attenuation) { Diffuse = light.Diffuse, Specular = light.Specular, };
                    var nzLight = new TSpotLight(light.Position, TSpotLightDirection.NZ, light.Attenuation) { Diffuse = light.Diffuse, Specular = light.Specular, };
                    var lights = new TSpotLight[] { xLight, nxLight, yLight, nyLight, zLight, nzLight };
                    foreach (var item in lights)
                    {
                        LightTheScene(item, scene, param);
                    }
                }
                else
                {
                    throw new Exception(string.Format("Unexpected light type:{0}", light.GetType().FullName));
                }
            }
        }

        private void LightTheScene(LightBase light, Scene scene, ActionParams param)
        {
            // cast shadow from specified light.
            {
                this.lightEquipment.Begin(param.Viewport);

                var arg = new ShadowMappingCastShadowEventArgs(param, scene.Camera, light);
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