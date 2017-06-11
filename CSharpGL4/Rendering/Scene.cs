using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SceneElement RootElement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            var args = new RenderEventArgs(this);
            this.Render(this.RootElement, args);
        }

        private void Render(SceneElement sceneElement, RenderEventArgs args)
        {
            sceneElement.Render(args);
            foreach (var item in sceneElement.Children)
            {
                item.Render(args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SceneElement Pick()
        {
            throw new NotImplementedException();
        }

        //public void Write(Stream stream)
        //{

        //}
    }
}