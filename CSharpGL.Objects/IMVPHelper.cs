using CSharpGL.Maths;
using CSharpGL.Objects.UIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;


namespace CSharpGL.Objects
{
    public static class IMVPHelper
    {
        /// <summary>
        /// public static string strMVP = "MVP";
        /// </summary>
        public static string strMVP = "MVP";

        /// <summary>
        /// 请确保此元素的GLSL中含有uniform mat4 MVP;并作为位置转换矩阵。
        /// </summary>
        /// <param name="element"></param>
        /// <param name="mvp"></param>
        public static void DoUpdateMVP(this IMVP element, mat4 mvp)
        {
            ShaderProgram shaderProgram = element.GetShaderProgram();

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());
        }

        /// <summary>
        /// 请确保此元素的GLSL中含有uniform mat4 MVP;并作为位置转换矩阵。
        /// </summary>
        /// <param name="element"></param>
        public static void DoUnbindShaderProgram(this IMVP element)
        {
            ShaderProgram shaderProgram = element.GetShaderProgram();

            shaderProgram.Unbind();
        }

        //private static readonly object synObj = new object();
        //private static EventHandler<RenderEventArgs> element_BeforeRenderingEvent = null;
        //private static EventHandler<RenderEventArgs> element_AfterRenderingEvent = null;

        ///// <summary>
        ///// 对Xxx : SceneElementBase, IMVP有效的After事件。
        ///// </summary>
        ///// <returns></returns>
        //public static EventHandler<RenderEventArgs> Getelement_AfterRendering<T>(this T element)
        //    where T : SceneElementBase, IMVP
        //{
        //    if (element_AfterRenderingEvent == null)
        //    {
        //        lock (synObj)
        //        {
        //            if (element_AfterRenderingEvent == null)
        //            {
        //                element_AfterRenderingEvent = new EventHandler<RenderEventArgs>(element_AfterRendering);
        //            }
        //        }
        //    }

        //    return element_AfterRenderingEvent;
        //}

        ///// <summary>
        ///// 对Xxx : SceneElementBase, IMVP有效的Before事件。
        ///// </summary>
        ///// <returns></returns>
        //public static EventHandler<RenderEventArgs> Getelement_BeforeRendering<T>(this T element)
        //    where T : SceneElementBase, IMVP
        //{
        //    if (element_BeforeRenderingEvent == null)
        //    {
        //        lock (synObj)
        //        {
        //            if (element_BeforeRenderingEvent == null)
        //            {
        //                element_BeforeRenderingEvent = new EventHandler<RenderEventArgs>(element_BeforeRendering);
        //            }
        //        }
        //    }

        //    return element_BeforeRenderingEvent;
        //}


        //static void element_AfterRendering(object sender, RenderEventArgs e)
        //{
        //    IMVP element = sender as IMVP;
        //    element.UnbindShaderProgram();
        //}

        //private static readonly mat4 modelMatrix = mat4.identity();
        //static void element_BeforeRendering(object sender, RenderEventArgs e)
        //{
        //    if (e.Camera == null)
        //    {
        //        throw new ArgumentNullException();
        //        //const float distance = 0.7f;
        //        //viewMatrix = glm.lookAt(new vec3(-distance, distance, -distance), new vec3(0, 0, 0), new vec3(0, -1, 0));

        //        //int[] viewport = new int[4];
        //        //GL.GetInteger(GetTarget.Viewport, viewport);
        //        //projectionMatrix = glm.perspective(60.0f, (float)viewport[2] / (float)viewport[3], 0.01f, 100.0f);
        //    }

        //    mat4 projectionMatrix, viewMatrix;

        //    viewMatrix = e.Camera.GetViewMat4();
        //    projectionMatrix = e.Camera.GetProjectionMat4();

        //    mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

        //    IMVP element = sender as IMVP;
        //    element.UpdateMVP(projectionMatrix * viewMatrix * modelMatrix);
        //}

    }
}
