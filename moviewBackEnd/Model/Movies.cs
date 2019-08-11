using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviewBackEnd.Model
{
    public partial class Movies
    {
        public Movies()
        {
            Reviews = new HashSet<Reviews>();
        }

        [Column("MovieID")]
        public int MovieId { get; set; }
        [Required]
        [StringLength(255)]
        public string Movie { get; set; }

        [InverseProperty("Movie")]
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
