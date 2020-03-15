using System;
using System.Collections.Generic;
using System.Text;

namespace PostsAPI.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId);
    }
}
