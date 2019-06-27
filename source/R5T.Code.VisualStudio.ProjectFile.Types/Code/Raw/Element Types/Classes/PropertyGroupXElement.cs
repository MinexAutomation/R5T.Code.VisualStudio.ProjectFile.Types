using System;
using System.Xml.Linq;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public class PropertyGroupXElement : TypedXElement
    {
        public ProjectXElement ProjectElement { get; set; }


        public PropertyGroupXElement(XElement value)
            : base(value)
        {
        }
    }
}
