﻿using TaskoMask.Domain.Core.Models;


namespace TaskoMask.Domain.Ownership.Entities
{
    /// <summary>
    /// Roles to determine operator's access level
    /// </summary>
    public class Role : BaseEntity
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string[] PermissionsId { get; set; }
    }
}