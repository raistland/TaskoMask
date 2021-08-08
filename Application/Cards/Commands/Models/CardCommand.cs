﻿using TaskoMask.Application.Core.Helpers;
using MediatR;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Cards.Commands.Models
{
  
    public abstract class CardCommand : BaseCommand
    {

        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Name { get; protected set; }


        [StringLength(250, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Description { get; protected set; }
       
        
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public CardType Type { get; protected set; }
        

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string BoardId { get; protected set; }
    }
}
