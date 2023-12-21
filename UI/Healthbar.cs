using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZerosAndHashtags.UI
{
    internal class Healthbar
    {
        private Card host;
        private string hpf = "000000";
        private int hostHp;
        private int hostMaxHp;

        public Healthbar(Card host) 
        {
            this.host = host;

            UpdateBar();
        }

        public void DrawBar(int x = 0, int y = 0, ConsoleColor color = ConsoleColor.Green)
        {
            UpdateBar();

            Canvas.DrawImage(hpf, 6, 1,x, y,"",color);

            string hp = host.hp.ToString();
            string maxHp = host.maxHp.ToString();

            if (host.hp < 10)
                hp = "0"+host.hp.ToString();

            if (host.maxHp < 10)
                maxHp = "0" + host.maxHp.ToString();

            Canvas.DrawText(hp, x + 1, y, color);
            Canvas.DrawText(maxHp, x + 4, y, color);
        }

        private void UpdateBar()
        {
            hostHp = host.hp;
            hostMaxHp = host.maxHp;

            if (hostHp == hostMaxHp)
                hpf = "111111";
            else if (hostHp == 0)
                hpf = "444444";
            else if (hostHp > hostMaxHp / 2 && hostHp < hostMaxHp)
                hpf = "111114";
            else if (hostHp == hostMaxHp / 2)
                hpf = "111444";
            else if (hostHp < hostMaxHp / 2 && hostHp > 0)
                hpf = "144444";
        }
    }
}
