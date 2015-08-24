using CSharpGL.Maths;
using CSharpGL.Objects.UIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.Cameras;


namespace CSharpGL.Objects
{
    public static class IMVPHelper
    {
        private static readonly object synObj = new object();
        private static EventHandler<RenderEventArgs> element_BeforeRenderingEvent = null;
        private static EventHandler<RenderEventArgs> element_AfterRenderingEvent = null;

        /// <summary>
        /// 对Xxx : SceneElementBase, IMVP有效的After事件。
        /// </summary>
        /// <returns></returns>
        public static EventHandler<RenderEventArgs> Getelement_AfterRendering()
        {
            if (element_AfterRenderingEvent == null)
            {
                lock (synObj)
                {
                    if (element_AfterRenderingEvent == null)
                    {
                        element_AfterRenderingEvent = new EventHandler<RenderEventArgs>(element_AfterRendering);
                    }
                }
            }

            return element_AfterRenderingEvent;
        }

        /// <summary>
        /// 对Xxx : SceneElementBase, IMVP有效的Before事件。
        /// </summary>
        /// <returns></returns>
        public static EventHandler<RenderEventArgs> Getelement_BeforeRendering()
        {
            if (element_BeforeRenderingEvent == null)
            {
                lock (synObj)
                {
                    if (element_BeforeRenderingEvent == null)
                    {
                        element_BeforeRenderingEvent = new EventHandler<RenderEventArgs>(element_BeforeRendering);
                    }
                }
            }

            return element_BeforeRenderingEvent;
        }


        static void element_AfterRendering(object sender, RenderEventArgs e)
        {
            IMVP element = sender as IMVP;
            element.UnbindShaderProgram();
        }

        static void element_BeforeRendering(object sender, RenderEventArgs e)
        {
            mat4 projectionMatrix, viewMatrix, modelMatrix;
            modelMatrix = mat4.identity();
            if(e.Camera==null)
            {
                viewMatrix=ScientificCamera.default
            }
            viewMatrix = e.Camera.GetViewMat4();
            projectionMatrix = e.Camera.GetProjectionMat4();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;
            element.UpdateMVP(projectionMatrix * viewMatrix * modelMatrix);
        }
    }
}
