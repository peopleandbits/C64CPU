using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOS6510.Execution;

namespace MOS6510.CPU
{
	public class Registers
	{
		public byte StackPtr { get; set; }
		public UInt16 PC {get; set;} // program counter 
		public StatusRegister SR { get; set; }
        private byte a;

        /// <summary>
        /// Accumulator handles setting SR flags: Z, N and V.
        /// </summary>
        public byte A
        {
            get { return a; }
            set
            {
                uint t = value; 
                if(t == 0)
                    SR.Z = true;
                else if (t < 0)
                    SR.N = true;
                else if (t > 255)
                    SR.V = true;
                a = (byte)t;
            }
        }
		public byte X { get; set; }
		public byte Y { get; set; }

		public Registers ()
		{
			SR = new StatusRegister();
			StackPtr = 0xFF;
			PC = 0x00;
		}

		public override string ToString ()
		{
			return string.Format("A:{0}  X:{1}  Y:{2}  PC:{3}", A.ToString("X2"), X.ToString("X2"), Y.ToString("X2"), PC.ToString("X4")); 
		}
	}
}
