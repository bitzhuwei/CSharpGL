using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Objects.UI.SimpleUI
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
        public static void GetMatrix(this IUILayout uiElement, out mat4 projectionMatrix, out mat4 viewMatrix, out mat4 modelMatrix, IViewCamera camera = null)
        {
            IUILayoutArgs args = uiElement.GetArgs();
            float max = (float)Math.Max(args.UIWidth, args.UIHeight);

            {
                projectionMatrix = glm.ortho((float)args.left, (float)args.right, (float)args.bottom, (float)args.top,
                    uiElement.zNear, uiElement.zFar);

                // 把UI元素移到ortho长方体的最靠近camera的地方，这样就可以把UI元素放到OpenGL最前方。
                projectionMatrix = glm.translate(projectionMatrix, new vec3(0, 0, uiElement.zFar - max / 2));
            }
            {
                if (camera == null)
                {
                    viewMatrix = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
                }
                else
                {
                    vec3 position = camera.Position - camera.Target;
                    position.Normalize();
                    viewMatrix = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
                }
            }
            {
                modelMatrix = glm.scale(mat4.identity(), new vec3(max / 2, max / 2, max / 2));
            }
        }


        /// <summary>
        /// 获取此UI元素的投影矩阵和模型矩阵
        /// </summary>
        /// <param name="uiElement"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="modelMatrix"></param>
        public static void GetMatrix(this IUILayout uiElement, out mat4 projectionMatrix, out mat4 modelMatrix)
        {
            IUILayoutArgs args = uiElement.GetArgs();

            projectionMatrix = glm.ortho((float)args.left, (float)args.right, (float)args.bottom, (float)args.top,
                uiElement.zNear, uiElement.zFar);

            float max = (float)Math.Max(args.UIWidth, args.UIHeight);
            // 把UI元素移到ortho长方体的最靠近camera的地方，这样就可以把UI元素放到OpenGL最前方。
            projectionMatrix = glm.translate(projectionMatrix, new vec3(0, 0, uiElement.zFar - max / 2));

            modelMatrix = glm.scale(mat4.identity(), new vec3(max / 2, max / 2, max / 2));
        }

        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right); 
        /// </summary>
        const AnchorStyles leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        const AnchorStyles topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);

        static IUILayoutArgs GetArgs(this IUILayout uiElement)
        {
            var args = new IUILayoutArgs();

            CalculateViewport(args);

            CalculateCoords(uiElement, args.viewWidth, args.viewHeight, args);

            return args;
        }

        static void CalculateViewport(IUILayoutArgs args)
        {
            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            args.viewWidth = viewport[2];
            args.viewHeight = viewport[3];
        }

        static void CalculateCoords(IUILayout uiElement, int viewWidth, int viewHeight, IUILayoutArgs args)
        {
            if ((uiElement.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.UIWidth = viewWidth - uiElement.Margin.Left - uiElement.Margin.Right;
                if (args.UIWidth < 0) { args.UIWidth = 0; }
            }
            else
            {
                args.UIWidth = uiElement.Size.Width;
            }

            if ((uiElement.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.UIHeight = viewHeight - uiElement.Margin.Top - uiElement.Margin.Bottom;
                if (args.UIHeight < 0) { args.UIHeight = 0; }
            }
            else
            {
                args.UIHeight = uiElement.Size.Height;
            }

            if ((uiElement.Anchor & leftRightAnchor) == AnchorStyles.None)
            {
                args.left = -(args.UIWidth / 2
                    + (viewWidth - args.UIWidth) * ((double)uiElement.Margin.Left / (double)(uiElement.Margin.Left + uiElement.Margin.Right)));
            }
            else if ((uiElement.Anchor & leftRightAnchor) == AnchorStyles.Left)
            {
                args.left = -(args.UIWidth / 2 + uiElement.Margin.Left);
            }
            else if ((uiElement.Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                args.left = -(viewWidth - args.UIWidth / 2 - uiElement.Margin.Right);
            }
            else // if ((Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.left = -(args.UIWidth / 2 + uiElement.Margin.Left);
            }

            if ((uiElement.Anchor & topBottomAnchor) == AnchorStyles.None)
            {
                args.bottom = -viewHeight / 2;
                args.bottom = -(args.UIHeight / 2
                    + (viewHeight - args.UIHeight) * ((double)uiElement.Margin.Bottom / (double)(uiElement.Margin.Bottom + uiElement.Margin.Top)));
            }
            else if ((uiElement.Anchor & topBottomAnchor) == AnchorStyles.Bottom)
            {
                args.bottom = -(args.UIHeight / 2 + uiElement.Margin.Bottom);
            }
            else if ((uiElement.Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                args.bottom = -(viewHeight - args.UIHeight / 2 - uiElement.Margin.Top);
            }
            else // if ((Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.bottom = -(args.UIHeight / 2 + uiElement.Margin.Bottom);
            }
        }
    }
}
