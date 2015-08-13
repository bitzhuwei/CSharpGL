using CSharpGL.Maths;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Objects.UI.SimpleUI
{
    public class SimpleUIAxis : SceneElementBase, IDisposable
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor">the edges of the viewport to which a SimpleUIRect is bound and determines how it is resized with its parent.
        /// <para>something like AnchorStyles.Left | AnchorStyles.Bottom.</para></param>
        /// <param name="margin">the space between viewport and SimpleRect.</param>
        /// <param name="size">Stores width when <see cref="OpenGLUIRect.Anchor"/>.Left & <see cref="OpenGLUIRect.Anchor"/>.Right is <see cref="OpenGLUIRect.Anchor"/>.None.
        /// <para> and height when <see cref="OpenGLUIRect.Anchor"/>.Top & <see cref="OpenGLUIRect.Anchor"/>.Bottom is <see cref="OpenGLUIRect.Anchor"/>.None.</para></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <param name="rectColor">default color is red.</param>
        public SimpleUIAxis(AnchorStyles anchor, Padding margin, System.Drawing.Size size,
            int zNear = -1000, int zFar = 1000, GLColor rectColor = null,
            float radius = 0.3f, float length = 10, int faceCount = 10)
        {
            this.radius = radius;
            this.length = length;
            this.faceCount = faceCount;

            this.planColor = new vec3(1, 1, 1);

            this.Anchor = anchor;
            this.Margin = margin;
            this.Size = size;
            this.zNear = zNear;
            this.zFar = zFar;
            if (rectColor == null)
            { this.RectColor = new vec3(1, 0, 0); }
            else
            { this.RectColor = new vec3(1, 0, 0); }

            this.RenderBound = true;
        }

        protected void CalculateViewport(SimpleUIRectArgs args)
        {
            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            args.viewWidth = viewport[2];
            args.viewHeight = viewport[3];
        }

        protected void CalculateCoords(int viewWidth, int viewHeight, SimpleUIRectArgs args)
        {
            if ((Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.UIWidth = viewWidth - Margin.Left - Margin.Right;
                if (args.UIWidth < 0) { args.UIWidth = 0; }
            }
            else
            {
                args.UIWidth = this.Size.Width;
            }

            if ((Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.UIHeight = viewHeight - Margin.Top - Margin.Bottom;
                if (args.UIHeight < 0) { args.UIHeight = 0; }
            }
            else
            {
                args.UIHeight = this.Size.Height;
            }

            if ((Anchor & leftRightAnchor) == AnchorStyles.None)
            {
                args.left = -(args.UIWidth / 2
                    + (viewWidth - args.UIWidth) * ((double)Margin.Left / (double)(Margin.Left + Margin.Right)));
            }
            else if ((Anchor & leftRightAnchor) == AnchorStyles.Left)
            {
                args.left = -(args.UIWidth / 2 + Margin.Left);
            }
            else if ((Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                args.left = -(viewWidth - args.UIWidth / 2 - Margin.Right);
            }
            else // if ((Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.left = -(args.UIWidth / 2 + Margin.Left);
            }

            if ((Anchor & topBottomAnchor) == AnchorStyles.None)
            {
                args.bottom = -viewHeight / 2;
                args.bottom = -(args.UIHeight / 2
                    + (viewHeight - args.UIHeight) * ((double)Margin.Bottom / (double)(Margin.Bottom + Margin.Top)));
            }
            else if ((Anchor & topBottomAnchor) == AnchorStyles.Bottom)
            {
                args.bottom = -(args.UIHeight / 2 + Margin.Bottom);
            }
            else if ((Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                args.bottom = -(viewHeight - args.UIHeight / 2 - Margin.Top);
            }
            else // if ((Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.bottom = -(args.UIHeight / 2 + Margin.Bottom);
            }
        }

        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right); 
        /// </summary>
        protected const AnchorStyles leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        protected const AnchorStyles topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);

        /// <summary>
        /// the edges of the OpenGLControl to which a SimpleUIRect is bound and determines how it is resized with its parent.
        /// <para>something like AnchorStyles.Left | AnchorStyles.Bottom.</para>
        /// </summary>
        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        /// <summary>
        /// Gets or sets the space between viewport and SimpleRect.
        /// </summary>
        public System.Windows.Forms.Padding Margin { get; set; }

        ///// <summary>
        ///// Left bottom point's location on view port.
        ///// <para>This works when <see cref="OpenGLUIRect.Anchor"/>.Left & <see cref="OpenGLUIRect.Anchor"/>.Right is <see cref="OpenGLUIRect.Anchor"/>.None.
        ///// or <see cref="OpenGLUIRect.Anchor"/>.Top & <see cref="OpenGLUIRect.Anchor"/>.Bottom is <see cref="OpenGLUIRect.Anchor"/>.None.</para>
        ///// </summary>
        //public System.Drawing.Point Location { get; set; }

        /// <summary>
        /// Stores width when <see cref="OpenGLUIRect.Anchor"/>.Left & <see cref="OpenGLUIRect.Anchor"/>.Right is <see cref="OpenGLUIRect.Anchor"/>.None.
        /// <para> and height when <see cref="OpenGLUIRect.Anchor"/>.Top & <see cref="OpenGLUIRect.Anchor"/>.Bottom is <see cref="OpenGLUIRect.Anchor"/>.None.</para>
        /// </summary>
        public System.Drawing.Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }

        public vec3 RectColor { get; set; }

        public bool RenderBound { get; set; }

        public SimpleUIRectArgs GetArgs()
        {
            var args = new SimpleUIRectArgs();

            CalculateViewport(args);

            CalculateCoords(args.viewWidth, args.viewHeight, args);

            return args;
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // AxisElement part
        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        public const string strprojectionMatrix = "projectionMatrix";
        public const string strviewMatrix = "viewMatrix";
        public const string strmodelMatrix = "modelMatrix";

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;

        /// <summary>
        /// 图元类型
        /// </summary>
        protected PrimitiveModes axisPrimitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        protected int axisVertexCount;

        private float radius;
        private float length;
        private int faceCount;

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        protected void InitializeVAO()
        {
            this.axisPrimitiveMode = PrimitiveModes.QuadStrip;
            this.axisVertexCount = faceCount * 2;
            this.vao = new uint[4];

            GL.GenVertexArrays(4, vao);

            vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1) };
            // 计算三个坐标轴
            for (int axisIndex = 0; axisIndex < 3; axisIndex++)
            {
                GL.BindVertexArray(vao[axisIndex]);

                //  Create a vertex buffer for the vertex data.
                {
                    UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(faceCount * 2);
                    for (int i = 0; i < faceCount * 2; i++)
                    {
                        int face = i / 2;
                        float[] components = new float[]{
                            i % 2 == 1 ? 0 : this.length,
                            (float)(this.radius * Math.Cos(face * (Math.PI * 2) / faceCount)),
                            (float)(this.radius * Math.Sin(face * (Math.PI * 2) / faceCount))};
                        positionArray[i] = new vec3(
                            components[(0 + axisIndex) % 3], components[(2 + axisIndex) % 3], components[(4 + axisIndex) % 3]);
                    }

                    uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(positionLocation);
                    positionArray.Dispose();
                }

                //  Now do the same for the colour data.
                {
                    UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(faceCount * 2);
                    for (int i = 0; i < colorArray.Length; i++)
                    {
                        colorArray[i] = colors[axisIndex];
                    }

                    uint colorLocation = shaderProgram.GetAttributeLocation(strin_Color);

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(colorLocation);
                    colorArray.Dispose();
                }
                {
                    UnmanagedArray<uint> cylinderIndex = new UnmanagedArray<uint>(faceCount * 2 + 2);
                    for (int i = 0; i < cylinderIndex.Length - 2; i++)
                    {
                        cylinderIndex[i] = (uint)i;
                    }
                    cylinderIndex[cylinderIndex.Length - 2] = 0;
                    cylinderIndex[cylinderIndex.Length - 1] = 1;

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ElementArrayBuffer, cylinderIndex, BufferUsage.StaticDraw);
                    cylinderIndex.Dispose();
                }
                //  Unbind the vertex array, we've finished specifying data for it.
                GL.BindVertexArray(0);
            }
            // 计算XZ平面
            {
                this.planPrimitveMode = PrimitiveModes.LineLoop;
                this.planVertexCount = 4;

                GL.BindVertexArray(vao[3]);

                //  Create a vertex buffer for the vertex data.
                {
                    UnmanagedArray<vec3> plan = new UnmanagedArray<vec3>(4);
                    float length = this.length;
                    plan[0] = new vec3(-length, 0, -length);
                    plan[1] = new vec3(-length, 0, length);
                    plan[2] = new vec3(length, 0, length);
                    plan[3] = new vec3(length, 0, -length);

                    uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ArrayBuffer, plan, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(positionLocation);

                    plan.Dispose();
                }

                //  Now do the same for the colour data.
                {
                    UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(4);
                    for (int i = 0; i < colorArray.Length; i++)
                    {
                        colorArray[i] = this.planColor;
                    }

                    uint colorLocation = shaderProgram.GetAttributeLocation(strin_Color);

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(colorLocation);

                    colorArray.Dispose();
                }

                //  Unbind the vertex array, we've finished specifying data for it.
                GL.BindVertexArray(0);
            }
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO();
        }

        protected override void DoRender(RenderModes renderMode)
        {
            // 画坐标轴
            for (int i = 0; i < 3; i++)
            {
                GL.BindVertexArray(vao[i]);

                //GL.DrawArrays(primitiveMode, 0, vertexCount);
                GL.DrawElements(axisPrimitiveMode, faceCount * 2 + 2, GL.GL_UNSIGNED_INT, IntPtr.Zero);

                GL.BindVertexArray(0);
            }

            // 画平面
            {
                GL.BindVertexArray(vao[3]);

                GL.DrawArrays(this.planPrimitveMode, 0, 4);

                GL.BindVertexArray(0);
            }
        }


        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;
        private PrimitiveModes planPrimitveMode;
        private int planVertexCount;
        private vec3 planColor;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            if (vao != null)
            {
                GL.DeleteVertexArrays(vao.Length, vao);
                vao = null;
            }

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
