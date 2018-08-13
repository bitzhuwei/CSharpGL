using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fuluDD02_LayeredEngraving.ComputeShader
{
    public interface IVolumeData
    {
        int Width { get; }

        int Height { get; }

        int Depth { get; }

        byte[] VolumeData { get; }

    }
}
