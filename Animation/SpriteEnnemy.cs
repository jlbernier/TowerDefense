using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using tower_Defense.Utils;
using Color = Microsoft.Xna.Framework.Color;

namespace tower_Defense.Animation
{
    public class SpriteEnnemy : TDSprite
    {
        public bool Flying { get; set; }
        public bool IsMirrored { get; set; }
        public TDRectangle rectangleLife;
        public TDRectangle rectangleDeath;
        public EnnemyDatas _ennemyDatas;
        public WaveDatas _waveDatas;
        public string _ennemyID;
        public int _HP { get; set; }

        static public int LENGHTLIFEWIDTH = 40;
        static public int LENGHTLIFEOFFSETX = -20;
        static public int LENGHTLIFEHEIGHT = 6;
        static public int LENGHTLIFEOFFSETY = -23;

        private SoundEffect _sndJump;
        private SoundEffect _sndLanding;
        static public List<SpriteEnnemy> lstEnnemy = new List<SpriteEnnemy>();
        public SpriteEnnemy(Game pGame, SpriteBatch pSpriteBatch, Texture2D pTexture, int pFrameWidth, int pFrameHeight, int pDecalageX, int pDecalageY, Vector2 pVelocity, int pInitDecalageX = 0): base(pGame, pSpriteBatch, pTexture, pFrameWidth, pFrameHeight, pDecalageX, pDecalageY, pVelocity, pInitDecalageX = 0)
        {
            lstEnnemy.Add(this);
        }

        public void Load(Game mainGame, string ennemyID)
        {
            _ennemyID = ennemyID;
            _HP = Ennemy.Data[_ennemyID].MaxHP;
            rectangleLife = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.LightGreen, Color.White);
            rectangleDeath = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.Black, Color.White);           
        }

        public void SetSounds(SoundEffect pSndJump, SoundEffect pSndLanding)
        {
            _sndJump = pSndJump;
            _sndLanding = pSndLanding;
        }

        public void IsAttack(int damages)
        {
            _HP -= damages;
        }

        public void Fly()
        {
            if (Flying) return;
            //base.velocity.Y = -400;

            // Play a sound
            if (_sndJump != null)
                _sndJump.Play();
        }

        public override void Update(GameTime gameTime)
        {
            velocity = isSpeedUp ?
               velocity = new Vector2(50, 0) :
                               velocity = new Vector2(15, 0);

            if (Flying)
            {
                //
            }

            if (IsMirrored)
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effect = SpriteEffects.None;
            }

            int maxHP = Ennemy.Data[_ennemyID].MaxHP;
            rectangleLife.Rect.X = (int)(spriteX + LENGHTLIFEOFFSETX);
            rectangleLife.Rect.Y = (int)(spriteY + LENGHTLIFEOFFSETY);
            rectangleLife.Rect.Width = ((int)(_HP * LENGHTLIFEWIDTH / maxHP));

            rectangleDeath.Rect.X = (int)(rectangleLife.Rect.X + rectangleLife.Rect.Width);
            rectangleDeath.Rect.Y = (int)(spriteY + LENGHTLIFEOFFSETY);
            rectangleDeath.Rect.Width = ((int)(LENGHTLIFEWIDTH - rectangleLife.Rect.Width));

           

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
          
            rectangleLife.Draw(spriteBatch);
            rectangleDeath.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
