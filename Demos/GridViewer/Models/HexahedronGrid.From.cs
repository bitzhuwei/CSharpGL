using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracyEnergy.Simba.Data.Keywords;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class HexahedronGrid
    {
        public static HexahedronGrid From(SimulationInputData inputData)
        {
            GridDimens dimens = inputData.RootDataFile.GetDIMENS();
            float[] dx = inputData.RootDataFile.GetDX();
            float[] dy = inputData.RootDataFile.GetDY();
            float[] dz = inputData.RootDataFile.GetDZ();
            if (dimens == null)
                throw new ArgumentException("Missing DIMENS or SPECGRID");
            if (dx == null)
                throw new ArgumentException("Missing DX or related description");
            if (dy == null)
                throw new ArgumentException("Missing DY or related description");
            if (dy == null)
                throw new ArgumentException("Missing DZ or related description");
            CatesianGridderSource cgs = new CatesianGridderSource();
            cgs.NX = dimens.NI;
            cgs.NY = dimens.NJ;
            cgs.NZ = dimens.NK;
            cgs.DX = dx;
            cgs.DY = dy;
            cgs.DZ = dz;
            cgs.TOPS = inputData.RootDataFile.GetTOPS();
            cgs.ActiveBlocks = inputData.RootDataFile.GetACTNUM();
            cgs.IBlocks = SimLab.ArrayHelper.CreateAllSlices(dimens.NI);
            cgs.JBlocks = SimLab.ArrayHelper.CreateAllSlices(dimens.NJ);
            cgs.KBlocks = SimLab.ArrayHelper.CreateAllSlices(dimens.NK);
            cgs.Init();
            //return cgs;
            throw new NotImplementedException();
        }
    }
}
