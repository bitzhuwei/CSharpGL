using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.GridSource.Factory
{
    public class HexahedronGridFactory : GridBufferDataFactory
    {

        public override MeshBase CreateMesh(GridderSource source)
        {
            HexahedronGridderSource src = (HexahedronGridderSource)source;

            PositionBuffer positions = new HexahedronPositionBuffer();
            HalfHexahedronIndexBuffer halfHexahedronIndices = new HalfHexahedronIndexBuffer();
            int dimSize = src.DimenSize;
            int I, J, K;
            unsafe
            {
                positions.AllocMem(dimSize);

                var cell = (HexahedronPosition*)positions.Data;
                for (int gridIndex = 0; gridIndex < dimSize; gridIndex++)
                {
                    src.InvertIJK(gridIndex, out I, out J, out K);
                    cell[gridIndex].FLT = src.TranslateMatrix * src.PointFLT(I, J, K);
                    cell[gridIndex].FRT = src.TranslateMatrix * src.PointFRT(I, J, K);
                    cell[gridIndex].BRT = src.TranslateMatrix * src.PointBRT(I, J, K);
                    cell[gridIndex].BLT = src.TranslateMatrix * src.PointBLT(I, J, K);
                    cell[gridIndex].FLB = src.TranslateMatrix * src.PointFLB(I, J, K);
                    cell[gridIndex].FRB = src.TranslateMatrix * src.PointFRB(I, J, K);
                    cell[gridIndex].BRB = src.TranslateMatrix * src.PointBRB(I, J, K);
                    cell[gridIndex].BLB = src.TranslateMatrix * src.PointBLB(I, J, K);
                }

                //网格个数*每个六面体的面数*描述每个六面体的三角形个数
                int halfHexahedronIndexCount = dimSize * 2;
                //int memorySizeInBytes = halfHexahedronIndexCount * sizeof(HalfHexahedronIndex);
                //halfHexahedronIndices.AllocMem(memorySizeInBytes);
                halfHexahedronIndices.AllocMem(halfHexahedronIndexCount);

                HalfHexahedronIndex* array = (HalfHexahedronIndex*)halfHexahedronIndices.Data;
                for (int gridIndex = 0; gridIndex < dimSize; gridIndex++)
                {
                    array[gridIndex * 2].dot0 = (uint)(8 * gridIndex + 6);
                    array[gridIndex * 2].dot1 = (uint)(8 * gridIndex + 2);
                    array[gridIndex * 2].dot2 = (uint)(8 * gridIndex + 7);
                    array[gridIndex * 2].dot3 = (uint)(8 * gridIndex + 3);
                    array[gridIndex * 2].dot4 = (uint)(8 * gridIndex + 4);
                    array[gridIndex * 2].dot5 = (uint)(8 * gridIndex + 0);
                    array[gridIndex * 2].dot6 = (uint)(8 * gridIndex + 5);
                    array[gridIndex * 2].dot7 = (uint)(8 * gridIndex + 1);
                    array[gridIndex * 2].restartIndex = uint.MaxValue;

                    array[gridIndex * 2 + 1].dot0 = (uint)(8 * gridIndex + 3);
                    array[gridIndex * 2 + 1].dot1 = (uint)(8 * gridIndex + 0);
                    array[gridIndex * 2 + 1].dot2 = (uint)(8 * gridIndex + 2);
                    array[gridIndex * 2 + 1].dot3 = (uint)(8 * gridIndex + 1);
                    array[gridIndex * 2 + 1].dot4 = (uint)(8 * gridIndex + 6);
                    array[gridIndex * 2 + 1].dot5 = (uint)(8 * gridIndex + 5);
                    array[gridIndex * 2 + 1].dot6 = (uint)(8 * gridIndex + 7);
                    array[gridIndex * 2 + 1].dot7 = (uint)(8 * gridIndex + 4);
                    array[gridIndex * 2 + 1].restartIndex = uint.MaxValue;
                }

                HexahedronMeshGeometry3D mesh = new HexahedronMeshGeometry3D(positions, halfHexahedronIndices);
                mesh.Max = source.TransformedActiveBounds.Min;
                mesh.Min = source.TransformedActiveBounds.Max;
                return mesh;
            }
        }

        public override TexCoordBuffer CreateTextureCoordinates(GridderSource source, int[] gridIndexes, float[] values, float minValue, float maxValue)
        {
            HexahedronGridderSource src = (HexahedronGridderSource)source;
            int[] resultsVisibles = src.ExpandVisibles(gridIndexes);
            int[] bindVisibles = src.BindCellActive(src.BindVisibles, resultsVisibles);

            int dimenSize = src.DimenSize;
            float[] textures = src.GetInvisibleTextureCoords();
            float distance = Math.Abs(maxValue - minValue);
            for (int i = 0; i < gridIndexes.Length; i++)
            {
                int gridIndex = gridIndexes[i];
                float value = values[i];
                if (value < minValue){
                   value = minValue;
                   bindVisibles[gridIndex] = 0;
                }
                if (value > maxValue){
                   value = maxValue;
                   bindVisibles[gridIndex] = 0;
                }
                
                if (bindVisibles[gridIndex] > 0)
                {
                    if (!(distance <= 0.0f))
                    {
                        textures[gridIndex] = (value - minValue) / distance;
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

            HexahedronTexCoordBuffer coordBuffer = new HexahedronTexCoordBuffer();
            unsafe
            {
                int gridCellCount = src.DimenSize;
                coordBuffer.AllocMem(gridCellCount);
                HexahedronTexCoord* coords = (HexahedronTexCoord*)coordBuffer.Data;
                for (int gridIndex = 0; gridIndex < dimenSize; gridIndex++)
                {
                    coords[gridIndex].SetCoord(textures[gridIndex]);
                }
            }
            return coordBuffer;
        }
    }
}
