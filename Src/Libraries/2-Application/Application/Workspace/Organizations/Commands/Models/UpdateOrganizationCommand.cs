﻿using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Models
{
    public class UpdateOrganizationCommand : OrganizationBaseCommand
    {
        public UpdateOrganizationCommand(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get;}

    }
}