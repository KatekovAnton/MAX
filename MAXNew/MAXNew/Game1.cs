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

using MAXNew.Helpers;
using MAXNew.Config;
using MAXNew.Game.Graphic;

namespace MAXNew
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //device
        public static GraphicsDevice device;

        //fps and debug info
        public FpsCounter FPSCounter;
        public SpriteFont font1;


        GraphicMap draw;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            FPSCounter = new FpsCounter();


            //disable vsync
            graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        GraphicUnit alienTank;
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            //Tools.MaxRes.maxresunpak("max.res", "\\unpacked");
            device = this.GraphicsDevice;
            /* SpriteTexture =*/
            //Tools.MaxRes.convertAll("\\unpacked\\");
            Tools.MapBase baseinfo = Tools.MaxRes.loadWrl("Green_6.wrl");
            draw = new GraphicMap(baseinfo);
            FileStream str1 = new FileStream("D:\\GAME\\MAX\\MAXNew\\MAXNew\\MAXNew\\bin\\x86\\Debug\\unpacked\\ALNTANK", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
            BinaryReader inf = new BinaryReader(str1);
            alienTank = Tools.MaxRes.LoadMultiImage(inf);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font1 = Content.Load<SpriteFont>("SpriteFont1");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
int index = 13;
bool lf = true;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            FPSCounter.Update(gameTime);
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.L) && lf)
            {
                lf = false;
                index++;
                if (index == alienTank.frames.Length)
                    index = 0;
            }
            if (ks.IsKeyUp(Keys.L))
                lf = true;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.BlendState = BlendState.Opaque;
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            Vector2 pos = new Vector2(100,100);
            spriteBatch.Draw(draw.mapElementsSingle, pos,draw.rectangles[10], Color.White);
            
            spriteBatch.Draw(alienTank.textures[index], pos - alienTank.frames[index].centerDelta + GameConfiguration.halfCell, Color.White);
            spriteBatch.DrawString(font1, string.Format("FPS: {0} Frame time: {1}", FPSCounter.FramesPerSecond, FPSCounter.FrameTime), Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
