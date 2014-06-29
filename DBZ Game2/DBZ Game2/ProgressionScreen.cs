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
    class ProgressionScreen
    {
        public Texture2D BGPic;
        public int selection = 0;
        public bool SelectionMade = false;
        int nimbusX;
        int nimbusY;
        public void Code(KeyboardState keyboard, KeyboardState oldkeyboard, Extra extra)
        {
            if (keyboard.IsKeyDown(Keys.Enter) && oldkeyboard.IsKeyUp(Keys.Enter))
            {
                SelectionMade = true;
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                if (selection > 0)
                    selection--;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                if (selection < 1)
                    selection++;
            }


            switch (selection)
            {
                case 0:
                    nimbusX = 140;
                    nimbusY = 400;
                    break;
                case 1:
                    nimbusX = 170;
                    nimbusY = 430;
                    break;
            }
            extra.NimbusRect = new Rectangle(nimbusX, nimbusY, 25, 25);

        }
        public void Draw(SpriteBatch spriteBatch, font Font, Extra extra)
        {
            spriteBatch.Draw(BGPic, new Rectangle(0, 0, 1100, 720), Color.White);
            spriteBatch.DrawString(Font.SelectionFont, "Move On", new Vector2(35, 400), Color.Red);
            spriteBatch.DrawString(Font.SelectionFont, "Endless Mode", new Vector2(35, 430), Color.Red);
            spriteBatch.Draw(extra.NimbusPic, extra.NimbusRect, Color.White);
        }
     
    }
}
