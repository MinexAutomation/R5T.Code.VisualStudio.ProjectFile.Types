using System;
using System.Xml;

using R5T.NetStandard;


namespace R5T.Code.VisualStudio.ProjectFile.Raw.XmlElements
{
    public abstract class TypedXmlElement : Typed<XmlElement>
    {
        public TypedXmlElement(XmlElement value)
            : base(value)
        {
        }
    }
}
