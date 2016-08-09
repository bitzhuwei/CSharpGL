using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TracyEnergy.Simba.Data;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    class HexahedronGridWellPipelineBuilder : WellPipelineBuilder
    {
        private CatesianGrid grid;

        public HexahedronGridWellPipelineBuilder(CatesianGrid grid)
        {
            // TODO: Complete member initialization
            this.grid = grid;
        }

        protected override NamedWellRenderer Convert(TracyEnergy.Simba.Data.Keywords.impl.WellSpecs wellspec, TracyEnergy.Simba.Data.Keywords.impl.WellCompatCollection wellCompatList)
        {
            int locI = wellspec.Li;
            int locJ = wellspec.Lj;

            //if compat has position ,use compat
            List<WellCompat> segments = null;
            if (wellCompatList != null)
                segments = wellCompatList.GetWellSegments(wellspec.WellName);
            if (segments != null && segments.Count > 0)
            {
                locI = segments[0].PosI;
                locJ = segments[0].PosJ;
            }

            if (!this.grid.DataSource.IsSliceBlock(locI, locJ))
            {
                return null;
            }

            vec3 h1 = this.grid.DataSource.PointFLT(locI, locJ, 1);
            vec3 h2 = this.grid.DataSource.PointBRT(locI, locJ, 1);
            vec3 d0 = h2 - h1;
            float L = (float)d0.length();
            d0 = d0.normalize();
            vec3 vec = d0 * (L * 0.5f);
            vec3 comp1 = CenterOfLine(h1, h2); ; //地层完井段的起始点

            //vec3 minCord = this.grid.FlipTransform * this.grid.SourceActiveBounds.Min;
            vec3 minCord = this.grid.DataSource.SourceActiveBounds.Min;
            vec3 maxCord = this.grid.DataSource.SourceActiveBounds.Max;
            Rectangle3D rectSrc = new Rectangle3D(minCord, maxCord);
            vec3 modelTop = new vec3(comp1.x, comp1.y, rectSrc.Max.z);

            float mdx = rectSrc.SizeX;
            float mdy = rectSrc.SizeY;
            float mdz = rectSrc.SizeZ;

            float xyextend = System.Math.Max(mdx, mdy); //XY平面的最大边长
            float extHeight; //延长线段
            if (mdz < 0.1f * xyextend) //z很小
            {
                extHeight = 0.1f * xyextend;
            }
            else if (mdz < 0.2f * xyextend)
            {
                extHeight = mdz * 0.5f;
            }
            else if (mdz < 0.3f * xyextend)
            {
                extHeight = mdz * 0.25f;
            }
            else if (mdz < 0.4f * xyextend)
            {
                extHeight = mdz * 0.2f;
            }
            else
            {
                extHeight = 0.2f * mdz;
            }

            //地表坐标

            vec3 direction = new vec3(0, 0, 1.0f);
            vec3 head = modelTop + direction * extHeight;

            //确定井的半径
            float wellRadius;
            #region decide the well radius
            if (mdx < mdy)
            {
                if (mdy * 0.5f >= mdx) //长方形的模型
                {
                    int n = this.grid.DataSource.NX;
                    if (n >= 10)
                    {
                        wellRadius = (mdx / n) * 0.5f;
                    }
                    else
                    {
                        wellRadius = (mdx / n) * 0.35f;
                    }

                }
                else
                {
                    int n = this.grid.DataSource.NX;
                    if (n >= 10)
                    {
                        n = 10;
                        wellRadius = (mdx / n) * 0.5f;
                    }
                    else
                    {
                        wellRadius = (mdx / n) * 0.35f;
                    }
                }
            }
            else if (mdx == mdy)
            {
                int n = Math.Min(this.grid.DataSource.NX, this.grid.DataSource.NY);
                if (n >= 10)
                {
                    n = 10;
                    wellRadius = (mdx / n) * 0.85f;
                }
                else
                {
                    wellRadius = (mdx / n) * 0.5f;
                }
            }
            else
            {

                if (mdx * 0.5f >= mdy)
                {
                    int n = this.grid.DataSource.NY;
                    if (n > 10)
                    {
                        n = 10;
                        wellRadius = (mdy / n) * 0.5f;
                    }
                    else
                    {
                        wellRadius = (mdy / n) * 0.35f;
                    }

                }
                else
                {

                    int n = this.grid.DataSource.NY;
                    if (n > 10)
                    {
                        n = 10;
                        wellRadius = (mdx / n) * 0.5f;
                    }
                    else
                    {
                        wellRadius = (mdx / n) * 0.35f;
                    }
                }

            }
            #endregion

            Fluid fluid = FluidConverter.Convert(wellspec.Fluid);
            Color pipeColor = MapFluidToColor(fluid);
            Color textColor = Color.White;

            List<vec3> wellPath = new List<vec3>();
            wellPath.Add(head);
            wellPath.Add(modelTop);

            #region start decide the trajery of the well
            {
                int lastI = locI;
                int lastJ = locJ;
                int lastK = -1;
                vec3 lastvec3 = comp1;
                int segCount = segments.Count;
                for (int i = 0; i < segCount; i++)
                {
                    WellCompat compseg = segments[i];
                    int compI = compseg.PosI;
                    int compJ = compseg.PosJ;
                    int compK1 = compseg.K1;
                    int compK2 = compseg.K2;
                    if (compK1 == compK2)//同一网格上
                    {
                        if ((lastI != compI) || (lastJ != compJ) || (lastK != compK1))
                        {
                            vec3 s1 = this.grid.DataSource.PointFLT(compI, compJ, compK1);
                            vec3 s2 = this.grid.DataSource.PointBRT(compI, compJ, compK1);
                            vec3 point = CenterOfLine(s1, s2);
                            wellPath.Add(point);
                            lastI = compI;
                            lastJ = compJ;
                            lastK = compK1;
                        }
                    }
                    else //compK1 != compK2
                    {
                        //k1 coord
                        if ((lastI != compI) || (lastJ != compJ) || (lastK != compK1))
                        {
                            vec3 s1 = this.grid.DataSource.PointFLT(compI, compJ, compK1);
                            vec3 s2 = this.grid.DataSource.PointBRT(compI, compJ, compK1);
                            vec3 point = CenterOfLine(s1, s2);
                            wellPath.Add(point);
                        }
                        lastI = compI;
                        lastJ = compJ;
                        lastK = compK1;

                        if ((lastI != compI) || (lastJ != compJ) || (lastK != compK2))
                        {
                            vec3 s1 = this.grid.DataSource.PointFLT(compI, compJ, compK2);
                            vec3 s2 = this.grid.DataSource.PointBRT(compI, compJ, compK2);
                            vec3 point = CenterOfLine(s1, s2);
                            wellPath.Add(point);
                        }
                        lastI = compI;
                        lastJ = compJ;
                        lastK = compK2;
                    }
                }//end for

                var model = new WellModel(wellPath, wellRadius);
                NamedWellRenderer renderer = NamedWellRenderer.Create(model, pipeColor, wellspec.WellName, 12);
                return renderer;
            }
            #endregion
        }

        private Color MapFluidToColor(Fluid fluid)
        {
            Color color;
            if (fluid == Fluid.OIL)
            {
                color = Color.Green;
            }
            else if (fluid == Fluid.WATER)
            {
                color = Color.Blue;
            }
            else if (fluid == Fluid.GAS)
            {
                color = Color.Red;
            }
            else
            {
                //默认按油井处理
                color = Color.FromArgb(255, 255, 127, 0);
            }

            return color;
        }

        /// <summary>
        /// 三维空间上a,b点的中点
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private vec3 CenterOfLine(vec3 a, vec3 b)
        {
            return (a * 0.5f + b * 0.5f);
        }


    }
}
