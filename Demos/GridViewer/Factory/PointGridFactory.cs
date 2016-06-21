using CSharpGL;
using SharpGL.SceneGraph;
using SimLab.SimGrid;
using SimLab.SimGrid.Geometry;
using SimLab.vec3Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.GridSource.Factory
{
    public class PointGridFactory : GridBufferDataFactory
    {

        public override MeshBase CreateMesh(GridderSource source)
        {
            PointGridderSource src = (PointGridderSource)source;
            vec3 minvec3 = new vec3();
            vec3 maxvec3 = new vec3();
            bool isSet = false;
            PointPositionBuffer positions = new PointPositionBuffer();
            PointRadiusBuffer radiusBuffer = null;
            int dimSize = src.DimenSize;
            Random random = new Random();
            // setup positions
            unsafe
            {
                positions.AllocMem(dimSize);
                var cells = (vec3*)positions.Data;
                for (int gridIndex = 0; gridIndex < dimSize; gridIndex++)
                {
                    vec3 p = src.TranslateMatrix * src.Positions[gridIndex];
                    cells[gridIndex] = p;
                }
            }
            radiusBuffer = this.CreateRadiusBufferData(src, src.Radius);
            PointMeshGeometry3D mesh = new PointMeshGeometry3D(positions, radiusBuffer, dimSize);
            mesh.Max = src.TransformedActiveBounds.Max;
            mesh.Min = src.TransformedActiveBounds.Min;
            return mesh;
        }

        public PointRadiusBuffer CreateRadiusBufferData(PointGridderSource src, float[] radius)
        {
            PointRadiusBuffer radiusBuffer = new PointRadiusBuffer();
            unsafe
            {
                int dimenSize = src.DimenSize;
                radiusBuffer.AllocMem(dimenSize);
                float* radiues = (float*)radiusBuffer.Data;
                for (int gridIndex = 0; gridIndex < dimenSize; gridIndex++)
                {
                    radiues[gridIndex] = radius[gridIndex];
                }
            }
            return radiusBuffer;
        }

        public PointRadiusBuffer CreateRadiusBufferData(PointGridderSource src, float radius)
        {
            PointRadiusBuffer radiusBuffer = new PointRadiusBuffer();
            unsafe
            {
                int dimenSize = src.DimenSize;
                radiusBuffer.AllocMem(dimenSize);
                float* radiues = (float*)radiusBuffer.Data;
                for (int gridIndex = 0; gridIndex < dimenSize; gridIndex++)
                {
                    radiues[gridIndex] = radius;
                }
            }
            return radiusBuffer;
        }

        public override TexCoordBuffer CreateTextureCoordinates(GridderSource source, int[] gridIndexes, float[] values, float minValue, float maxValue)
        {
            PointGridderSource src = (PointGridderSource)source;
            int[] visibles = src.BindResultsVisibles(gridIndexes);
            int dimenSize = src.DimenSize;
            float[] textures = src.GetInvisibleTextureCoords();
            float distance = Math.Abs(maxValue - minValue);
            for (int i = 0; i < gridIndexes.Length; i++)
            {
                int gridIndex = gridIndexes[i];
                if (visibles[gridIndex] > 0)
                {
                    float value = values[i];
                    if (value < minValue)
                        value = minValue;
                    if (value > maxValue)
                        value = maxValue;

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
                        textures[gridIndex] = 0.01f;
                        //textures[gridIndex] = 0;
                    }
                }
            }

            PointTexCoordBuffer coordBuffer = new PointTexCoordBuffer();
            unsafe
            {
                coordBuffer.AllocMem(src.DimenSize);
                float* coords = (float*)coordBuffer.Data;
                for (int gridIndex = 0; gridIndex < dimenSize; gridIndex++)
                {
                    coords[gridIndex] = textures[gridIndex];
                }
            }
            return coordBuffer;
        }

    }
}
