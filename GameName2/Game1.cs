#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;

#endregion

namespace GameName2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D imgBackground;
        Texture2D imgCloud;
        Texture2D imgpPlane;
        Texture2D imgBullet;
        Texture2D imgPotion;
        Texture2D imgBomb;
        Texture2D imgEnemybullet;
        Texture2D imgEnemy;
        EnemyPlane enemyPlane;
        Potion pot  = new Potion();
        Bomb   bomb = new Bomb();
        PlayerPlane playerPlane;
        Cloud cloud;
        Rectangle recBackground;
        SpriteFont Font;
        SoundEffect soundExplosion;

        int enemytime = 1;
        int potiontime = 1;
        int bombtime = 1;
        string GameOver = "GAME OVER";


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            statics.Content = Content;
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           
            recBackground = new Rectangle();
            cloud = new Cloud();
            playerPlane = new PlayerPlane();
            enemytime = 2;
            potiontime = 10;
            bombtime = 15;
           
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
         
            imgBackground = Content.Load<Texture2D>("sprites/Background");
            imgCloud = Content.Load<Texture2D>("sprites/cloud");
            imgpPlane = Content.Load<Texture2D>("sprites/plane");
            imgBullet = Content.Load<Texture2D>("sprites/bullet");
            imgEnemybullet = Content.Load<Texture2D>("sprites/enemybullet");
            imgPotion = Content.Load<Texture2D>("sprites/potion");
            imgEnemy = Content.Load<Texture2D>("sprites/plane2");
            imgBomb = Content.Load<Texture2D>("sprites/bomb");
            Font = Content.Load<SpriteFont>("Font/font");
            statics.BulletList = new List<Bullet>();
            statics.EnemyList = new List<EnemyPlane>();
            soundExplosion = Content.Load<SoundEffect>("Sounds/explosion");

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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            statics.gameTime = gameTime;
        

            for (int i = 0; i < statics.EnemyList.Count; i++)
            {
                statics.EnemyList[i].Update();
                if (statics.EnemyList[i].getPosition().X < 0)
                {
                    statics.EnemyList[i] = null;
                    statics.EnemyList.Remove(statics.EnemyList[i]);

                }

            }
            for (int i = 0; i < statics.BulletList.Count; i++)
            {
                statics.BulletList[i].Update();
                if (statics.BulletList[i].getPosition().X < -50 || statics.BulletList[i].getPosition().X > 800)
                {
                    statics.BulletList[i] = null;
                    statics.BulletList.Remove(statics.BulletList[i]);
                }

            }
            for (int i = 0; i < statics.EnemyList.Count; i++)
            {

                statics.EnemyList[i].Update();
                if (statics.EnemyList[i].ReduceHealth() == 0)
                {
                    soundExplosion.Play();
                    statics.EnemyList[i] = null;
                    statics.EnemyList.Remove(statics.EnemyList[i]);
                    statics.GameScore += 100;

                }
            }
            if (playerPlane.getRectangle().Intersects(bomb.getRectangle()))
            {

                for (int i = 0; i < statics.EnemyList.Count; i++)
                {
                    statics.EnemyList[i] = null;
                    statics.EnemyList.Remove(statics.EnemyList[i]);
                
                }


            }
            if (playerPlane.getRectangle().Intersects(pot.getRectangle()))
            {

                playerPlane.IncreaseHelath();
              
            
            }
            if ((int)statics.gameTime.TotalGameTime.TotalSeconds > enemytime)
            {

                EnemyPlane e = new EnemyPlane();
                
                statics.EnemyList.Add(e);
                enemytime = (int)(statics.gameTime.TotalGameTime.TotalSeconds + 0.5);
            }
            // TODO: Add your update logic here
            statics.gameTime = gameTime;
            playerPlane.Update();
            cloud.Update();
            pot.Update();
            bomb.Update();
            if (cloud.getRectangle().X < -300)
            {
                cloud = new Cloud();
            }
            if ((int)statics.gameTime.TotalGameTime.TotalSeconds > potiontime)
            {

                pot = new Potion();
                Random rnd = new Random();
                
                potiontime = (int)(statics.gameTime.TotalGameTime.TotalSeconds + rnd.Next(15,30));
            }
            if ((int)statics.gameTime.TotalGameTime.TotalSeconds > bombtime)
            {

                bomb = new Bomb();
                Random rnd = new Random();

                bombtime = (int)(statics.gameTime.TotalGameTime.TotalSeconds + rnd.Next(15, 30));
            }
            base.Update(gameTime);

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (statics.GameOver == true)
            {

                spriteBatch.DrawString(Font, GameOver, new Vector2(320, 200), Color.Red);
                spriteBatch.End();
                return;

            }
            recBackground = new Rectangle(0, 0, 1200, 1600);
            spriteBatch.Draw(imgBackground, recBackground, Color.White);
            spriteBatch.Draw(imgCloud, cloud.getRectangle(), Color.White);
            spriteBatch.Draw(imgPotion, pot.getRectangle(), Color.White);
            spriteBatch.Draw(imgBomb, bomb.getRectangle(), Color.White);
            for (int i = 0; i < statics.BulletList.Count; i++)
            {
                if (statics.BulletList[i].getBulletType() == 0)
                {
                    spriteBatch.Draw(imgBullet, new Rectangle(statics.BulletList[i].getPosition().X, statics.BulletList[i].getPosition().Y, 34, 21), Color.White);
                }           
                else
                    spriteBatch.Draw(imgEnemybullet, new Rectangle(statics.BulletList[i].getPosition().X, statics.BulletList[i].getPosition().Y, 34, 21), Color.White);
            }
            spriteBatch.Draw(imgpPlane, new Rectangle(playerPlane.getPosition().X, playerPlane.getPosition().Y, imgpPlane.Width, imgpPlane.Height), Color.White);
            for (int i = 0; i < statics.EnemyList.Count; i++)
            {
                spriteBatch.Draw(imgEnemy, new Rectangle(statics.EnemyList[i].getPosition().X, statics.EnemyList[i].getPosition().Y, imgEnemy.Width, imgEnemy.Height), Color.White);
            }
            if (playerPlane.getHealth() > 50)
            {
                spriteBatch.DrawString(Font, "Health:" + playerPlane.getHealth(), new Vector2(600, 20), Color.Green);
            }
            else
                spriteBatch.DrawString(Font, "Health:" + playerPlane.getHealth(), new Vector2(600, 20), Color.Red);
            spriteBatch.DrawString(Font, "Score:" + statics.GameScore, new Vector2(600, 50), Color.Blue);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}