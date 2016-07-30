using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    [Editor(typeof(IListEditor<GLSwitch>), typeof(UITypeEditor))]
    public class GLSwitchList : List<GLSwitch>
    {
    }
}
