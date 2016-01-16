using FormShaderDesigner1594Demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.ModelFactories
{
    class CubeFactory : ModelFactory
    {
        public override IModel Create(float radius)
        {
            return CubeModel.GetModel(radius);
        }
    }
}
