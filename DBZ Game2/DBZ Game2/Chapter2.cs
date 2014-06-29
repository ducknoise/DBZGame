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
    class Chapter2
    {
        Random rand = new Random();
        int ScoreTimer = 0;
        Bar bar = new Bar();
        int chance;
        double score;
       public bool Dead = false;
       public void Initialize(Ch2Goku goku2, SenzuBeans senzuBean, Ch2Villain Villain2, Death death)
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
           goku2.X = 500;
           goku2.Y = 350;
           goku2.level = 0;
          
           death.ReStart = false;
           Dead = false;
       }
        public void Code(Ch2Goku goku2, Ch2Goku MirrorGoku, SenzuBeans senzuBean,Goku goku,Redbull redBull, Ch2Villain Villain2, Extra extra)
        {
            SenzuBeanStuff(senzuBean);
            GokuStuff(goku2, goku, senzuBean, redBull);
            MirrorGokuStuff(MirrorGoku,goku2,senzuBean);
            score = goku.score * goku2.level;
            RedBullStuff(redBull,goku2, MirrorGoku,Villain2);
            VillainStuff(Villain2, goku2,MirrorGoku,extra);
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

        }
        private void VillainStuff(Ch2Villain Villain2, Ch2Goku goku2, Ch2Goku MirrorGoku, Extra extra)
        {
            chance = rand.Next(0, 600);
            Villain2.Movement(ref goku2.level, ref goku2.X, ref goku2.Y, ref MirrorGoku.X2, ref goku2.Y, extra, ref chance);
            Villain2.Attack(ref goku2.health, out goku2.health, ref goku2.Position, ref MirrorGoku.Position); 
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
        private void GokuStuff(Ch2Goku goku2, Goku goku, SenzuBeans senzuBean, Redbull redBull )
        {
            ScoreTimer+=2;
            if (ScoreTimer == 60)
            {
                goku.score++;
                ScoreTimer = 0;
            }
            goku2.Movement(ref redBull.XBoost);
            int OnScreen = senzuBean.SenzuBeanRect.Count;
            goku2.CaptureSenzuBean(ref senzuBean.SenzuBeanRect, out senzuBean.SenzuBeanRect, out senzuBean.RectsOnScreen);
            if (OnScreen != senzuBean.SenzuBeanRect.Count)
                goku.score += goku.level;
            bar.HealthANDExpBar(ref goku2.level, ref goku2.health, ref goku2.EXP);
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
        }
        private void MirrorGokuStuff(Ch2Goku MirrorGoku, Ch2Goku goku2, SenzuBeans senzuBean)
        {
            MirrorGoku.MirrorMovement(goku2);
            MirrorGoku.CaptureSenzuBeans2(ref senzuBean.SenzuBeanRect, out senzuBean.SenzuBeanRect, out senzuBean.RectsOnScreen, goku2);
        }
        private void SenzuBeanStuff(SenzuBeans senzuBean)
        {
            senzuBean.AddSenzuBeans();
        }
    }
}
