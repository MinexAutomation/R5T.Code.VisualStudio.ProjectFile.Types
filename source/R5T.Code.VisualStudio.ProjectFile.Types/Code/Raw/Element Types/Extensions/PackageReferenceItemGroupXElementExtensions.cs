using System;
using System.Xml.Linq;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class PackageReferenceItemGroupXElementExtensions
    {
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
    }
}