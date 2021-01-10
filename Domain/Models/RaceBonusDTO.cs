namespace Domain.Models
{
    public class RaceBonusDTO
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int Modifier { get; set; }
        public int SkillId { get; set; }
    }
}
