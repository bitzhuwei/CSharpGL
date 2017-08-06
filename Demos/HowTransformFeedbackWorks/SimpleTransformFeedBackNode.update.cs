using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    partial class SimpleTransformFeedBackNode
    {
        private const string updateVert = @"
    #version 150 core

    in float inValue;
    out float geoValue;

    void main()
    {
        geoValue = sqrt(inValue);
    }
";
    }
}
