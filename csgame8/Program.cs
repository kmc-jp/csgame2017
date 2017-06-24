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

            //タイトルシーン(追加)
            Engine.ChangeScene(new TitleScene());

            while (Engine.DoEvents())
            {
                Engine.Update();
            }
            Engine.Terminate();
        }
    }
}