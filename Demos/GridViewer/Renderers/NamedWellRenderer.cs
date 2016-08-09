using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    /// renders well pipeline(several cylinders) and its name(LabelRenderer).
    /// </summary>
    public class NamedWellRenderer : RendererBase//, IModelTransform
    {
        ///// <summary>
        ///// IModelTransform.ModelMatrix
        ///// </summary>
        //public mat4 ModelMatrix { get; set; }

        private WellRenderer wellRenderer;
        /// <summary>
        /// renders well(pipeline).
        /// </summary>
        public WellRenderer WellRenderer
        {
            get { return wellRenderer; }
        }

        private LabelRenderer nameRenderer;
        /// <summary>
        /// renders well(pipeline)'s name as text.
        /// </summary>
        public LabelRenderer NameRenderer
        {
            get { return nameRenderer; }
        }

        public static NamedWellRenderer Create(WellModel model, Color wellColor, string name = "", int maxCharCount = 64, int labelHeight = 32, IFontTexture fontTexture = null)
        {
            WellRenderer well = WellRenderer.Create(model);
            well.WellColor = wellColor;
            LabelRenderer label = new LabelRenderer(maxCharCount, labelHeight, fontTexture);
            label.Text = name;
            var renderer = new NamedWellRenderer(well, label);
            return renderer;
        }

        /// <summary>
        /// renders well pipeline(several cylinders)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="switches"></param>
        private NamedWellRenderer(WellRenderer wellRenderer, LabelRenderer nameRenderer)
        {
            //this.ModelMatrix = mat4.identity();
            this.wellRenderer = wellRenderer;
            this.nameRenderer = nameRenderer;
        }

        protected override void DoInitialize()
        {
            {
                WellRenderer renderer = this.wellRenderer;
                if (renderer != null) { renderer.Initialize(); }
            }
            {
                LabelRenderer renderer = this.nameRenderer;
                if (renderer != null) { renderer.Initialize(); }
            }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            {
                WellRenderer renderer = this.wellRenderer;
                if (renderer != null) { renderer.Render(arg); }
            }
            {
                LabelRenderer renderer = this.nameRenderer;
                if (renderer != null) { renderer.Render(arg); }
            }
        }

        protected override void DisposeUnmanagedResources()
        {
            {
                WellRenderer renderer = this.wellRenderer;
                if (renderer != null) { renderer.Dispose(); }
            }
            {
                LabelRenderer renderer = this.nameRenderer;
                if (renderer != null) { renderer.Dispose(); }
            }

            base.DisposeUnmanagedResources();
        }
    }
}
