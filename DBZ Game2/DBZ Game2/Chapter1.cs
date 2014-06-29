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
    class Chapter1
    {
        Random rand = new Random();
        int boost = 0;
        Rectangle BGRect = new Rectangle(0, 0, 1100, 740);
        Bar bar = new Bar();
        int timer;
        int ScoreTimer = 0;
        public bool Dead = false;
        public void Initialize(Goku goku, Death death, SenzuBeans senzuBean, Villain buu)
        {
            goku.health = 100;
            goku.EXP = 0;
            for (int i = 0; i < senzuBean.SenzuBeanRect.Count; i++)
            {
                senzuBean.SenzuBeanRect.RemoveAt(i);
            }
            
            senzuBean.RectsOnScreen = false;
            buu.X = 0;
            buu.Y = 30;
            goku.Lvled = false;
            goku.X = 500;
            goku.Y = 350;
            goku.level = 0;
            goku.score = 0;
            death.ReStart = false;
            Dead = false;
        }
        public void Code(Goku goku, SenzuBeans senzuBean, Villain buu, Redbull redBull )
        {
            SenzuBeanzStuff(senzuBean); //senzuBeanStuff HAS to be above GokuStuff.
            GokuStuff(goku, senzuBean, redBull);
            BuuStuff(buu, goku);
            RedBullStuff(redBull, goku, buu);
        }
        public void Draw(SpriteBatch spriteBatch, font Font, Extra extra, Goku goku,SenzuBeans senzuBean, Villain buu, Redbull redBull)
        {
            spriteBatch.Draw(extra.GameplayBackgroundPic, BGRect, Color.White);
            spriteBatch.Draw(goku.Sprite, goku.Position, Color.White);
            foreach (Rectangle rect in senzuBean.SenzuBeanRect)
                spriteBatch.Draw(senzuBean.Pic, rect, Color.White);
            spriteBatch.Draw(extra.pixel, bar.HealthRect, Color.Red);
            spriteBatch.Draw(extra.pixel, bar.EXPRect, Color.WhiteSmoke);
            LevelUpDraw(spriteBatch, goku, Font);
            spriteBatch.DrawString(Font.SelectionFont, "Health: " + goku.health, new Vector2(5, -7), Color.Black);
            spriteBatch.DrawString(Font.SelectionFont, "Level: " + goku.level, new Vector2(5, 690), Color.Black);
            spriteBatch.DrawString(Font.SelectionFont, "You're Score: " + goku.score * goku.level, new Vector2(570, 0), Color.Black);
            spriteBatch.Draw(buu.Sprite, buu.Position, Color.White);
            foreach (Rectangle rect in redBull.redBullRect)
                spriteBatch.Draw(redBull.redBullPic, rect, Color.White);
            redBull.RedbullIconDraw(spriteBatch, Font);
        }
        private void BuuStuff(Villain buu, Goku goku)
        {
            buu.Movement(ref goku.level, ref goku.X, ref goku.Y);
            buu.Attack(ref goku.health, out goku.health, ref goku.Position);
            if (goku.health <= 0)
            {
               Dead = true;
                if (goku.level != 0)
                    goku.score = goku.score * goku.level;
                string highScore = System.IO.File.ReadAllText(@"Content\Text.txt");
                goku.HighScore = int.Parse(highScore);
                if (goku.score > goku.HighScore)
                {
                    System.IO.File.WriteAllText(@"Content\Text.txt", goku.score.ToString());
                    goku.HighScore = goku.score;
                }
            }
        }
        private void GokuStuff(Goku goku, SenzuBeans senzuBean, Redbull redBull)
        {
            ScoreTimer++;
            if (ScoreTimer == 60)
            {
                goku.score++;
                ScoreTimer = 0;
            }
            goku.Movement(ref redBull.XBoost);
            int OnScreen = senzuBean.SenzuBeanRect.Count;
            goku.CaptureSenzuBean(ref senzuBean.SenzuBeanRect, out senzuBean.SenzuBeanRect, out senzuBean.RectsOnScreen);
            if (OnScreen != senzuBean.SenzuBeanRect.Count)
                goku.score += goku.level;
            bar.HealthANDExpBar(ref goku.level, ref goku.health, ref goku.EXP);
            goku.InstantaneousTransmisiion(ref senzuBean.SenzuBeanRect);
        }
        private void SenzuBeanzStuff(SenzuBeans senzuBean)
        {
            senzuBean.AddSenzuBeans();
        }
        private void LevelUpDraw(SpriteBatch spriteBatch, Goku goku, font Font)
        {
            if (goku.Lvled == true)
            {
                spriteBatch.DrawString(Font.LevelUp, "LEVEL UP!", new Vector2(200, 200), Color.Red);
                timer++;
                if (timer == 90)
                {
                    goku.Lvled = false;
                    timer = 0;
                }
            }
        }
        private void RedBullStuff(Redbull redBull, Goku goku, Villain buu)
        {
            redBull.RedBullStuff();
           if (redBull.Spawn == true)
            {
                redBull.redBullRect.Add(new Rectangle(rand.Next(0, 1010), rand.Next(0, 700), 50, 50));
                redBull.Spawn = false;
            }
           redBull.RedBullBoost(ref goku.Position, ref buu.Position);
        }
    }
}
