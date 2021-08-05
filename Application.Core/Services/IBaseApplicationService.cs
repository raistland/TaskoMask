﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Core.Services
{
    public interface IBaseApplicationService
    {
        Task<Result<CommandResult>> SendCommandAsync<T>(T cmd) where T : BaseCommand;
        Task<Result<T>> SendQueryAsync<T>(IRequest<T> query);
    }
}