using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOS6510.Execution;

namespace MOS6510.CPU
{
    public class MOS6510Chip
    { 
        bool isExecuting;
		bool debugging = true;
		public Registers Regs { get; set; }
        public byte[] Ram { get; set; }
        public byte[] RomBasic { get; set; }
        public byte[] RomKernel { get; set; }
        public ushort StackStartAddress = 0x0100;        

        public MOS6510Chip()
        {
            Init();
        }

        public void Init()
        {
			Regs = new Registers();
            Ram = new byte[0xFFFF];
            RomBasic = new byte[0x2000];
            RomKernel = new byte[0x2000];
			Commands.CommandBase.Cpu = this;
        }

        public void Run()
        {
			isExecuting = true;

            while (isExecuting)
            {
				var opcode = (Commands.Opcode)Ram[Regs.PC++];
				isExecuting = ExecutionContext.ApplyStrategy(opcode, debugging);
			}
        }
    }
}
