using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOS6510.CPU
{
    public enum SRFlags { C = 0, Z, I, D, B, minus, V, N }

    public abstract class StatusRegisterBase
    {
        const string flagStr = "NV-BDIZC"; // C is the zeroth bit
        char[] flags;
        public byte Value { get; set; }

        public bool GetFlag(SRFlags f)
        {
            return Helpers.BitMath.TestBit(Value, (byte)f);
        }

        public void SetFlag(SRFlags f, bool val)
        {
			Value = val ? Helpers.BitMath.SetBit(Value, (byte)f) : Helpers.BitMath.ClearBit(Value, (byte)f);
        }

        public StatusRegisterBase()
        {
            flags = flagStr.ToCharArray();
        }
    }
}
