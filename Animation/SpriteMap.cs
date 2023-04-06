using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Animation
{
    public class SpriteMap : TDSprite
    {
        public bool Flying { get; set; }
        public float Gravity { get; set; }
        private SoundEffect _sndJump;
        private SoundEffect _sndLanding;
        public SpriteMap(Game pGame, SpriteBatch pSpriteBatch, Texture2D pTexture, int pX, int pY, int pDecalageX, int pDecalageY, Vector2 pVelocity, int pInitDecalageX) : base(pGame, pSpriteBatch, pTexture, pX, pY, pDecalageX, pDecalageY, pVelocity, pInitDecalageX)
        {
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
