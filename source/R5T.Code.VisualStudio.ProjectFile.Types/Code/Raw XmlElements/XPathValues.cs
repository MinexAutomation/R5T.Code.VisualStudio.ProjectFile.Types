using System;


namespace R5T.Code.VisualStudio.ProjectFile.Raw.XmlElements
{
    public static class XPathValues
    {
        public const string ProjectElement = "//Project";

        public const string PropertyGroupElement = "//Project/PropertyGroup";
        public const string GenerateDocumentationFile = "//Project/PropertyGroup/GenerateDocumentationFile";
        public const string IsPackable = "//Project/PropertyGroup/IsPackable";
        public const string LangVersion = "//Project/PropertyGroup/LangVersion";
        public const string NoWarn = "//Project/PropertyGroup/NoWarn";
        public const string TargetFramework = "//Project/PropertyGroup/TargetFramework";
        public const string Version = "//Project/PropertyGroup/Version";

        public const string ItemGroupElement = "//Project/ItemGroup";
        public const string ProjectItemGroupElement = "//Project/ItemGroup[ProjectReference]";
        public const string ProjectReferenceElement = "//Project/ItemGroup/ProjectReference";
        public const string PackagesItemGroupElement = "//Project/ItemGroup[PackageReference]";
        public const string PackageReferenceElement = "//Project/ItemGroup/PackageReference";
    }
}
