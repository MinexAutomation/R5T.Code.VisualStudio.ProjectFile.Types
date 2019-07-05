using System;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class VersionExtensions
    {
        public static string ToStringProjectFileStandard(this Version version)
        {
            var versionString = version.ToString();
            return versionString;
        }
    }
}
