using System;
using System.Collections.Generic;

namespace Aplikacja121.Data
{
    public partial class Class
    {
        public Class()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
