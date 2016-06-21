using CSharpGL;
using SimLab.GridSource;
using SimLab.SimGrid.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public partial class CatesianGrid
    {
        public const string strColor = "color";
        private PropertyBufferPtr colorBufferPtr;

        private PropertyBufferPtr GetColorBufferPtr(string varNameInShader)
        {
            PropertyBufferPtr ptr = null;
            using (var buffer = new PropertyBuffer<HexahedronTexCoord>(varNameInShader, 1, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
            {
                var gridIndexes = this.gridProps[this.defaultBlockPropertyIndex].Positions;
                int[] resultsVisibles = this.dataSource.ExpandVisibles(gridIndexes);
                int[] bindVisibles = this.dataSource.BindCellActive(this.dataSource.BindVisibles, resultsVisibles);

                int dimenSize = this.dataSource.DimenSize;
                float[] textures = this.dataSource.GetInvisibleTextureCoords();
                float distance = Math.Abs(this.MaxColorCode - this.MinColorCode);
                float[] values = this.gridProps[this.defaultBlockPropertyIndex].Values;
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

                int gridCellCount = dimenSize;
                buffer.Alloc(gridCellCount);
                unsafe
                {
                    var array = (HexahedronTexCoord*)buffer.Header.ToPointer();
                    for (int gridIndex = 0; gridIndex < dimenSize; gridIndex++)
                    {
                        array[gridIndex].SetCoord(textures[gridIndex]);
                    }
                }
                ptr = buffer.GetBufferPtr() as PropertyBufferPtr;
            }

            return ptr;
        }

    }
}
