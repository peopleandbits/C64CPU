using System;

namespace emuConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to C64!\n");
			var cpu = new MOS6510.CPU.MOS6510Chip ();
			LoadSource (cpu);
			//TestRun();
		}

		static void LoadSource (MOS6510.CPU.MOS6510Chip cpu)
		{
			cpu.Init ();
			Console.WriteLine ("Now loading program from file.\n");
			var asm = new MOS6510.Execution.Assembler (cpu);
			asm.LoadSource("SourceCode//test.asm");
			if(asm.Go())
				Console.WriteLine ("\nOK.\n");
			else
				Console.WriteLine ("\nFail.\n");
		}
		
		static void TestRun(MOS6510.CPU.MOS6510Chip cpu)
		{
			cpu.Init ();
			cpu.Ram[0x00] = 0xA9; // LDA #$01
			cpu.Ram[0x01] = 0x01; 
			cpu.Ram[0x02] = 0xAD; // LDA $5001
			cpu.Ram[0x03] = 0x01; 
			cpu.Ram[0x04] = 0x50;
			cpu.Ram[0x05] = 0x09; // ORA #$1
			cpu.Ram[0x06] = 0x01;
			cpu.Ram[0x07] = 0xA2; // LDX #$10
			cpu.Ram[0x08] = 0x10; 
			cpu.Ram[0x09] = 0x01; // ORA ($80, X)
			cpu.Ram[0x0A] = 0x80;
			cpu.Ram[0x90] = 0x01;
			cpu.Ram[0x91] = 0x00; // result should then be A9 (because pointing to $0001)
			cpu.Ram[0x0B] = 0x78;
			cpu.Ram[0x0C] = 0xEA; // NOP
			cpu.Ram[0x0D] = 0xA0;
			cpu.Ram[0x0E] = 0x99;
			cpu.Ram[0x0F] = 0xCE; // DEC $D020
			cpu.Ram[0x10] = 0x20; 
			cpu.Ram[0x11] = 0xD0; 
			cpu.Ram[0x12] = 0xEE; // INC $D020
			cpu.Ram[0x13] = 0x21; 
			cpu.Ram[0x14] = 0xD0; 
			cpu.Run ();
			Console.WriteLine("\nProgram executed ok.");
		}
	}
}
