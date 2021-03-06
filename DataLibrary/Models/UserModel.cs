﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ActivityLevel { get; set; }
        public string MedicalConditions { get; set; }
    }
}
