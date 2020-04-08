using System;
using System.Collections.Generic;
using System.Text;

namespace textaventyr
{
    public class Player
    {
        public string name { get; set; }
        public int health { get; set; }
        public string ras { get; set; }
        public int atk { get; set; }
        public string vapen { get; internal set; }

        public List<Material> inventory = new List<Material>();
    }
}
