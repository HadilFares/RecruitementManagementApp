using System.ComponentModel.DataAnnotations;

namespace RecruitementManagementApp.Models
{
    public class Candidat
    {
        public int IdCandidat { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of Birthday")]
        [DataType(DataType.Date)]
        public DateTime DateNaiss { get; set; }
        [Required]
        public string University { get; set; }
        [Required]
        public string Langage { get; set; }
        [Required]
        public string Stagesexpercience { get; set; }
        [Url]
        public string Githuburl { get; set; }
        [Required]
        public string Frameworks { get; set; }
        public ICollection<CandidatOffre> candidatOffres { get; set; }
    }
}
