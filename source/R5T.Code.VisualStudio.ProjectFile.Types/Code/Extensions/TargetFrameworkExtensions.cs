using System;

using R5T.NetStandard;

using R5T.Code.VisualStudio.ProjectFile.Types;


namespace R5T.Code.VisualStudio.ProjectFile
{
    public static class TargetFrameworkExtensions
    {
        public static string ToStringStandard(this TargetFramework targetFramework)
        {
            var standardString = Utilities.ToStringStandard(targetFramework);
            return standardString;
        }
    }
}
