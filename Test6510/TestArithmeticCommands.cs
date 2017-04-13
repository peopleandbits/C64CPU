using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOS6510.CPU;
using MOS6510.Commands;

namespace MOSTest
{
    [TestClass]
    public class TestArithmeticCommands
    {
		MOS6510Chip cpu = new MOS6510Chip();

        [TestMethod]
        public void Test_ORA_Izx()
        {
			cpu.Init();
			cpu.Regs.A = 0x02;
			cpu.Regs.X = 0x01;
			cpu.Ram[0] = (byte)Opcode.ORA_IZX; // ORA ($80, X) 
			cpu.Ram[1] = 0x80; // becomes $81
			cpu.Ram[0x81] = 0x00;
			cpu.Ram[0x82] = 0xC0;
			cpu.Ram[0xC000] = 0x50;
			cpu.Run();
			Assert.AreEqual(cpu.Regs.A, 0x52);
		}

        [TestMethod]
        public void Test_Ora_Imm()
        {
			cpu.Init();
			cpu.Regs.A = 0x02;
			cpu.Ram[0] = (byte)Opcode.ORA_IMM; // ORA #$1
            cpu.Ram[1] = 0x01; 
            cpu.Run();
			Assert.AreEqual(cpu.Regs.A, 0x3);
        }

        [TestMethod]
        public void Test_Adc_Zp()
        {
            cpu.Init();
            cpu.Regs.A = 0x05;
            cpu.Ram[0] = (byte)Opcode.ADC_ZP; 
            cpu.Ram[1] = 0x05;
            cpu.Ram[5] = 0x01;
            cpu.Run();
            Assert.AreEqual(cpu.Regs.A, 0x6);
        }
    }
}
