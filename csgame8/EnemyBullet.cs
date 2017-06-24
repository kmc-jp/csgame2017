using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class EnemyBullet : CollidableObject
    {
        //速度
        float speed;
        float angle;

        //プレイヤー保持用
        Player player;

        public EnemyBullet(Vector2DF position,float _speed,float _angle,Player player)
        {
            //画像設定
            Texture = Engine.Graphics.CreateTexture2D("Resource/envelop_paper.png");
            CenterPosition = new Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            Position = position;
            Scale = new Vector2DF(0.05f, 0.05f);

            //初期化
            speed = _speed;
            angle = _angle;
            this.player = player;
        }

        //当たったら消える(追加)
        public override void OnCollide(CollidableObject obj)
        {
            Dispose();
        }

        protected override void OnUpdate()
        {
            //速度ベクトルを足す
            Position = Position + new Vector2DF(speed*(float)Math.Cos(angle), -speed * (float)Math.Sin(angle));
            
            //画面外に出たら消える
            if (Position.Y < 0|| Position.Y> Engine.WindowSize.Y|| Position.X < 0 || Position.X > Engine.WindowSize.X)
            {
                Dispose();
            }
        }
    }
}
