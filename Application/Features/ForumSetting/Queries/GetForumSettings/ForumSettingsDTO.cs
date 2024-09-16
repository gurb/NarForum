using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ForumSetting.Queries.GetForumSettings
{
    public class ForumSettingsDTO
    {
        public Guid? Id { get; set; }
        public string? ForumUrl { get; set; }
    }
}
