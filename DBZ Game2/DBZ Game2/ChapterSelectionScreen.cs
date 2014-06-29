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
    class ChapterSelectionScreen
    {
        public void Initilize()
        {
            StartGame = false;
            selection = 0;
        }
        public bool StartGame = false;
        public int selection = 0;
        int nimbusX;
        int nimbusY;
        public void Draw(SpriteBatch spriteBatch, font Font, Extra extra)
        {
            spriteBatch.Draw(extra.SelectionBackgroundPic, new Rectangle(0,0,1100,720), Color.White);
            spriteBatch.DrawString(Font.TitleFont, "Welcome To The DBZ GAME", new Vector2(30, 30), Color.Black);
            spriteBatch.DrawString(Font.TitleFont, "Chapter Selection", new Vector2(35, 100), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "Chapter 1", new Vector2(35, 400), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "Chapter 2", new Vector2(35, 430), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "Chapter 3", new Vector2(35, 460), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "Chapter 4", new Vector2(35, 490), Color.Red);
            spriteBatch.Draw(extra.NimbusPic, extra.NimbusRect, Color.White);
        }
        public void Code(KeyboardState keyboard,KeyboardState oldkeyboard, Extra extra)
        {
            if (keyboard.IsKeyDown(Keys.Enter) && oldkeyboard.IsKeyUp(Keys.Enter))
            {
                StartGame = true;
            }
            if (keyboard.IsKeyDown(Keys.Up) && oldkeyboard.IsKeyUp(Keys.Up))
            {
                if (selection > 0)
                    selection--;
            }
            if (keyboard.IsKeyDown(Keys.Down) && oldkeyboard.IsKeyUp(Keys.Down))
            {
                if (selection < 3)
                    selection++;
            }


            switch (selection)
            {
                case 0:
                    nimbusX = 140;
                    nimbusY = 400;
                    break;
                case 1:
                    nimbusX = 140;
                    nimbusY = 430;
                    break;
                case 2:
                    nimbusX = 140;
                    nimbusY = 460;
                    break;
                case 3:
                    nimbusX = 140;
                    nimbusY = 490;
                    break;
                
            }
            extra.NimbusRect = new Rectangle(nimbusX, nimbusY, 25, 25);
        }
    }
}
