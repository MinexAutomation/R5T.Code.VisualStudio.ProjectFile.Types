using System;

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

        public static PropertyGroupXElement AddTargetFramework(this PropertyGroupXElement propertyGroup, TargetFramework targetFramework, out TypedXElement targetFrameworkElement)
        {
            var standardString = targetFramework.ToStringStandard();

            targetFrameworkElement = propertyGroup.Value.AddElement(ProjectFileXmlElementNames.TargetFramework, standardString).AsGeneralXElement();

            return propertyGroup;
        }

        public static PropertyGroupXElement AddTargetFramework(this PropertyGroupXElement propertyGroup, TargetFramework targetFramework)
        {
            propertyGroup.AddTargetFramework(targetFramework, out var dummy);
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
            var standardString = version.ToString();

            propertyGroup.Value.AcquireElement(ProjectFileXmlElementNames.Version, standardString);

            return propertyGroup;
        }
    }
}
