using System;
using System.Collections.Generic;
using System.Text;

namespace cloudscribe.UserProfile.Kvp.Web.Models
{
    public class UserPropertySet
    {
        public string TenantId { get; set; }

        public List<UserPropertyDefinition> Properties { get; set; }
    }
}
