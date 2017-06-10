using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class Bullet : TextureObject2D
    {
        float speed;
        float angle;

        public Bullet(Vector2DF position,float _speed,float _angle)
        {
            Texture = Engine.Graphics.CreateTexture2D("Resource/business_taisyoku_todoke.png");

            CenterPosition = new Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);

            Position = position;

            Scale = new Vector2DF(0.2f, 0.2f);

            speed = _speed;
            angle = _angle;
        }

        protected override void OnUpdate()
        {
            Position = Position + new Vector2DF(speed*(float)Math.Cos(angle), -speed * (float)Math.Sin(angle));

            if (Position.Y < 0|| Position.Y> Engine.WindowSize.Y|| Position.X < 0 || Position.X > Engine.WindowSize.X)
            {
                Dispose();
            }
        }
    }
}
