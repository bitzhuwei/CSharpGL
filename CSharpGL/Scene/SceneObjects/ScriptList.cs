using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// A list of script.
    /// </summary>
    [Editor(typeof(IListEditor<Script>), typeof(UITypeEditor))]
    public class ScriptList : ComponentList<SceneObject, Script>
    {
        /// <summary>
        /// A list of script.
        /// </summary>
        /// <param name="bindingObject"></param>
        public ScriptList(SceneObject bindingObject = null) : base(bindingObject) { }
    }
}