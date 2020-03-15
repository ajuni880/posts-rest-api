using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAPI.Domain.Interfaces.Repos
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
