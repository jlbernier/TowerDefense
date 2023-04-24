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
using tower_Defense.Scenes;

namespace tower_Defense.Animation
{
    public class SpriteEnnemy : TDSprite
    {
        public bool IsFlying { get; set; }
        public bool isFlipHorizontally { get; set; }
        public TDRectangle rectangleLife;
        public TDRectangle rectangleDeath;
        public string ennemyID { get; private set; }
        public int speed { get; set; }
        public Vector2 CurrentBox { get; set; }
        public Vector2 NextBox { get; set; }
        public Vector2 NextAfterBox { get; set; }
        public Vector2 ennemyVelocity { get; set; }
        public TDData.eDirection currentDestination = TDData.eDirection.Right;
        public TDData.eDirection nextDestination { get; set; }
        public TDData.eDirection nextAfterDestination { get; set; }
        public bool IsEnnemyTurning { get; set; }
        public bool IsArrivalAfterNextCurrentBox { get; set; }
        public bool IsArrivalNextCurrentBox { get; set; }
        public bool IsArrivalCurrentBox { get; set; }
        public bool IsArrived { get; set; }

        public bool IsPreferredDirectionLeft { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public Rectangle ennemyRectangle { get; set; }
        public BoundingBox ennemyBoundingBox { get; set; }
                        
        public SpriteEnnemy(Game mainGame, Vector2 position, Vector2 velocity, String ennemyID) : base(mainGame, position, velocity, ennemyID)
        {
            this.ennemyID = ennemyID;
            texture = TDTextures.Textures[TDData.Data[ennemyID].NameTexture];
            frameWidth = TDData.Data[ennemyID].FrameWidth;
            frameHeight = TDData.Data[ennemyID].FrameHeight;            
            isFrame = true;
            scale = 1f;
            HP = TDData.Data[ennemyID].MaxHP;
            MaxHP = TDData.Data[ennemyID].MaxHP;
            IsFlying = TDData.Data[ennemyID].isFlying;
            isFlipHorizontally = TDData.Data[ennemyID].isTilesetDirectionLeft;            
            IsPreferredDirectionLeft = TDData.Data[ennemyID].isPreferredDirectionLeft;
            speed = TDData.Data[ennemyID].speed;
            rectangleLife = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.LightGreen, Color.White);
            rectangleDeath = new TDRectangle(mainGame, TDRectangle.Type.fill, 0, 0, 0, LENGHTLIFEHEIGHT, Color.Black, Color.White);
        }

        
        public override void Update(GameTime gameTime)
        {
            effect = isFlipHorizontally ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            velocity = new Vector2(ennemyVelocity.X * speed, ennemyVelocity.Y * speed);
            rectangleLife.Rect.X = (int)(position.X + LENGHTLIFEOFFSETX);
            rectangleLife.Rect.Y = (int)(position.Y + LENGHTLIFEOFFSETY);
            rectangleLife.Rect.Width = ((int)(HP * LENGHTLIFEWIDTH / MaxHP));
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
