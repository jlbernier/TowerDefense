using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_Defense.Animation
{
    public class SpriteWeapon : TDSprite
    {
        public String weaponID { get; set; }
        public String weaponType { get; set; }
        public int weaponLevel { get; set; }
        public int towerLevel { get; set; }
        public float weaponSpeed { get; set; }
        public int weaponDamage { get; set; }
        public bool isEnnemyInRange { get; set; }
        public SpriteEnnemy spriteEnnemy { get; set; }
        public int angleSelected { get; set; }
        public int angle { get; set; }

        public string towerType { get; set; }
        public string missileID { get; set; }
        public float speedMissile { get; set; }
        SpriteTower tower { get; set; }

        public SpriteWeapon(Game mainGame, Vector2 position, Vector2 velocity, String weaponID, SpriteTower tower, int angleSelected = 0) : base(mainGame, position, velocity, weaponID)
        {
            this.weaponID = weaponID;
            towerType = weaponID;
            texture = TDTextures.Textures[TDData.Data[weaponID].NameTexture];
            frameWidth = TDData.Data[weaponID].FrameWidth;
            frameHeight = TDData.Data[weaponID].FrameHeight;
            scale = TDData.Data[weaponID].Scale;
            isFrame = true;
            weaponType = tower.towerType;
            weaponLevel = tower.weaponLevel;
            towerLevel = tower.towerLevel;
            speedMissile = TDData.Data[weaponID].speed;
            this.angleSelected = angleSelected;            
        }

        public override void Update(GameTime gameTime)
        {
            int angleDegree = angleSelected;
            if (isEnnemyInRange)
            {
                angleDegree = angle;
                if (angleDegree < 0) angleDegree += 360;
                angleDegree %= 360;                
            }
            rotation = MathHelper.ToRadians(angleDegree);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
