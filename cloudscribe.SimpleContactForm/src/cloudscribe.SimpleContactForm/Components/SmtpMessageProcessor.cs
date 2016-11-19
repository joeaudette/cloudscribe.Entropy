using cloudscribe.Messaging.Email;
using cloudscribe.SimpleContactForm.Models;
using cloudscribe.Web.Common.Razor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudscribe.SimpleContactForm.Components
{
    public class SmtpMessageProcessor : IProcessMessages
    {
        public SmtpMessageProcessor(
            ViewRenderer viewRenderer,
            IContactFormResolver contactFormResolver,
            ISmtpOptionsProvider smtpOptionsProvider,
            ILogger<SmtpMessageProcessor> logger
            )
        {
            this.viewRenderer = viewRenderer;
            this.smtpOptionsProvider = smtpOptionsProvider;
            this.contactFormResolver = contactFormResolver;
            log = logger;
        }

        private ViewRenderer viewRenderer;
        private ISmtpOptionsProvider smtpOptionsProvider;
        private IContactFormResolver contactFormResolver;
        private ILogger log;


        public async Task Process(ContactFormMessage message)
        {
            var form = await contactFormResolver.GetCurrentContactForm().ConfigureAwait(false);
            var smtpOptions = await smtpOptionsProvider.GetSmtpOptions().ConfigureAwait(false);
            EmailSender sender = new EmailSender();
           
            try
            {
                var plainTextMessage
                   = await viewRenderer.RenderViewAsString<ContactFormMessage>("EmailTemplates/ContactFormTextEmail", message);

                var htmlMessage
                    = await viewRenderer.RenderViewAsString<ContactFormMessage>("EmailTemplates/ContactFormHtmlEmail", message);

                var replyTo = message.Email;
                await sender.SendMultipleEmailAsync(
                    smtpOptions,
                    form.NotificationEmailCsv,
                    smtpOptions.DefaultEmailFromAddress,
                    form.NotificationEmailCsv,
                    plainTextMessage,
                    htmlMessage,
                    replyTo
                    ).ConfigureAwait(false);

                if (form.CopySubmitterEmailOnSubmission)
                {
                    // TODO: send a different view without ipaddress?
                    await sender.SendEmailAsync(
                        smtpOptions,
                        message.Email,
                        smtpOptions.DefaultEmailFromAddress,
                        form.NotificationEmailCsv,
                        plainTextMessage,
                        htmlMessage
                        ).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                log.LogError("error sending password reset email", ex);
            }

        }
    }
}
