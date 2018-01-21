using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Aplikacja121.Data
{
    public partial class Mark
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Ocena: ")]
        public int? Value { get; set; }
        [DisplayName("Opis: ")]
        public string Description { get; set; }
        [DisplayName("ID studenta")]
        public int StudentId { get; set; }

        [DisplayName("Student")]
        public Student Student { get; set; }
    }
}
