using CSharpGL;
using SimLab.GridSource;
using SimLab.SimGrid.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.SimGrid.Loader
{
    public class PointSetLoader
    {
        public PointGridderSource LoadFromFile(string pathFileName, int nx, int ny, int nz)
        {
            StreamReader reader = new StreamReader(new FileStream(pathFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            try
            {
                return DoLoadPointSet(reader, nx, ny, nz);
            }
            finally
            {
                reader.Close();
            }
        }

        public PointGridderSource LoadFromFile(string pathFileName)
        {
            StreamReader reader = new StreamReader(new FileStream(pathFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            try
            {
                return DoLoadPointSet(reader);
            }
            finally
            {
                reader.Close();
            }
        }

        protected static PointGridderSource DoLoadPointSet(StreamReader reader)
        {
            PointGridderSource ps = new PointGridderSource();
            vec3 minValue = new vec3();
            vec3 maxValue = new vec3();
            char[] delimeters = new char[] { ' ', '\t' };
            string line;
            List<vec3> positions = new List<vec3>();

            int positionCount = 0;
            bool isSet = false;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (String.IsNullOrEmpty(line))
                    continue;
                string[] fields = line.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length >= 3)
                {
                    float x = System.Convert.ToSingle(fields[0]);
                    float y = System.Convert.ToSingle(fields[1]);
                    float z = Math.Abs(System.Convert.ToSingle(fields[2])); //全部Z按深度来处理，

                    vec3 pt = new vec3(x, y, z);
                    if (!isSet)
                    {
                        minValue = pt;
                        maxValue = pt;
                        isSet = true;
                    }
                    minValue = vec3Helper.Minvec3(minValue, pt);
                    maxValue = vec3Helper.Maxvec3(maxValue, pt);

                    positions.Add(pt);
                    positionCount++;
                }
            }

            ps.Max = maxValue;
            ps.Min = minValue;
            ps.Positions = positions.ToArray<vec3>();
            ps.NX = ps.Positions.Length;
            ps.NY = 1;
            ps.NZ = 1;
            if (positions.Count <= 0)
                return null;
            return ps;
        }

        protected static PointGridderSource DoLoadPointSet(StreamReader reader, int nx, int ny, int nz)
        {
            int dimenSize = nx * ny * nz;
            PointGridderSource ps = new PointGridderSource();
            ps.NX = nx;
            ps.NY = ny;
            ps.NZ = nz;
            vec3 minValue = new vec3();
            vec3 maxValue = new vec3();
            char[] delimeters = new char[] { ' ', '\t' };
            string line;
            vec3[] positions = new vec3[dimenSize];
            int positionCount = 0;
            bool isSet = false;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (String.IsNullOrEmpty(line))
                    continue;
                string[] fields = line.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length >= 3)
                {
                    float x = System.Convert.ToSingle(fields[0]);
                    float y = System.Convert.ToSingle(fields[1]);
                    float z = Math.Abs(System.Convert.ToSingle(fields[2])); //全部Z按深度来处理，

                    vec3 pt = new vec3(x, y, z);
                    if (!isSet)
                    {
                        minValue = pt;
                        maxValue = pt;
                        isSet = true;
                    }
                    minValue = vec3Helper.Minvec3(minValue, pt);
                    maxValue = vec3Helper.Maxvec3(maxValue, pt);

                    positions[positionCount] = pt;
                    positionCount++;
                    if (positionCount == dimenSize)
                        break;
                }
            }
            if (positionCount != dimenSize)
                throw new ArgumentException(String.Format("file format error,points number:{0} not equals DIMENS", positionCount, dimenSize));
            ps.Max = maxValue;
            ps.Min = minValue;
            ps.Positions = positions;
            return ps;
        }
    }
}
