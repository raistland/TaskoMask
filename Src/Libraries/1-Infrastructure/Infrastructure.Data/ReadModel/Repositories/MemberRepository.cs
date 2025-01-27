﻿using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        #region Fields

        private readonly IMongoCollection<Member> _members;

        #endregion

        #region Ctors

        public MemberRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _members = dbContext.GetCollection<Member>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Member>> GetListByBoardIdAsync(string boardId)
        {
            return await _members.AsQueryable().Where(o => o.BoardId == boardId).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Member>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _members.AsQueryable().Where(o => o.OrganizationId == organizationId).ToListAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
