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
using System.IO;

namespace DBZ_Game2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum GameState
        {
            IntroScreen,Chapter1, Dead, ChapterSelection, Chapter2, Progress, Chapter3, Chapter4, Instructions, Credits
        }
        KeyboardState keyboard;
        KeyboardState oldkeyboard;
        GamePadState gamepad;
         GameState State = new GameState();
        IntroScreen Intro = new IntroScreen();
        font Font = new font();
        Extra extra = new Extra();
        Chapter1 chapter1 = new Chapter1();
        Goku goku = new Goku();
        SenzuBeans senzuBean = new SenzuBeans();
        Villain buu = new Villain();
        Redbull redBull = new Redbull();
        Death death = new Death();
        ChapterSelectionScreen chapterSelectionScreen = new ChapterSelectionScreen();
        Chapter2 chapter2 = new Chapter2();
        Ch2Goku goku2 = new Ch2Goku();
        Ch2Goku MirrorGoku = new Ch2Goku();
        Ch2Villain Villain2 = new Ch2Villain();
        ProgressionScreen ProgScreen = new ProgressionScreen();
        Chapter3 chapter3 = new Chapter3();
        int LastChapter;
        Ch2Villain Villain3 = new Ch2Villain();
        Ch3Villain Frieza3 = new Ch3Villain();
        Ch3Villain Buu3 = new Ch3Villain();
        Chapter4 chapter4 = new Chapter4();
        Goku Gohan = new Goku();
        Instructions instructions = new Instructions();
        Credits Credit = new Credits();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
        
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Stream stream;
            Font.TitleFont = Content.Load<SpriteFont>("Title");
            Font.SelectionFont = Content.Load<SpriteFont>("Selection");
            Font.LevelUp = Content.Load<SpriteFont>("LevelUp");
            Font.xboostFont = Content.Load<SpriteFont>("xboost");
            Font.timeBoostFont = Content.Load<SpriteFont>("timeboost");
            stream = File.OpenRead(@"Content\IntroScreenBackground.jpg");
            extra.SelectionBackgroundPic = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Nimbus.png");
            extra.NimbusPic = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Kai's Planet.png");
            extra.GameplayBackgroundPic = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Goku3.png");
            goku.Sprite = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Senzu Bean.png");
            senzuBean.Pic = Texture2D.FromStream(GraphicsDevice, stream);
            extra.pixel = Content.Load<Texture2D>("Pixel");
            stream = File.OpenRead(@"Content\Buu.png");
            extra.buuPic = Texture2D.FromStream(GraphicsDevice, stream);
            buu.Sprite = extra.buuPic;
            stream = File.OpenRead(@"Content\RedBull.png");
            redBull.redBullPic = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\SpeedBoostIcon.png");
            redBull.BoostIcon = Texture2D.FromStream(GraphicsDevice, stream);
            redBull.redBullRect = new List<Rectangle>();
            stream = File.OpenRead(@"Content\GameOver.png");
            extra.DeadBGPic = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\NamekGreenPlanet.png");
            extra.Namek = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Goku1.png");
            goku2.Sprite = Texture2D.FromStream(GraphicsDevice, stream);
            MirrorGoku.Sprite = goku.Sprite;
            stream = File.OpenRead(@"Content\FriezaPic.png");
            extra.friezaPic = Texture2D.FromStream(GraphicsDevice, stream);
            Villain2.Sprite = extra.buuPic;
            ProgScreen.BGPic = extra.SelectionBackgroundPic;
            Villain3.Sprite = extra.friezaPic;
            stream = File.OpenRead(@"Content\Instructions1.png");
            extra.Slide[0] = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Instructions2.png");
            extra.Slide[1] = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Instructions3.png");
            extra.Slide[2] = Texture2D.FromStream(GraphicsDevice, stream);
            stream = File.OpenRead(@"Content\Credits.png");
            extra.Credits = Texture2D.FromStream(GraphicsDevice, stream);
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
           
            keyboard = Keyboard.GetState();
            IsMouseVisible = true;
 
            switch (State)
            {
                case GameState.IntroScreen:
                    
                    Intro.Code(keyboard,oldkeyboard, extra);
                    
                    IntroScreenStuff();
                    break;
                case GameState.ChapterSelection:
                    chapterSelectionScreen.Code(keyboard,oldkeyboard, extra);
                    ChapterSelectionScreenStuff();
                    break;
                case GameState.Chapter1:
                    chapter1.Code(goku, senzuBean, buu, redBull);
                    if (chapter1.Dead == true)
                        State = GameState.Dead;
                    if (goku.level == 14)
                    {
                        State = GameState.Progress;
                    }
                    LastChapter = 1;
                    break;
                case GameState.Dead:
                    death.DeathCode(goku);
                    if (death.ReStart == true)
                    {
                        State = GameState.IntroScreen;
                    }
                    break;
                case GameState.Chapter2:
                    chapter2.Code(goku2, MirrorGoku, senzuBean, goku, redBull,Villain2, extra);
                    if (chapter2.Dead == true)
                        State = GameState.Dead;
                    if (goku2.level == 14)
                    {
                        State = GameState.Progress;
                    }
                    LastChapter = 2;
                    break;
                case GameState.Progress:
                    ProgScreen.Code(keyboard, oldkeyboard, extra);
                    ProgScreenStuff();
                    break;
                case GameState.Chapter3:
                    chapter3.Code(goku2, MirrorGoku, senzuBean, goku, redBull,Villain2,Villain3,extra);
                    if (chapter3.Dead == true)
                        State = GameState.Dead;
                    if (goku2.level == 14)
                    {
                        State = GameState.Progress;
                    }
                    LastChapter = 3;
                    break;
                case GameState.Chapter4:
                    chapter4.Code(goku2, MirrorGoku, senzuBean, goku, redBull, Villain2, extra, oldkeyboard);
                    if (chapter4.Dead == true)
                        State = GameState.Dead;
                    break;
                case GameState.Instructions:
                    instructions.Code(keyboard, oldkeyboard, extra);
                    if (instructions.StartScreen == true)
                    {
                        instructions.OnSlide = 0;
                        Intro.StartGame = false;
                        State = GameState.IntroScreen;
                    }
                    break;
                case GameState.Credits:
                    Credit.Code(keyboard, oldkeyboard, extra);
                    if (Credit.StartScreen == true)
                    {
                        Intro.StartGame = false;
                        State = GameState.IntroScreen;
                    }
                    break;

            }
            oldkeyboard = keyboard;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (State)
            {
                case GameState.IntroScreen:
                    Intro.Draw(spriteBatch, Font, extra);
                    break;
                case GameState.ChapterSelection:
                    chapterSelectionScreen.Draw(spriteBatch, Font, extra);
                    break;
                case GameState.Chapter1:
                    chapter1.Draw(spriteBatch,Font,extra, goku, senzuBean, buu, redBull);
                    break;
                case GameState.Dead:
                    death.DeathDraw(spriteBatch, extra, Font, goku);
                    break;
                case GameState.Chapter2:
                    chapter2.Draw(spriteBatch,extra, goku2, MirrorGoku, senzuBean, Font,redBull,Villain2);
                    break;
                case GameState.Progress:
                    ProgScreen.Draw(spriteBatch, Font, extra);
                    break;
                case GameState.Chapter3:
                    chapter3.Draw(spriteBatch, extra, goku2, MirrorGoku, senzuBean, Font, redBull,Villain2,Villain3);
                    break;
                case GameState.Chapter4:
                    chapter4.Draw(spriteBatch, extra, goku2, MirrorGoku, senzuBean, Font, redBull, Villain2);
                    break;
                case GameState.Instructions:
                    instructions.Draw(spriteBatch, Font, extra);
                    break;
                case GameState.Credits:
                    Credit.Draw(spriteBatch, Font, extra);
                    break;
            }
            spriteBatch.End();
            oldkeyboard = keyboard;

            base.Draw(gameTime);
        }
        private void ProgScreenStuff()
        {
            switch(LastChapter)
            {
                case 1:
                    Chapter1ProgScreen();
            break;
                case 2:
            Chapter2ProgScreen();
            break;
                case 3:
            Chapter3ProgScreen();
            break;
        }

        }
       

        private void Chapter3ProgScreen()
        {
            if (ProgScreen.SelectionMade == true)
            {
                if (ProgScreen.selection == 0)
                {
                    chapter4.Initialize(goku2, MirrorGoku, senzuBean, Villain2, death);
                    ProgScreen.SelectionMade = false;
                    State = GameState.Chapter4;
                }
                if (ProgScreen.selection == 1)
                {
                    ProgScreen.SelectionMade = false;
                    goku2.level = 15;
                    State = GameState.Chapter3;
                }
            }
        }
        private void Chapter2ProgScreen()
        {
            if (ProgScreen.SelectionMade == true)
            {
                if (ProgScreen.selection == 0)
                {
                    chapter3.Initialize(goku2, senzuBean, Villain2, Villain3, death);
                    ProgScreen.SelectionMade = false;
                    State = GameState.Chapter3;
                }
                if (ProgScreen.selection == 1)
                {
                    ProgScreen.SelectionMade = false;
                    goku2.level = 15;
                    State = GameState.Chapter2;
                }
            }
        }

        private void Chapter1ProgScreen()
        {
            if (ProgScreen.SelectionMade == true)
            {
                if (ProgScreen.selection == 0)
                {
                    chapter2.Initialize(goku2, senzuBean, Villain2, death);
                    ProgScreen.SelectionMade = false;
                    State = GameState.Chapter2;
                }
                if (ProgScreen.selection == 1)
                {
                    ProgScreen.SelectionMade = false;
                    goku.level = 15;
                    State = GameState.Chapter1;
                }
            }
        }
        private void ChapterSelectionScreenStuff()
        {
            if (chapterSelectionScreen.StartGame == true)
            {
                switch (chapterSelectionScreen.selection)
                {
                    case 0:
                    chapter1.Initialize(goku, death, senzuBean, buu);
                    chapterSelectionScreen.StartGame = false;
                    goku.score = 0;
                    State = GameState.Chapter1;
                break;
                     
                    case 1:
                         State = GameState.Chapter2;
                         chapter2.Initialize(goku2, senzuBean, Villain2, death);
                         goku.score = 0;
                break;
                    case 2:
                        State = GameState.Chapter3;
                    chapter3.Initialize(goku2, senzuBean, Villain2, Villain3, death);
                    goku.score = 0;
                break;
                    case 3:
                        State = GameState.Chapter4;
                        chapter4.Initialize(goku2,MirrorGoku, senzuBean, Villain2, death);
                        goku.score = 0;
                break;                        
                }
             
            }
        }
        private void IntroScreenStuff()
        {
            if (Intro.StartGame == true)
            {
                if (Intro.selection == 0)
                {
                    State = GameState.Chapter1;
                    chapter1.Initialize(goku, death, senzuBean, buu);
                    Intro.StartGame = false;
                }
                if (Intro.selection == 1)
                {
                    chapterSelectionScreen.Initilize();
                    State = GameState.ChapterSelection;
                    Intro.StartGame = false;
                }
                if (Intro.selection == 2)
                    State = GameState.Instructions;
                if (Intro.selection == 3)
                    State = GameState.Credits;
            }
        }
    }
}
