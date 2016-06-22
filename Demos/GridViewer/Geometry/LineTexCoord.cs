using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace SimLab.SimGrid.Geometry
{

    [StructLayout(LayoutKind.Sequential)]
    public struct LineTexCoord
    {
       public  float P1;
       public  float P2;

       public void SetTextureCoord(float value)
       {
           this.P1 = value;
           this.P2 = value;
       }
    }
}
