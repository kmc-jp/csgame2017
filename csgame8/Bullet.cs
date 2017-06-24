using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    //継承元を変更(変更)
    class Bullet : CollidableObject
    {
        //速度
        float speed;
        float angle;

        public Bullet(Vector2DF position,float _speed,float _angle)
        {
            //画像設定
            Texture = Engine.Graphics.CreateTexture2D("Resource/business_taisyoku_todoke.png");
            CenterPosition = new Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            Position = position;
            Scale = new Vector2DF(0.2f, 0.2f);

            //初期化
            speed = _speed;
            angle = _angle;

            //半径(追加)
            radius = Texture.Size.X * Scale.X / 2f;
        }

        //当たったら消える(追加)
        public override void OnCollide(CollidableObject obj)
        {
            Dispose();
        }

        protected override void OnUpdate()
        {
            //速度分動く
            Position = Position + new Vector2DF(speed*(float)Math.Cos(angle), -speed * (float)Math.Sin(angle));

            //画面外に出たら消える
            if (Position.Y < 0|| Position.Y> Engine.WindowSize.Y|| Position.X < 0 || Position.X > Engine.WindowSize.X)
            {
                Dispose();
            }
        }
    }
}
