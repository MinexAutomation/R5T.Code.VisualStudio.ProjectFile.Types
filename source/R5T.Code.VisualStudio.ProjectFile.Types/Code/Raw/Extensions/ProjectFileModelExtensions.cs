using System;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class ProjectFileModelExtensions
    {
        public static PropertyGroupXElement AddPropertyGroup(this ProjectFileModel projectFile)
        {
            var propertyGroup = ProjectOperations.AddPropertyGroup(projectFile);

            propertyGroup.ProjectElement = projectFile.ProjectElement;

            return propertyGroup;
        }
    }
}
