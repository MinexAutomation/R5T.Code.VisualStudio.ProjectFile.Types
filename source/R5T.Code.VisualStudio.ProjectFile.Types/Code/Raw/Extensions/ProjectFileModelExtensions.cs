using System;
using System.Linq;
using System.Xml.Linq;

using R5T.NetStandard.Extensions;
using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class ProjectFileModelExtensions
    {
        public static void Save(this ProjectFileModel projectFile, string projectFilePath)
        {
            ProjectFileSerialization.Serialize(projectFilePath, projectFile);
        }

        public static bool IsPackageReferenceItemGroup(XElement xElement)
        {
            var output =
                xElement.Name == ProjectFileXmlElementNames.ItemGroup &&
                xElement.HasElement(ProjectFileXmlElementNames.PackageReference);

            return output;
        }

        public static PackageReferenceItemGroupXElement AcquirePackageReferenceItemGroup(this ProjectFileModel projectFile)
        {
            var projectXElement = projectFile.ProjectElement.Value;

            var packageReferenceItemGroup = projectXElement.Elements()
                    .AcquireSingle(
                        (x) => ProjectFileModelExtensions.IsPackageReferenceItemGroup(x),
                        () => projectXElement.AddElement(ProjectFileXmlElementNames.ItemGroup))
                    .AsPackageReferenceItemGroup(projectFile)
                    ;

            return packageReferenceItemGroup;
        }

        public static bool IsProjectReferenceItemGroup(XElement xElement)
        {
            var output =
                xElement.Name == ProjectFileXmlElementNames.ItemGroup &&
                xElement.HasElement(ProjectFileXmlElementNames.ProjectReference);

            return output;
        }

        public static ProjectReferenceItemGroupXElement AcquireProjectReferenceItemGroup(this ProjectFileModel projectFile)
        {
            var projectXElement = projectFile.ProjectElement.Value;

            var projectReferenceItemGroup = projectXElement.Elements()
                    .AcquireSingle(
                        (x) => ProjectFileModelExtensions.IsProjectReferenceItemGroup(x),
                        () => projectXElement.AddElement(ProjectFileXmlElementNames.ItemGroup))
                    .AsProjectReferenceItemGroup(projectFile)
                    ;

            return projectReferenceItemGroup;
        }

        public static PropertyGroupXElement AcquirePropertyGroup(this ProjectFileModel projectFile)
        {
            var propertyGroup = projectFile.ProjectElement.Value.AcquireElement(ProjectFileXmlElementNames.PropertyGroup).AsPropertyGroup();

            propertyGroup.ProjectElement = projectFile.ProjectElement;

            return propertyGroup;
        }

        public static ProjectFileModel AddPackageReference(this ProjectFileModel projectFile, string packageName, Version packageVersion)
        {
            var packageReferenceItemGroup = projectFile.AcquirePackageReferenceItemGroup();

            packageReferenceItemGroup.AddPackageReference(packageName, packageVersion);

            return projectFile;
        }

        public static ProjectFileModel AddProjectReference(this ProjectFileModel projectFile, string projectFileRelativeProjectFilePath)
        {
            var projectReferenceItemGroup = projectFile.AcquireProjectReferenceItemGroup();

            projectReferenceItemGroup.AddProjectReference(projectFileRelativeProjectFilePath);

            return projectFile;
        }
    }
}
