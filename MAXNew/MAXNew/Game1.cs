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
using MAXNew.Game;
using MAXNew.Game.Graphic;

using MAXNew.ResourceProviders;

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

        //camera
        public static Camera camera;

        //fps and debug info
        public FpsCounter FPSCounter;

        //user interface
        public UI.UIManager userInterface;

        //fonts
        public UI.UIFontHelper fonts;


        //resources
        MAXNew.ResourceProviders.MAXRESImageProvider maxres;
        MAXNew.ResourceProviders.ImageCache images;
        
        
        
        GraphicUnit AIREXPLD;

        public Map map;


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int index = 0;
        bool lf = true;

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

        protected override void Initialize()
        {
            

            GameConfiguration.ScreenBounds = this.Window.ClientBounds;
            GameConfiguration.ScreenResolution = new Vector2(this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height);
            // TODO: Add your initialization logic here
            base.Initialize();

            //graphics.IsFullScreen = true;
            
            
            device = this.GraphicsDevice;
            
            mouseManager = new MouseManager();

            map = Tools.MaxRes.loadWrl(SystemConfiguration.AppPath + "\\data\\maps\\Snow_5.wrl");
            map.mapDraw = new GraphicMap(map);
            Animator.Instance.AddAObject(map, map.AddFrame, 150.0);
            GraphicMap.mapShader.Parameters["ViewportSize"].SetValue(GameConfiguration.ScreenResolution);
            map.clearLoadData();


            AIREXPLD = maxres.loadMultiImage("TANK");
            camera = new Camera(map);
            userInterface = new UI.UIManager(Game1.device);
            
            CashedTexture2D t2d = ImageCache.Instance.GetImage("ENDGAME6",TextureType.Paletted);

            UI.UIMenu menu = new UI.UIMenu(new Rectangle(100, 100, 55, 32));
            userInterface.maincontrol.AddChild(menu);
            UI.UIFixedStateButton button = new UI.UIFixedStateButton(new Rectangle(0, 0, 55, 16), menu);
            button.SetIdleImage(new ImagePart(ImageCache.Instance.GetImage("AMMO_OF", TextureType.Simple), null));
            button.SetPressedImage(new ImagePart(ImageCache.Instance.GetImage("AMMO_ON", TextureType.Simple), null));


            UI.UIButton button1 = new UI.UIButton(new Rectangle(0, 16, 55, 16), menu);
            button1.SetIdleImage(new ImagePart(ImageCache.Instance.GetImage("AMMO_OF", TextureType.Simple), null));
            button1.SetPressedImage(new ImagePart(ImageCache.Instance.GetImage("AMMO_ON", TextureType.Simple), null));


            UI.UILabel label = new UI.UILabel(new Rectangle(52, 33, 100, 100));
            label.Font = UI.UIFontHelper.CourierNew12RegularBold;
            label.Text = "test text";
            label.Color = Color.Red;
            userInterface.maincontrol.AddChild(label);


        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GraphicMap.mapSprite = new SpriteBatch(GraphicsDevice);

            maxres = new ResourceProviders.MAXRESImageProvider();
            GraphicMap.mapShader = Content.Load<Effect>("MapRender");
            ResourceProviders.XNAFontProvider fonts1 = new ResourceProviders.XNAFontProvider(Content);
            fonts = new UI.UIFontHelper();
            // TODO: use this.Content to load your game content here
 
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            maxres.clear();
        }

        protected override void Update(GameTime gameTime)
        {
            Animator.Instance.Update(gameTime);
            mouseManager.Update();
            // TODO: Add your update logic here
            FPSCounter.Update(gameTime);
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.L) && lf)
            {
                lf = false;
                index++;
                if (index == AIREXPLD.frames.Length)
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

            userInterface.Update();
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


            Vector2 pos = new Vector2(200, 200);
          //RasterizerState oldstate = GraphicsDevice.RasterizerState;
          //RasterizerState newstate = new RasterizerState();
          //newstate.ScissorTestEnable = true;
          //GraphicsDevice.RasterizerState = newstate;

          //  GraphicsDevice.ScissorRectangle = new Rectangle(0, 0, 107, 200);

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, newstate);

            

            spriteBatch.Begin();
            spriteBatch.Draw(AIREXPLD.textures[index],
                pos - AIREXPLD.frames[index].centerDelta + GameConfiguration.halfCell, 
                Color.White);
            spriteBatch.DrawString(XNAFontProvider.CourierNew12RegularBold, string.Format("FPS: {0} Frame time: {1}", FPSCounter.FramesPerSecond, FPSCounter.FrameTime), Vector2.Zero, Color.White);
            spriteBatch.DrawString(XNAFontProvider.CourierNew12RegularBold, string.Format("scale: {0}", camera.scale), Vector2.Zero + new Vector2(0, 20), Color.White);
            spriteBatch.End();
            //GraphicsDevice.RasterizerState = oldstate;
            userInterface.Draw();
            base.Draw(gameTime);
        }
    }
}
