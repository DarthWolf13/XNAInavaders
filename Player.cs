using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAInvaders
{
    class Player
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
      
        public Player()
        {
            texture = Global.content.Load<Texture2D>("ship");
            Init();       
        }

        public void Init()
        {
            position.X = Global.width / 2; // horizontal center on screen
            position.Y = Global.height - texture.Height; // bottom of screen
        }

        public bool Update()
        {
            // Assume player is not moving
            velocity.X = 0;

            // Alter velocity when keys are pressed
            if (Global.keys.IsKeyDown(Keys.Left)) velocity.X = -10.0f;
            if (Global.keys.IsKeyDown(Keys.Right)) velocity.X = 10.0f;           

            position += velocity;

            // If x position is out of bounds, "undo" velocity
            if ((position.X < 100) || (position.X > Global.width - texture.Width - 100))
                position -= velocity;
          
            return true;
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

       
    }
}
