using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{

    enum Operation
    {
        nop,
        acc,
        jmp
    }
    class Instruction
    {
        public Operation Operation { get; set; }
        public int Argument { get; set; }
        public bool IsExecuted { get; set; }
    }
    static class Day8
    {
        static List<Instruction> Instructions = new List<Instruction>();
        static int accumulator = 0;
        static int instructionPosition = 0;
        //InstructionChanged is used to show which instruction had to be changed
        static Instruction InstructionChanged;
        public static void Execute()
        {
            List<string> input = new List<string>(File.ReadAllLines("C:\\Users\\DirkFraanje\\Documents\\adventofcodeday8.txt"));

            //Added a imer just for fun
            var timer = new Stopwatch();
            timer.Start();
            //First create a nice list of instructions from the inputfile
            foreach (var instruction in input)
            {
                Instructions.Add(CreateNewInstruction(instruction));
            }
            //Run recursive method to find the instruction that has to be changed
            FindInstructionToChange();
            //Stop the timer, show the answer and just for fun the instruction that has to be changed
            timer.Stop();
            Console.WriteLine($"Answer: {accumulator} ");
            Console.WriteLine($"Instruction to change: {InstructionChanged.Operation} {InstructionChanged.Argument}");
            Console.WriteLine($"Executed in: {timer.ElapsedMilliseconds} milliseconds");
        }

        private static void FindInstructionToChange()
        {
            var i = 0;
            while (true)
            {
                var instruction = Instructions[i];
                switch (Instructions[i].Operation)
                {
                    case Operation.nop:
                        instruction.Operation = Operation.jmp;
                        if (RunBootCodeSuccesful())
                        {
                            //Before returning the answer change the answer back to it's original Operation so it can be showed in the console
                            instruction.Operation = Operation.nop;
                            InstructionChanged = instruction;
                            return;
                        }
                        else
                            instruction.Operation = Operation.nop;
                        break;
                    case Operation.acc:
                        break;
                    case Operation.jmp:
                        instruction.Operation = Operation.nop;
                        if (RunBootCodeSuccesful())
                        {
                            //Before returning the answer change the answer back to it's original Operation so it can be showed in the console
                            instruction.Operation = Operation.jmp;
                            InstructionChanged = instruction;
                            return;
                        }
                        else
                            instruction.Operation = Operation.jmp;
                        break;
                    default:
                        break;
                }
                i++;
                //Reset everything to it's default
                accumulator = 0;
                instructionPosition = 0;
                Instructions.ForEach(x => x.IsExecuted = false);
            }
        }

        private static bool RunBootCodeSuccesful()
        {
            while (true)
            {
                var instruction = Instructions[instructionPosition];
                switch (instruction.Operation)
                {
                    case Operation.nop:
                        instructionPosition++;
                        break;
                    case Operation.acc:
                        accumulator += instruction.Argument;
                        instructionPosition++;
                        break;
                    case Operation.jmp:
                        instructionPosition += instruction.Argument;
                        break;
                    default:
                        break;
                }
                instruction.IsExecuted = true;
                if (instructionPosition > Instructions.Count - 1)
                    return true;
                var nextInstruction = Instructions[instructionPosition];
                if (nextInstruction.IsExecuted)
                    return false;
            }
        }

        static Instruction CreateNewInstruction(string instructionline)
        { 
            var instruction = new Instruction();
            var splitOperationAndArgument = instructionline.Split(' ');
            switch (splitOperationAndArgument[0])
            {
                case "nop":
                    instruction.Operation = Operation.nop;
                    break;
                case "acc":
                    instruction.Operation = Operation.acc;
                    break;
                case "jmp":
                    instruction.Operation = Operation.jmp;
                    break;
                default:
                    break;
            }
            instruction.Argument = int.Parse(splitOperationAndArgument[1]);
            return instruction;
        }
    }
}
