using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Shooting
{
    //当たり判定のあるオブジェクト
    class CollidableObject : TextureObject2D
    {
        //半径(初期値0)
        public float radius = 0f;

        //当たってるかの判定を返す
        public bool IsCollide(CollidableObject obj)
        {
            return (obj.Position - Position).Length < obj.radius + radius;
        }

        //当たったら何をするか
        public virtual void OnCollide(CollidableObject obj)
        {

        }
    }
}
