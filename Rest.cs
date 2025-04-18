using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TextRPG
{
    internal class Rest
    {
        public static void Heal(Player player)
        {
            const int restCost = 500;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)\n");
                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    if (player.Gold >= restCost)
                    {
                        player.Gold -= restCost;
                        player.CurrentHp = player.MaxHp;
                        Console.WriteLine("\n휴식을 완료했습니다.");
                    }
                    else
                    {
                        Console.WriteLine("\nGold 가 부족합니다.");
                    }
                    Console.ReadKey();
                    break;
                }
                else if (input == "0")
                {
                    break;
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