using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameName2
{
    class Potion
    {
      Rectangle recPotion;
        Point Position;
        Random rnd;
        
        public Potion()
        {
             recPotion = new Rectangle();
             rnd  = new Random();
             Position = new Point(1000, rnd.Next(200, 400));
            
            
        
        }

        public void Update()
        {
            if (Position.X > -100)
            {
                recPotion = new Rectangle(Position.X, Position.Y, 20, 30);
                Position.X -= 12;
            
            
            }
        
        
        }
       
        public Rectangle getRectangle()
        {

            return recPotion;
        
        }
    }
}
