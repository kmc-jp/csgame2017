using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    //継承元を変更(変更)
    class Enemy : HasHpObject
    {
        //ゲームシーン,プレイヤー保持用(追加)
        GameScene gameScene;
        Player player;

        //HP表示用(追加)
        HpText hpText;

        //経過時間
        int count;

        //動く方向
        bool moveRight;

        //当たったか&無敵状態(追加)
        bool hitted;
        //当たってからの時間(追加)
        int hitcount;

        public Enemy(Player player,GameScene gameScene)
        {
            //それぞれ初期化(追加)
            this.gameScene = gameScene;
            this.player = player;

            //画像設定
            Texture = Engine.Graphics.CreateTexture2D("Resource/leader_ibaru.png");
            CenterPosition = new Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            Position = new Vector2DF(240, 100);
            Scale = new Vector2DF(0.2f, 0.2f);

            //初期化
            moveRight = true;
            hitted = false;

            //初期化(追加)
            hitcount = 0;
            count = 0;

            hp = 100;

            //当たり判定の半径(追加)
            radius = Texture.Size.X * Scale.X / 2f;

            //HP表示(追加)
            hpText = new HpText("敵のHP", new Vector2DF(0, 0), this, gameScene);
            gameScene.UILayer.AddObject(hpText);
        }

        //弾に当たったら実行(追加)
        public override void OnCollide(CollidableObject obj)
        {
            //エフェクト用
            hitted = true;
            hitcount = 30;

            hp -= 1;
            //HP0でゲームクリア
            if (hp <= 0)
            {
                Engine.ChangeScene(new GameClearScene());
            }
        }

        //何かとぶつかったかの判定(追加)
        protected void CollideWith(CollidableObject obj)
        {
            if(obj is null)
            {
                return;
            }

            if(obj is Bullet)
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
            //弾のレイヤにあるもの全てと当たり判定(追加)
            foreach (var obj in gameScene.bulletLayer.Objects)
            {
                CollideWith(obj as CollidableObject);
            }

            //左右移動
            if (moveRight)
            {
                Position = Position + new Vector2DF(5, 0);
            }
            else
            {
                Position = Position + new Vector2DF(-5, 0);
            }

            //反射
            if (Position.X < 0)
            {
                moveRight = true;
            }

            if (Position.X > Engine.WindowSize.X)
            {
                moveRight = false;
            }

            //経過時間
            count++;

            //弾発射
            if (count % 60 == 0)
            {
                for(int i = 0; i < 36; ++i)
                {
                    float angle = i * 10;

                    EnemyBullet bullet = new EnemyBullet(Position, 5, angle * (float)Math.PI / 180, player);

                    gameScene.bulletLayer.AddObject(bullet);
                }
            }

            if (count % 170 == 0)
            {
                for (int i = 1; i < 10; ++i)
                {
                    float angle = (float)Math.Atan2(-(player.Position.Y- Position.Y), player.Position.X- Position.X);

                    EnemyBullet bullet = new EnemyBullet(Position, i, angle,player);

                    gameScene.bulletLayer.AddObject(bullet);
                }
            }

            //当たったらエフェクト(追加)
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
        }
    }
}
