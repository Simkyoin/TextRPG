using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리\n");

            if (items.Count == 0)
            {
                Console.WriteLine("보유한 아이템이 없습니다.\n");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"[{item.Type}] {item.Name} | +{item.Stat}");
                }
            }

            Console.WriteLine("\n0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            Console.ReadLine();
        }

        public int GetTotalAttack()
        {
            int total = 0;
            foreach (var item in items)
            {
                if (item.Type == "Weapon") total += item.Stat;
            }
            return total;
        }

        public int GetTotalDefense()
        {
            int total = 0;
            foreach (var item in items)
            {
                if (item.Type == "Armor") total += item.Stat;
            }
            return total;
        }
    }
}