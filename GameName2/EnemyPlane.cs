using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace GameName2
{
    class EnemyPlane 
    {
        Rectangle recEnemy;
        Point position;
        Random rnd;
        int health;
        double firetime = 1;

        public EnemyPlane() 
        {

            Random rnd = new Random();
            position = new Point(1000, rnd.Next(50, 450));
            health = 20;


        }

        public void Update()
        {
            position.X -= 2;
            if (statics.gameTime.TotalGameTime.TotalSeconds > firetime)
            {

                openFire();
                firetime = statics.gameTime.TotalGameTime.TotalSeconds + 1;
            }

             ReduceHealth();
            
            
            
            
           


        }

        public Point getPosition()
        {

            return position;

        }

        public void openFire()
        {
            Bullet b = new Bullet(getPosition(), 1);
            statics.BulletList.Add(b);

        }

        public Rectangle getEnemyRectangle()
        {
            Rectangle recEnemy = new Rectangle(position.X, position.Y, 116, 65);
            return recEnemy;

        }

        public int ReduceHealth()
        {

            for (int i = 0; i < statics.BulletList.Count; i++)
            {
                if (statics.BulletList[i].getBulletType() == 0)
                {
                    
                        if (getEnemyRectangle().Intersects(statics.BulletList[i].getRectangle()))
                        {
                            statics.BulletList[i] = null;
                            statics.BulletList.Remove(statics.BulletList[i]);
                           
                            health -= 10;
                            statics.GameScore += 10;
                        }
                       

                    }


                }
            return health;
            }
        }
    }

