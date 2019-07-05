﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.NetStandard.Xml;


namespace R5T.Code.VisualStudio.ProjectFile.Raw
{
    public static class ProjectReferenceItemGroupXElementExtensions
    {
        public static ProjectReferenceItemGroupXElement AddProjectReference(this ProjectReferenceItemGroupXElement projectReferenceItemGroup, string projectFileRelativeProjectFilePath, out XElement projectReferenceXElement)
        {
            projectReferenceXElement = projectReferenceItemGroup.Value.AddElement(ProjectFileXmlElementNames.ProjectReference)
                .AddContents(new XAttribute(ProjectFileXmlAttributeNames.Include, projectFileRelativeProjectFilePath))
                ;

            return projectReferenceItemGroup;
        }

        public static ProjectReferenceItemGroupXElement AddProjectReference(this ProjectReferenceItemGroupXElement projectReferenceItemGroup, string projectFileRelativeProjectFilePath)
        {
            projectReferenceItemGroup.AddProjectReference(projectFileRelativeProjectFilePath, out var dummy);

            return projectReferenceItemGroup;
        }

        public static IEnumerable<string> GetProjectReferences(this ProjectReferenceItemGroupXElement projectReferenceItemGroup)
        {
            foreach (var projectReferenceElement in projectReferenceItemGroup.Value.Elements().Where(x => x.Name == ProjectFileXmlElementNames.ProjectReference))
            {
                yield return projectReferenceElement.Attribute(ProjectFileXmlAttributeNames.Include).Value;
            }
        }
    }
}
