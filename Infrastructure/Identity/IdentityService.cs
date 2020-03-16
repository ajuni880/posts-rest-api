using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PostsAPI.Application.Dtos;
using PostsAPI.Application.Exceptions;
using PostsAPI.Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAPI.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> LogInAsync(AuthDto authDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == authDto.Email);
            var isValid = await _userManager.CheckPasswordAsync(user, authDto.Password);

            if (!isValid)
                return null;

            return user.Id;
        }

        public async Task CreateUserAsync(AuthDto authDto)
        {
            var user = new ApplicationUser
            {
                UserName = authDto.Email,
                Email = authDto.Email,
            };

            var result = await _userManager.CreateAsync(user, authDto.Password);

            if (!result.Succeeded)
            {
                throw new BadRequestException(result.Errors.Select(e => e.Description).ToList());
            }
        }

        public async Task<object> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return result;
        }
    }
}
