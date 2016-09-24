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
            string name = string.Format("{0}", renderer);
            return WrapToSceneObject(renderer, name, false, scripts);
        }

        /// <summary>
        /// Gets a <see cref="SceneObject"/> that contains this renderer.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="generateBoundingBox"></param>
        /// <param name="scripts"></param>
        /// <returns></returns>
        public static SceneObject WrapToSceneObject(
            this RendererBase renderer,
            bool generateBoundingBox,
            params Script[] scripts)
        {
            string name = string.Format("{0}", renderer);
            return WrapToSceneObject(renderer, name, generateBoundingBox, scripts);
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
            string name,
            params Script[] scripts)
        {
            return WrapToSceneObject(renderer, name, false, scripts);
        }

        /// <summary>
        /// Gets a <see cref="SceneObject"/> that contains this renderer.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="name"></param>
        /// <param name="generateBoundingBox"></param>
        /// <param name="scripts"></param>
        /// <returns></returns>
        public static SceneObject WrapToSceneObject(
            this RendererBase renderer,
            string name,
            bool generateBoundingBox,
            params Script[] scripts)
        {
            var obj = new SceneObject();
            obj.Renderer = renderer;
            obj.Name = name;
            obj.Scripts.AddRange(scripts);
            if (generateBoundingBox)
            {
                BoundingBoxRenderer box = renderer.GetBoundingBoxRenderer();
                var boxObj = new SceneObject();
                boxObj.Renderer = box;
                boxObj.Name = string.Format("Box of [{0}]", name);
                obj.Children.Add(boxObj);
            }

            return obj;
        }
    }
}