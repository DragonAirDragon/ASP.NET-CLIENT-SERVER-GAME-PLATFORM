using System.Diagnostics;
using WebApplication10.Models;

namespace WebApplication10.Data
{
    public class DbInitializer
    {
        public static void Initialize(Game context)
        {
            // Look for any students.
            if (context.Healthplayers.Any())
            {
                return;   // DB has been seeded
            }

            var healthplayers = new Healthplayer[]
            {
                new Healthplayer{ValueHealth=50},
                new Healthplayer{ValueHealth=100},
                new Healthplayer{ValueHealth=150},
                new Healthplayer{ValueHealth=200},
                new Healthplayer{ValueHealth=250},
                new Healthplayer{ValueHealth=300},
                new Healthplayer{ValueHealth=350},
                new Healthplayer{ValueHealth=400}
            };

            context.Healthplayers.AddRange(healthplayers);
            context.SaveChanges();

            var speedplayers = new Speedplayer[]
            {
                new Speedplayer{SpeedplayerID=1,ValueSpeed=1},
                new Speedplayer{SpeedplayerID=2,ValueSpeed=2},
                new Speedplayer{SpeedplayerID=3,ValueSpeed=3},
                new Speedplayer{SpeedplayerID=4,ValueSpeed=4},
                new Speedplayer{SpeedplayerID=5,ValueSpeed=5},
                new Speedplayer{SpeedplayerID=6,ValueSpeed=6},
                new Speedplayer{SpeedplayerID=7,ValueSpeed=7}
            };

            context.Speedplayers.AddRange(speedplayers);
            context.SaveChanges();

            var presets = new Preset[]
            {
                new Preset{HealthplayerID=1, SpeedplayerID= 1},
                new Preset{HealthplayerID=1, SpeedplayerID= 2},
                new Preset{HealthplayerID=2, SpeedplayerID= 1},
                new Preset{HealthplayerID=2, SpeedplayerID= 2},
                new Preset{HealthplayerID=2, SpeedplayerID= 3},
                new Preset{HealthplayerID=3, SpeedplayerID= 1},
                new Preset{HealthplayerID=3, SpeedplayerID= 2},
                new Preset{HealthplayerID=3, SpeedplayerID= 3},
                new Preset{HealthplayerID=4, SpeedplayerID= 1},
                new Preset{HealthplayerID=4, SpeedplayerID= 2},
                new Preset{HealthplayerID=4, SpeedplayerID= 3},
                new Preset{HealthplayerID=4, SpeedplayerID= 2},
            };

            context.Presets.AddRange(presets);
            context.SaveChanges();
        }
    }
}
