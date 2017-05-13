using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//おまじない
using asd;

namespace Altseedtest
{
    class Program
    {
        static void Main(string[] args)
        {
            //初期化処理
            //タイトル名、幅、高さ、オプション
            Engine.Initialize("STG", 640, 480, new EngineOption());
            
            //ウィンドウが閉じられていなければ、while内を実行
             while (Engine.DoEvents())
             {
                //更新処理
                Engine.Update();
             }

            //終了処理
            Engine.Terminate();
        }
    }
}
