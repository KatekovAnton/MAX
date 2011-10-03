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
using MAXNew.Game;
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

        //mouse
        public static MouseManager mouseManager;

        //fps and debug info
        public FpsCounter FPSCounter;
        public SpriteFont font1;

        //camera
        public static Camera camera;

        

        public Map map;


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        

        public Game1()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            FPSCounter = new FpsCounter();


            //sets destination resolution

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

            /*
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.ToggleFullScreen();
            */

            //disable vsync
            graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;
            
            //sets mouse visible
            IsMouseVisible = true;
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
            

            GameConfiguration.ScreenBounds = this.Window.ClientBounds;
            GameConfiguration.ScreenResolution = new Vector2(this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height);
            // TODO: Add your initialization logic here
            base.Initialize();
            //Tools.MaxRes.maxresunpak("max.res", "\\unpacked");
            //graphics.IsFullScreen = true;
            
            
            device = this.GraphicsDevice;
            
            mouseManager = new MouseManager();
            /* SpriteTexture =*/
            //Tools.MaxRes.convertAll("\\unpacked\\");
            map = Tools.MaxRes.loadWrl(SystemConfiguration.AppPath + "\\data\\maps\\Snow_3.wrl");
            map.mapDraw = new GraphicMap(map);
            map.clearLoadData();

            FileStream str1 = new FileStream(SystemConfiguration.AppPath + "\\unpacked\\AIREXPLD", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

            BinaryReader inf = new BinaryReader(str1);
            alienTank = Tools.MaxRes.LoadMultiImage(inf);
            camera = new Camera(map);
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GraphicMap.mapSprite = new SpriteBatch(GraphicsDevice);
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
            mouseManager.Update();
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


            bool needupdate = false;
            if (mouseManager.scrollWheelDelta != 0)
            {
                camera.updateScale(gameTime, mouseManager.mousePos, mouseManager.scrollWheelDelta > 0 ? 1 : -1);
                needupdate = true;
            }

            Vector2 cameraMove = Vector2.Zero;
            bool needMove = false;
            if (ks.IsKeyDown(Keys.Up))
            {
                needMove = true;
                cameraMove.Y += -1;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                cameraMove.Y += 1;
                needMove = cameraMove.Y!=0;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                needMove = true;
                cameraMove.X += -1;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                cameraMove.X += 1;
                needMove = cameraMove.X!=0;
            }
            if (needMove)
            {
                //cameraMove.Normalize();
                camera.updateMove(gameTime, cameraMove);
            }
            if (needMove || needupdate)
                camera.UpdateFinalInfo();
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
            map.draw();
            spriteBatch.Begin();

            Vector2 pos = new Vector2(100, 100);
            spriteBatch.Draw(alienTank.textures[index], pos - alienTank.frames[index].centerDelta + GameConfiguration.halfCell, Color.White);
            spriteBatch.DrawString(font1, string.Format("FPS: {0} Frame time: {1}", FPSCounter.FramesPerSecond, FPSCounter.FrameTime), Vector2.Zero, Color.White);
            spriteBatch.DrawString(font1, string.Format("scale: {0}", camera.scale), Vector2.Zero + new Vector2(0,20), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
