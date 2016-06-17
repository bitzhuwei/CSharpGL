using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpGL
{
    /// <summary>
    /// Description of SceneObject.
    /// </summary>
    public partial class SceneObjectFactory
    {
        public static SceneObject GetBuildInSceneObject(BuildInSceneObject buildIn)
        {
            var obj = new SceneObject();
            obj.Renderer = new DefaultRendererComponent(buildIn);
            obj.Name = string.Format("{0}", buildIn);

            return obj;
        }


    }

    public enum BuildInSceneObject
    {
        Cube,
        Sphere,
        Ground,
        Axis,
    }
}
