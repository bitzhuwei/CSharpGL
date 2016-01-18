using CSharpGL.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.ModelFactories
{
    public abstract class ModelFactory
    {
        public abstract IModel Create(float radius);
    }
}
