﻿using System;
using System.Collections.Generic;

namespace MvvmQuiz.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
    }
}