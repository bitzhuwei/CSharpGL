using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Description of SceneObject.
    /// </summary>
    public partial class SceneObject
    {
        public TransformComponent Transform { get; private set; }
        public List<Component> Components { get; private set; }

        public SceneObject()
        {
            this.Transform = new TransformComponent();
            this.Components = new List<Component>();
        }
    }
}
