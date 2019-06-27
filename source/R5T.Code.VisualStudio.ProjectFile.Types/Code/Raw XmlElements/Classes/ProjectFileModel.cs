using System;
using System.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw.XmlElements
{
    /// <summary>
    /// Represents a Visual Studio project file.
    /// </summary>
    /// <remarks>
    /// Built around an in-memory <see cref="System.Xml.XmlDocument"/> and allows using XML-related functions on the XML document project file content.
    /// </remarks>
    public class ProjectFileModel
    {
        #region Static

        public static ProjectFileModel FromXmlDocument(XmlDocument xmlDocument)
        {
            var projectFile = new ProjectFileModel(xmlDocument);
            return projectFile;
        }

        public static ProjectFileModel NewEmpty()
        {
            var emptyXmlDocument = new XmlDocument();

            var projectFile = ProjectFileModel.FromXmlDocument(emptyXmlDocument);
            return projectFile;
        }

        #endregion


        public XmlDocument XmlDocument { get; }


        private ProjectFileModel(XmlDocument xmlDocument)
        {
            this.XmlDocument = xmlDocument;
        }
    }
}
