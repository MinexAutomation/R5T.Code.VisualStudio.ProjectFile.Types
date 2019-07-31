using System;
using System.Linq;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class PropertyGroupXElementExtensions
    {
        public static ProjectFileModel ProjectFile(this PropertyGroupXElement propertyGroup)
        {
            var projecFile = propertyGroup.ProjectElement.ProjectFile;
            return projecFile;
        }

        public static PropertyGroupXElement AddProperty(this PropertyGroupXElement propertyGroup, string propertyElementName, out TypedXElement element)
        {
            element = propertyGroup.Value.AddElement(propertyElementName).AsGeneralXElement();

            return propertyGroup;
        }

        public static PropertyGroupXElement AddProperty(this PropertyGroupXElement propertyGroup, string propertyElementName)
        {
            propertyGroup.AddProperty(propertyElementName, out var _);

            return propertyGroup;
        }

        public static PropertyGroupXElement AddProperty(this PropertyGroupXElement propertyGroup, string propertyElementName, string propertyElementValue)
        {
            propertyGroup.AddProperty(propertyElementName, out var propertyElement);

            propertyElement.Value.Value = propertyElementValue;

            return propertyGroup;
        }

        public static bool HasProperty(this PropertyGroupXElement propertyGroup, string propertyElementName)
        {
            var output = propertyGroup.Value.Elements()
                .Where(x => x.Name == propertyElementName)
                .Any();
            return output;
        }

        public static PropertyGroupXElement GetPropertyValue(this PropertyGroupXElement propertyGroup, string propertyElementName, out string value)
        {
            var element = propertyGroup.Value.Elements()
                .Where(x => x.Name == propertyElementName)
                .Single();

            value = element.Value;

            return propertyGroup;
        }

        public static string GetPropertyValue(this PropertyGroupXElement propertyGroup, string propertyElementName)
        {
            propertyGroup.GetPropertyValue(propertyElementName, out var value);

            return value;
        }

        public static PropertyGroupXElement SetPropertyValue(this PropertyGroupXElement propertyGroup, string propertyElementName, string value)
        {
            var element = propertyGroup.Value.AcquireElement(propertyElementName);

            element.Value = value;

            return propertyGroup;
        }

        public static PropertyGroupXElement AddTargetFramework(this PropertyGroupXElement propertyGroup, TargetFramework targetFramework, out TypedXElement targetFrameworkElement)
        {
            var standardString = targetFramework.ToStringStandard();

            targetFrameworkElement = propertyGroup.Value.AddElement(ProjectFileXmlElementNames.TargetFramework, standardString).AsGeneralXElement();

            return propertyGroup;
        }

        public static PropertyGroupXElement AddTargetFramework(this PropertyGroupXElement propertyGroup, TargetFramework targetFramework)
        {
            propertyGroup.AddTargetFramework(targetFramework, out var _);

            return propertyGroup;
        }

        public static PropertyGroupXElement SetTargetFramework(this PropertyGroupXElement propertyGroup, TargetFramework targetFramework)
        {
            var standardString = targetFramework.ToStringStandard();

            propertyGroup.Value.AcquireElement(ProjectFileXmlElementNames.TargetFramework, standardString);

            return propertyGroup;
        }

        public static PropertyGroupXElement SetGenerateDocumentationFile(this PropertyGroupXElement propertyGroup, bool generateDocumentationFile)
        {
            var standardString = generateDocumentationFile.ToString().ToLowerInvariant();

            propertyGroup.Value.AcquireElement(ProjectFileXmlElementNames.GenerateDocumentationFile, standardString);

            return propertyGroup;
        }

        public static PropertyGroupXElement SetNoWarnStandard(this PropertyGroupXElement propertyGroup)
        {
            propertyGroup.Value.AcquireElement(ProjectFileXmlElementNames.NoWarn, ProjectFileXmlValues.NoWarnStandard);

            return propertyGroup;
        }

        public static PropertyGroupXElement SetVersion(this PropertyGroupXElement propertyGroup, Version version)
        {
            var versionString = version.ToStringProjectFileStandard();

            propertyGroup.Value.AcquireElement(ProjectFileXmlElementNames.Version, versionString);

            return propertyGroup;
        }

        public static PropertyGroupXElement SetGenerateAssemblyInfo(this PropertyGroupXElement propertyGroup, bool generateAssemblyInfo)
        {
            var valueString = generateAssemblyInfo.ToString();

            propertyGroup.Value.AcquireElement(ProjectFileXmlElementNames.GenerateAssemblyInfo, valueString);

            return propertyGroup;
        }
    }
}
