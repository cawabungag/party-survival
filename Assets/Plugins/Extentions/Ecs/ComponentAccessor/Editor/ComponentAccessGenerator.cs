using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DesperateDevs.Utils;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using FileGenerator;

namespace Ecs.ComponentAccessor
{
	public static class ComponentAccessGenerator
	{
		private static readonly StringBuilder Builder = new StringBuilder();

		public static List<GeneratedFile> GenerateProxy(DirectoryInfo generationDirectory)
		{
			if (!generationDirectory.Exists)
				generationDirectory.Create();

			var assemblies = AppDomain.CurrentDomain.GetAssemblies();

			var proxiedInfos = new List<GeneratedFile>();
			foreach (var assembly in assemblies)
			{
				var types = assembly.GetTypes();
				foreach (var type in types)
				{
					if (!type.IsDefined(typeof(AccessorAttribute), false)
					    || !type.ImplementsInterface<IComponent>())
						continue;
					var proxyFiles = GenerateComponentAccessor(type, generationDirectory);
					proxiedInfos.AddRange(proxyFiles);
				}
			}

			return proxiedInfos;
		}

		private static List<GeneratedFile> GenerateComponentAccessor(Type componentType,
			DirectoryInfo generationDirectory)
		{
			var files = new List<GeneratedFile>();

			var componentName = componentType.Name.Replace("Component", "");
			var contextNames = GetComponentContextNames(componentType);

			foreach (var contextName in contextNames)
			{
				var fileInfo = GetImplFileInfo(generationDirectory, componentName, contextName);
				var fileData = ComponentAccessGeneratorTemplate.GetProxiedImplBody(
					GetImplNameSpaces(componentType),
					contextName,
					componentName);
				files.Add(new GeneratedFile(fileInfo, fileData));
			}


			return files;
		}

		private static string[] GetComponentContextNames(Type componentType)
		{
			var attributes = componentType.GetCustomAttributes<ContextAttribute>();
			return attributes.Select(s => s.contextName).ToArray();
		}

		private static string GetImplNameSpaces(Type componentType)
		{
			var nameSpaces = new List<string>
			{
				"Entitas",
				componentType.Namespace
			};
			var cleared = ClearNameSpaces(nameSpaces);
			return GetNameSpacesBody(cleared);
		}

		private static List<string> ClearNameSpaces(List<string> nameSpaces)
		{
			nameSpaces.RemoveAll(string.IsNullOrEmpty);
			nameSpaces = nameSpaces.Distinct().ToList();
			return nameSpaces;
		}

		private static string GetNameSpacesBody(List<string> nameSpaces)
		{
			Builder.Clear();

			for (var i = 0; i < nameSpaces.Count; i++)
			{
				var nameSpace = nameSpaces[i];
				Builder.Append("using ").Append(nameSpace).Append(";");
				if (i + 1 < nameSpaces.Count)
					Builder.Append("\r\n");
			}

			return Builder.ToString();
		}

		private static FileInfo GetImplFileInfo(DirectoryInfo directory, string componentName, string contextName)
		{
			var fileName = contextName + componentName + "ComponentAccess.cs";
			return new FileInfo(Path.Combine(directory.FullName, componentName, fileName));
		}
	}
}