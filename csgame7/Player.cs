using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class Player : TextureObject2D
    {

        public Player()
        {
            Texture = Engine.Graphics.CreateTexture2D("Resource/icon_business_man01.png");
            CenterPosition = new Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            Position = new Vector2DF(240, 500);
            Scale = new Vector2DF(0.2f, 0.2f);
        }

        protected override void OnUpdate()
        {
            float speed = 3;

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

            if (Engine.Keyboard.GetKeyState(Keys.Z) == KeyState.Push)
            {
                Bullet bullet = new Bullet(Position,5,(float)Math.PI*0.5f);

                Engine.AddObject2D(bullet);
            }

            Vector2DF position = Position;

            position.X = MathHelper.Clamp(position.X, Engine.WindowSize.X - Texture.Size.X / 2.0f * Scale.X, Texture.Size.X / 2.0f * Scale.X);
            position.Y = MathHelper.Clamp(position.Y, Engine.WindowSize.Y - Texture.Size.Y / 2.0f * Scale.Y, Texture.Size.Y / 2.0f * Scale.Y);

            Position = position;
        }
    }
}
