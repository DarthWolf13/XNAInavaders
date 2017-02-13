using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    class Bullet
    {
        public Boolean isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public float speed;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("bullet");
            Init();
        }

        public void Init()
        {
            isFired = false;
            position.X = -1000;
            velocity.Y = 0;
        }

        public void Update()
        {
            if (isFired)
            {
                if (position.Y < 0)
                {
                    Init();
                }
            }
            position.Y += velocity.Y;
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

        public void Fire(Vector2 startPosition)
        {
            if (!isFired)
            {
                isFired = true;
                position = startPosition;
                velocity.Y = -3;
            }
        }

        public Boolean OverlapsInvader(Invader anInvader)
        {
            Rectangle bulletRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            Rectangle invaderRect = new Rectangle((int)anInvader.position.X, (int)anInvader.position.Y, anInvader.texture.Width, anInvader.texture.Height);

            if (bulletRect.Intersects(invaderRect)) { 
                Init();
                return true; }
            else
                return false;
        }

    }
}
