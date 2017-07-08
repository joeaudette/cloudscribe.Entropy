// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2017-07-08
// Last Modified:			2017-07-08
// 

using cloudscribe.Core.Models;
using cloudscribe.UserProperties.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace cloudscribe.UserProperties.Services
{
    public class TenantProfileOptionsResolver
    {
        public TenantProfileOptionsResolver(
            SiteContext currentSite,
            IOptions<ProfilePropertySetContainer> containerAccessor
            )
        {
            this.currentSite = currentSite;
            container = containerAccessor.Value;
        }

        private SiteContext currentSite;
        private ProfilePropertySetContainer container;

        public UserPropertySet GetProfileProps()
        {
            foreach(var s in container.PropertySets)
            {
                if(s.TenantId == currentSite.Id.ToString()) { return s; }
            }

            return new UserPropertySet();
        }
    }
}
