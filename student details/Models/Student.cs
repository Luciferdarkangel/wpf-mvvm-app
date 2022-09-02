using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_details.Models
{
    public class Student
    {
        public Student(string name, string contactNumber, string email)
        {
            Name = name;
            ContactNumber = contactNumber;
            Email = email;
        }

        public string Name { get; }
        public string ContactNumber { get; }
        public string Email { get; }

        public override string ToString()
        {
            return $"Student[name: {Name}]";
        }

        // TODO: Develop this (add constructor, properties, etc.)
    }
}
