using CSharpGL;
using System.Collections.Generic;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    internal abstract class WellPipelineBuilder
    {
        public List<CSharpGL.Tuple<WellRenderer, LabelRenderer>> Convert(vec3 originalWorldPosition, WellSpecsCollection wellSpecsList, WellCompatCollection wellCompatList)
        {
            var result = new List<CSharpGL.Tuple<WellRenderer, LabelRenderer>>();
            if (wellSpecsList != null)
            {
                foreach (WellSpecs wellspec in wellSpecsList)
                {
                    CSharpGL.Tuple<WellRenderer, LabelRenderer> wellPipelineRenderer = this.Convert(originalWorldPosition, wellspec, wellCompatList);
                    if (wellPipelineRenderer != null)
                    {
                        result.Add(wellPipelineRenderer);
                    }
                }
            }

            return result;
        }

        protected abstract CSharpGL.Tuple<WellRenderer, LabelRenderer> Convert(vec3 originalWorldPosition, WellSpecs wellspec, WellCompatCollection wellCompatList);
    }
}