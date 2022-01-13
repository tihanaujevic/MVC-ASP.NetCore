using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("ASISTENTI")]
    public partial class Asistenti
    {
        [Key]
        [Column("ID_IGRAC")]
        public int IdIgrac { get; set; }
        [Column("BROJ_ASISTENCIJA")]
        public int? BrojAsistencija { get; set; }

        [ForeignKey(nameof(IdIgrac))]
        [InverseProperty(nameof(Igrac.Asistenti))]
        public virtual Igrac IdIgracNavigation { get; set; }
    }
}
