using System;
using System.Collections.Generic;

namespace Aplikacja121.Data
{
    public partial class Student
    {
        public Student()
        {
            Mark = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? ClassId { get; set; }

        public Class Class { get; set; }
        public ICollection<Mark> Mark { get; set; }
    }
}
