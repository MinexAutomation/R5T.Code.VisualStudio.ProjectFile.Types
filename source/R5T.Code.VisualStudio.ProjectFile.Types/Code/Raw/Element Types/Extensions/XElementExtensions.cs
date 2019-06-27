using System;
using System.Xml.Linq;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class XElementExtensions
    {
        public static PackageReferenceItemGroupXElement AsPackageReferenceItemGroup(this XElement xElement)
        {
            var packageReferenceItemGroup = new PackageReferenceItemGroupXElement(xElement);
            return packageReferenceItemGroup;
        }

        public static ProjectReferenceItemGroupXElement AsProjectReferenceItemGroup(this XElement xElement)
        {
            var projectReferenceItemGroup = new ProjectReferenceItemGroupXElement(xElement);
            return projectReferenceItemGroup;
        }

        public static ProjectXElement AsProject(this XElement xElement)
        {
            var project = new ProjectXElement(xElement);
            return project;
        }

        public static PropertyGroupXElement AsPropertyGroup(this XElement xElement)
        {
            var propertyGroup = new PropertyGroupXElement(xElement);
            return propertyGroup;
        }
    }
}
