namespace CSharpGL
{
    /// <summary>
    /// Root object to be rendered in a scene.
    /// </summary>
    public partial class SceneGroupObject : SceneObject
    {
        /// <summary>
        /// an object to be rendered in a scene.
        /// </summary>
        public SceneGroupObject(Scene bindingScene)
        {
            this.BindingScene = bindingScene;
        }

        /// <summary>
        /// Which scene is this object in?
        /// </summary>
        public Scene BindingScene { get; private set; }
    }
}