using System;
using System.Xml.Linq;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public class ProjectXElement : TypedXElement
    {
        public ProjectFileModel ProjectFile { get; set; }


        public ProjectXElement(XElement value)
            : base(value)
        {
        }
    }
}
