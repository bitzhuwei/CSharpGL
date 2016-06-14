using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    [Editor(typeof(GLSwithListEditor), typeof(UITypeEditor))]
    public class GLSwitchList : List<GLSwitch>
    {
    }
}
