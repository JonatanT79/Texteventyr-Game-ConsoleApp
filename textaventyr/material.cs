using System;
using System.Collections.Generic;
using System.Text;

namespace textaventyr
{
    public class Material
    {
        public string namn { get; set; }
        public int addHp { get; set; }
        public int addAtk { get; set; }


        public void bonus(Player player)
        {
            player.health += addHp;
            player.atk += addAtk;
        }
   


    }
}
