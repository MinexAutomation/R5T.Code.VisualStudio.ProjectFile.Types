using System;
using System.Xml;

using R5T.Code.VisualStudio.ProjectFile.Types;
using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw.XmlElements
{
    public static class ProjectXmlElementOperations
    {
        public static bool HasProjectElement(XmlDocument projectDocument, out XmlElement projectElement)
        {
            var projectNode = projectDocument.SelectSingleNode(XPathValues.ProjectElement);

            projectElement = projectNode as XmlElement;

            var hasProjectNode = XmlHelper.SelectSingleNodeFound(projectNode);
            return hasProjectNode;
        }

        public static bool HasProjectElement(XmlDocument projectDocument)
        {
            var hasProjectNode = ProjectXmlElementOperations.HasProjectElement(projectDocument, out var dummy);
            return hasProjectNode;
        }

        public static XmlElement GetProjectElement(XmlDocument projectDocument)
        {
            var hasProjectNode = ProjectXmlElementOperations.HasProjectElement(projectDocument, out var projectElement);
            if(!hasProjectNode)
            {
                throw new Exception("Project document has no project node.");
            }

            return projectElement;
        }

        public static XmlElement AddProjectElement(XmlDocument projectDocument, string sdkValue = ProjectFileXmlValues.MicrosoftNetSDK)
        {
            var projectElement = projectDocument.CreateElement("Project");
            projectDocument.AppendChild(projectElement);

            var sdkAttribute = projectDocument.CreateAttribute("Sdk");
            projectElement.Attributes.Append(sdkAttribute);
            sdkAttribute.Value = sdkValue;

            return projectElement;
        }

        public static XmlElement AcquireProjectElement(XmlDocument projectDocument)
        {
            var hasProjectNode = ProjectXmlElementOperations.HasProjectElement(projectDocument, out var projectElement);
            if(hasProjectNode)
            {
                return projectElement;
            }

            projectElement = ProjectXmlElementOperations.AddProjectElement(projectDocument);
            return projectElement;
        }

        public static XmlElement AddPropertyGroupElement(XmlElement projectElement)
        {
            var propertyGroupElement = projectElement.OwnerDocument.CreateElement("PropertyGroup");
            projectElement.AppendChild(propertyGroupElement);

            return propertyGroupElement;
        }

        //public static XmlElement AddPropertyGroupElement(XmlDocument projectDocument)
        //{
        //    var projectElement = 
        //}
    }
}
