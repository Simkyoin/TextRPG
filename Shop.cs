using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TextRPG
{
    internal class Shop
    {
        private static List<Item> shopItems = new List<Item>
        {
            new Item("나무 검", "Weapon", 5, 500),
            new Item("천 갑옷", "Armor", 3, 400),
            new Item("철 검", "Weapon", 10, 1000),
            new Item("강철 갑옷", "Armor", 6, 900)
        };

        public static void Enter(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템을 구매할 수 있습니다.\n");

                for (int i = 0; i < shopItems.Count; i++)
                {
                    var item = shopItems[i];
                    string status = item.IsPurchased ? "구매 완료" : $"{item.Price} G";
                    Console.WriteLine($"{i + 1}. [{item.Type}] {item.Name} | +{item.Stat} | {status}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (input == "0") break;

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= shopItems.Count)
                {
                    var selectedItem = shopItems[choice - 1];
                    if (selectedItem.IsPurchased)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else if (player.Gold < selectedItem.Price)
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                    }
                    else
                    {
                        player.Gold -= selectedItem.Price;
                        player.Inventory.AddItem(selectedItem);
                        selectedItem.IsPurchased = true;
                        Console.WriteLine($"{selectedItem.Name}을(를) 구매했습니다!");
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }
    }
}