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
    class SenzuBeans
    {
        Random rand = new Random();
        public List<Rectangle> SenzuBeanRect = new List<Rectangle>();
        public bool RectsOnScreen = false;
        public Texture2D Pic;

        public void AddSenzuBeans()
        {
            if (SenzuBeanRect.Count ==0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int x = rand.Next(30, 1000);
                    int y = rand.Next(30, 600);
                    SenzuBeanRect.Add(new Rectangle(rand.Next(0, 1010), rand.Next(80, 700), 35, 35));
                }
                RectsOnScreen = true;
            }
        }
    }
}
