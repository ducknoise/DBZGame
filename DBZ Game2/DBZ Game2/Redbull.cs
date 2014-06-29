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
    class Redbull
    {
        public List<Rectangle> redBullRect;
        public Texture2D redBullPic;
        int RandSpawn;
        Random rand = new Random();
        public bool Spawn = false;
        public int XBoost = 0;
        public double boostTimer;
        public Rectangle IconRect = new Rectangle(1020, 30, 50, 50);
        public Texture2D BoostIcon;
       
        public void RedBullStuff()
        {
            RandSpawn = rand.Next(0,1800);
            if (RandSpawn == 14)
            {
                Spawn = true;
            }
            if (XBoost != 0)
            {
                boostTimer--;
                if (boostTimer == 0)
                {
                    XBoost--;
                    boostTimer = 600;
                }
            }
        }
        public void RedBullBoost(ref Rectangle GokuRect, ref Rectangle BuuRect)
        {
            for (int i = 0; i < redBullRect.Count; i++)
            {
                if (GokuRect.Intersects(redBullRect[i]))
                {
                    redBullRect.RemoveAt(i);
                    XBoost++;
                    boostTimer = 600;
                    
                }
                
            }
            for (int i = 0; i < redBullRect.Count; i++)
            {
                if (BuuRect.Intersects(redBullRect[i]))
                {
                    redBullRect.RemoveAt(i);
                }
            }
        }
        public void RedbullIconDraw(SpriteBatch spriteBatch, font Font)
        {
            if (XBoost != 0)
            {
                spriteBatch.Draw(BoostIcon, IconRect, Color.White);
                spriteBatch.DrawString(Font.timeBoostFont, ((int)(boostTimer / 60)).ToString(), new Vector2(1030, 40), Color.Red);
                spriteBatch.DrawString(Font.xboostFont, XBoost.ToString(), new Vector2(1060, 30), Color.Green);
            }
        }
        public void RedBullBoost2(ref Rectangle GokuRect,ref Rectangle Goku2Rect, ref Rectangle BuuRect)
        {
            for (int i = 0; i < redBullRect.Count; i++)
            {
                if (GokuRect.Intersects(redBullRect[i])||Goku2Rect.Intersects(redBullRect[i]))
                {
                    redBullRect.RemoveAt(i);
                    XBoost++;
                    boostTimer = 600;

                }

            }
            for (int i = 0; i < redBullRect.Count; i++)
            {
                if (BuuRect.Intersects(redBullRect[i]))
                {
                    redBullRect.RemoveAt(i);
                }
            }
        }
        public void RedBullBoost3(ref Rectangle GokuRect, ref Rectangle Goku2Rect, ref Rectangle Villain2Rect, ref Rectangle Villain3Rect)
        {
            for (int i = 0; i < redBullRect.Count; i++)
            {
                if (GokuRect.Intersects(redBullRect[i]) || Goku2Rect.Intersects(redBullRect[i]))
                {
                    redBullRect.RemoveAt(i);
                    XBoost++;
                    boostTimer = 600;

                }

            }
            for (int i = 0; i < redBullRect.Count; i++)
            {
                if (Villain2Rect.Intersects(redBullRect[i])|| Villain3Rect.Intersects(redBullRect[i]))
                {
                    redBullRect.RemoveAt(i);
                }
            }
        }
        
    }
    }

