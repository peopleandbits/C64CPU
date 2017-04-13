using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOS6510.Helpers
{
    static class BitMath
    {
        public static bool TestBit(byte val, byte bitIndex)
        {
            byte mask = (byte)(1 << bitIndex);
            return (val & mask) > 0;
        }

        public static byte ClearBit(byte val, byte bitIndex)
        {
            byte mask = (byte)(1 << bitIndex);
            val &= (byte)~mask;
            return val;
        }

        public static byte SetBit(byte val, byte bitIndex)
        {
            byte mask = (byte)(1 << bitIndex);
            val |= mask;
            return val;
        }
    }
}
