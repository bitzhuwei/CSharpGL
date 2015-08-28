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
        /// <para>使用此<see cref="IMVPHelper"/>的<see cref="SceneElement"/>所使用的Vertex Shader必须含有<code>uniform mat4 MVP;</code>并使其作为变换矩阵。</para>
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

        private static readonly object synObj = new object();
        private static EventHandler<RenderEventArgs> IMVPElement_BeforeRenderingEvent = null;
        private static EventHandler<RenderEventArgs> IMVPElement_AfterRenderingEvent = null;

        /// <summary>
        /// 对Xxx : SceneElementBase, IMVP有效的After事件。
        /// <para>如果场景中有很多元素，就不要用这个通用委托了。它会为每个元素计算一次MVP矩阵，所以会比较费时。</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static EventHandler<RenderEventArgs> GetIMVPElement_AfterRendering<T>(this T element)
            where T : SceneElementBase, IMVP
        {
            if (IMVPElement_AfterRenderingEvent == null)
            {
                lock (synObj)
                {
                    if (IMVPElement_AfterRenderingEvent == null)
                    {
                        IMVPElement_AfterRenderingEvent = new EventHandler<RenderEventArgs>(IMVPElement_AfterRendering);
                    }
                }
            }

            return IMVPElement_AfterRenderingEvent;
        }

        /// <summary>
        /// 对Xxx : SceneElementBase, IMVP有效的Before事件。
        /// <para>如果场景中有很多元素，就不要用这个通用委托了。它会为每个元素计算一次MVP矩阵，所以会比较费时。</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static EventHandler<RenderEventArgs> GetIMVPElement_BeforeRendering<T>(this T element)
            where T : SceneElementBase, IMVP
        {
            if (IMVPElement_BeforeRenderingEvent == null)
            {
                lock (synObj)
                {
                    if (IMVPElement_BeforeRenderingEvent == null)
                    {
                        IMVPElement_BeforeRenderingEvent = new EventHandler<RenderEventArgs>(IMVPElement_BeforeRendering);
                    }
                }
            }

            return IMVPElement_BeforeRenderingEvent;
        }


        static void IMVPElement_AfterRendering(object sender, RenderEventArgs e)
        {
            IMVP element = sender as IMVP;
            element.ResetShaderProgram();
        }

        private static readonly mat4 modelMatrix = mat4.identity();

        static void IMVPElement_BeforeRendering(object sender, RenderEventArgs e)
        {
            // 三维场景中所有的元素都应在Camera的照耀下现形，没有Camera就不知道元素该放哪儿。
            // UI元素不在三维场景中，所以其Camera可以是null。
            if (e.Camera == null)
            {
                throw new ArgumentNullException();
                //const float distance = 0.7f;
                //viewMatrix = glm.lookAt(new vec3(-distance, distance, -distance), new vec3(0, 0, 0), new vec3(0, -1, 0));

                //int[] viewport = new int[4];
                //GL.GetInteger(GetTarget.Viewport, viewport);
                //projectionMatrix = glm.perspective(60.0f, (float)viewport[2] / (float)viewport[3], 0.01f, 100.0f);
            }

            mat4 projectionMatrix, viewMatrix;

            viewMatrix = e.Camera.GetViewMat4();
            projectionMatrix = e.Camera.GetProjectionMat4();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;
            element.SetShaderProgram(projectionMatrix * viewMatrix * modelMatrix);
        }

    }
}
