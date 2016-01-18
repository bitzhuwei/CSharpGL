using CSharpGL.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.ModelFactories
{
    public class CubeFactory : ModelFactory
    {
        public override IModel Create(float radius)
        {
            return CubeModel.GetModel(radius);
        }
    }
}
