using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace GameName2
{
    class statics
    {
        public static GameTime gameTime;
        public static ContentManager Content;
        public static List<Bullet> BulletList;
        public static List<EnemyPlane> EnemyList;
        public static bool GameOver = false;
        public static int GameScore = 0;
        public static Potion pot = new Potion();
        
    }
}
