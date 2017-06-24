﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class TitleScene:Scene
    {
        protected override void OnRegistered()
        {
            //単一のレイヤ
            Layer2D layer = new Layer2D();
            AddLayer(layer);

            //テキスト表示
            TextObject2D text = new TextObject2D();
            text.Font= Engine.Graphics.CreateFont("Resource/test.aff");
            text.Text = "Zキーでスタート";
            text.Position = new Vector2DF(10, 100);

            layer.AddObject(text);
        }

        protected override void OnUpdated()
        {
            //Zキーでゲームシーン
            if (Engine.Keyboard.GetKeyState(Keys.Z) == KeyState.Push)
            {
                Engine.ChangeScene(new GameScene());
            }
        }
    }
}
