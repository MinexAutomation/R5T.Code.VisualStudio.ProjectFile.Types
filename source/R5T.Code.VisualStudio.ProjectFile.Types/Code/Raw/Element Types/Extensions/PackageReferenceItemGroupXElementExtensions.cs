using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class PackageReferenceItemGroupXElementExtensions
    {
        public static bool HasPackageReference(this PackageReferenceItemGroupXElement packageReferenceItemGroup, string packageName, Version packageVersion)
        {
            var versionString = packageVersion.ToStringProjectFileStandard();

            var output = packageReferenceItemGroup.Value.Elements(ProjectFileXmlElementNames.PackageReference)
                .Where(x => x.Attributes(ProjectFileXmlAttributeNames.Include).Where(y => y.Value == packageName).Any() &&
                    x.Attributes(ProjectFileXmlAttributeNames.Version).Where(y => y.Value == versionString).Any())
                .Any();
            return output;
        }

        public static PackageReferenceItemGroupXElement AddPackageReference(this PackageReferenceItemGroupXElement packageReferenceItemGroup, string packageName, Version packageVersion, out XElement packageReferenceXElement)
        {
            var versionStandardString = packageVersion.ToString();

            packageReferenceXElement = packageReferenceItemGroup.Value.AddElement(ProjectFileXmlElementNames.PackageReference)
                .AddContents(
                    new XAttribute(ProjectFileXmlAttributeNames.Include, packageName),
                    new XAttribute(ProjectFileXmlAttributeNames.Version, versionStandardString))
                ;

            return packageReferenceItemGroup;
        }

        public static PackageReferenceItemGroupXElement AddPackageReference(this PackageReferenceItemGroupXElement packageReferenceItemGroup, string packageName, Version packageVersion)
        {
            packageReferenceItemGroup.AddPackageReference(packageName, packageVersion, out var dummy);

            return packageReferenceItemGroup;
        }

        public static IEnumerable<Tuple<string, Version>> GetPackageReferences(this PackageReferenceItemGroupXElement projectReferenceItemGroup)
        {
            foreach (var projectReferenceElement in projectReferenceItemGroup.Value.Elements().Where(x => x.Name == ProjectFileXmlElementNames.PackageReference))
            {
                var packageName = projectReferenceElement.Attribute(ProjectFileXmlAttributeNames.Include).Value;
                var packageVersionStr = projectReferenceElement.Attribute(ProjectFileXmlAttributeNames.Version).Value;
                var packageVersion = Version.Parse(packageVersionStr);

                yield return Tuple.Create(packageName, packageVersion);
            }
        }

        public static void SetPackageReferenceVersion(this PackageReferenceItemGroupXElement packageReferenceItemGroup, string packageName, Version packageVersion)
        {
            var versionString = packageVersion.ToStringProjectFileStandard();

            var packageReference = packageReferenceItemGroup.Value.Elements()
                .Where(x => x.Name == ProjectFileXmlElementNames.PackageReference &&
                    x.Attributes().Where(y => y.Name == ProjectFileXmlAttributeNames.Include && y.Value == packageName).Any())
                .Single();

            packageReference.Attribute(ProjectFileXmlAttributeNames.Version).Value = versionString;
        }

        public static void RemovePackageReference(this PackageReferenceItemGroupXElement packageReferenceItemGroup, string packageName)
        {
            var packageReferenceElement = packageReferenceItemGroup.Value.Elements(ProjectFileXmlElementNames.PackageReference)
                .Where(x => x.Attributes(ProjectFileXmlAttributeNames.Include).Where(y => y.Value == packageName).Any())
                .Single();

            packageReferenceElement.Remove();
        }
    }
}