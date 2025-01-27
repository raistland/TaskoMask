﻿using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{

    internal class ProjectNameMustUniqueSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            foreach (var organization in owner.Organizations)
            {
                var projectsCount = organization.Projects.Count;
                if (projectsCount < 2)
                    continue;

                var distincprojectsCount = organization.Projects.Select(p => p.Name).Distinct().Count();
                if (distincprojectsCount != projectsCount)
                    return false;
            }

            return true;
        }
    }
}
