using Microsoft.AspNetCore.Http;
using PostsAPI.Application.Interfaces;
using System;
using System.Security.Claims;

namespace PostsAPI.Application.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            try
            {
                return _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
