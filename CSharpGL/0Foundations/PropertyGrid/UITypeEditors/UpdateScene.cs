using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    static class UpdateScene
    {
        internal static void UpdateRender(this SceneObject sceneObject)
        {
            if (sceneObject != null)
            {
                SceneRootObject rootObject = null;
                while (sceneObject != null && sceneObject.Parent != null)
                {
                    sceneObject = sceneObject.Parent;
                }
                rootObject = sceneObject as SceneRootObject;
                if (rootObject != null)
                {
                    Scene scene = rootObject.BindingScene;
                    ICanvas canvas = scene.Canvas;
                    scene.Update();
                    canvas.Repaint();
                }
            }
        }
    }
}
