using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Altseedshoot
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

            player.Scale = new Vector2DF(0.2f, 0.2f) ;

            while (Engine.DoEvents())
             {
                float speed = 1;

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

                Engine.Update();
             }
            
               Engine.Terminate();
        }
    }
}
