using CSharpGL;
using SimLab.SimGrid;

namespace SimLab.GridSource
{
    /// <summary>
    /// 正交网格数据源
    /// </summary>
    public class CatesianGridderSource : HexahedronGridderSource
    {
        /// <summary>
        /// X(I)方向上的网格宽度
        /// </summary>
        public float[] DX { get; internal set; }

        /// <summary>
        /// Y(J)方向上的网格宽度
        /// </summary>
        public float[] DY { get; internal set; }

        /// <summary>
        /// Z(K)方向上的网格宽度
        /// </summary>
        public float[] DZ { get; internal set; }

        public float[] TOPS { get; internal set; }

        /// <summary>
        /// 数组大小为 (nx+1)*(ny+1)*(nz+1);
        /// </summary>
        private float[] xcoords;

        /// <summary>
        ///  数组大小为 (nx+1)*(ny+1)*(nz+1);
        /// </summary>
        private float[] ycoords;

        private float[] zcoords;

        private GridIndexer coordIndexer;

        /// <summary>
        /// 网格起始原点X坐标
        /// </summary>
        public float OX { get; internal set; }

        /// <summary>
        /// 网格起始原点Y坐标
        /// </summary>
        public float OY { get; internal set; }

        /// <summary>
        /// 网格起始原点Z坐标
        /// </summary>
        public float OZ { get; internal set; }

        /// <summary>
        /// 前左上角坐标
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public override vec3 PointFLT(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i, j, k);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        public override vec3 PointFRT(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i + 1, j, k);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        public override vec3 PointFLB(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i, j, k + 1);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        public override vec3 PointFRB(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i + 1, j, k + 1);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        public override vec3 PointBLT(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i, j + 1, k);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        public override vec3 PointBRT(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i + 1, j + 1, k);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        public override vec3 PointBLB(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i, j + 1, k + 1);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        public override vec3 PointBRB(int i, int j, int k)
        {
            vec3 p = new vec3();
            int gridIndex = this.coordIndexer.IndexOf(i + 1, j + 1, k + 1);
            p.x = this.xcoords[gridIndex];
            p.y = this.ycoords[gridIndex];
            p.z = this.zcoords[gridIndex];
            return p;
        }

        /// <summary>
        /// 初始化网格坐标
        /// </summary>
        protected override void InitGridCoordinates()
        {
            if (this.TOPS == null)
            {
                this.TOPS = ArrayHelper.NewFloatArray(this.DimenSize, 0);
            }
            //xcoords;
            int coordSize = (this.NX + 1) * (this.NY + 1) * (this.NZ + 1);
            float[] coordX = new float[coordSize];
            float[] coordY = new float[coordSize];
            float[] coordZ = new float[coordSize];

            float[] srcDX = this.DX;
            float[] srcDY = this.DY;
            float[] srcDZ = this.DZ;
            float[] tops = this.TOPS;

            int cnx = this.NX + 1;
            int cny = this.NY + 1;
            int cnz = this.NZ + 1;

            int dnx = this.NX;
            int dny = this.NY;
            int dnz = this.NZ;

            GridIndexer coordIndexer = new GridIndexer(cnx, cny, cnz);
            //dx, dy,dx 描述
            GridIndexer dIndexer = new GridIndexer(this.NX, this.NY, this.NZ);

            int coordIndex;
            int prevcIndex;
            int di, dj, dk, xGridIndex, yGridIndex, zGridIndex;
            for (int kcz = 1; kcz <= cnz; kcz++)
            {
                for (int jcy = 1; jcy <= cny; jcy++)
                {
                    for (int icx = 1; icx <= cnx; icx++)
                    {
                        coordIndex = coordIndexer.IndexOf(icx, jcy, kcz);

                        //处理x坐标
                        if (icx == 1)
                        {
                            coordX[coordIndex] = this.OX;
                        }
                        else
                        {
                            prevcIndex = coordIndexer.IndexOf(icx - 1, jcy, kcz);
                            //距离坐标
                            di = icx - 1;
                            dj = jcy > dny ? jcy - 1 : jcy;
                            dk = kcz > dnz ? kcz - 1 : kcz;
                            xGridIndex = dIndexer.IndexOf(di, dj, dk);
                            coordX[coordIndex] = coordX[prevcIndex] + srcDX[xGridIndex];
                        }

                        //计算(icx,jcy,kcz)网格的坐标
                        if (jcy == 1)
                        {
                            coordY[coordIndex] = this.OY;
                        }
                        else
                        {
                            prevcIndex = coordIndexer.IndexOf(icx, jcy - 1, kcz);
                            di = icx > dnx ? icx - 1 : icx;
                            dj = jcy - 1;
                            dk = kcz > dnz ? kcz - 1 : kcz;
                            yGridIndex = dIndexer.IndexOf(di, dj, dk);
                            coordY[coordIndex] = coordY[prevcIndex] + srcDY[yGridIndex];
                        }

                        if (kcz == 1)
                        {
                            int celli = icx > this.NX ? this.NX : icx;
                            int cellj = jcy > this.NY ? this.NY : jcy;
                            int cellk = kcz > this.NZ ? this.NZ : kcz;
                            int cellIndex = dIndexer.IndexOf(celli, cellj, cellk);
                            float topz = tops[cellIndex];
                            coordZ[coordIndex] = this.OZ + topz;
                        }
                        else
                        {
                            prevcIndex = coordIndexer.IndexOf(icx, jcy, kcz - 1);
                            di = icx > dnx ? dnx : icx;
                            dj = jcy > dny ? dny : jcy;
                            dk = kcz - 1;
                            zGridIndex = dIndexer.IndexOf(di, dj, dk);
                            coordZ[coordIndex] = coordZ[prevcIndex] + srcDZ[zGridIndex];
                        }
                    }
                }
            }
            this.xcoords = coordX;
            this.ycoords = coordY;
            this.zcoords = coordZ;
            this.coordIndexer = coordIndexer;
        }
    }
}