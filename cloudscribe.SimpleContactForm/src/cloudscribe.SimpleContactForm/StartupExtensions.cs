// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. 
// Author:					Joe Audette
// Created:					2016-11-19
// Last Modified:			2016-11-19
// 

using cloudscribe.SimpleContactForm.Components;
using cloudscribe.SimpleContactForm.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddCloudscribeSimpleContactForm(this IServiceCollection services)
        {
            services.TryAddScoped<IFormIdProvider, DefaultFormIdProvider>();
            services.AddScoped<ContactFormService, ContactFormService>();


            return services;
        }
    }
}
