﻿using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IMediator _mediator;


        #endregion


        #region constructors


        protected BaseCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        #endregion


        #region Protected Methods





        protected async Task PublishValidationErrorAsync(BaseCommand message)
        {
            foreach (var error in message.ValidationResult.Errors)
                await _mediator.Publish(new DomainNotification(error.PropertyName, error.ErrorMessage));
        }



        protected async Task PublishValidationErrorAsync(DomainNotification message)
        {
            await _mediator.Publish(message);
        }



        #endregion
    }
}