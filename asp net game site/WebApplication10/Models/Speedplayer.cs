using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class Speedplayer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpeedplayerID { get; set; }
        public int ValueSpeed { get; set; }
        public ICollection<Preset> Presets { get; set; }
    }
}
