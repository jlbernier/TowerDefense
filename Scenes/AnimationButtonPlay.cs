using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Scenes
{
    public class AnimationButtonPlay
    {
        private Texture2D texture;
        private Rectangle textureRect;
        private float timer;
        public float scale;
        private bool scaleUP;

        public AnimationButtonPlay(Texture2D texture)
        {
            this.texture = texture;
            textureRect = new Rectangle(0, 0, texture.Width, texture.Height);
            scale = 0.95f;
            scaleUP = true;
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {            
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 0.05f)
            {
                if (scaleUP)
                {
                    scale += 0.01f;
                    if (scale > 1.05f)
                    {
                        scaleUP = false;
                    }
                }
                else
                {
                    scale -= 0.01f;
                    if (scale < 0.95f)
                    {
                        scaleUP = true;
                    }
                }
                timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2),
            textureRect, Color.White, 0f,
            new Vector2(texture.Width / 2, texture.Height / 2),
            scale, SpriteEffects.None, 0);
        }
    }
}
