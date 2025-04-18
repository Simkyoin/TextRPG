using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    internal class Game
    {
        private Player player;

        public void Start()
        {
            Console.Clear();
            Console.Write("플레이어 이름을 입력하세요: ");
            string name = Console.ReadLine();
            player = new Player(name);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기");
                Console.WriteLine("0. 게임 종료");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.DisplayStatus();
                        Console.ReadLine();
                        break;
                    case "2":
                        player.Inventory.ShowInventory();
                        break;
                    case "3":
                        Shop.Enter(player);
                        break;
                    case "4":
                        Dungeon.Enter(player);
                        break;
                    case "5":
                        Rest.Heal(player);
                        break;
                    case "0":
                        Console.WriteLine("게임을 종료합니다.");
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}