using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public interface IBindingObject<TBinding>
    {
        TBinding BindingObject { get; set; }
    }
}
