using System.ComponentModel;
namespace CSharpGL
{
    /// <summary>
    /// Root object to be rendered in a scene.
    /// </summary>
    public partial class SceneRootObject : SceneObject
    {
        /// <summary>
        /// an object to be rendered in a scene.
        /// </summary>
        public SceneRootObject(Scene bindingScene)
        {
            this.BindingScene = bindingScene;
        }

        /// <summary>
        /// Which scene is this object in?
        /// </summary>
        [Category(strSceneObject)]
        [Description("Which scene is this object in?")]
        public Scene BindingScene { get; private set; }
    }
}