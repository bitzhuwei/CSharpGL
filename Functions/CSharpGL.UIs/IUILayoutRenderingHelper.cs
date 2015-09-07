using GLM;
using CSharpGL.UIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    public static class IUILayoutRenderingHelper
    {
        private static readonly object synObj = new object();
        private static EventHandler<RenderEventArgs> simpleUIAxis_BeforeRendering = null;
        private static EventHandler<RenderEventArgs> simpleUIAxis_AfterRendering = null;

        /// <summary>
        /// 对Xxx : SceneElementBase, IUILayout, IMVP有效的After事件。
        /// <para>此处用泛型方法是为了让编译器检测where约束条件，这样就没有“坑”了。</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static EventHandler<RenderEventArgs> GetSimpleUI_AfterRendering<T>(this T element) 
            where T : SceneElementBase, IUILayout, IMVP
        {
            if (simpleUIAxis_AfterRendering == null)
            {
                lock (synObj)
                {
                    if (simpleUIAxis_AfterRendering == null)
                    {
                        simpleUIAxis_AfterRendering = new EventHandler<RenderEventArgs>(SimpleUI_AfterRendering);
                    }
                }
            }

            return simpleUIAxis_AfterRendering;
        }

        /// <summary>
        /// 对Xxx : SceneElementBase, IUILayout, IMVP有效的Before事件。
        /// <para>此处用泛型方法是为了让编译器检测where约束条件，这样就没有“坑”了。</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static EventHandler<RenderEventArgs> GetSimpleUI_BeforeRendering<T>(this T element)
            where T : SceneElementBase, IUILayout, IMVP
        {
            if (simpleUIAxis_BeforeRendering == null)
            {
                lock (synObj)
                {
                    if (simpleUIAxis_BeforeRendering == null)
                    {
                        simpleUIAxis_BeforeRendering = new EventHandler<RenderEventArgs>(SimpleUI_BeforeRendering);
                    }
                }
            }

            return simpleUIAxis_BeforeRendering;
        }

        static void SimpleUI_AfterRendering(object sender, RenderEventArgs e)
        {
            IMVP element = sender as IMVP;
            element.ResetShaderProgram();
        }

        static void SimpleUI_BeforeRendering(object sender, RenderEventArgs e)
        {
            mat4 projectionMatrix, viewMatrix, modelMatrix;
            {
                IUILayout element = sender as IUILayout;
                element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix, e.Camera);
            }

            {
                IMVP element = sender as IMVP;
                element.SetShaderProgram(projectionMatrix * viewMatrix * modelMatrix);
            }
        }
    }
}
