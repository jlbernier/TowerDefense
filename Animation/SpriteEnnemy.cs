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
        public int speed { get; set; }
        public Vector2 CurrentBox { get; set; }
        public Vector2 NextBox { get; set; }
        public Vector2 NextAfterBox { get; set; }
        public TDData.eDirection previousDestination = TDData.eDirection.Right;
        public TDData.eDirection currentDestination = TDData.eDirection.Right;
        public string nextDestination { get; set; }
        public int HP { get; set; }
        public Rectangle ennemyRectangle { get; set; }
        public BoundingBox ennemyBoundingBox { get; set; }

        
        static public int LENGHTLIFEWIDTH = 40;
        static public int LENGHTLIFEOFFSETX = -20;
        static public int LENGHTLIFEHEIGHT = 6;
        static public int LENGHTLIFEOFFSETY = -23;

        
        public SpriteEnnemy(Game mainGame, Vector2 position, Vector2 velocity, String ennemyID) : base(mainGame, position, velocity, ennemyID)
        {
            this.ennemyID = ennemyID;
            CurrentBox = velocity;
            NextBox = new Vector2(velocity.X + 1, velocity.Y);
            texture = TDTextures.Textures[TDData.Data[ennemyID].NameTexture];
            frameWidth = TDData.Data[ennemyID].FrameWidth;
            frameHeight = TDData.Data[ennemyID].FrameHeight;            
            isFrame = true;
            scale = 1f;
            HP = TDData.Data[ennemyID].MaxHP;
            IsFlying = TDData.Data[ennemyID].isFlying;
            speed = TDData.Data[ennemyID].speed;
            rectangleLife = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.LightGreen, Color.White);
            rectangleDeath = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.Black, Color.White);
            ennemyRectangle = new Rectangle(
               (int)(position.X - TDData.Data[ennemyID].FrameWidth / 2),
               (int)(position.Y - TDData.Data[ennemyID].FrameHeight / 2),
               TDData.Data[ennemyID].FrameWidth,
               TDData.Data[ennemyID].FrameHeight);
            ennemyBoundingBox = new BoundingBox(new Vector3(ennemyRectangle.Left, ennemyRectangle.Top, 0),
                                            new Vector3(ennemyRectangle.Right, ennemyRectangle.Bottom, 0));
            IsMirrored = !TDData.Data[ennemyID].isMirrored;
            base.velocity = new Vector2(TDData.Data[ennemyID].speed, 0);   
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
            ennemyRectangle = new Rectangle(
                (int)(position.X),
                (int)(position.Y),
                frameWidth/4,
                frameHeight/4);
            ennemyBoundingBox = new BoundingBox(new Vector3(ennemyRectangle.Left, ennemyRectangle.Top, 0),
                                                new Vector3(ennemyRectangle.Right, ennemyRectangle.Bottom, 0));

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
