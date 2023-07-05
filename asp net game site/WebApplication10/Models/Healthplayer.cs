namespace WebApplication10.Models
{
    public class Healthplayer
    {
        public int ID { get; set; }
        public int ValueHealth { get; set; }
        public ICollection<Preset> Presets { get; set; }
    }
}
