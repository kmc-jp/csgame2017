using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Enemy
    {
        protected int hp;

        virtual public void Damage(int _damage)
        {
            hp -= _damage;
            Console.WriteLine("敵に" + _damage + "のダメージ！");
        }

        public Enemy(int _hp)
        {
            hp = _hp;
        }
    }

    class Phoenix : Enemy
    {
        private int revivalNum;

        public override void Damage(int _damage)
        {
            base.Damage(_damage);
            if (hp <= 0 && revivalNum > 0)
            {
                revivalNum--;
                hp += 100;
                Console.WriteLine("敵の体力が復活した！");
            }
        }

        public Phoenix(int _hp,int _revivalNum) 
            :base(_hp){
                 revivalNum = _revivalNum;
            }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Enemy phoenix = new Phoenix(500, 10);
            phoenix.Damage(600);
        }
    }
}
