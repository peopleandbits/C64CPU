using System;
using System.Collections.Generic;
using MOS6510.Commands;
using MOS6510.Commands.MoveCommands;
using MOS6510.Commands.JumpFlagCommands;
using MOS6510.Commands.ArithmeticCommands;

namespace MOS6510.Execution
{
    /// <summary>
    /// Stores opcodes and related command classes. Part of a strategy design pattern.
    /// </summary>
	public class ExecutionContext
	{
		// this is the strategy design pattern
		private static Dictionary<Opcode, IExecution> commands = new Dictionary<Opcode, IExecution>();

		static ExecutionContext ()
		{
			commands.Add(Opcode.BRK, 	 new BRK() 		{ Name = "BRK" });
			commands.Add(Opcode.ORA_IZX, new ORA_Izx() 	{ Name = "ORA" });
			commands.Add(Opcode.PHP, 	 new PHP() 		{ Name = "PHP" }); 
			commands.Add(Opcode.ORA_IMM, new ORA_Imm() 	{ Name = "ORA" });
			commands.Add(Opcode.CLC,	 new CLC()	 	{ Name = "CLC" }); 
			commands.Add(Opcode.BIT_ABS, new BIT_Abs()	{ Name = "BIT" });
			commands.Add(Opcode.SEC,	 new SEC()	 	{ Name = "SEC" }); 
			commands.Add(Opcode.PHA, 	 new PHA() 		{ Name = "PHA" }); 
			commands.Add(Opcode.CLI,	 new CLI()	 	{ Name = "CLI" }); 
			commands.Add(Opcode.RTS, 	 new RTS() 		{ Name = "RTS" }); 
			commands.Add(Opcode.SEI, 	 new SEI() 		{ Name = "SEI" }); 
			commands.Add(Opcode.DEY,	 new INY()	 	{ Name = "DEY" }); 
			commands.Add(Opcode.STY_ABS, new STY_Abs() 	{ Name = "STY" });
			commands.Add(Opcode.STA_ABS, new STA_Abs() 	{ Name = "STA" });
			commands.Add(Opcode.STX_ABS, new STX_Abs() 	{ Name = "STX" });
			commands.Add(Opcode.LDY_IMM, new LDY_Imm() 	{ Name = "LDY" });
			commands.Add(Opcode.LDX_IMM, new LDX_Imm() 	{ Name = "LDX" });
			commands.Add(Opcode.LDA_IMM, new LDA_Imm() 	{ Name = "LDA" });
			commands.Add(Opcode.LDY_ABS, new LDY_Abs() 	{ Name = "LDY" });
			commands.Add(Opcode.LDA_ABS, new LDA_Abs() 	{ Name = "LDA" });
			commands.Add(Opcode.LDX_ABS, new LDX_Abs() 	{ Name = "LDX" });
			commands.Add(Opcode.CLV,	 new CLV()	 	{ Name = "CLV" }); 
			commands.Add(Opcode.INY,	 new INY()	 	{ Name = "INY" }); 
			commands.Add(Opcode.DEX,	 new DEX()	 	{ Name = "DEX" }); 
			commands.Add(Opcode.DEC_ABS, new DEC_Abs() 	{ Name = "DEC" });
			commands.Add(Opcode.INX,	 new INX()	 	{ Name = "INX" }); 
			commands.Add(Opcode.NOP, 	 new NOP() 		{ Name = "NOP" }); 
			commands.Add(Opcode.INC_ABS, new INC_Abs() 	{ Name = "INC" });
			commands.Add(Opcode.TAX,	 new TAX()	 	{ Name = "TAX" });
            commands.Add(Opcode.TXA,	 new TXA()	 	{ Name = "TXA" });
            commands.Add(Opcode.TAY,     new TAY()      { Name = "TAY" });
            commands.Add(Opcode.TYA,     new TYA()      { Name = "TYA" });
            commands.Add(Opcode.TSX,     new TSX()      { Name = "TSX" });
            commands.Add(Opcode.TXS,     new TXS()      { Name = "TXS" });
            commands.Add(Opcode.PLA,     new PLA()      { Name = "PLA" });
            commands.Add(Opcode.PLP,     new PLP()      { Name = "PLP" });
            commands.Add(Opcode.ADC_IMM, new ADC_Imm()  { Name = "ADC" });
            commands.Add(Opcode.ADC_ZP,  new ADC_Zp()   { Name = "ADC" }); 

			// insert opcodes (important)
			foreach(var cmd in commands)
			{
				var exec = (CommandBase)cmd.Value;
				exec.Opcode = (byte)cmd.Key;
			}
			int k = 0;
		}

		public static bool ApplyStrategy(Opcode title, bool disassembly)
		{
			Disassembler da = commands[title].Execute();
			if(disassembly)
			{
				string output = String.Format("{0,-14} [{1}]", da.Span, da.RegisterSnapshot);
				Console.WriteLine(output);
			}
			return (da.Opcode != 0x00 && da.Opcode != 0x60);
		}
	}
}

