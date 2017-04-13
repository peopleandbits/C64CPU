using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOS6510.CPU;
using MOS6510.Execution;

namespace MOSTest
{
    [TestClass]
    public class TestAssembler
    {
		Assembler asm;

		[TestInitialize]
		public void Setup()
		{
			asm = new Assembler(new MOS6510Chip());
		}

		[TestMethod]
		public void Test_Assembler_InlineSource()
		{
			asm.Reset();
			string s = 
				@"LDA #$01
				STA $8000";
			asm.InsertSource(s);
			asm.Go();
			Assert.AreEqual(asm.Cpu.Ram[0x8000], 0x01);
		}

		[TestMethod]
		public void Test_Assembler_LoadFromFile()
		{
			asm.Reset();
            asm.LoadSource("SourceCode//test.asm");
			asm.Go();
			Assert.AreEqual(asm.Cpu.Ram[0x8000], 0x01);
            Assert.AreEqual(asm.Cpu.Regs.A, 0x01);
        }
    }
}
