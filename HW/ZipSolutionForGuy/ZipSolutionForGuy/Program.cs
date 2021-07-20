using System;
using System.IO;
using System.IO.Compression;

namespace ZipSolutionForGuy
{
    class Program
    {
		public static void Main()
		{
            Console.Write("Enter solution full path: ");
			DirectoryInfo solutionDir;
			while (!(solutionDir = new DirectoryInfo(Console.ReadLine())).Exists)
			{
				Console.Write("Directory does not exist. Try again: ");
			}

			string tempDir = "C:\\temp";
			string destinationDir = Path.Combine(tempDir, solutionDir.Name);
			string destinationArchiveFileName = Path.Combine(tempDir, solutionDir.Name + ".zip");

			if (Directory.Exists(destinationDir))
			{
				Console.WriteLine($"{destinationDir} already exists. Deleting it..");
				Directory.Delete(destinationDir, true);
			}

			if (File.Exists(destinationArchiveFileName))
			{
				Console.WriteLine($"{destinationArchiveFileName} already exists. Deleting it..");
				File.Delete(destinationArchiveFileName);
			}

			DirectoryCopy(solutionDir, 
						  destinationDir, 
						  directory => directory.Name != "obj" && directory.Name != "bin" && directory.Name != ".vs",
						  file => file.Extension != ".Cache" && file.Extension != ".StyleCop" && file.Extension != ".editorconfig");

			Console.WriteLine($"Solution copied to: {destinationDir}");

			// Remove .editorconfig from solution file
			DirectoryInfo destinationDirInfo = new DirectoryInfo(destinationDir);
			string solutionName = destinationDirInfo.Name.Replace("Adrian", string.Empty).Replace("Saadia", string.Empty) + ".sln";
			string solutionFilePath = Path.Combine(destinationDirInfo.FullName, solutionName);
			string text = File.ReadAllText(solutionFilePath);
			text = text.Replace(@"
Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = ""Solution Items"", ""Solution Items"", ""{053419CD-53D8-4345-8DE3-D8FC6F068649}""
	ProjectSection(SolutionItems) = preProject
		.editorconfig = .editorconfig
	EndProjectSection
EndProject", string.Empty);
			File.WriteAllText(solutionFilePath, text);

			ZipFile.CreateFromDirectory(destinationDir, destinationArchiveFileName);
			Console.WriteLine($"Solution zipped to: {destinationArchiveFileName}");

			Console.WriteLine("Press Enter to exit.");
			Console.ReadLine();
		}

		private static void DirectoryCopy(DirectoryInfo sourceDir, 
										  string destDirName, 
										  Func<DirectoryInfo, bool> directoryFilter,
										  Func<FileInfo, bool> fileFilter)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo[] dirs = sourceDir.GetDirectories();

			// If the destination directory doesn't exist, create it.       
			Directory.CreateDirectory(destDirName);

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = sourceDir.GetFiles();
			foreach (FileInfo file in files)
			{
				if (fileFilter(file))
				{
					string tempPath = Path.Combine(destDirName, file.Name);
					file.CopyTo(tempPath, true);
				}
			}

			foreach (DirectoryInfo subDir in dirs)
			{
				if (directoryFilter(subDir))
				{
					string destPath = Path.Combine(destDirName, subDir.Name);
					DirectoryCopy(subDir, destPath, directoryFilter, fileFilter);
				}
			}
		}
    }
}
