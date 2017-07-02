using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace cloudscribe.UserProfile.Kvp.Web.Models
{
    public class UserPropertyDefinition
    {
        public string Key { get; set; }

        public string Label { get; set; }

        public string Tooltip { get; set; }

        public string DefaultValue { get; set; }

        public string InputType { get; set; }

        public string CssClass { get; set; }

        public bool RequiredForRegistration { get; set; }

        public bool OptionalForRegistration { get; set; }

       
        public string OnlyAvailableForRoles { get; set; }

        public string OnlyVisibleForRoles { get; set; }

        public bool VisibleToUser { get; set; } = true;

        public bool EditableByUser { get; set; }

        public int MaxLength { get; set; } = -1;

        public string RegexValidationExpression { get; set; }
        public string RegexErrorMessage { get; set; }

        public List<SelectListItem> Options { get; set; } = null;
    }
}
