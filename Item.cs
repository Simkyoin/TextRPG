using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Item
    {
        public string Name { get; set; }
        public string Type { get; set; } // "Weapon" or "Armor"
        public int Stat { get; set; }
        public int Price { get; set; }
        public bool IsPurchased { get; set; } = false;

        public Item(string name, string type, int stat, int price)
        {
            Name = name;
            Type = type;
            Stat = stat;
            Price = price;
        }
    }
}