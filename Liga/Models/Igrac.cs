using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("IGRAC")]
    public partial class Igrac
    {
        [Key]
        [Column("ID_IGRAC")]
        public int IdIgrac { get; set; }
        [Required]
        [Column("IME")]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required]
        [Column("PREZIME")]
        [StringLength(50)]
        public string Prezime { get; set; }
        [Column("ID_KLUB")]
        public int IdKlub { get; set; }
        [Column("ID_POZICIJA")]
        public int IdPozicija { get; set; }
        [Column("BROJ_DRESA")]
        public int? BrojDresa { get; set; }

        [ForeignKey(nameof(IdKlub))]
        [InverseProperty(nameof(Klub.Igracs))]
        public virtual Klub IdKlubNavigation { get; set; }
        [ForeignKey(nameof(IdPozicija))]
        [InverseProperty(nameof(Pozicija.Igracs))]
        public virtual Pozicija IdPozicijaNavigation { get; set; }
        [InverseProperty("IdIgracNavigation")]
        public virtual Asistenti Asistenti { get; set; }
        [InverseProperty("IdIgracNavigation")]
        public virtual Kartonirani Kartonirani { get; set; }
        [InverseProperty("IdIgracNavigation")]
        public virtual Strijelci Strijelci { get; set; }

        public string Klub1 { get; set; }
        public string Pozicija1 { get; set; }
        public int? Asistencija { get; set; }
        public int? Karton { get; set; }
        public int? Golovi { get; set; }
    }
}
