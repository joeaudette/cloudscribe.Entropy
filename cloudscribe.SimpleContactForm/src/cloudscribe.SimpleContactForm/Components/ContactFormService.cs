// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. 
// Author:					Joe Audette
// Created:					2016-11-19
// Last Modified:			2016-11-19
// 

using cloudscribe.SimpleContactForm.Models;
using cloudscribe.SimpleContactForm.ViewModels;
using cloudscribe.Web.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudscribe.SimpleContactForm.Components
{
    public class ContactFormService
    {
        public ContactFormService(
            IFormIdProvider formIdProvider,
            IRecaptchaKeysProvider recaptchaKeysProvider
            )
        {
            this.formIdProvider = formIdProvider;
            recaptchaKeys = recaptchaKeysProvider;
        }

        private IFormIdProvider formIdProvider;
        private IRecaptchaKeysProvider recaptchaKeys;

        public async Task<string> GetFormId()
        {
            return await formIdProvider.GetFormId().ConfigureAwait(false);
        }

        public async Task<RecaptchaKeys> GetRecaptchaKeys()
        {
            return await recaptchaKeys.GetKeys().ConfigureAwait(false);
        }

        public Task<MessageResult> ProcessMessage(MessageViewModel model)
        {
            var result = MessageResult.Success;
            // TODO: implement

            return Task.FromResult(result);
        }
    }
}
