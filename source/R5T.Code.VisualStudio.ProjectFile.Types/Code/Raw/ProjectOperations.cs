using System;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class ProjectOperations
    {
        public static PropertyGroupXElement AddPropertyGroup(ProjectFileModel projectFile)
        {
            var propertyGroup = projectFile.ProjectElement.Value.AddElement(ProjectFileXmlElementNames.PropertyGroup).AsPropertyGroup();
            return propertyGroup;
        }
    }
}
