using System;
using System.Collections.Generic;

namespace jasonApı.Models
{
    public partial class ArgusDatum
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Age { get; set; }
    }
}
