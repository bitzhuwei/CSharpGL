using CSharpGL.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.ModelFactories
{
    public class SphereInQuadFactory : ModelFactory
    {
        public override IModel Create(float radius)
        {
            return SphereModelInQuad.GetModel(radius);
        }
    }
}
