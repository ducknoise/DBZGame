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
    class Goku
    {
        public Texture2D Sprite;
        public Rectangle Position;
        public double X;
        public double Y;
        public int HighScore;
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
                speed = 20;
            }
            Position = new Rectangle((int)X, (int)Y, 75, 100);
            if ((Keyboard.GetState().IsKeyDown(Keys.Up) && Y >= 30))
            {
                Y -= (Boost + 1)*5 + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Down) && (Y + 100) <= 720))
            {
                Y += ((Boost + 1)*5) + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Left) && X >= 0))
            {
                X -= (Boost + 1)*5 + speed;

            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Right) && (X + 50) <= 1060))
            {
                X += (Boost + 1)*5 + speed;

            }
        }
        public void CaptureSenzuBean(ref List<Rectangle> RECT, out List<Rectangle> rect, out bool OnScreen)
        {
            OnScreen = true;
            rect = RECT;
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
            LevelUp();
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
        public void InstantaneousTransmisiion(ref List<Rectangle> RECT)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                if (ITUsed == false)
                {
                    X = RECT[0].X;
                    Y = RECT[0].Y;

                    ITUsed = true;
                }
            }

        }
    }
}
