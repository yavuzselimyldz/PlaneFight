using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameName2
{
    class Cloud
    {
        Rectangle recCloud;
        Point Position;
        Random rnd;
        int choice=0;
        public Cloud()
        {
             recCloud = new Rectangle();
             rnd  = new Random();
             Position = new Point(1000, rnd.Next(200, 400));
             setCloud();
            
        
        }
        
        public void Update()
        {

            if (Position.X > 500)
            {

                recCloud.X -= 2;

            }
            else
                setCloud();
        
        
        
        }
        public Point getPosition()
        {
            return Position;
        }
        public Rectangle getRectangle()
        {

            return recCloud;
        
        }

        public void setCloud()
        {

            Position = new Point(1000, rnd.Next(50, 400));
            choice = rnd.Next(0, 3);
            if (choice == 0)
            {
                recCloud = new Rectangle(Position.X, Position.Y, 330, 234);

            }
            if (choice == 1)
            {
                recCloud = new Rectangle(Position.X, Position.Y, 230, 134);

            }
            if (choice == 2)
            {
                recCloud = new Rectangle(Position.X, Position.Y, 130, 50);

            }

        }
    }
}
