using System.ComponentModel.DataAnnotations;

namespace FootballPlayers.ViewModels
{
    public class AddPlayerViewModel
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
        [Required]
        [MaxLength(32)]
        public string Surname { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(32)]
        public string Team { get; set; }
        [Required]
        [MaxLength(32)]
        public string Country { get; set; }
    }
}
