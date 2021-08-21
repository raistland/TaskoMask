﻿using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Domain.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
   public class Operator :User
    {
        #region Fields


        #endregion

        #region Ctors

        public Operator(string displayName, string email, string userName, string password, IEncryptionService encryptionService)
        :base(displayName, email, userName, password,encryptionService)
        {
        
        }



        #endregion

        #region Properties

       

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public override void Update(string displayName, string email, string userName)
        {
            base.Update(displayName,email, userName);
        }


        #endregion

        #region Private Methods



        #endregion
    }
}