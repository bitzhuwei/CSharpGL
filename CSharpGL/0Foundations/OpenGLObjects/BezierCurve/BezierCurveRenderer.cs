using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class BezierCurveRenderer : RendererBase
    {
        private unsafe UnmanagedArray<vec3> controlPoints;
        private int numOfPoints;
        public BezierCurveRenderer(int numOfPoints, UnmanagedArray<vec3> controlPoints)
        {
            this.numOfPoints = numOfPoints;
            this.controlPoints = controlPoints;
        }

        protected override void DoInitialize()
        {
            //设置贝塞尔曲线，这个函数其实只需要调用一次，可以放在SetupRC中设置
            OpenGL.Map1f(OpenGL.GL_MAP1_VERTEX_3, //生成的数据类型
             0.0f, //u值的下界
              100.0f, //u值的上界
               3, //顶点在数据中的间隔，x,y,z所以间隔是3
                numOfPoints, //u方向上的阶，即控制点的个数
                 controlPoints.Header//指向控制点数据的指针
                 );
            //必须在绘制顶点之前开启
            OpenGL.Enable(OpenGL.GL_MAP1_VERTEX_3);
            //使用画线的方式来连接点
            OpenGL.Begin(OpenGL.GL_LINE_STRIP);
            for (int i = 0; i <= 100; i++)
            {
                OpenGL.EvalCoord1f((float)i);
            }
            OpenGL.End();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            OpenGL.LoadIdentity();
            //使用正交投影
            OpenGL.MatrixMode(OpenGL.GL_PROJECTION);
            OpenGL.LoadIdentity();

            OpenGL.Ortho(-10.0f, 10.0f, -10.0f, 10.0f, -100, 100);

            OpenGL.MatrixMode(OpenGL.GL_MODELVIEW);
            //this.LegacyTransform();
            OpenGL.Color(1.0f, 0, 0, 1.0f);


            //画控制点
            OpenGL.PointSize(2.5f);
            OpenGL.Begin(OpenGL.GL_LINES);
            unsafe
            {
                var array = (vec3*)controlPoints.Header.ToPointer();
                for (int i = 0; i < numOfPoints; ++i)
                {
                    OpenGL.Vertex(array[i].x, array[i].y, array[i].z);
                }
            }
            OpenGL.End();
        }
    }
}
