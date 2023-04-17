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
        public string typeMissile { get; set; }
        public int missileLevel { get; set; }
        public int towerLevel { get; set; }
        public String weaponType { get; set; }
        public int MissileDamage { get; set; }
        public int angle { get; set; }
        public float timeoutMissile { get; set; }
        public bool isTimeOutMissile { get; set; }


        public Rectangle boundingBox { get; set; }
        public SpriteEnnemy spriteEnnemySelected { get; set; }
        public bool outOfRange { get; set; }
        public Vector2 origineMissile { get; set; }
        public float distance { get; set; }
        public float distanceMax { get; set; }
        public bool isCollision { get; set; }
        public bool isExploded {  get; set; }
        public bool isGamePaused { get; set; }

        public bool isCooldownShootUp { get; set; }

        public string missileID {  get; set; }
        
        public SpriteMissile(Game mainGame, Vector2 position, Vector2 velocity, String missileID, int missileLevel, int towerLevel, string towerType) : base(mainGame, position, velocity, missileID)
        {
            typeMissile = missileID;
            texture = TDTextures.Textures[TDData.Data[missileID].NameTexture];
            frameWidth = TDData.Data[missileID].FrameWidth;
            frameHeight = TDData.Data[missileID].FrameHeight;
            scale = TDData.Data[missileID].Scale;
            isFrame = true;
            origineMissile = position;
            this.missileLevel = missileLevel;
            this.towerLevel = towerLevel;
            this.weaponType   = towerType;
            distanceMax = 450; // pour les tests !!!!!!!!!!!!!!!!!!!!!!
            boundingBox = new Rectangle(
               (int)(position.X - TDData.Data[missileID].FrameWidth / 2),
               (int)(position.Y - TDData.Data[missileID].FrameHeight / 2),
            TDData.Data[missileID].FrameWidth,
               TDData.Data[missileID].FrameHeight);
        }        

        public void GameIsPaused()
        {
            isGamePaused = true;
        }

        public override void Update(GameTime gameTime)
        {
            timeoutMissile += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeoutMissile > 8) isTimeOutMissile = true;
            distance = (float)Math.Sqrt(Math.Pow(Math.Abs(position.X - origineMissile.X),2) +
                                  Math.Pow(Math.Abs(position.Y - origineMissile.Y), 2));
            if (distance > distanceMax ) outOfRange = true;
            // a faire en fonction des missiles
            boundingBox = new Rectangle(
                (int)(position.X - frameWidth / 2),
                (int)(position.Y - frameHeight / 2),
                frameWidth,
                frameHeight);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {           
            base.Draw(gameTime);
        }
    }
}
