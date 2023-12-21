namespace RecruitementManagementApp.Models
{

    public enum ApplicationStatus
    {
        EnAttente,   // Pending
        Acceptees,   // Accepted
        Rejetees     // Rejected
    }
    public class CandidatOffre
    {    public int IdCandidat{ get; set; }
        public int codeOffre { get; set; }
        public ApplicationStatus Status { get; set; }
        public Candidat Candidat { get; set; } 
        public Offre Offre { get; set; }
    }
}
