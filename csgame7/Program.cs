using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{

    class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize("STG", 480, 640, new EngineOption());

            Player player = new Player();

            Engine.AddObject2D(player);

            Enemy enemy = new Enemy(player);

            Engine.AddObject2D(enemy);

            while (Engine.DoEvents())
            {
                Engine.Update();
            }
            Engine.Terminate();
        }
    }
}