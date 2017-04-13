using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOS6510.Execution;

namespace MOS6510.Commands.JumpFlagCommands
{
    // http://www.oxyron.de/html/opcodes02.html
    // http://c64-retro-coding.blogspot.de/p/writing-6502-emulator-in-net.html
            
	/// <summary>
	/// $00
	/// </summary>
	class BRK : CommandBase, IExecution
    {
		public Disassembler Execute()
        {
			return GenerateNormalDisAsm();
		}
    }

	/// <summary>
	/// $18
	/// </summary>
	class CLC : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.SR.C = false;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $2C
	/// </summary>
	class BIT_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			byte memval = GetAbsoluteMemoryByte();
			bool z = (memval & Cpu.Regs.A) == 0;
			Cpu.Regs.SR.Z = z;
			Cpu.Regs.SR.N = Helpers.BitMath.TestBit(memval, 7); 
			Cpu.Regs.SR.V = Helpers.BitMath.TestBit(memval, 6); 
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $38
	/// </summary>
	class SEC : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.SR.C = true;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $4C
	/// </summary>
	class JMP_ABS : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			Cpu.Regs.PC = GetAddress();
			return GenerateAbsX4DisAsm(Cpu.Regs.PC);
		}
	}

	/// <summary>
	/// $58
	/// </summary>
	class CLI : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.SR.I = false;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $60
	/// </summary>
	class RTS : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $78
	/// </summary>
	class SEI : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			// TODO: Implement interrupts
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $B8
	/// </summary>
	class CLV : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.SR.V = false;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $D8
	/// </summary>
	class CLD : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.SR.D = false;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $EA
	/// </summary>
	class NOP : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $F8
	/// </summary>
	class SED : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.SR.D = true;
			return GenerateNormalDisAsm();
		}
	}
}
