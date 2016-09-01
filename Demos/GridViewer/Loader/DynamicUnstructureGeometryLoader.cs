using CSharpGL;
using System;
using System.Globalization;
using System.IO;

namespace SimLab.SimGrid.Loader
{
    public class DynamicUnstructureGeometryLoader
    {
        private static readonly string[] delimeters = { "\t", " " };

        public const int ElEMENT_FORMAT3_TRIANGLE = 3;
        public const int ELEMENT_FORMAT4_TETRAHEDRON = 4;
        public const int ELEMENT_FORMAT6_TRIANGULAR_PRISM = 6;

        public const int FRACTURE_FORMAT2_LINE = 2;
        public const int FRACTURE_FORMAT3_TRIANGLE = 3;
        public const int FRACTURE_FORMAT4_QUAD = 4;

        public const int MARKER_FRACTURE = 1;
        public const int MARKER_FAULT = 2;

        public DynamicUnstructuredGridderSource LoadSource(string pathFileName)
        {
            DynamicUnstructuredGridderSource src = new DynamicUnstructuredGridderSource();
            StreamReader reader = Open(pathFileName);
            try
            {
                int lineCounter = 0;
                String headerDescriptor = ReadLine(reader, ref lineCounter);
                if (headerDescriptor == null)
                    throw new FormatException("unexpected end of file");
                if (!headerDescriptor.StartsWith("node"))
                    throw new FormatException("bad format,header descriptor missing");
                String head = ReadLine(reader, ref lineCounter);
                if (String.IsNullOrEmpty(head))
                    throw new FormatException("bad format,header mising");

                string[] heads = head.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                if (heads.Length < 6)
                    throw new FormatException("bad format, head not match");

                int total = src.DimenSize;
                //src.NX = total;//TODO：是否应由此处指定NX？
                int nodeNum, elemNum, elemFormat, fracNum, fracFormat;

                #region read header

                nodeNum = System.Convert.ToInt32(heads[0], CultureInfo.InvariantCulture);
                elemNum = System.Convert.ToInt32(heads[1], CultureInfo.InvariantCulture);
                elemFormat = System.Convert.ToInt32(heads[2], CultureInfo.InvariantCulture);
                fracNum = System.Convert.ToInt32(heads[3], CultureInfo.InvariantCulture);
                fracFormat = System.Convert.ToInt32(heads[4], CultureInfo.InvariantCulture);

                if (elemFormat != ElEMENT_FORMAT3_TRIANGLE && elemFormat != ELEMENT_FORMAT4_TETRAHEDRON && elemFormat != ELEMENT_FORMAT6_TRIANGULAR_PRISM && elemFormat != 0)
                    throw new FormatException("bad format, unknown element format");
                if (fracFormat != FRACTURE_FORMAT2_LINE && fracFormat != FRACTURE_FORMAT3_TRIANGLE && fracFormat != FRACTURE_FORMAT4_QUAD)
                    throw new FormatException("bad format, unknown frac format");

                #endregion read header

                bool gotFirstMin = false; bool gotFirstMax = false;
                vec3 min = new vec3(), max = new vec3();

                #region read nodes

                vec3[] nodes = new vec3[nodeNum];
                for (int i = 0; i < nodeNum; i++)
                {
                    String nodeLine = ReadLine(reader, ref lineCounter);
                    if (nodeLine == null)
                        throw new FormatException("unexpected end of node");

                    String[] fields = nodeLine.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

                    if (fields.Length < 3)
                        throw new FormatException(String.Format("node format error,line:{0}", lineCounter));

                    float x = System.Convert.ToSingle(fields[0], CultureInfo.InvariantCulture);
                    float y = System.Convert.ToSingle(fields[1], CultureInfo.InvariantCulture);
                    float z = System.Convert.ToSingle(fields[2], CultureInfo.InvariantCulture);
                    nodes[i] = new vec3(x, y, z);
                    if (!gotFirstMax)
                    {
                        max = nodes[i];
                        gotFirstMax = true;
                    }
                    else
                    {
                        max = vec3Helper.Max(max, nodes[i]);
                    }
                    if (!gotFirstMin)
                    {
                        min = nodes[i];
                        gotFirstMin = true;
                    }
                    else
                    {
                        min = vec3Helper.Min(min, nodes[i]);
                    }
                }

                #endregion read nodes

                src.Min = min;
                src.Max = max;

                #region read elements

                int[][] elements = new int[elemNum][];
                for (int i = 0; i < elemNum; i++)
                {
                    String elemLine = ReadLine(reader, ref lineCounter);
                    if (elemLine == null)
                        throw new FormatException("unexpected end of element");
                    String[] fields = elemLine.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                    if (fields.Length < elemFormat)
                        throw new FormatException(String.Format("element format error, line:{0}", lineCounter));

                    int[] elemnt = new int[elemFormat];
                    for (int j = 0; j < elemFormat; j++)
                    {
                        elemnt[j] = System.Convert.ToInt32(fields[j]);
                    }
                    elements[i] = elemnt;
                }

                #endregion read elements

                #region read fracture

                int[][] fractures = new int[fracNum][];
                for (int i = 0; i < fracNum; i++)
                {
                    String fracLine = ReadLine(reader, ref lineCounter);
                    if (fracLine == null)
                        throw new FormatException("unexpected end of element");
                    String[] fields = fracLine.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                    if (fields.Length < fracFormat)
                        throw new FormatException(String.Format("element format error, line:{0}", lineCounter));

                    int[] frac = new int[fracFormat];
                    for (int j = 0; j < fracFormat; j++)
                    {
                        frac[j] = System.Convert.ToInt32(fields[j]);
                    }
                    fractures[i] = frac;
                }

                #endregion read fracture

                src.NodeNum = nodeNum;
                src.Nodes = nodes;
                src.ElementFormat = elemFormat;
                src.ElementNum = elemNum;
                src.Elements = elements;
                src.FractureFormat = fracFormat;
                src.FractureNum = fracNum;
                src.Fractures = fractures;
                src.NX = src.ElementNum + src.FractureNum;
                src.NY = 1;
                src.NZ = 1;

                if (src.ElementNum <= 0)
                {
                    src.ElementNum = 0;
                    if (src.ElementFormat == 0)
                        src.ElementFormat = ELEMENT_FORMAT4_TETRAHEDRON;
                }
                if (src.FractureNum <= 0)
                {
                    src.FractureNum = 0;
                    if (src.FractureFormat == 0)
                        src.FractureFormat = FRACTURE_FORMAT3_TRIANGLE;
                }
                return src;
            }
            finally
            {
                reader.Close();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pathFileName"></param>
        /// <param name="nx"></param>
        /// <param name="ny"></param>
        /// <param name="nz"></param>
        /// <returns></returns>
        public DynamicUnstructuredGridderSource LoadSource(string pathFileName, int nx, int ny, int nz)
        {
            DynamicUnstructuredGridderSource src = this.LoadSource(pathFileName);
            if (src.NX != nx || src.NY != ny || src.NZ != nz)
                throw new ArgumentException(String.Format("grid dimens not match"));
            return src;
        }

        private StreamReader Open(String fileName)
        {
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 512 * 1024)));
            return reader;
        }

        private string ReadLine(StreamReader reader, ref int lineCounter)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                lineCounter++;
                line = line.Trim();
                if (String.IsNullOrEmpty(line))
                    continue;
                else
                    break;
            }
            return line;
        }

        private class vec3Helper
        {
            public static vec3 Min(vec3 current, vec3 other)
            {
                var x = Math.Min(current.x, other.x);
                var y = Math.Min(current.y, other.y);
                var z = Math.Min(current.z, other.z);
                return new vec3(x, y, z);
            }

            public static vec3 Max(vec3 current, vec3 other)
            {
                var x = Math.Max(current.x, other.x);
                var y = Math.Max(current.y, other.y);
                var z = Math.Max(current.z, other.z);
                return new vec3(x, y, z);
            }
        }
    }
}