using System;

using R5T.Code.VisualStudio.ProjectFile.Raw;


namespace R5T.Code.VisualStudio.ProjectFile.Types.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            //Construction.CreateNewNetStandardLibraryProjectFile();
            Construction.DeserializeProjectFile();
        }

        private static void DeserializeProjectFile()
        {
            var projectFilePath = @"C:\Temp\temp.csproj";

            var projectFile = ProjectFileSerialization.Deserialize(projectFilePath);
        }

        private static void CreateNewNetStandardLibraryProjectFile()
        {
            var projectFilePath = @"C:\Temp\temp.csproj";

            var projectFile = ProjectFileModel.NewEmpty();

            ProjectXmlOperations.AddProjectElement(projectFile.XmlDocument);

            ProjectFileSerialization.Serialize(projectFilePath, projectFile);
        }
    }
}
