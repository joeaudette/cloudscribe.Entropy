using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cloudscribe.UserProperties.Models
{
    public interface IUserPropertyService
    {
        Task<List<UserProperty>> FetchByUser(string siteId, string userId);
        Task CreateOrUpdate(string siteId, string userId, string key, string value);
    }
}
