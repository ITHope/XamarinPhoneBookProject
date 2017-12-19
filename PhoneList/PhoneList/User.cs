using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneList
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Icon { get; set; }

        public User(int id, string name, string lastName, int phone, string icon)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Icon = icon;
        }
    }
}