using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fuluDD01_LayeredEngraving.PNG {
    public interface IVolumeData {
        int Width { get; }

        int Height { get; }

        int Depth { get; }

        byte[] VolumeData { get; }

    }
}
