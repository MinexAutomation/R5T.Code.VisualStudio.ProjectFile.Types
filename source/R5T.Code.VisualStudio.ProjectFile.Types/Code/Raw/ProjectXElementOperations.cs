using System;
using System.Xml.Linq;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class ProjectXElementOperations
    {
        public static XAttribute CreateSdkAttribute(string sdkValue = ProjectFileXmlValues.MicrosoftNetSDK)
        {
            var sdkAttribute = new XAttribute(ProjectFileXmlAttributeNames.Sdk, sdkValue);
            return sdkAttribute;
        }

        public static XElement CreateProjectElement(string sdkValue = ProjectFileXmlValues.MicrosoftNetSDK)
        {
            var projectElement = new XElement(ProjectFileXmlElementNames.Project, ProjectXElementOperations.CreateSdkAttribute(sdkValue));
            return projectElement;
        }

        public static XElement CreatePropertyGroupElement()
        {
            var propertyGroup = new XElement(ProjectFileXmlElementNames.PropertyGroup);
            return propertyGroup;
        }
    }
}
