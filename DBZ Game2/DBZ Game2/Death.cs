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
    class Death
    {
              public bool ReStart = false;
        public void DeathCode(Goku goku)
        {
   
            
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                ReStart = true;
        }
        public void DeathDraw(SpriteBatch spriteBatch, Extra extra, font Font, Goku goku)
        {
            spriteBatch.Draw(extra.DeadBGPic, new Rectangle(0,0,1100,720), Color.White);
            spriteBatch.DrawString(Font.LevelUp, "GAME OVER", new Vector2(200, 250), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "Press [ENTER] to Start Again", new Vector2(350, 600), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "You're Score: " + goku.score, new Vector2(100, 100), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "High Score: " + goku.HighScore, new Vector2(100, 150), Color.Red);
        }
    }
}
