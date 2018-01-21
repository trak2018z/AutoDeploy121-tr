using System;
using System.Collections.Generic;

namespace Aplikacja121.Data
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int? Value { get; set; }
        public string Description { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
