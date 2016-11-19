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
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddCloudscribeSimpleContactForm(this IServiceCollection services)
        {
            
            services.AddScoped<ContactFormService, ContactFormService>();
            services.AddScoped<IProcessMessages, SmtpMessageProcessor>();
            services.AddScoped<IContactFormResolver, ConfigContactFormResolver>();

            


            return services;
        }

        public static RazorViewEngineOptions AddEmbeddedViewsForCloudscribeSimpleContactForm(this RazorViewEngineOptions options)
        {
            options.FileProviders.Add(new EmbeddedFileProvider(
                    typeof(ContactFormService).GetTypeInfo().Assembly,
                    "cloudscribe.SimpleContactForm"
                ));

            return options;
        }
    }
}
