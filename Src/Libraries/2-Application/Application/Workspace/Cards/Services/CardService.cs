﻿using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Cards.Commands.Models;
using TaskoMask.Application.Workspace.Cards.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Queries.Models.Boards;
using System.Collections.Generic;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Workspace.Projects.Queries.Models;
using TaskoMask.Application.Workspace.Organizations.Queries.Models;
using TaskoMask.Application.Workspace.Tasks.Queries.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;

namespace TaskoMask.Application.Workspace.Cards.Services
{
    public class CardService : ApplicationService, ICardService
    {
        #region Fields


        #endregion

        #region Ctors

        public CardService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { 

        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(CardUpsertDto input)
        {
            var cmd = new CreateCardCommand(boardId: input.BoardId, name: input.Name, description: input.Description, type: input.Type);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(CardUpsertDto input)
        {
            var cmd = new UpdateCardCommand(id: input.Id, name: input.Name, description: input.Description,type:input.Type);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CardDetailsViewModel>> GetDetailsAsync(string id)
        {
            var cardQueryResult = await SendQueryAsync(new GetCardByIdQuery(id));
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(cardQueryResult.Errors);


            var boardQueryResult = await SendQueryAsync(new GetBoardByIdQuery(cardQueryResult.Value.BoardId));
            if (!boardQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(boardQueryResult.Errors);


            var projectQueryResult = await SendQueryAsync(new GetProjectByIdQuery(boardQueryResult.Value.ProjectId));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(projectQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(projectQueryResult.Value.OrganizationId));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(organizationQueryResult.Errors);


            var cardReportQueryResult = await SendQueryAsync(new GetCardReportQuery(id));
            if (!cardReportQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(cardReportQueryResult.Errors);


            var taskQueryResult = await SendQueryAsync(new GetTasksByCardIdQuery(id));
            if (!taskQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(taskQueryResult.Errors);


            var cardDetail = new CardDetailsViewModel
            {
                Organization = organizationQueryResult.Value,
                Project = projectQueryResult.Value,
                Board = boardQueryResult.Value,
                Reports = cardReportQueryResult.Value,
                Card = cardQueryResult.Value,
                Tasks = taskQueryResult.Value,
            };

            return Result.Success(cardDetail);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CardBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetCardByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<CardBasicInfoDto>>> GetListByBoardIdAsync(string boardId)
        {
            return await SendQueryAsync(new GetCardsByBoardIdQuery(boardId));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CardReportDto>> GetReportAsync(string id)
        {
            return await SendQueryAsync(new GetCardReportQuery(id));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedListReturnType<CardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchCardsQuery(page, recordsPerPage, term));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetCardsCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteCardCommand(id);
            return await SendCommandAsync(cmd);
        }


        #endregion
    }
}
