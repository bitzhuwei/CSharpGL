using CSharpGL;
using System;
using System.Runtime.InteropServices;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class CatesianGrid
    {
        public const string strColor = "color";
        private VertexAttributeBufferPtr colorBufferPtr;

        private VertexAttributeBufferPtr GetColorBufferPtr(string varNameInShader)
        {
            float[] textures = GetTextureCoords(this.GridBlockProperties[this.defaultBlockPropertyIndex]);
            int gridCellCount = this.DataSource.DimenSize;
            int length = gridCellCount;
            VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(HexahedronTexCoord), length, VertexAttributeConfig.Float, BufferUsage.StaticDraw, varNameInShader);
            unsafe
            {
                IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (HexahedronTexCoord*)pointer;
                for (int gridIndex = 0; gridIndex < gridCellCount; gridIndex++)
                {
                    array[gridIndex].SetCoord(textures[gridIndex]);
                }
                bufferPtr.UnmapBuffer();
            }

            return bufferPtr;
        }

        public override void UpdateColor(TracyEnergy.Simba.Data.Keywords.impl.GridBlockProperty property)
        {
            float[] textures = GetTextureCoords(property);
            int gridCellCount = this.DataSource.DimenSize;

            unsafe
            {
                IntPtr pointer = this.colorBufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (HexahedronTexCoord*)pointer;
                for (int gridIndex = 0; gridIndex < gridCellCount; gridIndex++)
                {
                    array[gridIndex].SetCoord(textures[gridIndex]);
                }
            }
            this.colorBufferPtr.UnmapBuffer();
        }

        private float[] GetTextureCoords(GridBlockProperty property)
        {
            int[] gridIndexes = property.Positions;
            float[] values = property.Values;
            int[] resultsVisibles = this.DataSource.ExpandVisibles(gridIndexes);
            int[] bindVisibles = this.DataSource.BindCellActive(this.DataSource.BindVisibles, resultsVisibles);

            int dimenSize = this.DataSource.DimenSize;
            float[] textures = this.DataSource.GetInvisibleTextureCoords();
            float distance = Math.Abs(this.MaxColorCode - this.MinColorCode);
            for (int i = 0; i < gridIndexes.Length; i++)
            {
                int gridIndex = gridIndexes[i];
                float value = values[i];
                if (value < this.MinColorCode)
                {
                    value = this.MinColorCode;
                    bindVisibles[gridIndex] = 0;
                }
                if (value > this.MaxColorCode)
                {
                    value = this.MaxColorCode;
                    bindVisibles[gridIndex] = 0;
                }

                if (bindVisibles[gridIndex] > 0)
                {
                    if (!(distance <= 0.0f))
                    {
                        textures[gridIndex] = (value - this.MinColorCode) / distance;
                        if (textures[gridIndex] < 0.5f)
                        {
                            textures[gridIndex] = 0.5f - (0.5f - textures[gridIndex]) * 0.99f;
                        }
                        else
                        {
                            textures[gridIndex] = (textures[gridIndex] - 0.5f) * 0.99f + 0.5f;
                        }
                    }
                    else
                    {
                        //最小值最大值相等时，显示最小值的颜色
                        //textures[gridIndex] = 0.01f;
                        textures[gridIndex] = 0.01f;
                    }
                }
            }

            return textures;
        }
    }

    /// <summary>
    /// 描述六面体顶点颜色的U坐标（由于使用色标，色标在纵向的颜色相同，所以不需要V坐标）
    /// <para>U坐标在0.0~1.0之间为正常值，否则为透明色。</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HexahedronTexCoord
    {
        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FLT;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FRT;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BRT;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BLT;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FLB;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FRB;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BRB;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BLB;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        /// <param name="value"></param>
        public void SetCoord(float value)
        {
            FLT = value;
            FRT = value;
            BRT = value;
            BLT = value;
            FLB = value;
            FRB = value;
            BRB = value;
            BLB = value;
        }
    }
}