using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("UTAKMICE")]
    public partial class Utakmice
    {
        public Utakmice()
        {
            Rezultats = new HashSet<Rezultat>();
        }

        [Key]
        [Column("ID_UTAKMICA")]
        public int IdUtakmica { get; set; }
        [Column("ID_KOLO")]
        public int IdKolo { get; set; }
        [Column("VRIJEME", TypeName = "datetime")]
        public DateTime? Vrijeme { get; set; }
        [Column("ID_MJESTO")]
        public int? IdMjesto { get; set; }

        [ForeignKey(nameof(IdKolo))]
        [InverseProperty(nameof(Kola.Utakmices))]
        public virtual Kola IdKoloNavigation { get; set; }
        [ForeignKey(nameof(IdMjesto))]
        [InverseProperty(nameof(Mjesto.Utakmices))]
        public virtual Mjesto IdMjestoNavigation { get; set; }
        [InverseProperty(nameof(Rezultat.IdUtakmicaNavigation))]
        public virtual ICollection<Rezultat> Rezultats { get; set; }

    }
}
