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
            foreach (var sceneObject in this.scene.ObjectList)
            {
                foreach (var obj in sceneObject)
                {
                    if (obj.Script != null)
                    {
                        obj.Update(this.timer1.Interval);
                    }
                }
            }
        }

    }
}
