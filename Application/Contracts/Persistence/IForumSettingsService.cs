using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IForumSettingsService
    {
        Task AddAsync(ForumSettings Entity);
        Task UpdateAsync(ForumSettings Entity);
        Task<ForumSettings?> GetAsync();
    }
}
