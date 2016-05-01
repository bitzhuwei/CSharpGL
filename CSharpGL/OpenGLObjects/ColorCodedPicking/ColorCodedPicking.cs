using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class ColorCodedPicking
    {

        /// <summary>
        /// Color Coded Picking
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="x">鼠标位置</param>
        /// <param name="y">鼠标位置</param>
        /// <param name="canvasWidth">画布宽度</param>
        /// <param name="canvasHeight">画布高度</param>
        /// <param name="pickableElements">在哪些对象中执行拾取操作</param>
        /// <returns></returns>
        public static PickedGeometry Pick(
            RenderEventArgs arg, 
            int x, int y, int canvasWidth, int canvasHeight,
            params IColorCodedPicking[] pickableElements)
        {
            Rectangle rect = new Rectangle(x, y, 1, 1);
            List<Tuple<Point, PickedGeometry>> list = Pick(arg, 
                rect, canvasWidth, canvasHeight,  pickableElements);
            if (list.Count > 0)
            { return list[0].Item2; }
            else
            { return null; }
        }

        /// <summary>
        /// Color Coded Picking
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="x">鼠标位置</param>
        /// <param name="y">鼠标位置</param>
        /// <param name="radius">以鼠标位置为中心，在半径为<paramref name="radius"/>的正方形范围内进行拾取</param>
        /// <param name="width">画布宽度</param>
        /// <param name="height">画布高度</param>
        /// <param name="pickableElements">在哪些对象中执行拾取操作</param>
        /// <returns></returns>
        public static List<Tuple<Point, PickedGeometry>> Pick(
            RenderEventArgs e, 
            int x, int y, int radius, int width, int height,
             params IColorCodedPicking[] pickableElements)
        {
            Rectangle rect = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            return Pick(e, rect, width, height,  pickableElements);
        }

        /// <summary>
        /// Color Coded Picking
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="rect">拾取范围</param>
        /// <param name="canvasWidth">画布宽度</param>
        /// <param name="canvasHeight">画布高度</param>
        /// <param name="pickableElements">在哪些对象中执行拾取操作</param>
        /// <returns></returns>
        public static List<Tuple<Point, PickedGeometry>> Pick(
            RenderEventArgs arg, 
            Rectangle rect, int canvasWidth, int canvasHeight,
            params IColorCodedPicking[] pickableElements)
        {
            var result = new List<Tuple<Point, PickedGeometry>>();
            if (pickableElements.Length == 0) { return result; }

            Render4Picking(arg,  pickableElements);

            for (int row = 0; row < rect.Width; row++)
            {
                for (int col = 0; col < rect.Height; col++)
                {
                    int x = rect.X + col;
                    int y = rect.Y + row;

                    PickedGeometry pickedGeometry = ReadPixel(arg, 
                        x, y, canvasWidth, canvasHeight, pickableElements);

                    if (pickedGeometry != null)
                    {
                        result.Add(new Tuple<Point, PickedGeometry>(new Point(x, y), pickedGeometry));
                    }
                }
            }

            return result;
        }

        private static void Render4Picking(RenderEventArgs arg, IColorCodedPicking[] pickableElements)
        {
            // 暂存clear color
            var originalClearColor = new float[4];
            GL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);// 白色意味着没有拾取到任何对象
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            // 恢复clear color
            GL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            SharedStageInfo info = new SharedStageInfo();
            foreach (var pickable in pickableElements)
            {
                info.RenderForPicking(pickable, arg);
            }

            GL.Flush();
        }

        private static PickedGeometry ReadPixel(
            RenderEventArgs arg, 
            int x, int y, int canvasWidth, int canvasHeight,
            params IColorCodedPicking[] pickableElements)
        {
            PickedGeometry pickedGeometry = null;
            // get coded color.
            //byte[] codedColor = new byte[4];
            UnmanagedArray<byte> codedColor = new UnmanagedArray<byte>(4);
            GL.ReadPixels(x, canvasHeight - y - 1, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, codedColor.Header);
            if (!
                // This is when (x, y) is on background and no primitive is picked.
                (codedColor[0] == byte.MaxValue && codedColor[1] == byte.MaxValue
                && codedColor[2] == byte.MaxValue && codedColor[3] == byte.MaxValue))
            {
                /* // This is how is vertexID coded into color in vertex shader.
                 * 	int objectID = gl_VertexID;
                    codedColor = vec4(
                        float(objectID & 0xFF), 
                        float((objectID >> 8) & 0xFF), 
                        float((objectID >> 16) & 0xFF), 
                        float((objectID >> 24) & 0xFF));
                 */
                // get vertexID from coded color.
                // the vertexID is the last vertex that constructs the primitive.
                // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
                uint shiftedR = (uint)codedColor[0];
                uint shiftedG = (uint)codedColor[1] << 8;
                uint shiftedB = (uint)codedColor[2] << 16;
                uint shiftedA = (uint)codedColor[3] << 24;
                uint stageVertexId = shiftedR + shiftedG + shiftedB + shiftedA;

                // get picked primitive.
                foreach (var item in pickableElements)
                {
                    pickedGeometry = item.Pick(arg, stageVertexId,
                        x, y, canvasWidth, canvasHeight);
                    if (pickedGeometry != null)
                    { break; }
                }
            }

            return pickedGeometry;
        }

    }

}
