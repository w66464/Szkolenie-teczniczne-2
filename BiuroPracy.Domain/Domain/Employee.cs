﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuroPracy.Domain
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Profession Profession { get; set; }
    }
}
