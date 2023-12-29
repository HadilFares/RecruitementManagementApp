using System.ComponentModel.DataAnnotations;

namespace RecruitementManagementApp.Models
{
    public class Candidat
    {
        public int IdCandidat { get; set; }

        [Required(ErrorMessage = "Please enter the Date of Birth.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateNaiss { get; set; }

        [Required(ErrorMessage = "Please enter the University.")]
        public string University { get; set; }

        [Required(ErrorMessage = "Please enter the Language.")]
        public string Langage { get; set; }

        [Required(ErrorMessage = "Please enter the Stage/Experience.")]
        public string Stagesexpercience { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Githuburl { get; set; }

        [Required(ErrorMessage = "Please enter the Frameworks.")]
        public string Frameworks { get; set; }

        // Navigation property for the related entities
        public ICollection<CandidatOffre> candidatOffres { get; set; }
    }

}
