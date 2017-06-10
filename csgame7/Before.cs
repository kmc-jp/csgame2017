using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize("STG", 480, 640, new EngineOption());

            TextureObject2D player = new TextureObject2D();

            player.Texture = Engine.Graphics.CreateTexture2D("Resource/icon_business_man01.png");

            Engine.AddObject2D(player);

            player.CenterPosition = new Vector2DF(player.Texture.Size.X / 2.0f, player.Texture.Size.Y / 2.0f);

            player.Position = new Vector2DF(240, 500);

            player.Scale = new Vector2DF(0.2f, 0.2f);

            List<TextureObject2D> bullets = new List<TextureObject2D>();

            while (Engine.DoEvents())
            {
                float speed = 3;

                if (Engine.Keyboard.GetKeyState(Keys.Up) == KeyState.Hold)
                {
                    player.Position = player.Position + new Vector2DF(0, -speed);
                }

                if (Engine.Keyboard.GetKeyState(Keys.Down) == KeyState.Hold)
                {
                    player.Position = player.Position + new Vector2DF(0, speed);
                }

                if (Engine.Keyboard.GetKeyState(Keys.Left) == KeyState.Hold)
                {
                    player.Position = player.Position + new Vector2DF(-speed, 0);
                }

                if (Engine.Keyboard.GetKeyState(Keys.Right) == KeyState.Hold)
                {
                    player.Position = player.Position + new Vector2DF(speed, 0);
                }

                Vector2DF position = player.Position;

                position.X = MathHelper.Clamp(position.X, Engine.WindowSize.X - player.Texture.Size.X / 2.0f * player.Scale.X, player.Texture.Size.X / 2.0f * player.Scale.X);
                position.Y = MathHelper.Clamp(position.Y, Engine.WindowSize.Y - player.Texture.Size.Y / 2.0f * player.Scale.Y, player.Texture.Size.Y / 2.0f * player.Scale.Y);

                player.Position = position;

                if (Engine.Keyboard.GetKeyState(Keys.Z) == KeyState.Push)
                {

                    TextureObject2D bullet = new TextureObject2D();

                    bullet.Texture = Engine.Graphics.CreateTexture2D("Resource/business_taisyoku_todoke.png");

                    bullet.CenterPosition = new Vector2DF(bullet.Texture.Size.X / 2.0f, bullet.Texture.Size.Y / 2.0f);

                    bullet.Position = player.Position;

                    bullet.Scale = new Vector2DF(0.2f, 0.2f);

                    Engine.AddObject2D(bullet);

                    bullets.Add(bullet);

                }

                foreach (TextureObject2D bullet in bullets)
                {
                    bullet.Position = bullet.Position + new Vector2DF(0, -5);
                }

                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}