using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Liga.Models
{
    [Table("REZULTAT")]
    public partial class Rezultat
    {
        [Key]
        [Column("ID_UTAKMICA")]
        public int IdUtakmica { get; set; }
        [Key]
        [Column("ID_KLUB1")]
        public int IdKlub1 { get; set; }
        [Key]
        [Column("ID_KLUB2")]
        public int IdKlub2 { get; set; }
        [Column("REZULTAT")]
        [StringLength(50)]
        public string Rezultat1 { get; set; }

        [ForeignKey(nameof(IdKlub1))]
        [InverseProperty(nameof(Klub.RezultatIdKlub1Navigations))]
        public virtual Klub IdKlub1Navigation { get; set; }
        [ForeignKey(nameof(IdKlub2))]
        [InverseProperty(nameof(Klub.RezultatIdKlub2Navigations))]
        public virtual Klub IdKlub2Navigation { get; set; }
        [ForeignKey(nameof(IdUtakmica))]
        [InverseProperty(nameof(Utakmice.Rezultats))]
        public virtual Utakmice IdUtakmicaNavigation { get; set; }

        public string Klub1 { get; set; }
        public string Klub2 { get; set; }

        public string Kolo { get; set; }
        public DateTime Datum { get; set; }
        public string Mjesto { get; set; }
    }
}
