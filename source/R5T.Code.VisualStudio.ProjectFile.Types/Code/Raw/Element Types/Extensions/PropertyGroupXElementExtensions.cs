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
    }
}
