using System;

using R5T.NetStandard.Xml;
using R5T.NetStandard.Xml.Extensions;


namespace R5T.Code.VisualStudio
{
    public static class ProjectFileXmlElementNames
    {
        public static readonly XmlNodeName GenerateAssemblyInfo = "GenerateAssemblyInfo".AsXmlNodeName();
        public static readonly XmlNodeName GenerateDocumentationFile = "GenerateDocumentationFile".AsXmlNodeName();
        public static readonly XmlNodeName ItemGroup = "ItemGroup".AsXmlNodeName();
        public static readonly XmlNodeName IsPackable = "IsPackable".AsXmlNodeName();
        public static readonly XmlNodeName LangVersion = "LangVersion".AsXmlNodeName();
        public static readonly XmlNodeName NoWarn = "NoWarn".AsXmlNodeName();
        public static readonly XmlNodeName OutputType = "OutputType".AsXmlNodeName();
        public static readonly XmlNodeName PackageReference = "PackageReference".AsXmlNodeName();
        public static readonly XmlNodeName Project = "Project".AsXmlNodeName();
        public static readonly XmlNodeName ProjectReference = "ProjectReference".AsXmlNodeName();
        public static readonly XmlNodeName PropertyGroup = "PropertyGroup".AsXmlNodeName();
        public static readonly XmlNodeName TargetFramework = "TargetFramework".AsXmlNodeName();
        public static readonly XmlNodeName Version = "Version".AsXmlNodeName();
    }
}
