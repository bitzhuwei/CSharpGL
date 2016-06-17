using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in this.Scene.ObjectList)
            {
                if (item.Script != null)
                {
                    item.Script.Update(this.timer1.Interval);
                }
            }
        }

    }
}
