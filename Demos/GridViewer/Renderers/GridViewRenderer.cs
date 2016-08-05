using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public class GridViewRenderer : Renderer, IUpdateColorPalette
    {
        public GridViewRenderer(IBufferable catesianGrid, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(catesianGrid, shaderCodes, propertyNameMap, switches)
        {
        }


        public void UpdateColor(TracyEnergy.Simba.Data.Keywords.impl.GridBlockProperty property)
        {
            throw new NotImplementedException();
        }

        public float MinColorCode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float MaxColorCode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
