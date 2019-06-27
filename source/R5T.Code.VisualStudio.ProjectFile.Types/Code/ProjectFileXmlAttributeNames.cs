using System;

using R5T.NetStandard.Xml;
using R5T.NetStandard.Xml.Extensions;


namespace R5T.Code.VisualStudio.ProjectFile
{
    public static class ProjectFileXmlAttributeNames
    {
        public static readonly XmlNodeName Include = "Include".AsXmlNodeName();
        public static readonly XmlNodeName Sdk = "Sdk".AsXmlNodeName();
        public static readonly XmlNodeName Version = "Version".AsXmlNodeName();
    }
}
