﻿using Microsoft.Xna.Framework.Audio;
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
using static tower_Defense.Utils.Wave;

namespace tower_Defense.Animation
{
    public class SpriteEnnemy : TDSprite
    {
        public bool IsFlying { get; set; }
        public bool IsMirrored { get; set; }
        public TDRectangle rectangleLife;
        public TDRectangle rectangleDeath;
        public string ennemyID { get; private set; }
        public int HP { get; set; }

        static public int LENGHTLIFEWIDTH = 40;
        static public int LENGHTLIFEOFFSETX = -20;
        static public int LENGHTLIFEHEIGHT = 6;
        static public int LENGHTLIFEOFFSETY = -23;

        private SoundEffect _sndJump;
        private SoundEffect _sndLanding;
        public SpriteEnnemy(Game mainGame, Vector2 position, Vector2 velocity, String ennemyID) : base(mainGame, position, velocity)
        {
            this.ennemyID = ennemyID;
            texture = TDTextures.Textures[TDData.Data[ennemyID].NameTexture];
            frameWidth = TDData.Data[ennemyID].FrameWidth;
            frameHeight = TDData.Data[ennemyID].FrameHeight;
            offsetX = TDData.Data[ennemyID].OffsetX;
            offsetY = TDData.Data[ennemyID].OffsetY;
            initOffsetX = TDData.Data[ennemyID].InitOffsetX;
            IsMirrored = TDData.Data[ennemyID].isMirrored;
            HP = TDData.Data[ennemyID].MaxHP;
            IsFlying = TDData.Data[ennemyID].isFlying;
            isFrame = true;
            rectangleLife = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.LightGreen, Color.White);
            rectangleDeath = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.Black, Color.White);

        }
        
       public void IsAttack(int damages)
        {
            HP -= damages;
        }

        public void Fly()
        {
            if (IsFlying) return;
                       
        }

        public override void Update(GameTime gameTime)
        {
            velocity = isSpeedUp ?
               velocity = new Vector2(50, 0) :
                               velocity = new Vector2(15, 0);
            if (IsFlying)
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

            int maxHP = TDData.Data[ennemyID].MaxHP;
            rectangleLife.Rect.X = (int)(position.X + LENGHTLIFEOFFSETX);
            rectangleLife.Rect.Y = (int)(position.Y + LENGHTLIFEOFFSETY);
            rectangleLife.Rect.Width = ((int)(HP * LENGHTLIFEWIDTH / maxHP));

            rectangleDeath.Rect.X = (int)(rectangleLife.Rect.X + rectangleLife.Rect.Width);
            rectangleDeath.Rect.Y = (int)(position.Y + LENGHTLIFEOFFSETY);
            rectangleDeath.Rect.Width = ((int)(LENGHTLIFEWIDTH - rectangleLife.Rect.Width));                     

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
          
            rectangleLife.Draw(MainGame.spriteBatch);
            rectangleDeath.Draw(MainGame.spriteBatch);
            base.Draw(gameTime);
        }
    }
}
