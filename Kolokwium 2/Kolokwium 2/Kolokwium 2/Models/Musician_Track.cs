using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Models
{
    public class Musician_Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMusicianTrack { get; set; }
        [ForeignKey("Musician")]
        public int IdMusician { get; set; }
        [ForeignKey("Track")]
        public int IdTrack { get; set; }

    }
}
