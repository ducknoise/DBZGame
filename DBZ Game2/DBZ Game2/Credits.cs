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
    class Credits
    {
        Rectangle BGRect = new Rectangle(0, 0, 1080, 720);
        public bool StartScreen = false;
        public int OnSlide = 0;


        public void Code(KeyboardState keyboard, KeyboardState oldkeyboard, Extra extra)
        {
            StartScreen = false;

            if (keyboard.IsKeyDown(Keys.Left) && oldkeyboard.IsKeyUp(Keys.Left))
            {
                StartScreen = true;
            }
            
        }
        public void Draw(SpriteBatch spriteBatch, font Font, Extra extra)
        {
            spriteBatch.Draw(extra.Credits, BGRect, Color.White);
            spriteBatch.DrawString(Font.SelectionFont, "[<--] Back", new Vector2(35, 680), Color.Black);
            
        }
    }
}
