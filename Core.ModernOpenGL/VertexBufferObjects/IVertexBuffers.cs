using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{
    /// <summary>
    /// 创建、更新指定的vertex buffer object。
    /// </summary>
    public interface IVertexBuffers
    {
        /// <summary>
        /// 添加一个指定<paramref name="varNameInShader"/>的顶点属性数组的vertex buffer object并赋值。
        /// <para>一个<see cref="IVertexBuffers"/>可以有多个属性buffer。</para>
        /// </summary>
        /// <param name="varNameInShader">为即将添加的VBO赋予一个名字，在更新或删除VBO时用于识别此VBO。
        /// <para>此名字必须与shader中的'in someType xxx;'中的xxx命名相同。</para>
        /// <para>建议开发者在具体的子类中用<code>const string strxxx = "xxx";</code>来定义和使用xxx。</para>
        /// </param>
        /// <param name="values"></param>
        /// <param name="usage"></param>
        /// <param name="size"><paramref name="values"/>中的分量数目，是VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)里的size，常见的如UnmanagedArray&lt;Vertex&gt;时为3，UnmanagedArray&lt;float&gt;时为1，</param>
        /// <param name="type"><paramref name="values"/>中的分量类型，是VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)里的type，常见的例如GL.GL_FLOAT</param>
        /// <returns></returns>
        PropertyBuffer AddPropertyBuffer(string varNameInShader, UnmanagedArrayBase values, UsageType usage, int size, uint type);

        /// <summary>
        /// 设置指定<paramref name="key"/>的顶点索引数组的vertex buffer object并赋值。
        /// <para>一个<see cref="IVertexBuffers"/>最多有1个索引buffer。</para>
        /// <para>如果再次调用此方法，会销毁上一次调用产生的<see cref="IndexBuffer"/>对象。</para>
        /// <para>返回设置的索引buffer。</para>
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="usage"></param>
        /// <param name="indexLength"></param>
        /// <returns></returns>
        IndexBuffer SetupIndexBuffer(UnmanagedArrayBase indexes, UsageType usage);

        /// <summary>
        /// 更新指定<paramref name="varNameInShader"/>的vertex buffer object。
        /// </summary>
        /// <param name="varNameInShader">根据指定的名字找到要更新的VBO。
        /// <para>此key是在<see cref="CreateVertexBuffer()"/>中的参数key。</para>
        /// </param>
        /// <param name="newValues"></param>
        void UpdateVertexBuffer(string varNameInShader, UnmanagedArrayBase newValues);

        /// <summary>
        /// 更新指定<paramref name="varNameInShader"/>的vertex buffer object。
        /// 仅更新其中一部分。
        /// </summary>
        /// <param name="varNameInShader">根据指定的名字找到要更新的VBO。</param>
        /// <param name="newValues"></param>
        /// <param name="startIndex">要更新的部分在VBO数组中的起始位置。</param>
        void UpdateVertexBuffer(string varNameInShader, UnmanagedArrayBase newValues, int startIndex);

        /// <summary>
        /// 更新索引buffer。
        /// </summary>
        /// <param name="indexes"></param>
        void UpdateIndexBuffer(UnmanagedArrayBase indexes);

        /// <summary>
        /// 更新索引buffer。
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="startIndex"></param>
        void UpdateIndexBuffer(UnmanagedArrayBase indexes, int startIndex);
    }

}
