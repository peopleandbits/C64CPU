using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOS6510.Execution;

namespace MOS6510.Commands.MoveCommands
{
    // http://www.oxyron.de/html/opcodes02.html
    // http://c64-retro-coding.blogspot.de/p/writing-6502-emulator-in-net.html
            
	/// <summary>
	/// $A9
	/// </summary>
	class LDA_Imm : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.A = GetNextMem(); 
			return GenerateImmX2DisAsm(Cpu.Regs.A);
        }
    }

	/// <summary>
	/// $AC
	/// </summary>
	class LDY_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			UInt16 addr = GetAddress();
			Cpu.Regs.Y = Cpu.Ram[addr];
			return GenerateAbsX4DisAsm(addr);
		}
	}

	/// <summary>
	/// $AE
	/// </summary>
	class LDX_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			UInt16 addr = GetAddress();
			Cpu.Regs.X = Cpu.Ram[addr];
			return GenerateAbsX4DisAsm(addr);
		}
	}

	/// <summary>
	/// $AD
	/// </summary>
	class LDA_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			UInt16 addr = GetAddress();
			Cpu.Regs.A = Cpu.Ram[addr];
			return GenerateAbsX4DisAsm(addr);
		}
	}

	/// <summary>
	/// $AD
	/// </summary>
	class STA_Abs : CommandBase, IExecution
    {
		public Disassembler Execute()
        {
            Lo = GetNextMem();
            Hi = GetNextMem();
			var addr = GetAddress();
			MemoryWrite(addr, Cpu.Regs.A);
			return GenerateAbsX4DisAsm(addr);
		}
    }

	/// <summary>
	/// $A2
	/// </summary>
	class LDX_Imm : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.X = GetNextMem();
			return GenerateImmX2DisAsm(Cpu.Regs.X);
		}
	}

	/// <summary>
	/// $8E
	/// </summary>
	class STX_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			var addr = GetAddress();
			MemoryWrite(addr, Cpu.Regs.X);
			return GenerateAbsX4DisAsm(addr);
		}
	}

	/// <summary>
	/// $A0
	/// </summary>
	class LDY_Imm : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.Y = GetNextMem();
			return GenerateImmX2DisAsm(Cpu.Regs.Y);
		}
	}

	/// <summary>
	/// $8F
	/// </summary>
	class STY_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			var addr = GetAddress();
			MemoryWrite(addr, Cpu.Regs.Y);
			return GenerateAbsX4DisAsm(addr);
		}
	}

    /// <summary>
    /// PLA ($68) - Pull Accumulator
    /// </summary>
    class PLA : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.A += Pop();
            return GenerateNormalDisAsm();
        }
    }

	/// <summary>
	/// PHA ($48) - Push Accumulator
	/// </summary>
	class PHA : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Push(Cpu.Regs.A);
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// PHP ($08) - Push Status Register (status flags)
	/// </summary>
	class PHP : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Push(Cpu.Regs.SR.Value);
			return GenerateNormalDisAsm();
		}
	}

    /// <summary>
    /// PLP ($28) - Pull Status Register (status flags)
    /// </summary>
    class PLP : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.SR.Value = Pop();
            return GenerateNormalDisAsm();
        }
    }

    /// <summary>
    /// TXS ($9A) - Transfer X to Stack pointer
    /// </summary>
    class TXS : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.StackPtr = Cpu.Regs.X;
            return GenerateNormalDisAsm();
        }
    }

    /// <summary>
    /// TSX ($BA) - Transfer Stack pointer to X
    /// </summary>
    class TSX : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.X = Cpu.Regs.StackPtr;
            return GenerateNormalDisAsm();
        }
    }

    /// <summary>
    /// TYA ($98) - Transfer Y to A
    /// </summary>
    class TYA : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.A = Cpu.Regs.Y;
            return GenerateNormalDisAsm();
        }
    }

    /// <summary>
    /// TAY ($A8) - Transfer A to X
    /// </summary>
    class TAY : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.Y = Cpu.Regs.A;
            return GenerateNormalDisAsm();
        }
    }

    /// <summary>
    /// TXA ($8A) - Transfer X to A
    /// </summary>
    class TXA : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.A = Cpu.Regs.X;
            return GenerateNormalDisAsm();
        }
    }

    /// <summary>
    /// TAX ($AA) - Transfer A to X
    /// </summary>
    class TAX : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.X = Cpu.Regs.A;
            return GenerateNormalDisAsm();
        }
    }
}
