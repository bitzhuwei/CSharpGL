using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridViewer
{
    /// <summary>
    /// Dump a TreeNode object that binds to this renderer.
    /// </summary>
    public class DumpTreeNodeScript : Script
    {
        /// <summary>
        /// Dump a TreeNode object that binds to this renderer.
        /// </summary>
        [Category("Desc")]
        [Description("Dump a TreeNode object that binds to this renderer.")]
        public string Desc { get { return "retarget label's position to specified target."; } }

        public virtual TreeNode DumpTreeNode()
        {
            SceneObject obj = this.BindingObject;
            var node = new TreeNode(string.Format("{0}", obj));
            node.Tag = obj;
            return node;
        }
    }
}
