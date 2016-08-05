using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL;

namespace GridViewer
{
    public partial class ScriptComponentTreeNode : TreeNode
    {
        private ScriptComponent scriptComponent;
        public ScriptComponentTreeNode(ScriptComponent scriptComponent)
        {
            this.scriptComponent = scriptComponent;
        }
    }
}
