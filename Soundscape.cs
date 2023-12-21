using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ZerosAndHashtags
{
    struct Music
    {
        public static SoundPlayer XYIsland = new SoundPlayer(@"..\..\Sound\Music\XYIsland.wav");
    }
    internal class Soundscape
    {
        static public void PlayLoop(SoundPlayer player)
        {
            player.PlayLooping();

            if (!Options.enableMusic)
            {
                player.Stop();
                player.Dispose();
                return;
            }
        }
    }
}
