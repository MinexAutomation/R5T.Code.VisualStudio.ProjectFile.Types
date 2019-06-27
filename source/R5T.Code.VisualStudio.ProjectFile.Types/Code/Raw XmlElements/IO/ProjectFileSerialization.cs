using System;
using System.Xml;

using R5T.NetStandard.IO;



namespace R5T.Code.VisualStudio.ProjectFile.Raw.XmlElements
{
    public static class ProjectFileSerialization
    {
        public static ProjectFileModel Deserialize(string projectFilePath)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(projectFilePath);

            var projectFile = ProjectFileModel.FromXmlDocument(xmlDocument);
            return projectFile;
        }

        public static void Serialize(string projectFilePath, ProjectFileModel projectFile, bool overwrite = true)
        {
            using (var fileStream = FileStreamHelper.NewWrite(projectFilePath, overwrite))
            {
                projectFile.XmlDocument.Save(fileStream);
            }
        }
    }
}
