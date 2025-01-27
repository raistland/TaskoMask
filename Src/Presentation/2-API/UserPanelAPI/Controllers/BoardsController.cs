﻿using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BoardsController : BaseApiController, IBoardClientService
    {
        #region Fields

        private readonly IBoardService _boardService;

        #endregion

        #region Ctors

        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get board detail
        /// </summary>
        [HttpGet]
        [Route("boards/{id}")]
        public async Task<Result<BoardBasicInfoDto>> Get(string id)
        {
            return await _boardService.GetByIdAsync(id);
        }



        /// <summary>
        /// create new board
        /// </summary>
        [HttpPost]
        [Route("boards")]
        public async Task<Result<CommandResult>> Create([FromBody] BoardUpsertDto input)
        {
            return await _boardService.CreateAsync(input);
        }



        /// <summary>
        /// update existing board
        /// </summary>
        [HttpPut]
        [Route("boards")]
        public async Task<Result<CommandResult>> Update([FromBody] BoardUpsertDto input)
        {
            return await _boardService.UpdateAsync(input);
        }




        /// <summary>
        /// soft delete board
        /// </summary>
        [HttpDelete]
        [Route("boards")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _boardService.DeleteAsync(id);
        }




        #endregion

    }
}
