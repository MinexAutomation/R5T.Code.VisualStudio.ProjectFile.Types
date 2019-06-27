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

        public static PackageReferenceItemGroupXElement AsPackageReferenceItemGroup(this XElement xElement, ProjectXElement projectElement)
        {
            var packageReferenceItemGroup = xElement.AsPackageReferenceItemGroup();

            packageReferenceItemGroup.ProjectElement = projectElement;

            return packageReferenceItemGroup;
        }

        public static PackageReferenceItemGroupXElement AsPackageReferenceItemGroup(this XElement xElement, ProjectFileModel projectFile)
        {
            var packageReferenceItemGroup = xElement.AsPackageReferenceItemGroup(projectFile.ProjectElement);
            return packageReferenceItemGroup;
        }

        public static ProjectReferenceItemGroupXElement AsProjectReferenceItemGroup(this XElement xElement)
        {
            var projectReferenceItemGroup = new ProjectReferenceItemGroupXElement(xElement);
            return projectReferenceItemGroup;
        }

        public static ProjectReferenceItemGroupXElement AsProjectReferenceItemGroup(this XElement xElement, ProjectXElement projectElement)
        {
            var projectReferenceItemGroup = xElement.AsProjectReferenceItemGroup();

            projectReferenceItemGroup.ProjectElement = projectElement;

            return projectReferenceItemGroup;
        }

        public static ProjectReferenceItemGroupXElement AsProjectReferenceItemGroup(this XElement xElement, ProjectFileModel projectFile)
        {
            var projectReferenceItemGroup = xElement.AsProjectReferenceItemGroup(projectFile.ProjectElement);
            return projectReferenceItemGroup;
        }

        public static ProjectXElement AsProject(this XElement xElement)
        {
            var project = new ProjectXElement(xElement);
            return project;
        }

        public static ProjectXElement AsProject(this XElement xElement, ProjectFileModel projectFile)
        {
            var projectElement = xElement.AsProject();

            projectElement.ProjectFile = projectFile;

            return projectElement;
        }

        public static PropertyGroupXElement AsPropertyGroup(this XElement xElement)
        {
            var propertyGroup = new PropertyGroupXElement(xElement);
            return propertyGroup;
        }

        public static PropertyGroupXElement AsPropertyGroup(this XElement xElement, ProjectXElement projectElement)
        {
            var propertyGroup = xElement.AsPropertyGroup();

            propertyGroup.ProjectElement = projectElement;

            return propertyGroup;
        }

        public static PropertyGroupXElement AsPropertyGroup(this XElement xElement, ProjectFileModel projectFile)
        {
            var propertyGroup = xElement.AsPropertyGroup(projectFile.ProjectElement);
            return propertyGroup;
        }
    }
}
