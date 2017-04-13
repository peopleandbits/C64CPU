using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOS6510.CPU;

namespace MOSTest
{
    [TestClass]
    public class TestJumpFlagComamnds
    {
		MOS6510Chip cpu = new MOS6510Chip();

        [TestMethod]
        public void Test_BIT_Abs()
        {
			cpu.Init();
			cpu.Regs.A = 0x09;
			cpu.Ram[0] = 0x2C; // BIT absolute mode 
			cpu.Ram[1] = 0x00; 
			cpu.Ram[2] = 0x20;
			cpu.Ram[0x2000] = 0xE8;
			cpu.Run();
			Assert.AreEqual(cpu.Regs.SR.N, true);
			Assert.AreEqual(cpu.Regs.SR.V, true);
			Assert.AreEqual(cpu.Regs.SR.Z, false);

			cpu.Init();
			cpu.Regs.A = 0x01;
			cpu.Ram[0] = 0x2C; // BIT absolute mode 
			cpu.Ram[1] = 0x00; 
			cpu.Ram[2] = 0x20;
			cpu.Ram[0x2000] = 0x02; 
			// this should raise z flag
			cpu.Run();
			Assert.AreEqual(cpu.Regs.SR.N, false);
			Assert.AreEqual(cpu.Regs.SR.V, false);
			Assert.AreEqual(cpu.Regs.SR.Z, true);
		}
    }
}
