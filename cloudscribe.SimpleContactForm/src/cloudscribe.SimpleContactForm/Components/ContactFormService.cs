// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. 
// Author:					Joe Audette
// Created:					2016-11-19
// Last Modified:			2016-11-19
// 

using cloudscribe.SimpleContactForm.Models;
using cloudscribe.SimpleContactForm.ViewModels;
using cloudscribe.Web.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudscribe.SimpleContactForm.Components
{
    public class ContactFormService
    {
        public ContactFormService(
            IEnumerable<IProcessMessages> messageProcessors,
            IContactFormResolver contactFormResolver,
            IRecaptchaKeysProvider recaptchaKeysProvider,
            ILogger<ContactFormService> logger
            )
        {
            this.contactFormResolver = contactFormResolver;
            recaptchaKeys = recaptchaKeysProvider;
            this.messageProcessors = messageProcessors;
            log = logger;
        }

        private IContactFormResolver contactFormResolver;
        private IRecaptchaKeysProvider recaptchaKeys;
        private ContactForm form = null;
        private IEnumerable<IProcessMessages> messageProcessors;
        private ILogger log;

        public async Task<string> GetFormId()
        {
            if(form == null)
            {
                form = await contactFormResolver.GetCurrentContactForm();
            }

            return form.Id;
        }

        public async Task<RecaptchaKeys> GetRecaptchaKeys()
        {
            return await recaptchaKeys.GetKeys().ConfigureAwait(false);
        }

        public async Task<MessageResult> ProcessMessage(MessageViewModel model, string ipAddress)
        {
            var message = new ContactFormMessage();
            message.FormId = model.FormId;
            message.Email = model.Email;
            message.Name = model.Name;
            message.Message = model.Message;
            message.IpAddress = ipAddress;

            foreach(var processor in messageProcessors)
            {
                try
                {
                    await processor.Process(message);
                }
                catch(Exception ex)
                {
                    log.LogError("error processing contact form message", ex);
                }
            }

            var result = MessageResult.Success;

            return result;
        }
    }
}
