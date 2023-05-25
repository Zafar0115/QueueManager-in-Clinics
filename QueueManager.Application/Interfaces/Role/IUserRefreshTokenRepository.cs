﻿using QueueManager.Application.Interfaces.common;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.Interfaces.role
{
    public interface IUserRefreshTokenRepository:IGenericRepository<UserRefreshToken>
    {
    }
}