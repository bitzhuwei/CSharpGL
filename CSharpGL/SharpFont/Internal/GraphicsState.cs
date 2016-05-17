using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace SharpFont
{
    public struct GraphicsState
    {
        public Vector2 Freedom;
        public Vector2 DualProjection;
        public Vector2 Projection;
        public InstructionControlFlags InstructionControl;
        public RoundMode RoundState;
        public float MinDistance;
        public float ControlValueCutIn;
        public float SingleWidthCutIn;
        public float SingleWidthValue;
        public int DeltaBase;
        public int DeltaShift;
        public int Loop;
        public int Rp0;
        public int Rp1;
        public int Rp2;
        public bool AutoFlip;

        public void Reset()
        {
            ValueType v;
            Freedom = Vector2.UnitX;
            Projection = Vector2.UnitX;
            DualProjection = Vector2.UnitX;
            InstructionControl = InstructionControlFlags.None;
            RoundState = RoundMode.ToGrid;
            MinDistance = 1.0f;
            ControlValueCutIn = 17.0f / 16.0f;
            SingleWidthCutIn = 0.0f;
            SingleWidthValue = 0.0f;
            DeltaBase = 9;
            DeltaShift = 3;
            Loop = 1;
            Rp0 = Rp1 = Rp2 = 0;
            AutoFlip = true;
        }
    }
}
