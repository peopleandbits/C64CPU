using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOS6510.Commands
{
    public enum Opcode
    {
		BRK 	= 0x00,
		ORA_IZX = 0x01,
		PHP 	= 0x08,
		ORA_IMM = 0x09,
		CLC		= 0x18,
        PLP     = 0x28,
        BIT_ABS = 0x2C,
		SEC		= 0x38,
		PHA 	= 0x48,
		CLI		= 0x58,
		RTS 	= 0x60,
        ADC_ZP  = 0x65,
        PLA     = 0x68,
        ADC_IMM = 0x69,
        SEI     = 0x78,
		DEY		= 0x88,
        TXA     = 0x8A,
		STY_ABS = 0x8C,
		STA_ABS = 0x8D,
		STX_ABS = 0x8E,
        TYA     = 0x98,
        TXS     = 0x9A,
		LDY_IMM = 0xA0,
		LDX_IMM = 0xA2,
        TAY     = 0xA8,
        LDA_IMM = 0xA9,
        TAX     = 0xAA,
        LDY_ABS = 0xAC,
		LDA_ABS = 0xAD,
		LDX_ABS = 0xAE,
		CLV		= 0xB8,
        TSX     = 0xBA,
        INY     = 0xC8,
		DEX		= 0xCA,
		DEC_ABS = 0xCE,
		CLD		= 0xD8,
		INX		= 0xE8,
		NOP		= 0xEA,
		INC_ABS = 0xEE,
		SED		= 0xF8,
	}
}
