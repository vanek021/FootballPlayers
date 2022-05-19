using System.ComponentModel.DataAnnotations;

namespace FootballPlayers.ViewModels
{
    public class EditPlayerViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
        [Required]
        [MaxLength(32)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(32)]
        public string Gender { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(32)]
        public string Team { get; set; }
        [Required]
        [MaxLength(32)]
        public string Country { get; set; }
    }
}
