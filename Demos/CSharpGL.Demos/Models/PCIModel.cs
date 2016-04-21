using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Models
{
    /// <summary>
    /// Position, Color, Index
    /// </summary>
    abstract class PCIModel
    {
        public vec3[] Positions { get; protected set; }
        public vec3[] Colors { get; protected set; }
        public uint[] Indexes { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0} vertexes, {1} indexes", Positions.Length, Indexes.Length);
        }
    }
}
