﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Repository.Models
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}