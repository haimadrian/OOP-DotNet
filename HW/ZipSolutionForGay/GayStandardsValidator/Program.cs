using System;
using System.IO;

namespace GayStandardsValidator
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Enter solution full path: ");
			DirectoryInfo solutionDir;
			while (!(solutionDir = new DirectoryInfo(Console.ReadLine())).Exists)
			{
				Console.Write("Directory {0} does not exist. Try again: ", solutionDir.FullName);
			}

			ScanDirectoryRecursively(solutionDir);

			Console.WriteLine("Press Enter to exit.");
			Console.ReadLine();
		}

		private static void ScanDirectoryRecursively(DirectoryInfo sourceDir)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo[] dirs = sourceDir.GetDirectories();

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = sourceDir.GetFiles();
			foreach (FileInfo file in files)
			{
				if (isClass(file))
				{
					TypeInfo typeInfo = ScanFile(file);
					if (string.IsNullOrWhiteSpace(typeInfo.Name))
					{
						Console.WriteLine("File: {0}, Unable to detect type info for file.", file.FullName);
						continue;
					}

					if (typeInfo.Name != typeInfo.FileName)
					{
						Console.WriteLine("File: {0}, Type name ({1}) differs from file name ({2}).", file.FullName, typeInfo.Name, typeInfo.FileName);
					}

					switch (typeInfo.Type)
					{
						case TypesEnum.INTERFACE:
							if (typeInfo.Name[0] != 'I')
							{
								Console.WriteLine("File: {0}, Interface name must start with 'I'. Was: {1}", file.FullName, typeInfo.Name);
							}

							break;
						case TypesEnum.ENUM:
							if (typeInfo.Name[0] != 'e')
							{
								Console.WriteLine("File: {0}, Enum name must start with 'e'. Was: {1}", file.FullName, typeInfo.Name);
							}

							break;
					}
				}
			}

			foreach (DirectoryInfo subDir in dirs)
			{
				ScanDirectoryRecursively(subDir);
			}
		}

		private static bool isClass(FileInfo file)
		{
			return file.Extension.Equals(".cs", StringComparison.InvariantCultureIgnoreCase);
		}

		private static TypeInfo ScanFile(FileInfo classToScan)
		{
			bool TryExtractingTypeInfo(string line, TypeInfo i_TypeInfo, TypesEnum type)
			{
				string typeName;
				typeName = TryExtractingTypeName(line, type.ToString().ToLower());
				if (typeName != null)
				{
					i_TypeInfo.Name = typeName;
					i_TypeInfo.Type = type;
					return true;
				}

				return false;
			}

			string[] lines = File.ReadAllLines(classToScan.FullName);

			TypeInfo typeInfo = new TypeInfo() { FileName = classToScan.Name.Split('.')[0] };

			foreach (var currLine in lines)
			{
				string currLineTrimmed = currLine.Trim();
				if (currLineTrimmed.StartsWith("/") || currLineTrimmed.StartsWith("*"))
				{
					continue;
				}

				if (TryExtractingTypeInfo(currLineTrimmed, typeInfo, TypesEnum.CLASS))
				{
					break;
				}

				if (TryExtractingTypeInfo(currLineTrimmed, typeInfo, TypesEnum.INTERFACE))
				{
					break;
				}

				if (TryExtractingTypeInfo(currLineTrimmed, typeInfo, TypesEnum.ENUM))
				{
					break;
				}

				if (TryExtractingTypeInfo(currLineTrimmed, typeInfo, TypesEnum.STRUCT))
				{
					break;
				}
			}

			return typeInfo;
		}

		private static string TryExtractingTypeName(string line, string varToFind)
		{
			string typeName = null;
			string findWhat = varToFind + " ";

			if (line.Contains(findWhat))
			{
				string[] words = line.Split();

				for (int i = 0; i < words.Length; i++)
				{
					string currWord = words[i];
					if ((currWord == varToFind) && (i < words.Length - 1) && (char.IsLetter(words[i + 1][0])))
					{
						typeName = words[i + 1].Split('<')[0];
						break;
					}
				}
			}

			return typeName;
		}

		class TypeInfo
		{
			public string Name { get; set; }

			public string FileName { get; set; }

			public TypesEnum Type { get; set; }
		}

		enum TypesEnum
		{
			CLASS,
			INTERFACE,
			ENUM,
			STRUCT
		}
	}
}