using System;

using R5T.NetStandard;


namespace R5T.Code.VisualStudio.ProjectFile.Types
{
    public static class Utilities
    {
        public static string ToStringStandard(TargetFramework targetFramework)
        {
            switch(targetFramework)
            {
                case TargetFramework.NetCoreApp_2_2:
                    return ProjectFileXmlValues.NetCoreApp_2_2;

                case TargetFramework.NetStandard_2_0:
                    return ProjectFileXmlValues.NetStandard_2_0;

                default:
                    throw new Exception(EnumHelper.UnexpectedEnumerationValueMessage(targetFramework));
            }
        }
    }
}
