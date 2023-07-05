namespace WebApplication10.Models
{
    public class Preset
    {
        public int PresetID { get; set; }
        public int HealthplayerID { get; set; }
        public int SpeedplayerID { get; set; }
        public Healthplayer Healthplayer { get; set; }
        public Speedplayer Speedplayer { get; set; }
    }
}
