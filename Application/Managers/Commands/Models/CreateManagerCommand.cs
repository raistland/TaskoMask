﻿
namespace TaskoMask.Application.Managers.Commands.Models
{
   public class CreateManagerCommand : ManagerCommand
    {
        public CreateManagerCommand(string displayName,string email,string password)
        {
            DisplayName = displayName;
            Email = email;
            Password = password;
        }


    }
}