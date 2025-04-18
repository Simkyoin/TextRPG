using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; } = 1;
        public int BaseAttack { get; private set; } = 10;
        public int BaseDefense { get; private set; } = 5;
        public int MaxHp { get; private set; } = 100;
        public int CurrentHp { get; set; }
        public int Gold { get; set; } = 1500;
        public Inventory Inventory { get; private set; }

        public Player(string name)
        {
            Name = name;
            Inventory = new Inventory();
            CurrentHp = MaxHp;
        }

        public int GetTotalAttack() => BaseAttack + Inventory.GetTotalAttack();
        public int GetTotalDefense() => BaseDefense + Inventory.GetTotalDefense();

        public void DisplayStatus()
        {
            Console.Clear();
            Console.WriteLine("상태 보기\n");
            Console.WriteLine($"Lv. {Level:D2}");
            Console.WriteLine($"{Name}");
            Console.WriteLine($"공격력 : {GetTotalAttack()}");
            Console.WriteLine($"방어력 : {GetTotalDefense()}");
            Console.WriteLine($"체 력 : {CurrentHp} / {MaxHp}");
            Console.WriteLine($"Gold : {Gold} G\n");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
        }
    }
}