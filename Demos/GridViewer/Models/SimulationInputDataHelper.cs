using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TracyEnergy.Simba.Data.Keywords;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public static class SimulationInputDataHelper
    {
        public static CatesianGrid DumpCatesianGrid(this SimulationInputData inputData,
            float minColorCode, float maxColorCode)
        {
            GridDimens dimens = inputData.RootDataFile.GetDIMENS();
            if (dimens == null)
            { throw new ArgumentException("Missing DIMENS or SPECGRID"); }
            float[] dx = inputData.RootDataFile.GetDX();
            if (dx == null)
            { throw new ArgumentException("Missing DX or related description"); }
            float[] dy = inputData.RootDataFile.GetDY();
            if (dy == null)
            { throw new ArgumentException("Missing DY or related description"); }
            float[] dz = inputData.RootDataFile.GetDZ();
            if (dy == null)
            { throw new ArgumentException("Missing DZ or related description"); }

            var dataSource = new CatesianGridderSource();
            dataSource.NX = dimens.NI;
            dataSource.NY = dimens.NJ;
            dataSource.NZ = dimens.NK;
            dataSource.DX = dx;
            dataSource.DY = dy;
            dataSource.DZ = dz;
            dataSource.TOPS = inputData.RootDataFile.GetTOPS();
            dataSource.ActiveBlocks = inputData.RootDataFile.GetACTNUM();
            dataSource.IBlocks = SimLab.ArrayHelper.CreateAllSlices(dimens.NI);
            dataSource.JBlocks = SimLab.ArrayHelper.CreateAllSlices(dimens.NJ);
            dataSource.KBlocks = SimLab.ArrayHelper.CreateAllSlices(dimens.NK);
            dataSource.Init();
            List<GridBlockProperty> gridProps = inputData.RootDataFile.GetGridProperties();
            var grid = new CatesianGrid(dataSource, gridProps, minColorCode, maxColorCode);

            return grid;
        }
    }
}
