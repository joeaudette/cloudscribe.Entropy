// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2017-07-10
// Last Modified:			2017-07-10
//

using cloudscribe.Core.Identity;
using cloudscribe.Core.Models;
using cloudscribe.Core.Web.ExtensionPoints;
using cloudscribe.Core.Web.ViewModels.Account;
using cloudscribe.UserProperties.Models;
using cloudscribe.UserProperties.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cloudscribe.UserProperties.Web.Kvp
{
    public class KvpUserInfoAdminHandler : IHandleCustomUserInfoAdmin
    {
        public KvpUserInfoAdminHandler(
            SiteUserManager<SiteUser> userManager,
            TenantProfileOptionsResolver customPropsResolver,
            UserPropertyService userPropertyService,
            IUserPropertyValidator userPropertyValidator,
            ILogger<KvpUserInfoAdminHandler> logger
            )
        {
            _userManager = userManager;
            _customPropsResolver = customPropsResolver;
            _log = logger;
            _props = _customPropsResolver.GetProfileProps();
            _userPropertyValidator = userPropertyValidator;
        }

        protected SiteUserManager<SiteUser> _userManager;
        protected TenantProfileOptionsResolver _customPropsResolver;
        protected ILogger _log;
        protected UserPropertySet _props;
        protected UserPropertyService _userPropertyService;
        protected IUserPropertyValidator _userPropertyValidator;

        public virtual Task<string> GetUserEditViewName(
            ISiteContext site,
            HttpContext httpContext)
        {
            return Task.FromResult("UserEdit"); // this is just returning the default view name.
        }

        public virtual async Task HandleUserEditGet(
            ISiteContext site,
            EditUserViewModel viewModel,
            HttpContext httpContext,
            ViewDataDictionary viewData,
            CancellationToken cancellationToken = default(CancellationToken)
            )
        {
            // add user props to viewData to pass them to the view
            var userProps = await _userPropertyService.FetchByUser(site.Id.ToString(), viewModel.UserId.ToString());

            foreach (var p in _props.Properties)
            {   
                var found = userProps.Where(x => x.Key == p.Key).FirstOrDefault();
                if (found != null)
                {
                    viewData[p.Key] = found.Value;
                }              
            }
        }

        public virtual Task<bool> HandleUserEditValidation(
            ISiteContext site,
            EditUserViewModel viewModel,
            HttpContext httpContext,
            ViewDataDictionary viewData,
            ModelStateDictionary modelState,
            CancellationToken cancellationToken = default(CancellationToken)
            )
        {
            var result = true;

            foreach (var p in _props.Properties)
            {   
                var postedValue = httpContext.Request.Form[p.Key];
                if (_userPropertyValidator.IsValid(p, postedValue, modelState))
                {
                    // if valid keep the field populated in case some other model validation failed and the form is re-displayed
                    viewData[p.Key] = postedValue;
                }
                else
                {
                    result = false;
                }    
            }

            return Task.FromResult(result);
        }

        public virtual async Task HandleUserEditPostSuccess(
            ISiteContext site,
            ISiteUser siteUser,
            EditUserViewModel viewModel,
            HttpContext httpContext,
            CancellationToken cancellationToken = default(CancellationToken)
            )
        {
            // we "could" re-validate here but
            // the method above gets called just before this in the same postback
            // so we know there were no validation errors or this method would not be invoked
            if (siteUser != null)
            {
                foreach (var p in _props.Properties)
                {
                    var postedValue = httpContext.Request.Form[p.Key];
                    // persist to kvp storage
                    await _userPropertyService.CreateOrUpdate(
                        site.Id.ToString(),
                        siteUser.Id.ToString(),
                        p.Key,
                        postedValue);     
                }
            }
            else
            {
                _log.LogError("user was null in HandleUserInfoPostSuccess, unable to update user with custom data");
            }
        }


    }
}
