namespace RecruitementManagementApp.Models
{
    public class CandidatOffre
    {
        public int IdCandidat{ get; set; }
        public int codeOffre { get; set; }
        public Candidat Candidat { get; set; } 
        public Offre Offre { get; set; }
    }
}
