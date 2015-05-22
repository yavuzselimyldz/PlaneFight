using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameName2
{

    class Bullet
    {
        Point position;
        int bulletType;
        Rectangle recBullet;
        public Bullet(Point pos,int type)
        {
          
            bulletType = type;
            if (bulletType == 0)
            {
                position.X = pos.X + 120;
                position.Y = pos.Y + 20;
            }
            else 
            {
                position.X = pos.X - 10;
                position.Y = pos.Y + 20;
            
            }
           
        }
        public void Update()
        {
           
            
            
            if (bulletType == 0)
                position.X += 8;
            else
                position.X -= 8;

            recBullet = new Rectangle(position.X, position.Y, 34, 21);
        }
        public Point getPosition()
        {
            return position;

        }
        public int getBulletType()
        {

            return bulletType;
        }

        public Rectangle getRectangle()
        {
            return recBullet;
        
        
        }


    }
}
