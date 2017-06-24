using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    class GameScene : Scene
    {
        //キャラ表示用
        public Layer2D characterLayer;
        //弾表示用
        public Layer2D bulletLayer;
        //UI表示用
        public Layer2D UILayer;

        protected override void OnRegistered()
        {
            //レイヤ初期化
            characterLayer = new Layer2D();
            bulletLayer = new Layer2D();
            UILayer = new Layer2D();

            //レイヤを設定
            AddLayer(characterLayer);
            AddLayer(bulletLayer);
            AddLayer(UILayer);

            //プレイヤーと敵を生成
            Player player = new Player(this);
            characterLayer.AddObject(player);

            Enemy enemy = new Enemy(player, this);
            characterLayer.AddObject(enemy);
        }
    }
}
