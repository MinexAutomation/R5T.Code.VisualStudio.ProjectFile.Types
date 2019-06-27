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
            //Construction.CreateNewNetStandardLibraryProjectFile();
            //Construction.DeserializeProjectFile();
            //Construction.AddProjectAndPackageReferenceToProject();
            Construction.AddProjectAndPackageReferenceToProjectAgain();
        }

        private static void AddProjectAndPackageReferenceToProjectAgain()
        {
            var inputProjectFilePath = @"C:\Temp\temp-with references.csproj";
            var outputProjectFilePath = @"C:\Temp\temp-with references, again.csproj";

            var projectFile = ProjectFileModel.FromFile(inputProjectFilePath)
                .AddPackageReference("HeyHey", Version.Parse("2.3.4"))
                .AddProjectReference(@"..\..\Yup\Yup\Yup.csproj")
                ;

            projectFile.Save(outputProjectFilePath);
        }

        private static void AddProjectAndPackageReferenceToProject()
        {
            var inputProjectFilePath = @"C:\Temp\temp.csproj";
            var outputProjectFilePath = @"C:\Temp\temp-with references.csproj";

            var projectFile = ProjectFileModel.FromFile(inputProjectFilePath)
                .AddPackageReference("YoYoYo", Version.Parse("1.2.3"))
                .AddProjectReference(@"..\..\Yo\Yo\Yo.csproj")
                ;

            projectFile.Save(outputProjectFilePath);
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
