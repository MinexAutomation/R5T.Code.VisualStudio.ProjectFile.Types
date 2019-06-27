using System;

using R5T.NetStandard.IO.Serialization;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public class ProjectFileSerializer : IFileSerializer<ProjectFileModel>
    {
        public ProjectFileModel Deserialize(string projectFilePath)
        {
            var projectFile = ProjectFileSerialization.Deserialize(projectFilePath);
            return projectFile;
        }

        public void Serialize(string projectFilePath, ProjectFileModel projectFile, bool overwrite = true)
        {
            ProjectFileSerialization.Serialize(projectFilePath, projectFile, overwrite);
        }
    }
}
