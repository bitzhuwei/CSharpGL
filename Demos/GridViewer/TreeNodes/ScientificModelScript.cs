using CSharpGL;
using SimLab.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public class ScientificModelScript : ScriptComponent
    {
        private GridBlockProperty gridBlockProperty;
        private UIColorPaletteRenderer uiCodedColorBar;
        public ScientificModelScript(SceneObject sceneObject, GridBlockProperty property, UIColorPaletteRenderer uiCodedColorBar)
            : base(sceneObject)
        {
            this.gridBlockProperty = property;
            this.uiCodedColorBar = uiCodedColorBar;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Show property's color binded to this script.
        /// </summary>
        public void Show()
        {
            var sceneObject = this.BindingObject;
            var renderer = sceneObject.Renderer as GridViewRenderer;
            if (renderer != null)
            {
                IUpdateColorPalette grid = renderer.Grid;
                UpdateCatesianGrid(grid, this.gridBlockProperty);
            }
            //this.scientificCanvas.Invalidate();
        }

        private void UpdateCatesianGrid(IUpdateColorPalette grid, GridBlockProperty property)
        {
            double axisMin, axisMax, step;
            ColorIndicatorAxisAutomator.Automate(property.MinValue, property.MaxValue, out axisMin, out axisMax, out step);
            grid.MinColorCode = (float)axisMin;
            grid.MaxColorCode = (float)axisMax;
            grid.UpdateColor(property);
            this.uiCodedColorBar.SetCodedColor(axisMin, axisMax, step);
        }

    }
}
