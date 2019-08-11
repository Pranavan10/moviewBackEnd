using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviewBackEnd.Model
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int? UserKey { get; set; }
        [Column("MovieID")]
        public int? MovieId { get; set; }
        public int Rating { get; set; }
        [Required]
        [StringLength(255)]
        public string Review { get; set; }

        [ForeignKey("MovieId")]
        [InverseProperty("Reviews")]
        public virtual Movies Movie { get; set; }
        [ForeignKey("UserKey")]
        [InverseProperty("Reviews")]
        public virtual Users UserKeyNavigation { get; set; }
    }
}
