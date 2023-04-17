using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
//using System.Drawing;
using tower_Defense.Utils;
using Color = Microsoft.Xna.Framework.Color;
using static tower_Defense.DataBase.TDWave;
using static tower_Defense.TDData;

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
        public Rectangle boundingBox { get; set; }

        static public int LENGHTLIFEWIDTH = 40;
        static public int LENGHTLIFEOFFSETX = -20;
        static public int LENGHTLIFEHEIGHT = 6;
        static public int LENGHTLIFEOFFSETY = -23;

        
        public SpriteEnnemy(Game mainGame, Vector2 position, Vector2 velocity, String ennemyID, eDirection eDirection) : base(mainGame, position, velocity, ennemyID)
        {
            scale = 1f;
            this.ennemyID = ennemyID;
            texture = TDTextures.Textures[TDData.Data[ennemyID].NameTexture];
            frameWidth = TDData.Data[ennemyID].FrameWidth;
            frameHeight = TDData.Data[ennemyID].FrameHeight;            
            HP = TDData.Data[ennemyID].MaxHP;
            IsFlying = TDData.Data[ennemyID].isFlying;
            isFrame = true;
            
            rectangleLife = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.LightGreen, Color.White);
            rectangleDeath = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.Black, Color.White);
            boundingBox = new Rectangle(
               (int)(position.X - TDData.Data[ennemyID].FrameWidth / 2),
               (int)(position.Y - TDData.Data[ennemyID].FrameHeight / 2),
               TDData.Data[ennemyID].FrameWidth,
               TDData.Data[ennemyID].FrameHeight);
            switch (eDirection)
            {
                case eDirection.None:
                    break;
                case eDirection.Left:
                    IsMirrored = TDData.Data[ennemyID].isMirrored;
                    break;
                case eDirection.Right:
                    IsMirrored = !TDData.Data[ennemyID].isMirrored;
                    base.velocity = new Vector2(TDData.Data[ennemyID].speed, 0);
                    break;
                case eDirection.Up:
                    break;
                case eDirection.Botton:
                    break;
                default:
                    break;
            }

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
            boundingBox = new Rectangle(
                (int)(position.X - frameWidth / 2),
                (int)(position.Y - frameHeight / 2),
                frameWidth,
                frameHeight);
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
