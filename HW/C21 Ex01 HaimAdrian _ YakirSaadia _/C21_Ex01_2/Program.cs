using System;
using System.Text;

namespace C21_Ex01_2
{
	public class Program
	{
		private const int k_SandMachineDefaultHeight = 5;
		private const char k_SandMachineSymbol = '*';

		public static void Main()
		{
			DrawSandMachine(k_SandMachineDefaultHeight);
			Console.WriteLine("Please press 'Enter' to exit...");
			Console.ReadLine();
		}

		public static void DrawSandMachine(int i_NumOfLines)
		{
			if (i_NumOfLines > 0)
			{
				StringBuilder sandMachine = new StringBuilder();
				drawSandMachineRecursive(i_NumOfLines, 0, sandMachine);
				Console.WriteLine(sandMachine);
			}
		}

		private static void drawSandMachineRecursive(int i_NumOfLines, int i_SpaceLength, StringBuilder i_SandMachine)
		{
			appendSpaces(i_SandMachine, i_SpaceLength);

			// It might be zero because we could not validate that the input is odd in this exercise.
			// Instead, the validation is in exercise 3....
			if (i_NumOfLines <= 1)
			{
				i_SandMachine.Append(k_SandMachineSymbol);
			}
			else
			{
				// Begin: Append current level line of asterisks.
				appendSandSymbol(i_SandMachine, i_NumOfLines).AppendLine();

				// Middle: Let the recursive call handle the inner part of sand machine.
				drawSandMachineRecursive(i_NumOfLines - 2, i_SpaceLength + 1, i_SandMachine);

				// End: Append current level line of asterisks.
				i_SandMachine.AppendLine();
				appendSpaces(i_SandMachine, i_SpaceLength);
				appendSandSymbol(i_SandMachine, i_NumOfLines);
			}
		}

		private static void appendSpaces(StringBuilder i_SandMachine, int i_Count)
		{
			i_SandMachine.Append(' ', i_Count);
		}

		private static StringBuilder appendSandSymbol(StringBuilder i_SandMachine, int i_Count)
		{
			i_SandMachine.Append(k_SandMachineSymbol, i_Count);
			return i_SandMachine;
		}
	}
}
