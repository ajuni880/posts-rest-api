using PostsAPI.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostsAPI.Application.Interfaces
{
    public interface IIdentityService
    {
        Task CreateUserAsync(AuthDto authDto);
        Task<string> LogInAsync(AuthDto authDto);
    }
}
