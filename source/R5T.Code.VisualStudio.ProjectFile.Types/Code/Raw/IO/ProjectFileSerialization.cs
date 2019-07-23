using System;
using System.Xml.Linq;

using R5T.NetStandard.IO;
using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class ProjectFileSerialization
    {
        public static ProjectFileModel Deserialize(string projectFilePath)
        {
            var xElement = XElement.Load(projectFilePath);

            var projectFile = ProjectFileModel.FromXElement(xElement);
            return projectFile;
        }

        public static void Serialize(string projectFilePath, ProjectFileModel projectFile, bool overwrite = true)
        {
            using (var fileStream = FileStreamHelper.NewWrite(projectFilePath, overwrite))
            using (var xmlWriter = XmlWriterHelper.New(fileStream))
            {
                projectFile.ProjectElement.Value.Save(xmlWriter);
            }
        }
    }
}
