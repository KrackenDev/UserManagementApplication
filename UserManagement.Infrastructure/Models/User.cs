﻿using System;

namespace UserManagement.Infrastructure.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? LastModified { get; set; }
    }
}