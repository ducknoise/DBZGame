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
    class Chapter4
    {
        Random rand = new Random();
        int ScoreTimer = 0;
        Bar bar = new Bar();
        int chance;
        double score;
        public bool Dead = false;
        int ToonChoice = 1;
        int SenzuBeanCollectionCountdown = 360;
        public void Initialize(Ch2Goku goku2,Ch2Goku goku3, SenzuBeans senzuBean, Ch2Villain Villain2, Death death)
        {
            goku2.health = 100;
            goku2.EXP = 0;
            for (int i = 0; i < senzuBean.SenzuBeanRect.Count; i++)
            {
                senzuBean.SenzuBeanRect.RemoveAt(i);
            }

            senzuBean.RectsOnScreen = false;
            Villain2.X = 0;
            Villain2.Y = 30;
            goku2.Lvled = false;
            goku2.X = 600;
            goku2.Y = 350;
            goku3.X = 10;
            goku3.Y = 200;
            goku2.level = 0;
    
            death.ReStart = false;
            Dead = false;
            goku2.Position = new Rectangle(600, 350, 50, 75);
            goku3.Position = new Rectangle(10, 200, 50, 75);
        }
        public void Code(Ch2Goku goku2, Ch2Goku MirrorGoku, SenzuBeans senzuBean, Goku goku, Redbull redBull, Ch2Villain Villain2, Extra extra, KeyboardState oldkeyboard)
        {
            SenzuBeanStuff(senzuBean);
            GokuStuff(goku2, goku,MirrorGoku, senzuBean, redBull);
            score = goku.score * goku2.level;
            RedBullStuff(redBull, goku2, MirrorGoku, Villain2);
            VillainStuff(Villain2, goku2, MirrorGoku, extra, goku);
            if (Keyboard.GetState().IsKeyDown(Keys.C) && oldkeyboard.IsKeyUp(Keys.C))
            {
                if (ToonChoice == 0)
                { ToonChoice = 1; }

                else if (ToonChoice == 1)
                    ToonChoice = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Extra extra, Ch2Goku goku2, Ch2Goku MirrorGoku, SenzuBeans senzuBean, font Font, Redbull redBull, Ch2Villain Villain2)
        {
            spriteBatch.Draw(extra.GameplayBackgroundPic, new Rectangle(0, 0, 545, 720), Color.White);
            spriteBatch.Draw(extra.Namek, new Rectangle(540, 0, 545, 720), Color.White);
            spriteBatch.Draw(goku2.Sprite, goku2.Position, Color.White);
            spriteBatch.Draw(MirrorGoku.Sprite, MirrorGoku.Position, Color.White);
            foreach (Rectangle rect in senzuBean.SenzuBeanRect)
                spriteBatch.Draw(senzuBean.Pic, rect, Color.White);
            spriteBatch.Draw(extra.pixel, bar.HealthRect, Color.Red);
            spriteBatch.Draw(extra.pixel, bar.EXPRect, Color.WhiteSmoke);
            spriteBatch.DrawString(Font.SelectionFont, "Health: " + goku2.health, new Vector2(5, -7), Color.Black);
            spriteBatch.DrawString(Font.SelectionFont, "Level: " + goku2.level, new Vector2(5, 690), Color.Black);
            spriteBatch.DrawString(Font.SelectionFont, "You're Score: " + score, new Vector2(570, 0), Color.Green);
            foreach (Rectangle rect in redBull.redBullRect)
                spriteBatch.Draw(redBull.redBullPic, rect, Color.White);
            redBull.RedbullIconDraw(spriteBatch, Font);
            spriteBatch.Draw(Villain2.Sprite, Villain2.Position, Color.White);
            spriteBatch.DrawString(Font.SelectionFont, "Senzu Bean Collection Countdown " + (int)(SenzuBeanCollectionCountdown/60), new Vector2(570, 690), Color.White);
        }
        private void VillainStuff(Ch2Villain Villain2, Ch2Goku goku2, Ch2Goku MirrorGoku, Extra extra, Goku goku)
        {
            Villain2.CH4 = true;
            chance = rand.Next(0, 300);
            Villain2.Movement(ref goku2.level,ref goku2.X,ref goku2.Y,ref MirrorGoku.X,ref MirrorGoku.Y, extra, ref chance);
            Villain2.Attack(ref goku2.health, out goku2.health, ref goku2.Position, ref MirrorGoku.Position);
            if (goku2.health <= 0)
            {
                Dead = true;
                if (goku2.level != 0)
                    goku.score = goku.score * goku.level;
                string highScore = System.IO.File.ReadAllText(@"Content\Text.txt");
                goku.HighScore = int.Parse(highScore);
                if (goku.score > goku.HighScore)
                {
                    System.IO.File.WriteAllText(@"Content\Text.txt", goku.score.ToString());
                    goku.HighScore = goku.score;
                }
            }
            Villain2.CH4 = false;
        }
        private void RedBullStuff(Redbull redBull, Ch2Goku goku2, Ch2Goku MirrorGoku, Ch2Villain Villain2)
        {
            redBull.RedBullStuff();
            if (redBull.Spawn == true)
            {
                redBull.redBullRect.Add(new Rectangle(rand.Next(0, 1010), rand.Next(0, 700), 50, 50));
                redBull.Spawn = false;
            }
            redBull.RedBullBoost2(ref goku2.Position, ref MirrorGoku.Position, ref Villain2.Position);
        }
        private void GokuStuff(Ch2Goku goku2, Goku goku, Ch2Goku goku3, SenzuBeans senzuBean, Redbull redBull)
        {
            ScoreTimer +=2;
            if (ScoreTimer == 60)
            {
                goku.score+=4;
                ScoreTimer = 0;
            }
            if (ToonChoice == 0)
            {
                goku2.Movement(ref redBull.XBoost);               
            }
            if (ToonChoice == 1)
            {
                goku3.Ch4Movement(ref redBull.XBoost, ref goku2.level);
            }
            int OnScreen = senzuBean.SenzuBeanRect.Count;
            goku2.CaptureSenzuBean(ref senzuBean.SenzuBeanRect, out senzuBean.SenzuBeanRect, out senzuBean.RectsOnScreen);
            if (OnScreen != senzuBean.SenzuBeanRect.Count)
            {
                goku.score += goku.level;
                SenzuBeanCollectionCountdown = 360;
            }
            SenzuBeanCollectionCountdown--;
            if (SenzuBeanCollectionCountdown == 0)
            {
                SenzuBeanCollectionCountdown = 360;
                goku2.health -= 100;
            }
            bar.HealthANDExpBar(ref goku2.level, ref goku2.health, ref goku2.EXP);
            int Onscreen = senzuBean.SenzuBeanRect.Count;
            goku3.CaptureSenzuBeans2(ref senzuBean.SenzuBeanRect, out senzuBean.SenzuBeanRect, out senzuBean.RectsOnScreen, goku2);
            if (Onscreen != senzuBean.SenzuBeanRect.Count)
            {
                goku.score += goku.level;
                SenzuBeanCollectionCountdown = 360;
            }
            
        }
       
        private void SenzuBeanStuff(SenzuBeans senzuBean)
        {
            senzuBean.AddSenzuBeans();
        }
    }
}
