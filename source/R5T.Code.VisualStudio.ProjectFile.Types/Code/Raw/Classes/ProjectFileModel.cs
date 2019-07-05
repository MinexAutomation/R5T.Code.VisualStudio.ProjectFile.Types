using System;
using System.Xml;
using System.Xml.Linq;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    /// <summary>
    /// Represents a Visual Studio project file.
    /// </summary>
    /// <remarks>
    /// Built around an in-memory <see cref="ProjectElement"/>, allow using <see cref="ProjectElement"/>-related functions on the Xml project file content.
    /// </remarks>
    public class ProjectFileModel
    {
        #region Static

        public static ProjectFileModel FromProjectElement(ProjectXElement projectElement)
        {
            var projectFile = new ProjectFileModel(projectElement);
            return projectFile;
        }

        public static ProjectFileModel FromXElement(XElement xElement)
        {
            var projectElement = xElement.AsProject();

            var projectFile = new ProjectFileModel(projectElement);

            projectElement.ProjectFile = projectFile;

            return projectFile;
        }

        public static ProjectFileModel FromFile(string projectFilePath)
        {
            var xElement = XElement.Load(projectFilePath);

            var projectFile = ProjectFileModel.FromXElement(xElement);
            return projectFile;
        }

        public static ProjectFileModel Load(string projectFilePath)
        {
            var projectFile = ProjectFileModel.FromFile(projectFilePath);
            return projectFile;
        }

        public static ProjectFileModel FromXmlNode(XmlNode xmlNode)
        {
            var xElement = xmlNode.ToXElement();

            var projectFile = ProjectFileModel.FromXElement(xElement);
            return projectFile;
        }

        public static ProjectFileModel FromXmlDocument(XmlDocument xmlDocument)
        {
            var projectFile = ProjectFileModel.FromXmlNode(xmlDocument);
            return projectFile;
        }

        public static ProjectFileModel New(string sdkValue = ProjectFileXmlValues.MicrosoftNetSDK)
        {
            var projectElement = ProjectXElementOperations.CreateProjectElement(sdkValue);

            var projectFile = ProjectFileModel.FromXElement(projectElement);
            return projectFile;
        }

        public static ProjectFileModel NewNetStandardLibrary()
        {
            var projectFile = ProjectFileModel.New()
                .AcquirePropertyGroup()
                    .SetTargetFramework(TargetFramework.NetStandard_2_0)
                    .SetVersion(Version.Parse("0.0.1"))
                    .SetGenerateDocumentationFile(true)
                    .SetNoWarnStandard()
                .ProjectFile()
                ;

            return projectFile;
        }

        #endregion


        public ProjectXElement ProjectElement { get; }


        public ProjectFileModel(ProjectXElement projectElement)
        {
            this.ProjectElement = projectElement;
        }
    }
}
