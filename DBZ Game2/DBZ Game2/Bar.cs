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
    class Bar
    {
        public Rectangle HealthRect = new Rectangle(0, 0, 0, 0);
        public double HealthWidth;
        public Rectangle EXPRect = new Rectangle(0,0,0,0);
        public double EXPWidth;
        
   
       
        
    public void HealthANDExpBar(ref int level,ref double health, ref double EXP)
        {
            HealthWidth = health * 1.08;
            HealthRect = new Rectangle(0, 0, (int)HealthWidth, 15);
            EXPWidth = EXP * (1080 / (9 + level));
            EXPRect = new Rectangle(0, 15, (int)EXPWidth, 15);

        }
    }
  }

