using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Part_4__Time_and_Sound
{
    public class Game1 : Game
    {
        float seconds;
        float startTime;
        bool exploded;
        MouseState mouseState;
        SoundEffect explode;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bombTexture;
        Rectangle bombRect;
        Texture2D boomTexture;
        Rectangle boomRect;
        SpriteFont timeFont;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            bombRect = new Rectangle(50, 50, 700, 400);
            boomRect = new Rectangle(50, 50, 700, 600);
            startTime = 0;
            exploded = false;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            timeFont = Content.Load<SpriteFont>("timefont");
            bombTexture = Content.Load<Texture2D>("bomb");
            explode = Content.Load<SoundEffect>("explosion");
            boomTexture = Content.Load<Texture2D>("big boom");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;

            if (mouseState.LeftButton == ButtonState.Pressed)
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
           
           
            if (seconds >= 10 || )
            {
                explode.Play();
                exploded = true;
            }
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            _spriteBatch.DrawString(timeFont, (10 - seconds).ToString("00.0"), new Vector2(310, 220), Color.Black);
            if (seconds >= 10)
                _spriteBatch.Draw(boomTexture, boomRect, Color.White);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            

            _spriteBatch.End();
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}