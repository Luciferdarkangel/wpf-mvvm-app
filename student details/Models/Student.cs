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

        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Student[name: {Name}]";
        }

      
    }
}
