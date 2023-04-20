using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;
using Microsoft.Xna.Framework.Input;
using static tower_Defense.DataBase.TDWave;

namespace tower_Defense.Animation
{
    public class SpriteMissile : TDSprite
    {
        public string missileID {  get; set; }
        public string impactID { get; set; }
        public string typeMissile { get; set; }
        public int missileLevel { get; set; }
        public int towerLevel { get; set; }
        public float speedMissile { get; set; }
        public int angleDegree { get; set; }
        public String weaponType { get; set; }
        public int MissileDamage { get; set; }
        public int angle { get; set; }
        public float timeoutMissile { get; set; }
        public bool isTimeOutMissile { get; set; }


        public Rectangle missileRectangle { get; set; }
        public BoundingBox missileBoundingBox { get; set; }
        public SpriteEnnemy spriteEnnemy { get; set; }
        public bool outOfRange { get; set; }
        public Vector2 origineMissile { get; set; }
        public float distance { get; set; }
        public float distanceMax { get; set; }
        public bool isCollision { get; set; }
        public bool isExploded {  get; set; }
        public bool isGamePaused { get; set; }

        public bool isCooldownShootUp { get; set; }

        
        public SpriteMissile(Game mainGame, Vector2 position, Vector2 velocity, String missileID, SpriteWeapon spriteWeapon) : base(mainGame, position, velocity, missileID)
        {
            this.missileID = missileID;
            texture = TDTextures.Textures[TDData.Data[missileID].NameTexture];
            frameWidth = TDData.Data[missileID].FrameWidth;
            frameHeight = TDData.Data[missileID].FrameHeight;
            scale = TDData.Data[missileID].Scale;
            isFrame = true;
            origineMissile = position;
            this.missileLevel = spriteWeapon.weaponLevel;
            this.towerLevel = spriteWeapon.towerLevel;
            this.weaponType   = spriteWeapon.weaponType;
            this.spriteEnnemy = spriteWeapon.spriteEnnemy;
            this.speedMissile = spriteWeapon.speedMissile;
            distanceMax = TDData.Data[spriteWeapon.ID].maxDistance; // + towerdistance à ajouter
            missileRectangle = new Rectangle(
               (int)(position.X - TDData.Data[missileID].FrameWidth / 2),
               (int)(position.Y - TDData.Data[missileID].FrameHeight / 2),
            TDData.Data[missileID].FrameWidth,
               TDData.Data[missileID].FrameHeight);
            missileBoundingBox = new BoundingBox(new Vector3(missileRectangle.Left, missileRectangle.Top, 0),
                                                     new Vector3(missileRectangle.Right, missileRectangle.Bottom, 0));
        }
        public SpriteMissile(Game mainGame, Vector2 position, Vector2 velocity, String impactID, SpriteMissile spriteMissile) : base(mainGame, position, velocity, impactID)
        {
            this.impactID = impactID;
            texture = TDTextures.Textures[TDData.Data[impactID].NameTexture];
            frameWidth = TDData.Data[impactID].FrameWidth;
            frameHeight = TDData.Data[impactID].FrameHeight;
            scale = TDData.Data[impactID].Scale;
            isFrame = true;
            origineMissile = position;
            this.missileLevel = spriteMissile.missileLevel;
            this.towerLevel = spriteMissile.towerLevel;
            this.weaponType = spriteMissile.weaponType;
            missileRectangle = new Rectangle(
               (int)(position.X - TDData.Data[impactID].FrameWidth / 2),
               (int)(position.Y - TDData.Data[impactID].FrameHeight / 2),
               TDData.Data[impactID].FrameWidth,
               TDData.Data[impactID].FrameHeight);
        }

    

    public void GameIsPaused()
        {
            isGamePaused = true;
        }

        public override void Update(GameTime gameTime)
        {
            rotation = MathHelper.ToRadians(angleDegree);
            timeoutMissile += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeoutMissile > 8) isTimeOutMissile = true;
            distance = (float)Math.Sqrt(Math.Pow(Math.Abs(position.X - origineMissile.X),2) +
                                  Math.Pow(Math.Abs(position.Y - origineMissile.Y), 2));
            if (distance > distanceMax ) outOfRange = true;
            // a faire en fonction des missiles
            missileRectangle = new Rectangle(
                (int)(position.X - frameWidth / 2),
                (int)(position.Y - frameHeight / 2),
                frameWidth,
                frameHeight);
            missileBoundingBox = new BoundingBox(new Vector3(missileRectangle.Left, missileRectangle.Top, 0),
                                                   new Vector3(missileRectangle.Right, missileRectangle.Bottom, 0));

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {           
            base.Draw(gameTime);
        }
    }
}
