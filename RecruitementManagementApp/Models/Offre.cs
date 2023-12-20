using System.ComponentModel.DataAnnotations;

namespace RecruitementManagementApp.Models
{
    public class Offre
    {
        public int codeOffre { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool published { get; set; }=false;
        public bool archived { get; set; } = false;
        public ICollection<CandidatOffre> candidatOffres { get; set; }
        public int nameRh { get; set; }
        public virtual Rh? LeRh { get; set; }
    }
}
