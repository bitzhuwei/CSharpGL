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

        void FormMain_Load(object sender, EventArgs e)
        {
            SceneObject ground = SceneObjectFactory.GetBuildInSceneObject(BuildInSceneObject.Ground);
            this.scene.Scene.ObjectList.Add(ground);
            SceneObject axis = SceneObjectFactory.GetBuildInSceneObject(BuildInSceneObject.Axis);
            this.scene.Scene.ObjectList.Add(axis);

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.lblCameraInfo.Text = string.Format("eye{0}, center:{1}, up:{2}",
                this.scene.Scene.Camera.Position,
                this.scene.Scene.Camera.Target,
                this.scene.Scene.Camera.UpVector);
        }

    }
}
