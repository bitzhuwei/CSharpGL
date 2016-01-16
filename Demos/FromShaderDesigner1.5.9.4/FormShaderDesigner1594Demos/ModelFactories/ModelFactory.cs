using FormShaderDesigner1594Demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.ModelFactories
{
    abstract class ModelFactory
    {
        public abstract IModel Create(float radius);
    }
}
