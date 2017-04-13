# C64CPU
An emulator for MOS 6510 CPU used in Commodore 64. This project contains no UI, only internal representation of the CPU written in C#. There are also an assembler and a disassembler. 

## Goals

I wrote this only for learning purposes. There are no specific goals.

## Learning insights

The strategy design pattern is used to avoid a long switch statement in file ExecutionContext.cs. 

## Solution structure

MOS6510 - the actual emulation engine
emuConsole - a console app for running some quick tests
Test6510 - a VS unit test project 

## Progress

The progress is visible in the file called Opcode.cs that lists all implemented opcodes. If you contribute, then please only add opcodes to this list that are implemented and tested. This ensures that that Opcode.cs file is up-to-date at all times and reflects the progress of the project. 

