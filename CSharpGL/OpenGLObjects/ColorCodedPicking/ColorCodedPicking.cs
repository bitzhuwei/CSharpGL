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
            params PickableModernRenderer[] pickableElements)
        {
            if (x < 0 || canvasWidth <= x || y < 0 || canvasHeight <= y) { return null; }

            Rectangle rect = new Rectangle(x, y, 1, 1);
            List<Tuple<Point, PickedGeometry>> list = Pick(arg,
                rect, canvasWidth, canvasHeight, pickableElements);
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
            int x, int y, int radius, int canvasWidth, int canvasHeight,
             params PickableModernRenderer[] pickableElements)
        {
            if (x < 0 || canvasWidth <= x || y < 0 || canvasHeight <= y) { return null; }

            Rectangle rect = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            return Pick(e, rect, canvasWidth, canvasHeight, pickableElements);
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
            params PickableModernRenderer[] pickableElements)
        {
            var result = new List<Tuple<Point, PickedGeometry>>();
            if (pickableElements.Length == 0) { return result; }

            Render4Picking(arg, pickableElements);
            List<Tuple<Point, uint>> stageVertexIdList = ReadPixels(rect, canvasHeight);
            foreach (var tuple in stageVertexIdList)
            {
                int x = tuple.Item1.X;
                int y = tuple.Item1.Y;
                if (x < 0 || canvasWidth <= x || y < 0 || canvasHeight <= y) { continue; }

                uint stageVertexId = tuple.Item2;
                PickedGeometry pickedGeometry = PickGeometry(arg,
                    x, y, canvasWidth, canvasHeight, stageVertexId, pickableElements);
                if (pickedGeometry != null)
                {
                    result.Add(new Tuple<Point, PickedGeometry>(new Point(x, y), pickedGeometry));
                }
            }

            return result;
        }

        /// <summary>
        /// 在多个buffer中拾取一个图元
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="pickableElements"></param>
        public static void Render4Picking(RenderEventArgs arg, params PickableModernRenderer[] pickableElements)
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


        /// <summary>
        /// get picked primitive
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="canvasWidth"></param>
        /// <param name="canvasHeight"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="pickableElements"></param>
        /// <returns></returns>
        private static PickedGeometry PickGeometry(RenderEventArgs arg,
            int x, int y, int canvasWidth, int canvasHeight,
            uint stageVertexId,
            params IColorCodedPicking[] pickableElements)
        {
            PickedGeometry pickedGeometry = null;
            foreach (var item in pickableElements)
            {
                pickedGeometry = item.Pick(arg, stageVertexId,
                    x, y, canvasWidth, canvasHeight);
                if (pickedGeometry != null)
                { break; }
            }

            return pickedGeometry;
        }

        /// <summary>
        /// 读取指定范围内的像素，获取其代表的VertexId
        /// <para>Read specified rect and get the VertexIds they represent.</para>
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="canvasHeight"></param>
        /// <returns></returns>
        public static unsafe List<Tuple<Point, uint>> ReadPixels(
            Rectangle rect, int canvasHeight)
        {
            var result = new List<Tuple<Point, uint>>();
            if (rect.Width <= 0 || rect.Height <= 0) { return result; }

            // get coded color.
            using (var codedColor = new UnmanagedArray<Pixel>(4 * rect.Width * rect.Height))
            {
                GL.ReadPixels(rect.X, canvasHeight - rect.Y - 1, rect.Width, rect.Height,
                    GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, codedColor.Header);

                var array = (Pixel*)codedColor.FirstElement();
                int index = 0;
                var vertexIdList = new List<uint>();
                for (int y = rect.Height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < rect.Width; x++)
                    {
                        Pixel pixel = array[index++];
                        if (!
                            // This is when (x, y) is on background and no primitive is picked.
                            (pixel.r == byte.MaxValue && pixel.g == byte.MaxValue
                            && pixel.b == byte.MaxValue && pixel.a == byte.MaxValue))
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
                            uint shiftedR = (uint)pixel.r;
                            uint shiftedG = (uint)pixel.g << 8;
                            uint shiftedB = (uint)pixel.b << 16;
                            uint shiftedA = (uint)pixel.a << 24;
                            var vertexId = shiftedR + shiftedG + shiftedB + shiftedA;
                            if (!vertexIdList.Contains(vertexId))
                            {
                                result.Add(new Tuple<Point, uint>(
                                    new Point(x, y), vertexId));
                                vertexIdList.Add(vertexId);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static uint ReadPixel(
            int x, int y, int canvasHeight)
        {
            uint stageVertexId = uint.MaxValue;
            // get coded color.
            //byte[] codedColor = new byte[4];
            using (var codedColor = new UnmanagedArray<byte>(4))
            {
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
                    stageVertexId = shiftedR + shiftedG + shiftedB + shiftedA;
                }
            }

            return stageVertexId;
        }

    }

}
