﻿
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;

namespace XNAInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        Player thePlayer;
        Bullet theBullet;
        int nInvaders = 16;
        List<Invader> invaders = new List<Invader>();

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);            
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
 
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
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;            
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();

            for (int iInvader = 0; iInvader < nInvaders; iInvader++)
            {
                Invader newInvader = new Invader();
                newInvader.Init();
                invaders.Add(newInvader);
            }
 

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("background");
            scanlines = Content.Load<Texture2D>("scanlines");
            base.Initialize();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();
            if (Global.keys.IsKeyDown(Keys.Space)) theBullet.Fire(thePlayer.position);
            // Update the game objects
            thePlayer.Update();
            theBullet.Update();

            foreach (Invader anInvader in invaders)
            {
                anInvader.Update();

                if (theBullet.OverlapsInvader(anInvader) == true)
                {
                    anInvader.Init();
                }

            }

            
                

                base.Update(gameTime);
            }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();
            theBullet.Draw();
            foreach(Invader invader in invaders)
            {
                invader.draw();
            }

            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
