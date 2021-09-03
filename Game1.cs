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

namespace Roman_Pig
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    
    public class Game1 : Microsoft.Xna.Framework.Game
        
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pigsTexture;
        Texture2D pigsTexture2;
        int vowelIndex;
        int Timer;
        String consonants;
        SpriteFont font1;
        String word;
        String word2;
        String character;
        Boolean isVowel;
        double x, y;
        double x1, y1;
        Rectangle pig1;
        Rectangle pig2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Timer = 0;
            word = "cat";
            word2 = "stack";
            vowelIndex = 0;
            x = 50;
            y = 50;
            x1 = 500;
            y1 = 200;
            // TODO: Add your initialization logic here
            pig1 = new Rectangle((int)x, (int)y, 100, 100);
            pig2 = new Rectangle((int)x1, (int)y1, 100, 100);
            base.Initialize();
        }
        private string translate(string word)
        {
            string restOfWord = word.Substring(1, word.Length - 1);
            string first = word.Substring(0,1);
            string second = word.Substring(1, 1);
            if ("AEIOUaeiou".Contains(first))
            {
                return word + "way";
            }
            else
            {
                if ("AEIOUaeiou".Contains(second))
                {
                    return restOfWord + word.Substring(0,1);
                }
            }
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font1 = this.Content.Load<SpriteFont>("SpriteFont1");
            pigsTexture = this.Content.Load<Texture2D>("Pig 1");
            pigsTexture2 = this.Content.Load<Texture2D>("Pig 2");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            Timer++;
            
            pig1.X = (int)x;
            pig1.Y = (int)y;
            pig2.X = (int)x1;
            pig2.Y = (int)y1;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Vector2 location = new Vector2(60, 30);
            spriteBatch.Begin();
            spriteBatch.DrawString(font1, translate, location, Color.White);
            spriteBatch.Draw(pigsTexture, pig1, Color.White);
            spriteBatch.Draw(pigsTexture2, pig2, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
