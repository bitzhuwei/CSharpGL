using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.UIs
{
    public static class IUILayoutHelper
    {
        /// <summary>
        /// 获取此UI元素的投影矩阵、视图矩阵和模型矩阵
        /// </summary>
        /// <param name="uiElement"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="modelMatrix"></param>
        /// <param name="camera">如果为null，会以glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0))计算默认值。</param>
        /// <param name="maxDepth">UI元素的外接球半径的倍数。</param>
        public static void GetMatrix(this IUILayout uiElement,
            out mat4 projectionMatrix, out mat4 viewMatrix, out mat4 modelMatrix,
            IViewCamera camera = null, float maxDepth = 2.0f)
        {
            IUILayoutArgs args = uiElement.GetArgs();
            float max = (float)Math.Max(args.UIWidth, args.UIHeight);

            {
                //projectionMatrix = glm.ortho((float)args.left, (float)args.right, (float)args.bottom, (float)args.top,
                // TODO: / 2后与legacy opengl的UI元素显示就完全一致了。为什么？？？
                projectionMatrix = glm.ortho((float)args.left / 2, (float)args.right / 2, (float)args.bottom / 2, (float)args.top / 2,
                    uiElement.Param.zNear, uiElement.Param.zFar);
                // 下面注释掉的代码是用来测试legacy OpenGL的matrix与GLM库计算的matrix是否相同用的。已经证明了两者完全相同，此处仅作留念+以防万一。
                //{
                //    float[] matrix = new float[16];

                //    GL.MatrixMode(GL.GL_PROJECTION);
                //    GL.PushMatrix();
                //    GL.GetFloat(GetTarget.ProjectionMatrix, matrix);

                //    GL.LoadIdentity();
                //    GL.GetFloat(GetTarget.ProjectionMatrix, matrix);

                //    GL.Ortho(args.left / 2, args.right / 2, args.bottom / 2, args.top / 2, uiElement.Param.zNear, uiElement.Param.zFar);
                //    GL.GetFloat(GetTarget.ProjectionMatrix, matrix);// this equals projectionMatrix

                //    GL.PopMatrix();
                //}
                // 把UI元素移到ortho长方体的最靠近camera的地方，这样就可以把UI元素放到OpenGL最前方。
                projectionMatrix = glm.translate(projectionMatrix, new vec3(0, 0, uiElement.Param.zFar - max / 2 * maxDepth));
            }
            {
                // UI元素不在三维场景中，所以其Camera可以是null。
                if (camera == null)
                {
                    //viewMatrix = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
                    viewMatrix = glm.lookAt(
                        Camera.defaultPosition, 
                        Camera.defaultTarget, 
                        Camera.defaultUpVector);
                }
                else
                {
                    vec3 position = camera.Position - camera.Target;
                    position.Normalize();
                    viewMatrix = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
                }
                // 下面注释掉的代码是用来测试legacy OpenGL的matrix与GLM库计算的matrix是否相同用的。已经证明了两者完全相同，此处仅作留念+以防万一。
                //{
                //    float[] matrix = new float[16];

                //    GL.MatrixMode(GL.GL_MODELVIEW);
                //    GL.PushMatrix();
                //    GL.GetFloat(GetTarget.ModelviewMatix, matrix);

                //    GL.LoadIdentity();
                //    GL.GetFloat(GetTarget.ModelviewMatix, matrix);

                //    if(camera==null)
                //    {
                //        GL.gluLookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);
                //    }
                //    else
                //    {
                //        vec3 position = camera.Position - camera.Target;
                //        position.Normalize();
                //        GL.gluLookAt(position.x, position.y, position.z, 0, 0, 0, camera.UpVector.x, camera.UpVector.y, camera.UpVector.z);
                //    }
                //    GL.GetFloat(GetTarget.ModelviewMatix, matrix);// this equals viewMatrix

                //    GL.PopMatrix();
                //}
            }
            {
                modelMatrix = glm.scale(mat4.identity(), new vec3(args.UIWidth / 2, args.UIHeight / 2, max / 2));
                // 下面注释掉的代码是用来测试legacy OpenGL的matrix与GLM库计算的matrix是否相同用的。已经证明了两者完全相同，此处仅作留念+以防万一。
                //{
                //    float[] matrix = new float[16];

                //    GL.MatrixMode(GL.GL_MODELVIEW);
                //    GL.PushMatrix();
                //    GL.GetFloat(GetTarget.ModelviewMatix, matrix);

                //    GL.LoadIdentity();
                //    GL.GetFloat(GetTarget.ModelviewMatix, matrix);

                //    GL.Scale(args.UIWidth / 2, args.UIHeight / 2, max / 2);
                //    GL.GetFloat(GetTarget.ModelviewMatix, matrix);// this equals modelMatrix

                //    GL.PopMatrix();
                //}
            }
        }


        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right); 
        /// </summary>
        const AnchorStyles leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        const AnchorStyles topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        
        /// <summary>
        /// 获取为UI元素布局所需的参数对象。
        /// </summary>
        /// <param name="uiElement"></param>
        /// <returns></returns>
        public static IUILayoutArgs GetArgs(this IUILayout uiElement)
        {
            var args = new IUILayoutArgs();

            CalculateViewport(args);

            CalculateCoords(uiElement, args.viewportWidth, args.viewportHeight, args);

            return args;
        }

        /// <summary>
        /// 计算opengl画布的大小。
        /// </summary>
        /// <param name="args"></param>
        static void CalculateViewport(IUILayoutArgs args)
        {
            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            args.viewportWidth = viewport[2];
            args.viewportHeight = viewport[3];
        }

        /// <summary>
        /// 根据UI元素的布局设定，计算其应有的宽高及其在ortho()中应有的参数。
        /// </summary>
        /// <param name="uiElement"></param>
        /// <param name="viewportWidth"></param>
        /// <param name="viewportHeight"></param>
        /// <param name="args"></param>
        static void CalculateCoords(IUILayout uiElement, int viewportWidth, int viewportHeight, IUILayoutArgs args)
        {
            IUILayoutParam param = uiElement.Param;

            if ((param.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.UIWidth = viewportWidth - param.Margin.Left - param.Margin.Right;
                if (args.UIWidth < 0) { args.UIWidth = 0; }
            }
            else
            {
                args.UIWidth = param.Size.Width;
            }

            if ((param.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.UIHeight = viewportHeight - param.Margin.Top - param.Margin.Bottom;
                if (args.UIHeight < 0) { args.UIHeight = 0; }
            }
            else
            {
                args.UIHeight = param.Size.Height;
            }

            if ((param.Anchor & leftRightAnchor) == AnchorStyles.None)
            {
                args.left = -(args.UIWidth / 2
                    + (viewportWidth - args.UIWidth)
                        * ((double)param.Margin.Left / (double)(param.Margin.Left + param.Margin.Right)));
            }
            else if ((param.Anchor & leftRightAnchor) == AnchorStyles.Left)
            {
                args.left = -(args.UIWidth / 2 + param.Margin.Left);
            }
            else if ((param.Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                args.left = -(viewportWidth - args.UIWidth / 2 - param.Margin.Right);
            }
            else // if ((Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.left = -(args.UIWidth / 2 + param.Margin.Left);
            }

            if ((param.Anchor & topBottomAnchor) == AnchorStyles.None)
            {
                args.bottom = -viewportHeight / 2;
                args.bottom = -(args.UIHeight / 2
                    + (viewportHeight - args.UIHeight)
                        * ((double)param.Margin.Bottom / (double)(param.Margin.Bottom + param.Margin.Top)));
            }
            else if ((param.Anchor & topBottomAnchor) == AnchorStyles.Bottom)
            {
                args.bottom = -(args.UIHeight / 2 + param.Margin.Bottom);
            }
            else if ((param.Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                args.bottom = -(viewportHeight - args.UIHeight / 2 - param.Margin.Top);
            }
            else // if ((Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.bottom = -(args.UIHeight / 2 + param.Margin.Bottom);
            }
        }
    }
}
