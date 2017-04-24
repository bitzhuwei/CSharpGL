using System;
using System.Drawing;
using System.Windows.Forms;

namespace EMGraphics
{
    /// <summary>
    /// </summary>
    public abstract class TranslateSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="deltaTranslate"></param>
        public abstract void Setup(RendererBase renderer, vec3 deltaTranslate);
    }

    /// <summary>
    /// 
    /// </summary>
    public class DirectionalLightSetup : TranslateSetup
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="deltaTranslate"></param>
        public override void Setup(RendererBase renderer, vec3 deltaTranslate)
        {
            renderer.WorldPosition += deltaTranslate;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PointLightSetup : TranslateSetup
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="deltaTranslate"></param>
        public override void Setup(RendererBase renderer, vec3 deltaTranslate)
        {
            renderer.WorldPosition += deltaTranslate;
        }
    }
}