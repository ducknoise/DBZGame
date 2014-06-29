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
    class Ch2Villain
    {
        Random rand = new Random();
        double chance;
        int choice = 0;
        public Texture2D Sprite;
        public Rectangle Position;
        public double X = 0;
        public double Y = 30;
        int speed;
        public bool CH4 = false;
        public void Movement(ref int level, ref double GokuX, ref double GokuY, ref double Goku2X,ref double Goku2Y, Extra extra, ref int chance)
        {
            Target(ref chance);

            if (level == 0)
                level = 1;
            if (level <= 17)
            {
                speed = level;
            }
            if (CH4 ==true && level >2)
            { speed = (int)(speed * 0.8); }

            if (level >= 18 && CH4 == false)
            { speed = 17; }
            else if (level >= 18 && CH4 == true)
            { speed = 15; }
            Position = new Rectangle((int)X, (int)Y, 50, 75);
            VillainSprite(extra);
            if (choice == 0)
            {
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
            if (choice == 1)
            {
                if (X < Goku2X)
                {
                    X += speed;
                }
                if (X > Goku2X)
                {
                    X -= speed;
                }
                if (Y < Goku2Y)
                {
                    Y += speed;
                }
                if (Y > Goku2Y)
                {
                    Y -= speed;
                }
            }
        }
        public void Attack(ref double HEALTH, out double health, ref Rectangle goku2, ref Rectangle MirrorGoku)
        {
            health = HEALTH;
            if (Position.Intersects(goku2)|| Position.Intersects(MirrorGoku))
                health -=2;

        }
        private void Target(ref int chance)
        {
          
            if (chance == 108|| chance == 69)
            {
                if (choice == 0)
                    choice = 1;
                else
                    choice = 0;
            }

        }
        private void VillainSprite(Extra extra)
        {
            if (X >= 520)
                Sprite = extra.friezaPic;
            if (X < 520)
                Sprite = extra.buuPic;
        }
    }
}
