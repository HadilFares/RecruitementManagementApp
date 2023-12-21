using System.ComponentModel.DataAnnotations;

namespace RecruitementManagementApp.Models
{
    public class Rh
    {

        public int IdRh { get; set; }
        [Required]
        [Display(Name = "CompanyName")]
        public string Name { get; set; }
        [Required]
        public string adresse { get; set; }
        [Url]
        [Required] 
        public string website { get; set; }
        public virtual ICollection<Offre>? Offres { get; set; }
    }
}
