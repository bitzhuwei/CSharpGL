using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    abstract class WellPipelineBuilder
    {
        public List<NamedWellRenderer> Convert(WellSpecsCollection wellSpecsList, WellCompatCollection wellCompatList)
        {
            var result = new List<NamedWellRenderer>();
            if (wellSpecsList != null)
            {
                foreach (WellSpecs wellspec in wellSpecsList)
                {
                    NamedWellRenderer wellPipelineRenderer = this.Convert(wellspec, wellCompatList);
                    if (wellPipelineRenderer != null)
                    {
                        result.Add(wellPipelineRenderer);
                    }
                }
            }

            return result;
        }

        protected abstract NamedWellRenderer Convert(WellSpecs wellspec, WellCompatCollection wellCompatList);

    }
}
