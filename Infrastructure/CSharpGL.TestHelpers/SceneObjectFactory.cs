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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildIn"></param>
        /// <returns></returns>
        public static SceneObject GetBuildInSceneObject(BuildInSceneObject buildIn)
        {
            var obj = new SceneObject();
            obj.RendererComponent = new DefaultRendererComponent(buildIn);
            obj.Name = string.Format("{0}", buildIn);

            return obj;
        }


    }

    /// <summary>
    /// 
    /// </summary>
    public enum BuildInSceneObject
    {
        /// <summary>
        /// 
        /// </summary>
        Cube,
        /// <summary>
        /// 
        /// </summary>
        Sphere,
        /// <summary>
        /// 
        /// </summary>
        Ground,
        /// <summary>
        /// 
        /// </summary>
        Axis,
    }
}
