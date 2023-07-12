﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Model
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

        public Contact(string name, string number, string email)
        {
            this.Id = IdGenerator.GetNextId<Contact>();
            this.Name = name;
            this.Number = number;
            this.Email = email;
        }

    }
}
