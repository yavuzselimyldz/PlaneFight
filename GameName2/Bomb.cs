using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameName2
{
    class Bomb
    {

         Rectangle recBomb;
        Point Position;
        Random rnd;
        
        public Bomb()
        {
             recBomb = new Rectangle();
             rnd  = new Random();
             Position = new Point(rnd.Next(100,500),10);
            
            
        
        }

        public void Update()
        {
            if (Position.Y > -100)
            {
                recBomb = new Rectangle(Position.X, Position.Y, 40, 40);
                Position.Y += 6;


            }


        }

        public Rectangle getRectangle()
        {

            return recBomb;

        }
    }
}
