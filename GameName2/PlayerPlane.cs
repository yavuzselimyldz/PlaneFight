using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;



namespace GameName2
{
    class PlayerPlane
    {
        Point position;
        double firetime=1;
        double health;
        int score;
        SoundEffect soundBullet;
       
       
        public PlayerPlane()
        {
            position = new Point(0, 300);
            health = 100;
            soundBullet = statics.Content.Load<SoundEffect>("Sounds/bulletsound");
        
           
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (position.Y > 0)
                    position.Y -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (position.Y < 430)
                    position.Y += 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (position.X > 0)
                    position.X -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (position.X < 700)
                    position.X += 6;
            }
           
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                if (statics.gameTime.TotalGameTime.TotalSeconds > firetime)
                {
                    

                    openFire();
                    firetime = statics.gameTime.TotalGameTime.TotalSeconds + 0.2;
                }
                
            
            }
            ReduceHealth();
           

        }
        public Point getPosition()
        {
            return position;
        }
        public void openFire()
        {
            Bullet b = new Bullet(getPosition(),0);
            statics.BulletList.Add(b);
            
            soundBullet.Play();

        }
        public void ReduceHealth()
        { 
            Rectangle recPlayer = new Rectangle(position.X,position.Y,115,67);
       for(int i=0;i<statics.BulletList.Count;i++)
            {
                if (statics.BulletList[i].getBulletType() == 1)
                
                {
                    if (recPlayer.Intersects(statics.BulletList[i].getRectangle()))
                    {
                        statics.BulletList[i] = null;
                        statics.BulletList.Remove(statics.BulletList[i]);
                        health -= 10;
                        if (health <= 0)
                        {

                            statics.GameOver = true;
                        }
                    
                    }
                
                }
            
            
            
            }
           
        
        
        }

      
        
        
        public int getHealth()
        {
             int health2 = Convert.ToInt16(health);
            return health2;
        }

        public Rectangle getRectangle()
        { 
       Rectangle recPlayer = new Rectangle(position.X, position.Y, 115, 67);
       return recPlayer;
        
        }

        public void IncreaseHelath()
        {
            health += 1.8;
        
        }
    
    }
}
