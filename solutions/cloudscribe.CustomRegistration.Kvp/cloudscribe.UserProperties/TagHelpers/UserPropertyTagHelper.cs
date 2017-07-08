// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2017-07-08
// Last Modified:			2017-07-08
// 

using cloudscribe.UserProperties.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace cloudscribe.UserProperties.TagHelpers
{
    [HtmlTargetElement("input", Attributes = UserPropertyAttributeName)]
    [HtmlTargetElement("select", Attributes = UserPropertyAttributeName)]
    public class UserPropertyTagHelper : TagHelper
    {
        public UserPropertyTagHelper()
        {

        }

        private const string UserPropertyAttributeName = "cs-user-property";

        [HtmlAttributeName(UserPropertyAttributeName)]
        public UserPropertyDefinition UserProperty { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // we don't need to output this attribute it was only used for matching in razor
            TagHelperAttribute modalAttribute = null;
            output.Attributes.TryGetAttribute(UserPropertyAttributeName, out modalAttribute);
            if (modalAttribute != null) { output.Attributes.Remove(modalAttribute); }
            if (UserProperty == null) return;

            if(UserProperty.Required | !string.IsNullOrEmpty(UserProperty.RegexValidationExpression))
            {
                output.Attributes.Add("data-val", "true");
            }
            if (UserProperty.Required)
            {
                output.Attributes.Add("data-val-required", UserProperty.RequiredErrorMessage);
            }

            //output.Attributes.Add("data-ajax", "true");
            //output.Attributes.Add("data-ajax-begin", "prepareModalDialog('" + dialogDivId + "')");
            //output.Attributes.Add("data-ajax-failure", "clearModalDialog('" + dialogDivId + "');alert('Ajax call failed')");
            //output.Attributes.Add("data-ajax-method", "GET");
            //output.Attributes.Add("data-ajax-mode", "replace");
            //output.Attributes.Add("data-ajax-success", "openModalDialog('" + dialogDivId + "')");
            //output.Attributes.Add("data-ajax-update", "#" + dialogDivId);

        }

    }
}
