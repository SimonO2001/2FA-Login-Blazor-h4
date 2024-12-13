using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareTest.ModelsTodo
{
    public partial class Todolist
    {
        [Key]
        public int Id { get; set; } // Add Id as the primary key

        public string UserId { get; set; } = null!;

        public string Item { get; set; } = null!;

        [NotMapped]
        public string DecryptedItem { get; set; } = null!;

        public virtual Cpr User { get; set; } = null!;
    }
}
