using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviewBackEnd.Model
{
    public partial class Users
    {
        public Users()
        {
            Reviews = new HashSet<Reviews>();
        }

        public int UserKey { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [InverseProperty("UserKeyNavigation")]
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
