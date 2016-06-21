using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.Utils
{
    public static class SceneExtension
    {
        /// <summary>
        /// 释放model Container中的对象
        /// </summary>
        /// <param name="scene"></param>
        public static void ReleaseContainerElements(this ScientificVisual3DControl scene)
        {
            scene.Scene.OpenGL.MakeCurrent();
            List<SceneElement> children = new List<SceneElement>();
            children.AddRange(scene.ModelContainer.Children);
            foreach (SceneElement child in children)
            {
                ReleaseElement(child);
                scene.ModelContainer.RemoveChild(child);
            }
            children.Clear();
        }

        private static void ReleaseElement(SceneElement element)
        {
            List<SceneElement> children = new List<SceneElement>();
            children.AddRange(element.Children);
            foreach (SceneElement child in children)
            {
                ReleaseElement(child);
                element.RemoveChild(child);
            }
            children.Clear();
            if (element is IDisposable)
            {
                ((IDisposable)element).Dispose();
            }
        }
    }
}
