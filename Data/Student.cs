using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Aplikacja121.Data
{
    public partial class Student
    {
        [DisplayName("Studenci")]
        public Student()
        {
            Mark = new HashSet<Mark>();
        }

        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Imie: ")]
        public string Name { get; set; }
        [DisplayName("Nazwisko: ")]
        public string Surname { get; set; }
        [DisplayName("ID klasy: ")]
        public int? ClassId { get; set; }

        [DisplayName("Klasa")]
        public Class Class { get; set; }
        [DisplayName("Oceny")]
        public ICollection<Mark> Mark { get; set; }
    }
}
