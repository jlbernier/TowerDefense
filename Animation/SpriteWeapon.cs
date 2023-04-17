using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Buttons;

namespace tower_Defense.Animation
{
    public class SpriteWeapon : TDSprite
    {
        public String weaponType { get; set; }
        public int weaponLevel { get; set; }
        public int towerLevel { get; set; }
        public float weaponSpeed { get; set; } = 1f;
        public int weaponDamage { get; set; }
        public int angle { get; set; }
        public string towerType { get; set; }
        public float speed { get; set; }
        Tower tower { get; set; }

        public SpriteWeapon(Game mainGame, Vector2 position, Vector2 velocity, String weaponID, Tower tower) : base(mainGame, position, velocity, weaponID)
        {
            towerType = weaponID;
            texture = TDTextures.Textures[TDData.Data[weaponID].NameTexture];
            frameWidth = TDData.Data[weaponID].FrameWidth;
            frameHeight = TDData.Data[weaponID].FrameHeight;
            scale = TDData.Data[weaponID].Scale;
            isFrame = true;
            weaponType = tower.towerType;
            weaponLevel = tower.weaponLevel;
            towerLevel = tower.towerLevel;
            speed = TDData.Data[weaponID].speed;

        }

        public override void Update(GameTime gameTime)
        {
            rotation = MathHelper.ToRadians(angle);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
