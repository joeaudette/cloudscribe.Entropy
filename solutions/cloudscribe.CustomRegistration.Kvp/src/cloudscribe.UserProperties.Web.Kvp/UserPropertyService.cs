// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2017-07-10
// Last Modified:			2017-07-10
//

using cloudscribe.Kvp.Models;
using cloudscribe.UserProperties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudscribe.UserProperties.Web.Kvp
{
    public class UserPropertyService : IUserPropertyService
    {
        public UserPropertyService(
            IKvpStorageService kvpStorage
            )
        {
            _kvpStorage = kvpStorage;
        }

        private IKvpStorageService _kvpStorage;

        //public async Task<UserProperty> FetchByKey(string siteId, string userId, string key)
        //{
        //    var kvp = await _kvpStorage.FetchByKey(
        //        siteId, //projectid
        //        key,
        //        "*", // featureId
        //        siteId, // setId
        //        userId //subSetId
        //        ).ConfigureAwait(false);

        //    if (kvp == null) return null;

        //    var prop = new UserProperty();
        //    prop.CreatedUtc = kvp.CreatedUtc;
        //    prop.Key = kvp.Key;
        //    prop.ModifiedUtc = kvp.ModifiedUtc;
        //    prop.SiteId = kvp.SetId;
        //    prop.UserId = kvp.SubSetId;
        //    prop.Value = kvp.Value;

        //    return prop;
        //}

        public async Task<List<UserProperty>> FetchByUser(string siteId, string userId)
        {
            var result = new List<UserProperty>();

            var kvpList = await _kvpStorage.FetchById(
                siteId, //projectId
                "*", // featureId
                siteId, //setId
                userId // subSetId
                ).ConfigureAwait(false);
            
            foreach (var kvp in kvpList)
            {
                var prop = new UserProperty();
                prop.CreatedUtc = kvp.CreatedUtc;
                prop.Key = kvp.Key;
                prop.ModifiedUtc = kvp.ModifiedUtc;
                prop.SiteId = kvp.SetId;
                prop.UserId = kvp.SubSetId;
                prop.Value = kvp.Value;

                result.Add(prop);
            }
            
            return result;
        }

        public async Task CreateOrUpdate(string siteId, string userId, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(siteId)) throw new ArgumentException("siteid must be provided");
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentException("userId must be provided");
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("key must be provided");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("value must be provided");

            var kvpList = await _kvpStorage.FetchById(
                siteId, //projectId
                "*", // featureId
                siteId, //setId
                userId // subSetId
                ).ConfigureAwait(false);

            var foundKvp = kvpList.Where(x => x.Key == key).FirstOrDefault();
            if(foundKvp != null)
            {
                foundKvp.Value = value;
                foundKvp.ModifiedUtc = DateTime.UtcNow;
                await _kvpStorage.Update(
                    siteId,
                    foundKvp).ConfigureAwait(false);
            }
            else
            {
                var kvp = new KvpItem();
                kvp.Key = key;
                kvp.Value = value;
                kvp.SetId = siteId;
                kvp.SubSetId = userId;

                await _kvpStorage.Create(
                    siteId,
                    foundKvp).ConfigureAwait(false);
            }
        }
    }
}
