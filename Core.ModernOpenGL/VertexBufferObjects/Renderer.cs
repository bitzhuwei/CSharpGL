using CSharpGL;
using CSharpGL.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{
    /// <summary>
    /// 渲染器，用于指定渲染方式。可选用IndexRenderer或NonIndexRenderer或MultiDrawArraysRenderer或自定义。
    /// </summary>
    public abstract class Renderer : IRenderable
    {
        /// <summary>
        /// GL.TRIANGLES etc.
        /// </summary>
        public uint Mode { get; set; }

        /// <summary>
        /// 渲染器，用于指定渲染方式。可选用IndexRenderer或NonIndexRenderer或MultiDrawArraysRenderer或自定义。
        /// </summary>
        /// <param name="mode">GL.TRIANGLES etc.</param>
        public Renderer(uint mode)
        {
            this.Mode = mode;
        }

        public abstract void Render(RenderEventArgs e);
    }

    /// <summary>
    /// 用索引方式渲染。(GL.DrawElements())
    /// </summary>
    public class IndexRenderer : Renderer
    {
        /// <summary>
        /// 用索引方式渲染。(GL.DrawElements())
        /// </summary>
        /// <param name="count">count in DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>要渲染多少个索引。</para></param>
        /// <param name="type">type in DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>GL.GL_UNSIGNED_INT等</para></param>
        public IndexRenderer(uint mode, int count,uint type)
            :base(mode)
        {
            this.Count = count;
            this.Type = type;
        }

        /// <summary>
        /// count in DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>要渲染多少个索引。</para>
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// type in DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>GL.GL_UNSIGNED_INT等</para>
        /// </summary>
        public uint Type { get; set; }


        public override void Render(RenderEventArgs e)
        {
            GL.DrawElements(this.Mode, this.Count, this.Type, IntPtr.Zero);
        }
    }
    
    /// <summary>
    /// 不用索引的方式渲染。(GL.DrawArrays())
    /// </summary>
    public class DrawArraysRenderer : Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="first">Specifies the starting	index in the enabled arrays.</param>
        /// <param name="vertexCount">Specifies the number of vertexes to be rendered.</param>
        public DrawArraysRenderer(uint mode, int first, int vertexCount)
            :base(mode)
        {
            this.First = first;
            this.VertexCount = vertexCount;
        }
        public override void Render(RenderEventArgs e)
        {
            GL.DrawArrays(base.Mode, 0, VertexCount);
        }

        /// <summary>
        /// Specifies the starting	index in the enabled arrays
        /// </summary>
        public int First { get; set; }

        /// <summary>
        /// Specifies the number of vertexes to be rendered.
        /// </summary>
        public int VertexCount { get; set; }

    }

    /// <summary>
    /// 不用索引的方式渲染。(GL.MultiDrawArrays())
    /// </summary>
    public class MultiDrawArraysRenderer : Renderer
    {
        /// <summary>
        /// 不用索引的方式渲染。(GL.MultiDrawArrays())
        /// </summary>
        /// <param name="vertexCountPerPrim">VBO中每个单元（一个三角形、一个六面体等等）包含的顶点数。</param>
        /// <param name="PrimCount">VBO中包含的单元（一个三角形、一个六面体）的数目。</param>
        public MultiDrawArraysRenderer(uint mode, int vertexCountPerPrim, int PrimCount)
            :base(mode)
        {
            this.First = new int[PrimCount];
            this.Count = new int[PrimCount];
            for (int i = 0; i < this.First.Length; i++)
            {
                this.First[i] = i * vertexCountPerPrim;
                this.Count[i] = vertexCountPerPrim;
            }
            this.PrimCount = PrimCount;
        }
        /// <summary>
        /// first in MultiDrawArrays(uint mode, int[] first, int[] count, int primcount)
        /// </summary>
        public int[] First { get; set; }

        /// <summary>
        /// count in MultiDrawArrays(uint mode, int[] first, int[] count, int primcount)
        /// </summary>
        public int[] Count { get; set; }

        /// <summary>
        /// primcount in MultiDrawArrays(uint mode, int[] first, int[] count, int primcount)
        /// </summary>
        public int PrimCount { get; set; }

        public override void Render(RenderEventArgs e)
        {
            GL.MultiDrawArrays(this.Mode, this.First, this.Count, this.PrimCount);
        }


    }
}
