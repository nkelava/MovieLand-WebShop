﻿using MovieLand.Domain.Entities;
using MovieLand.Domain.Interfaces.Repositories.Base;
using System.Threading.Tasks;


namespace MovieLand.Domain.Interfaces.Repositories
{
    public interface IRepository : IRepository<Cart>
    {
        Task<Cart> GetByUsernameAsync(string username);
    }
}
