using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("KLUB")]
    public partial class Klub
    {
        public Klub()
        {
            Igracs = new HashSet<Igrac>();
            RezultatIdKlub1Navigations = new HashSet<Rezultat>();
            RezultatIdKlub2Navigations = new HashSet<Rezultat>();
        }

        [Key]
        [Column("ID_KLUB")]
        public int IdKlub { get; set; }
        [Required]
        [Column("NAZIV")]
        [StringLength(50)]
        public string Naziv { get; set; }
        [Column("ID_MJESTO")]
        public int IdMjesto { get; set; }
        [Column("BODOVI")]
        public int? Bodovi { get; set; }
        [Column("POSTIGNUTI_GOLOVI")]
        public int? PostignutiGolovi { get; set; }
        [Column("PRIMLJENI_GOLOVI")]
        public int? PrimljeniGolovi { get; set; }

        [ForeignKey(nameof(IdMjesto))]
        [InverseProperty(nameof(Mjesto.Klubs))]
        public virtual Mjesto IdMjestoNavigation { get; set; }
        [InverseProperty(nameof(Igrac.IdKlubNavigation))]
        public virtual ICollection<Igrac> Igracs { get; set; }
        [InverseProperty(nameof(Rezultat.IdKlub1Navigation))]
        public virtual ICollection<Rezultat> RezultatIdKlub1Navigations { get; set; }
        [InverseProperty(nameof(Rezultat.IdKlub2Navigation))]
        public virtual ICollection<Rezultat> RezultatIdKlub2Navigations { get; set; }
        public string Mjesto1 { get; set; }
    }
}
