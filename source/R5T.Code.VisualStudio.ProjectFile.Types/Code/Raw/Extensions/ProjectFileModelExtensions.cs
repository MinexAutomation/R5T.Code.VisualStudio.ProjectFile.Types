using System;
using System.Collections.Generic;
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

        public static bool HasPackageReferenceItemGroup(this ProjectFileModel projectFile)
        {
            var output = projectFile.ProjectElement.Value.Elements()
                .Where(x => ProjectFileModelExtensions.IsPackageReferenceItemGroup(x))
                .Any();
            return output;
        }

        public static PackageReferenceItemGroupXElement GetPackageReferenceItemGroup(this ProjectFileModel projectFile)
        {
            var output = projectFile.ProjectElement.Value.Elements()
                .Where(x => ProjectFileModelExtensions.IsPackageReferenceItemGroup(x))
                .Single()
                .AsPackageReferenceItemGroup();
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

        public static bool HasProjectReferenceItemGroup(this ProjectFileModel projectFile)
        {
            var output = projectFile.ProjectElement.Value.Elements()
                .Where(x => ProjectFileModelExtensions.IsProjectReferenceItemGroup(x))
                .Any();
            return output;
        }

        public static ProjectReferenceItemGroupXElement GetProjectReferenceItemGroup(this ProjectFileModel projectFile)
        {
            var output = projectFile.ProjectElement.Value.Elements()
                .Where(x => ProjectFileModelExtensions.IsProjectReferenceItemGroup(x))
                .Single()
                .AsProjectReferenceItemGroup();
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

        public static bool IsPropertyGroup(XElement xElement)
        {
            var output = xElement.Name == ProjectFileXmlElementNames.PropertyGroup;
            return output;
        }

        public static bool HasPropertyGroup(this ProjectFileModel projectFile)
        {
            var output = projectFile.ProjectElement.Value.Elements()
                .Where(x => ProjectFileModelExtensions.IsPropertyGroup(x))
                .Any();
            return output;
        }

        public static PropertyGroupXElement GetPropertyGroup(this ProjectFileModel projectFile)
        {
            var output = projectFile.ProjectElement.Value.Elements()
                .Where(x => ProjectFileModelExtensions.IsPropertyGroup(x))
                .Single()
                .AsPropertyGroup();
            return output;
        }

        public static PropertyGroupXElement AcquirePropertyGroup(this ProjectFileModel projectFile)
        {
            var propertyGroup = projectFile.ProjectElement.Value.AcquireElement(ProjectFileXmlElementNames.PropertyGroup).AsPropertyGroup();

            propertyGroup.ProjectElement = projectFile.ProjectElement;

            return propertyGroup;
        }

        public static bool HasProperty(this ProjectFileModel projectFile, string propertyElementName)
        {
            var hasPropertyGroup = projectFile.HasPropertyGroup();
            if(!hasPropertyGroup)
            {
                return false;
            }

            var propertyGroup = projectFile.GetPropertyGroup();

            var output = propertyGroup.HasProperty(propertyElementName);
            return output;
        }

        public static bool HasProperty(this ProjectFileModel projectFile, XmlNodeName propertyName)
        {
            var output = projectFile.HasProperty(propertyName.Value);
            return output;
        }

        public static void SetPropertyValue(this ProjectFileModel projectFile, string propertyElementName, string value)
        {
            projectFile.AcquirePropertyGroup().SetPropertyValue(propertyElementName, value);
        }

        public static void SetPropertyValue(this ProjectFileModel projectFile, XmlNodeName propertyName, string value)
        {
            projectFile.SetPropertyValue(propertyName.Value, value);
        }

        public static string GetPropertyValue(this ProjectFileModel projectFile, string propertyElementName)
        {
            var value = projectFile.GetPropertyGroup().GetPropertyValue(propertyElementName);
            return value;
        }

        public static string GetPropertyValue(this ProjectFileModel projectFile, XmlNodeName propertyName)
        {
            var value = projectFile.GetPropertyValue(propertyName.Value);
            return value;
        }

        public static Version GetVersion(this ProjectFileModel projectFile)
        {
            var versionStr = projectFile.GetPropertyValue(ProjectFileXmlElementNames.Version);

            var version = Version.Parse(versionStr);
            return version;
        }

        public static void SetVersion(this ProjectFileModel projectFile, Version version)
        {
            var versionString = version.ToStringProjectFileStandard();

            projectFile.SetPropertyValue(ProjectFileXmlElementNames.Version, versionString);
        }

        public static ProjectFileModel AddPackageReference(this ProjectFileModel projectFile, string packageName, Version packageVersion)
        {
            var packageReferenceItemGroup = projectFile.AcquirePackageReferenceItemGroup();

            packageReferenceItemGroup.AddPackageReference(packageName, packageVersion);

            return projectFile;
        }

        public static ProjectFileModel RemovePackageReference(this ProjectFileModel projectFile, string packageName)
        {
            var packageReferenceItemGroup = projectFile.AcquirePackageReferenceItemGroup();

            packageReferenceItemGroup.RemovePackageReference(packageName);

            return projectFile;
        }

        public static IEnumerable<Tuple<string, Version>> GetPackageReferences(this ProjectFileModel projectFile)
        {
            if(projectFile.HasPackageReferenceItemGroup())
            {
                var packageReferenceItemGroup = projectFile.GetPackageReferenceItemGroup();

                var packageReferences = packageReferenceItemGroup.GetPackageReferences();
                return packageReferences;
            }
            else
            {
                return Enumerable.Empty<Tuple<string, Version>>();
            }
        }

        public static void SetPackageReferenceVersion(this ProjectFileModel projectFile, string packageName, Version packageVersion)
        {
            var packageReferenceItemGroup = projectFile.AcquirePackageReferenceItemGroup();

            packageReferenceItemGroup.SetPackageReferenceVersion(packageName, packageVersion);
        }

        public static ProjectFileModel AddProjectReference(this ProjectFileModel projectFile, string projectFileRelativeProjectFilePath)
        {
            var projectReferenceItemGroup = projectFile.AcquireProjectReferenceItemGroup();

            projectReferenceItemGroup.AddProjectReference(projectFileRelativeProjectFilePath);

            return projectFile;
        }

        public static IEnumerable<string> GetProjectReferences(this ProjectFileModel projectFile)
        {
            if (projectFile.HasProjectReferenceItemGroup())
            {
                var projectReferenceItemGroup = projectFile.GetProjectReferenceItemGroup();

                var projectReferences = projectReferenceItemGroup.GetProjectReferences();
                return projectReferences;
            }
            else
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}
