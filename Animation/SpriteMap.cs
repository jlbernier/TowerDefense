using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Map;

namespace tower_Defense.Animation
{
    public class SpriteMap : TDSprite
    {
        public bool Flying { get; set; }
        public float Gravity { get; set; }
        private SoundEffect _sndJump;
        private SoundEffect _sndLanding;
        public SpriteMap(Game mainGame, SpriteBatch spriteBatch, String tileID, Vector2 position, Vector2 velocity, Tile tile = null) : base(mainGame, spriteBatch, tileID, position, velocity)
        {
            base.mainGame = mainGame;
            base.spriteBatch = spriteBatch;
            base.texture = tile._texture;
            base.frameWidth = tile.frameWidth;
            base.frameHeight = tile.frameHeight;
            base.offsetX = 256;
            base.offsetY = 0;
            base.velocity = velocity;
            base.position = position;

            Flying = false;
            Gravity = 10;
        }

        public void SetSounds(SoundEffect pSndJump, SoundEffect pSndLanding)
        {
            _sndJump = pSndJump;
            _sndLanding = pSndLanding;
        }

        /* public void SetGroundPosition(int pPosition)
         {
             spriteY = pPosition;
         }*/

        public void Jump()
        {
            if (Flying) return;
            //velocity.Y = -400;
            Flying = true;
            // Play a sound
            if (_sndJump != null)
                _sndJump.Play();
        }

        public override void Update(GameTime gameTime)
        {
            // Test if the hero is on the ground

            // Apply the velocity
            if (Flying)
            {
                //velocity.Y += Gravity;
            }
            base.Update(gameTime);
        }
    }
}
