using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("POZICIJA")]
    public partial class Pozicija
    {
        public Pozicija()
        {
            Igracs = new HashSet<Igrac>();
        }

        [Key]
        [Column("ID_POZICIJA")]
        public int IdPozicija { get; set; }
        [Required]
        [Column("NAZIV_POZICIJE")]
        [StringLength(50)]
        public string NazivPozicije { get; set; }

        [InverseProperty(nameof(Igrac.IdPozicijaNavigation))]
        public virtual ICollection<Igrac> Igracs { get; set; }
    }
}
