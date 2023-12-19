using System.ComponentModel.DataAnnotations;

namespace RecruitementManagementApp.Models
{
    public class Candidat
    {
        public int IdCandidat { get; set; }
        public string DateNaiss { get; set; }
        public string University { get; set; }
        public string Langage { get; set; }
        public string Stagesexpercience { get; set; }
        [Url]
        public string Githuburl { get; set; }
        public string Frameworks { get; set; }
        public ICollection<CandidatOffre> candidatOffres { get; set; }
    }
}
