using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Dungeon
    {
        public static void Enter(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. 쉬운 던전     | 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전     | 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                int requiredDefense = 0;
                int baseReward = 0;
                string dungeonName = "";

                switch (input)
                {
                    case "1": requiredDefense = 5; baseReward = 1000; dungeonName = "쉬운"; break;
                    case "2": requiredDefense = 11; baseReward = 1700; dungeonName = "일반"; break;
                    case "3": requiredDefense = 17; baseReward = 2500; dungeonName = "어려운"; break;
                    case "0": return;
                    default: continue;
                }

                int playerDefense = player.GetTotalDefense();
                int playerAttack = player.GetTotalAttack();
                Random rand = new Random();

                if (playerDefense < requiredDefense && rand.Next(0, 100) < 40)
                {
                    int damage = rand.Next(10, 21);
                    player.CurrentHp = Math.Max(player.CurrentHp - damage, 0);
                    Console.WriteLine("\n던전 실패... 체력을 소모하고 보상을 얻지 못했습니다.");
                    Console.WriteLine($"체력 {player.CurrentHp + damage} -> {player.CurrentHp}");
                    Console.ReadKey();
                    return;
                }

                int diff = playerDefense - requiredDefense;
                int hpLoss = rand.Next(20 + diff, 36 + diff);
                player.CurrentHp = Math.Max(player.CurrentHp - hpLoss, 0);

                int bonusPercent = rand.Next(playerAttack, playerAttack * 2 + 1);
                int reward = baseReward + baseReward * bonusPercent / 100;

                int oldGold = player.Gold;
                int oldHp = player.CurrentHp + hpLoss;

                player.Gold += reward;

                Console.WriteLine($"\n축하합니다!!");
                Console.WriteLine($"{dungeonName} 던전을 클리어 하였습니다.\n");
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {oldHp} -> {player.CurrentHp}");
                Console.WriteLine($"Gold {oldGold} G -> {player.Gold} G");

                Console.WriteLine("\n0. 나가기");
                Console.ReadLine();
                return;
            }
        }
    }
}