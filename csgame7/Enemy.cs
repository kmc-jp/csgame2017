using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class Enemy : TextureObject2D
    {

        int count;

        bool moveRight;

        Player player;

        public Enemy(Player _player)
        {
            Texture = Engine.Graphics.CreateTexture2D("Resource/leader_ibaru.png");

            CenterPosition = new Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);

            Position = new Vector2DF(240, 100);

            Scale = new Vector2DF(0.2f, 0.2f);

            moveRight = true;

            player = _player;
        }

        protected override void OnUpdate()
        {
            if (moveRight)
            {
                Position = Position + new Vector2DF(5, 0);
            }
            else
            {
                Position = Position + new Vector2DF(-5, 0);
            }

            if (Position.X < 0)
            {
                moveRight = true;
            }

            if (Position.X > Engine.WindowSize.X)
            {
                moveRight = false;
            }

            count++;

            if (count % 60 == 0)
            {
                for(int i = 0; i < 36; ++i)
                {
                    float angle = i * 10;

                    EnemyBullet bullet = new EnemyBullet(Position, 5, angle * (float)Math.PI / 180);

                    Engine.AddObject2D(bullet);
                }
            }

            if (count % 170 == 0)
            {
                for (int i = 1; i < 10; ++i)
                {
                    float angle = (float)Math.Atan2(-(player.Position.Y- Position.Y), player.Position.X- Position.X);

                    EnemyBullet bullet = new EnemyBullet(Position, i, angle);

                    Engine.AddObject2D(bullet);
                }
            }
        }
    }
}
