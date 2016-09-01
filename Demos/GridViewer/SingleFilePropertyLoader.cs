using System;
using System.Globalization;
using System.IO;

using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public class SingleFilePropertyLoader
    {
        public string[] delemeters = new string[]{
          " ","\t","\r","\n"
       };

        public GridBlockProperty Load(string fileName, GridDimens dimens)
        {
            StreamReader reader = new StreamReader(fileName);
            try
            {
                String data = reader.ReadToEnd();
                String[] strValues = data.Split(delemeters, StringSplitOptions.RemoveEmptyEntries);
                float[] values = new float[strValues.Length];
                int[] gridIndexes = new int[strValues.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    gridIndexes[i] = i;
                    values[i] = Convert.ToSingle(strValues[i], CultureInfo.InvariantCulture);
                }
                String name = System.IO.Path.GetFileName(fileName);
                GridBlockProperty gbp = new GridBlockProperty(name, dimens, gridIndexes, values);
                return gbp;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}