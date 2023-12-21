using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class StrongBat:Bat
    {
        public StrongBat(string name, int health) : base(name, health)
        {
        }

        public StrongBat() : base("Strong Bat", 8)
        {
        }
    }
}
