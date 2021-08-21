﻿using MongoDB.Driver;
using System.Threading.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class UserBaseRepository<TEntity> : BaseRepository<TEntity>, IUserBaseRepository<TEntity> where TEntity:User
    {

        #region Fields

        private readonly IMongoCollection<User> _users;


        #endregion

        #region Ctors

        public UserBaseRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.GetCollection<User>(); 

        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> GetByUserNameAsync(string userName)
        {
            return await _users.OfType<TEntity>().Find(e => e.UserName == userName).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _users.OfType<TEntity>().Find(e => e.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }



        #endregion

        #region Private Methods



        #endregion
    }
}