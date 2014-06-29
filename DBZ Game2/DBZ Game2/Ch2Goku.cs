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
    class Ch2Goku
    {
        public Texture2D Sprite;
        public Rectangle Position;
        public double X = 600;
        public double Y = 500;
        public double X2;
        public double EXP = 0;
        public double health = 10;
        public int level = 1;
        public bool Lvled = false;
        public int score = 0;
        private bool ITUsed = false;
        int speed;
        public void Movement(ref int Boost)
        {
            if (level <= 14)
            {
                speed = (10 + (int)(.9 * level));
            }
            if (level >= 15)
            {
                speed = 22;
            }
            Position = new Rectangle((int)X, (int)Y, 50, 75);
            if ((Keyboard.GetState().IsKeyDown(Keys.Up) && Y >= 30))
            {
                Y -= (Boost + 1)*5 + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Down) && (Y + 75) <= 720))
            {
                Y += (Boost + 1)*5 + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Left) && X >= 545))
            {
                X -= (Boost + 1)*5 + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Right) && (X + 50) <= 1060))
            {
                X += (Boost + 1)*5 + speed;

            }

        }
        public void MirrorMovement(Ch2Goku goku2)
        {
            X2 = (1010 - goku2.X);
            
            Position = new Rectangle((int)(X2), (int)goku2.Y, 75, 100);
        }
        public void CaptureSenzuBean(ref List<Rectangle> RECT, out List<Rectangle> rect, out bool OnScreen)
        {
            OnScreen = true;
            rect = RECT;
            LevelUp();
            for (int i = 0; i < rect.Count(); i++)
            {
                if (Position.Intersects(rect[i]))
                {
                    rect.RemoveAt(i);
                    i--;
                    SenzuBeanBenifits();
                    if (rect.Count() == 0)
                    {
                        OnScreen = false;
                    }
                    
                }
                
            }
        }
        private void SenzuBeanBenifits()
        {
            if (health < 1000)
                health += 10;
            if (health > 1000)
                health = 1000;
            EXP += 1;
            
        }
        public void LevelUp()
        {
            if (EXP == level + 9)
            {
                level++;
                EXP = 0;
                Lvled = true;
                ITUsed = false;
            }
        }
        public void CaptureSenzuBeans2(ref List<Rectangle> Rect, out List<Rectangle> rect, out bool OnScreen, Ch2Goku goku2)
        {
            rect = Rect;
            OnScreen = true;
            for (int i = 0; i < rect.Count(); i++)
            {
                if (Position.Intersects(rect[i]))
                {
                    rect.RemoveAt(i);
                    i--;
                    SenzuBeanBenifits2(goku2);
                    if (rect.Count() == 0)
                    {
                        OnScreen = false;
                    }
                    
                }
            }
        }
        private void SenzuBeanBenifits2(Ch2Goku goku2)
        {
            if (goku2.health < 1000)
                goku2.health += 10;
            if (goku2.health > 1000)
                goku2.health = 1000;
            goku2.EXP += 1;   
        }
        public void Ch4Movement(ref int Boost, ref int LEVEL)
        {
            if (level <= 14)
            {
                speed = (10 + (int)(.9 * LEVEL));
            }
            if (level >= 15)
            {
                speed = 22;
            }
            Position = new Rectangle((int)X, (int)Y, 50, 75);
            if ((Keyboard.GetState().IsKeyDown(Keys.Up) && Y >= 30))
            {
                Y -=(Boost + 1)*5+ speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Down) && (Y + 75) <= 720))
            {
                Y += (Boost + 1) * 5 + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Left) && X >= 0))
            {
                X -= (Boost + 1) * 5 + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Right) && (X + 50) <= 530))
            {
                X += (Boost + 1) * 5 + speed;

            }
        }
    }
}
