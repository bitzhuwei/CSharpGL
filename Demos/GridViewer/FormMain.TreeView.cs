using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain
    {

        private void objectsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.propertyGrid1.SelectedObject = e.Node.Tag;
        }

    }
}
