using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    //継承元を変更(変更)
    class Player : HasHpObject
    {
        //ゲームシーン(追加)
        GameScene gameScene;

        //HP表示用(追加)
        HpText hpText;

        //当たったか&無敵状態(追加)
        bool hitted;
        //当たってからの時間(追加)
        int hitcount;

        public Player(GameScene gameScene)
        {
            //ゲームシーン保持用(追加)
            this.gameScene = gameScene;

            //画像設定
            Texture = Engine.Graphics.CreateTexture2D("Resource/icon_business_man01.png");
            CenterPosition = new Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            Position = new Vector2DF(240, 500);
            Scale = new Vector2DF(0.2f, 0.2f);

            //HP設定(追加)
            hp = 5;

            //HP表示(追加)
            hpText = new HpText("自分のHP", new Vector2DF(0, Engine.WindowSize.Y-30), this, gameScene);
            gameScene.UILayer.AddObject(hpText);

            //当たり判定の半径(追加)
            radius = Texture.Size.X *Scale.X/ 32f;

            //初期化(追加)
            hitted = false;
            hitcount = 0;
        }

        //弾に当たったら実行(追加)
        public override void OnCollide(CollidableObject obj)
        {
            //無敵でなければ判定する
            if (!hitted)
            {
                hitted = true;
                hitcount = 120;

                hp -= 1;
                //HP0でゲームオーバー
                if (hp <= 0)
                {
                    Engine.ChangeScene(new GameOverScene());
                }
            }
        }

        //何かとぶつかったかの判定(追加)
        protected void CollideWith(CollidableObject obj)
        {
            if (obj is null)
            {
                return;
            }

            if (obj is EnemyBullet)
            {
                if (IsCollide(obj))
                {
                    OnCollide(obj);
                    obj.OnCollide(this);
                }
            }
        }

        protected override void OnUpdate()
        {
            //移動スピード
            float speed = 3;

            //移動
            if (Engine.Keyboard.GetKeyState(Keys.Up) == KeyState.Hold)
            {
                Position = Position + new Vector2DF(0, -speed);
            }

            if (Engine.Keyboard.GetKeyState(Keys.Down) == KeyState.Hold)
            {
                Position = Position + new Vector2DF(0, speed);
            }

            if (Engine.Keyboard.GetKeyState(Keys.Left) == KeyState.Hold)
            {
                Position = Position + new Vector2DF(-speed, 0);
            }

            if (Engine.Keyboard.GetKeyState(Keys.Right) == KeyState.Hold)
            {
                Position = Position + new Vector2DF(speed, 0);
            }

            //ショット
            if (Engine.Keyboard.GetKeyState(Keys.Z) == KeyState.Push)
            {
                //前からショットを出す(ちょっと変更)
                Bullet bullet = new Bullet(Position+new Vector2DF(0,-50),5,(float)Math.PI*0.5f);

                //弾のレイヤに入れる(変更)
                gameScene.bulletLayer.AddObject(bullet);
            }

            //画面外に出ないように調整
            Vector2DF position = Position;

            position.X = MathHelper.Clamp(position.X, Engine.WindowSize.X - Texture.Size.X / 2.0f * Scale.X, Texture.Size.X / 2.0f * Scale.X);
            position.Y = MathHelper.Clamp(position.Y, Engine.WindowSize.Y - Texture.Size.Y / 2.0f * Scale.Y, Texture.Size.Y / 2.0f * Scale.Y);

            Position = position;

            //当たってる(無敵状態)ならエフェクト＆無敵時間減らす(追加)
            if (hitted)
            {
                hitcount--;
                if (hitcount <= 0)
                {
                    hitted = false;
                    Color = new Color(255, 255, 255, 255);
                }
                else
                {
                    if (hitcount % 4 == 0)
                    {
                        Color = new Color(255, 255, 255, 0);
                    }
                    else
                    {
                        Color = new Color(255, 255, 255, 128);
                    }
                }
            }
            else
            {
                //(無敵でないとき)
                //弾のレイヤにあるもの全てと当たり判定(追加)
                foreach (var obj in gameScene.bulletLayer.Objects)
                {
                    CollideWith(obj as CollidableObject);
                }
            }
        }
    }
}
