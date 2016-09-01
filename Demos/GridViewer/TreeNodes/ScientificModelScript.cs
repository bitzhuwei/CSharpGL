using CSharpGL;
using SimLab.helper;
using System.ComponentModel;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    /// <summary>
    /// Used in <see cref="DumpCatesianGridTreeNodeScript"/>.
    /// </summary>
    public class ScientificModelScript : Script
    {
        /// <summary>
        /// used in DumpCatesianGridTreeNodeScript.
        /// </summary>
        [Description("used in DumpCatesianGridTreeNodeScript.")]
        public string Desc { get { return "used in DumpCatesianGridTreeNodeScript."; } }

        public GridBlockProperty GridBlockProperty { get; private set; }

        public UIColorPaletteRenderer UIColorPalette { get; private set; }

        /// <summary>
        /// Used in <see cref="DumpCatesianGridTreeNodeScript"/>.
        /// </summary>
        /// <param name="sceneObject"></param>
        /// <param name="property"></param>
        /// <param name="uiCodedColorBar"></param>
        public ScientificModelScript(SceneObject sceneObject, GridBlockProperty property, UIColorPaletteRenderer uiCodedColorBar)
            : base(sceneObject)
        {
            this.GridBlockProperty = property;
            this.UIColorPalette = uiCodedColorBar;
        }

        /// <summary>
        /// Show property's color binded to this script.
        /// </summary>
        public void Show()
        {
            SceneObject sceneObject = this.BindingObject;
            var renderer = sceneObject.Renderer as GridViewRenderer;
            if (renderer != null)
            {
                IUpdateColorPalette grid = renderer.Grid;
                UpdateCatesianGrid(grid, this.GridBlockProperty);
            }
        }

        private void UpdateCatesianGrid(IUpdateColorPalette grid, GridBlockProperty property)
        {
            double axisMin, axisMax, step;
            ColorIndicatorAxisAutomator.Automate(property.MinValue, property.MaxValue, out axisMin, out axisMax, out step);
            grid.MinColorCode = (float)axisMin;
            grid.MaxColorCode = (float)axisMax;
            grid.UpdateColor(property);
            this.UIColorPalette.SetCodedColor(axisMin, axisMax, step);
        }
    }
}