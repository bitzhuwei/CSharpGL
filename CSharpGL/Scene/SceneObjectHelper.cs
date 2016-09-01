namespace CSharpGL
{
    /// <summary>
    /// </summary>
    public static class SceneObjectHelper
    {
        /// <summary>
        /// Gets a <see cref="SceneObject"/> that contains this renderer.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="scripts"></param>
        /// <returns></returns>
        public static SceneObject WrapToSceneObject(
            this RendererBase renderer,
            params Script[] scripts)
        {
            return WrapToSceneObject(renderer, "", scripts);
        }

        /// <summary>
        /// Gets a <see cref="SceneObject"/> that contains this renderer.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="name"></param>
        /// <param name="scripts"></param>
        /// <returns></returns>
        public static SceneObject WrapToSceneObject(
            this RendererBase renderer,
            string name, params Script[] scripts)
        {
            var obj = new SceneObject();
            obj.Renderer = renderer;
            obj.Name = string.IsNullOrEmpty(name) ? string.Format("{0}", renderer) : name;
            obj.ScriptList.AddRange(scripts);

            return obj;
        }
    }
}