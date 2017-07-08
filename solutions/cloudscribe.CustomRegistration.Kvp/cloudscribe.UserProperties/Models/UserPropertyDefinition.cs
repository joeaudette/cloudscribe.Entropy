// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2017-07-08
// Last Modified:			2017-07-08
// 

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace cloudscribe.UserProperties.Models
{
    public class UserPropertyDefinition
    {
        public UserPropertyDefinition()
        {
            Options = new List<SelectListItem>();
        }

        public string Key { get; set; }

        public string Label { get; set; }

        public string Tooltip { get; set; }

        public string DefaultValue { get; set; }
        
        public string EditPartialViewName { get; set; } = "PropertyDefInputPartial";

        public string CssClass { get; set; }

        public bool VisibleOnRegistration { get; set; }
        
        public string OnlyAvailableForRoles { get; set; }

        public string OnlyVisibleForRoles { get; set; }

        public bool VisibleToUserOnProfile { get; set; } = true;

        public bool EditableByUserOnProfile { get; set; } = true;

        public int MaxLength { get; set; } = -1;

        public bool Required { get; set; }

        public string RequiredErrorMessage { get; set; }

        public string RegexValidationExpression { get; set; }
        public string RegexErrorMessage { get; set; }

        public List<SelectListItem> Options { get; set; } = null;
    }
}
