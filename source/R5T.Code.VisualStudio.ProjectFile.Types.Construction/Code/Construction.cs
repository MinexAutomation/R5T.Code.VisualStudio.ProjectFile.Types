using System;

using R5T.Code.VisualStudio.ProjectFile.Raw;

using XmlElements = R5T.Code.VisualStudio.ProjectFile.Raw.XmlElements;


namespace R5T.Code.VisualStudio.ProjectFile.Types.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            //Construction.CreateNewProjectOnlyFileXmlElements();
            //Construction.DeserializeProjectFileXmlElements();
            //Construction.CreateNewProjectOnly();
            Construction.CreateNewNetStandardLibraryProjectFile();
            //Construction.DeserializeProjectFile();
        }

        private static void DeserializeProjectFile()
        {
            var projectFilePath = @"C:\Temp\temp.csproj";

            var projectFile = ProjectFileSerialization.Deserialize(projectFilePath);
        }

        private static void CreateNewNetStandardLibraryProjectFile()
        {
            var projectFilePath = @"C:\Temp\temp.csproj";

            var projectFile = ProjectFileModel.NewNetStandardLibrary();

            ProjectFileSerialization.Serialize(projectFilePath, projectFile);
        }

        private static void CreateNewProjectOnly()
        {
            var projectFilePath = @"C:\Temp\temp.csproj";

            var projectFile = ProjectFileModel.New();

            ProjectFileSerialization.Serialize(projectFilePath, projectFile);
        }

        private static void DeserializeProjectFileXmlElements()
        {
            var projectFilePath = @"C:\Temp\temp.csproj";

            var projectFile = XmlElements.ProjectFileSerialization.Deserialize(projectFilePath);
        }

        private static void CreateNewProjectOnlyFileXmlElements()
        {
            var projectFilePath = @"C:\Temp\temp.csproj";

            var projectFile = XmlElements.ProjectFileModel.NewEmpty();

            XmlElements.ProjectXmlElementOperations.AddProjectElement(projectFile.XmlDocument);

            XmlElements.ProjectFileSerialization.Serialize(projectFilePath, projectFile);
        }
    }
}
