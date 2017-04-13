using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOS6510.CPU;

namespace MOSTest
{
    [TestClass]
    public class TestStatusRegister
    {
        MOS6510Chip cpu = new MOS6510Chip();
        
		[TestMethod]
        public void Test_SR_B_WriteRead()
        {
            byte origSR = Convert.ToByte("11110000", 2);
            byte targetSR = Convert.ToByte("11100000", 2);
			cpu.Regs.SR.Value = origSR;
			cpu.Regs.SR.B = false;
			Assert.AreEqual(cpu.Regs.SR.Value, targetSR);
			cpu.Regs.SR.B = true;
			Assert.AreEqual(cpu.Regs.SR.Value, origSR);
        }

		[TestMethod]
        public void Test_SR_C_WriteRead()
        {
            byte origSR = Convert.ToByte("11110000", 2);
            byte targetSR = Convert.ToByte("11110001", 2);
			cpu.Regs.SR.Value = origSR;
			cpu.Regs.SR.C = true;
			Assert.AreEqual(cpu.Regs.SR.Value, targetSR);
			cpu.Regs.SR.C = false;
			Assert.AreEqual(cpu.Regs.SR.Value, origSR);
        }

		[TestMethod]
        public void Test_SR_N_WriteRead()
        {
            byte origSR = Convert.ToByte("01110000", 2);
            byte targetSR = Convert.ToByte("11110000", 2);
			cpu.Regs.SR.Value = origSR;
			cpu.Regs.SR.N = true;
			Assert.AreEqual(cpu.Regs.SR.Value, targetSR);
			cpu.Regs.SR.N = false;
			Assert.AreEqual(cpu.Regs.SR.Value, origSR);
        }

		[TestMethod]
		public void Test_SR_Z_setbit()
		{
			cpu.Regs.SR.Value = 0xCC;
			cpu.Regs.SR.Z = true;
			Assert.AreEqual(cpu.Regs.SR.Z, true);
			cpu.Regs.SR.Z = false;
			Assert.AreEqual(cpu.Regs.SR.Z, false);
			cpu.Regs.SR.Z = false;
			Assert.AreEqual(cpu.Regs.SR.Z, false);
		}

		[TestMethod]
		public void Test_SR_Z_WriteRead()
		{
			byte origSR = Convert.ToByte("01110000", 2);
			byte targetSR = Convert.ToByte("01110010", 2);
			cpu.Regs.SR.Value = origSR;
			cpu.Regs.SR.Z = true;
			Assert.AreEqual(cpu.Regs.SR.Value, targetSR);
			cpu.Regs.SR.Z = false;
			Assert.AreEqual(cpu.Regs.SR.Value, origSR);
		}
    }
}
