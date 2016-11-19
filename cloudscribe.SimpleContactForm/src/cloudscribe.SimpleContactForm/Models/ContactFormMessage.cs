// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0.
// Author:					Joe Audette
// Created:					2016-11-19
// Last Modified:			2016-11-19
// 


namespace cloudscribe.SimpleContactForm.Models
{
    public class ContactFormMessage
    {
        public string FormId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string IpAddress { get; set; }
    }
}
