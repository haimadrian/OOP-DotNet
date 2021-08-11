using System;
using System.IO;

namespace ExNameFixer
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.Write("Enter solution full path: ");
			DirectoryInfo solutionDir;
			while (!(solutionDir = new DirectoryInfo(Console.ReadLine())).Exists)
			{
				Console.Write("Directory does not exist. Try again: ");
			}

            Console.WriteLine("Fix what? e.g. Ex01");
			string oldName = Console.ReadLine();
			Console.WriteLine("Fix to? e.g. Ex02");
			string newName = Console.ReadLine();

			FixRecursively(solutionDir, oldName, newName);
		}

		private static void FixRecursively(DirectoryInfo sourceDir, string oldName, string newName)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo[] dirs = sourceDir.GetDirectories();

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = sourceDir.GetFiles();
			foreach (FileInfo file in files)
			{
				// Fix content
				string text = File.ReadAllText(file.FullName);
				text = text.Replace(oldName, newName);
				File.WriteAllText(file.FullName, text);

				// Rename
				if (file.Name.Contains(oldName))
				{
					File.Move(file.FullName, file.FullName.Replace(oldName, newName));
				}
			}

			foreach (DirectoryInfo subDir in dirs)
			{
				if (subDir.Name.Contains(oldName))
				{
					string newDirName = subDir.FullName.Replace(oldName, newName);
					Directory.Move(subDir.FullName, newDirName);
					FixRecursively(new DirectoryInfo(newDirName), oldName, newName);
				}
				else
				{
					FixRecursively(subDir, oldName, newName);
				}
			}
		}
	}
}
