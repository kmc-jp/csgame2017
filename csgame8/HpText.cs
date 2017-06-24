using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class HpText :TextObject2D
    {
        //誰のHPか
        string name;
        //誰か
        HasHpObject hasHpObject;
        //ゲームシーン
        GameScene gameScene;

        public HpText(string name,Vector2DF position,HasHpObject hasHpObject,GameScene gameScene)
        {
            this.name = name;
            this.hasHpObject = hasHpObject;
            this.gameScene = gameScene;

            this.Position = position;

            //テキストの設定
            Font = Engine.Graphics.CreateFont("Resource/test.aff");
            Text = name + ":" + hasHpObject.hp;
        }

        protected override void OnUpdate()
        {
            //テキストを毎フレーム変更
            Text = name + ":" + hasHpObject.hp;
        }
    }
}
