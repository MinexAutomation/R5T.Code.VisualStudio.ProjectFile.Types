using System;
using System.Collections.Generic;

using R5T.NetStandard;

using R5T.Code.VisualStudio.ProjectFile.Raw;

using PathUtilities = R5T.NetStandard.IO.Paths.Utilities;


namespace R5T.Code.VisualStudio.ProjectFile.Types
{
    public static class Utilities
    {
        public static string ToStringStandard(TargetFramework targetFramework)
        {
            switch(targetFramework)
            {
                case TargetFramework.NetCoreApp_2_2:
                    return ProjectFileXmlValues.NetCoreApp_2_2;

                case TargetFramework.NetStandard_2_0:
                    return ProjectFileXmlValues.NetStandard_2_0;

                default:
                    throw new Exception(EnumHelper.UnexpectedEnumerationValueMessage(targetFramework));
            }
        }

        /// <summary>
        /// The project reference relative file paths are relative to the project directory, not file path.
        /// </summary>
        public static IEnumerable<string> GetProjectReferenceDependencyFilePathsForProjectDirectory(string projectDirectoryPath, IEnumerable<string> projectReferenceRelativeFilePaths)
        {
            foreach (var projectReferenceRelativeFilePath in projectReferenceRelativeFilePaths)
            {
                var projectFileUnresolvedPath = PathUtilities.Combine(projectDirectoryPath, projectReferenceRelativeFilePath);

                var projectFilePath = PathUtilities.ResolveFilePath(projectFileUnresolvedPath);
                yield return projectFilePath;
            }
        }

        public static IEnumerable<string> GetProjectReferenceDependencyFilePaths(string projectFilePath)
        {
            var projectFile = ProjectFileModel.Load(projectFilePath);

            var projectReferenceDependencyFilePaths = Utilities.GetProjectReferenceDependencyFilePaths(projectFile, projectFilePath);
            return projectReferenceDependencyFilePaths;
        }

        public static IEnumerable<string> GetProjectReferenceDependencyFilePaths(ProjectFileModel projectFile, string projectFilePath)
        {
            var projectDirectoryPath = PathUtilities.GetDirectoryPath(projectFilePath);

            var projectReferenceRelativeFilePaths = projectFile.GetProjectReferenceRelativePaths();

            var projectReferenceDependencyFilePaths = Utilities.GetProjectReferenceDependencyFilePathsForProjectDirectory(projectDirectoryPath, projectReferenceRelativeFilePaths);
            return projectReferenceDependencyFilePaths;
        }

        public static IEnumerable<string> GetProjectReferenceDependencyFilePathsRecursive(string projectFilePath)
        {
            var projectFile = ProjectFileModel.Load(projectFilePath);

            var projectReferenceDependencyFilePaths = Utilities.GetProjectReferenceDependencyFilePathsRecursive(projectFile, projectFilePath);
            return projectReferenceDependencyFilePaths;
        }

        public static IEnumerable<string> GetProjectReferenceDependencyFilePathsRecursive(ProjectFileModel projectFile, string projectFilePath)
        {
            var pathAccumulator = new HashSet<string>();

            var projectReferenceDependencyFilePaths = Utilities.GetProjectReferenceDependencyFilePathsRecursive(projectFile, projectFilePath, pathAccumulator);
            return projectReferenceDependencyFilePaths;
        }

        public static IEnumerable<string> GetProjectReferenceDependencyFilePathsRecursive(string projectFilePath, HashSet<string> pathAccumulator)
        {
            var projectFile = ProjectFileModel.Load(projectFilePath);

            var projectReferenceDependencyFilePaths = Utilities.GetProjectReferenceDependencyFilePathsRecursive(projectFile, projectFilePath, pathAccumulator);
            return projectReferenceDependencyFilePaths;
        }

        public static IEnumerable<string> GetProjectReferenceDependencyFilePathsRecursive(ProjectFileModel projectFileModel, string projectFilePath, HashSet<string> pathAccumulator)
        {
            var dependencyProjectFilePaths = projectFileModel.GetProjectReferenceDependencyFilePaths(projectFilePath);

            foreach (var dependencyProjectFilePath in dependencyProjectFilePaths)
            {
                if (!pathAccumulator.Contains(dependencyProjectFilePath))
                {
                    pathAccumulator.Add(dependencyProjectFilePath);
                    yield return dependencyProjectFilePath;
                }

                var dependencyProjectFile = ProjectFileModel.Load(dependencyProjectFilePath);

                var dependencyDependencyProjectFilePaths = dependencyProjectFile.GetProjectReferenceDependencyFilePathsRecursive(dependencyProjectFilePath);
                foreach (var dependencyDependencyProjectFilePath in dependencyDependencyProjectFilePaths)
                {
                    if (!pathAccumulator.Contains(dependencyDependencyProjectFilePath))
                    {
                        pathAccumulator.Add(dependencyDependencyProjectFilePath);
                        yield return dependencyDependencyProjectFilePath;
                    }
                }
            }
        }

        public static IEnumerable<string> GetProjectReferenceDependencyFilePathsRecursive(IEnumerable<string> projectFilePaths)
        {
            var pathAccumulator = new HashSet<string>();

            foreach (var projectFilePath in projectFilePaths)
            {
                var projectReferenceDependencyFilePaths = Utilities.GetProjectReferenceDependencyFilePathsRecursive(projectFilePath, pathAccumulator);
                foreach (var projectReferenceDependencyFilePath in projectReferenceDependencyFilePaths)
                {
                    yield return projectReferenceDependencyFilePath;
                }
            }
        }

        /// <summary>
        /// Adds the dependency project file as a project-reference dependency to the project file.
        /// </summary>
        public static void AddProjectReference(string projectFilePath, string dependencyProjectFilePath)
        {
            var projectFile = ProjectFileModel.Load(projectFilePath);

            projectFile.AddProjectReference(projectFilePath, dependencyProjectFilePath);

            projectFile.Save(projectFilePath);
        }

        /// <summary>
        /// Get the file path relative to the project directory of the specified project file path for the specified file path.
        /// Useful in determining 
        /// </summary>
        public static string GetProjectDirectoryRelativeFilePath(string projectFilePath, string filePath)
        {
            var projectDirectoryPath = PathUtilities.GetDirectoryPath(projectFilePath);

            var relativeFilePath = PathUtilities.GetRelativePathDirectoryToFile(projectDirectoryPath, filePath);
            return relativeFilePath;
        }
    }
}
