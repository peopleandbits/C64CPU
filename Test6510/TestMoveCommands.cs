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
    public class TestMoveCommands
    {
		MOS6510Chip cpu = new MOS6510Chip();

        [TestMethod]
        public void TestLDA_Imm()
        {
			cpu.Init();
			Assert.AreEqual(cpu.Regs.A, 0x00);
			cpu.Ram[0] = (byte)Opcode.LDA_IMM; // LDA
            cpu.Ram[1] = 0x73; // immediate mode dec 115
            cpu.Run();
			Assert.AreEqual(cpu.Regs.A, 0x73);
        }

        [TestMethod]
        public void TestSTA_Abs()
        {
			cpu.Init();
			Assert.AreEqual(cpu.Regs.A, 0x00);
			cpu.Ram[0] = (byte)Opcode.LDA_IMM; // LDA
            cpu.Ram[1] = 0x44; 
			cpu.Ram[2] = (byte)Opcode.STA_ABS; // STA
            cpu.Ram[3] = 0x00; // absolute addres $1000
            cpu.Ram[4] = 0x10; 
            cpu.Run();
            Assert.AreEqual(cpu.Ram[0x1000], 0x44);
        }

        [TestMethod]
        public void TestLDX_Imm()
        {
			cpu.Init();
			Assert.AreEqual(cpu.Regs.X, 0x00);
			cpu.Ram[0] = (byte)Opcode.LDX_IMM; // LDX
            cpu.Ram[1] = 0x73; // immediate mode dec 115
            cpu.Run();
			Assert.AreEqual(cpu.Regs.X, 0x73);
        }

        [TestMethod]
        public void TestSTX_Abs()
        {
			cpu.Init();
			Assert.AreEqual(cpu.Regs.X, 0x00);
			cpu.Ram[0] = (byte)Opcode.LDX_IMM; // LDX
            cpu.Ram[1] = 0x44;
			cpu.Ram[2] = (byte)Opcode.STX_ABS; // STX
            cpu.Ram[3] = 0x02; // absolute addres $1002
            cpu.Ram[4] = 0x10;
            cpu.Run();
            Assert.AreEqual(cpu.Ram[0x1002], 0x44);
        }

        [TestMethod]
        public void TestLDY_Imm()
        {
			cpu.Init();
			Assert.AreEqual(cpu.Regs.Y, 0x00);
			cpu.Ram[0] = (byte)Opcode.LDY_IMM; // LDY
            cpu.Ram[1] = 0x73; // immediate mode dec 115
            cpu.Run();
			Assert.AreEqual(cpu.Regs.Y, 0x73);
        }

        [TestMethod]
        public void TestSTY_Abs()
        {
			cpu.Init();
			Assert.AreEqual(cpu.Regs.Y, 0x00);
			cpu.Ram[0] = (byte)Opcode.LDY_IMM; // LDY
            cpu.Ram[1] = 0x44;
            cpu.Ram[2] = (byte)Opcode.STY_ABS;
            cpu.Ram[3] = 0x04; // absolute addres $1004
            cpu.Ram[4] = 0x10;
            cpu.Run();
            Assert.AreEqual(cpu.Ram[0x1004], 0x44);
        }

        [TestMethod]
        public void TestPHA()
        {
			cpu.Init();
			cpu.Ram[0] = (byte)Opcode.LDA_IMM; // LDA
            cpu.Ram[1] = 0x13; 
			cpu.Ram[2] = (byte)Opcode.PHA; // PHA
            cpu.Ram[3] = 0xA9; // LDA
            cpu.Ram[4] = 0x88;
			cpu.Ram[5] = (byte)Opcode.PHA; // PHA
            cpu.Run();
            Assert.AreEqual(cpu.Ram[0x1FF], 0x13);
            Assert.AreEqual(cpu.Ram[0x1FE], 0x88);
        }

        [TestMethod]
        public void TestPHP()
        {
			cpu.Init();
			cpu.Regs.SR.Value = Convert.ToByte("01010101", 2);
			cpu.Ram[0] = (byte)Opcode.PHP; // PHP
			cpu.Ram[1] = (byte)Opcode.PHP; // PHP
            cpu.Run();
			Assert.AreEqual(cpu.Ram[0x1FF], cpu.Regs.SR.Value);
			Assert.AreEqual(cpu.Ram[0x1FE], cpu.Regs.SR.Value);
            Assert.AreEqual(cpu.Ram[0x1FD], 0x00);
        }

        [TestMethod]
        public void TestTAX()
        {
            cpu.Init();
            cpu.Regs.A = 0x07;
            cpu.Ram[0] = (byte)Opcode.TAX; 
            cpu.Run();
            Assert.AreEqual(cpu.Regs.X, cpu.Regs.A);
        }
    }
}
