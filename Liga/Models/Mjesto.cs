using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("MJESTO")]
    public partial class Mjesto
    {
        public Mjesto()
        {
            Klubs = new HashSet<Klub>();
            Utakmices = new HashSet<Utakmice>();
        }

        [Key]
        [Column("ID_MJESTO")]
        public int IdMjesto { get; set; }
        [Required]
        [Column("NAZIV_MJESTA")]
        [StringLength(50)]
        public string NazivMjesta { get; set; }

        [InverseProperty(nameof(Klub.IdMjestoNavigation))]
        public virtual ICollection<Klub> Klubs { get; set; }
        [InverseProperty(nameof(Utakmice.IdMjestoNavigation))]
        public virtual ICollection<Utakmice> Utakmices { get; set; }
    }
}
