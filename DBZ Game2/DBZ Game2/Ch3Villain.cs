using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace DBZ_Game2
{
    class Ch3Villain
    {
        public Texture2D Sprite;
        public Rectangle Position;
        public double X = 0;
        public double Y = 30;
        public int speed;
        public void Movement(ref int level, ref double GokuX, ref double GokuY)
        {
          
            Position = new Rectangle((int)X, (int)Y, 75, 75);
            if (X < GokuX)
            {
                X += speed;
            }
            if (X > GokuX)
            {
                X -= speed;
            }
            if (Y < GokuY)
            {
                Y += speed;
            }
            if (Y > GokuY)
            {
                Y -= speed;
            }
        }
        public void Attack(ref double HEALTH, out double health, ref Rectangle goku)
        {
            health = HEALTH;
            if (Position.Intersects(goku))
                health -= 1;

        }
    }
}
