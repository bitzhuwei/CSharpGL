using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

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