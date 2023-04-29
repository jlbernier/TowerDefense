using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Map;
using tower_Defense.Scenes;
using static tower_Defense.DataBase.TDWave;


namespace tower_Defense.Animation
{
    public class SpriteTower : TDSprite
    {
        public Vector2 positionBase { get; set; }
        public bool IsBuilded { get; set; }
        public bool IsActiveTower { get; set; }
        public bool IsMenuUpgradeOpen { get; set; }
        public SpriteWeapon spriteWeapon { get; set; }


        public int weaponSelectedAngle { get; set; }
        public string towerID { get; set; }
        public string towerType { get; set; }
        public int towerLevel { get; set; }
        public int weaponLevel { get; set; }
        public float timerBuild { get; set; }
        public int offsetCenterY { get; set; }
        public Rectangle BoundingBox { get; set; }
        public SpriteTower(Game mainGame, Vector2 position, Vector2 velocity, string towerID, string towerType, int towerLevel) : base(mainGame, position, velocity, towerID)
        {
            texture = TDTextures.Textures[TDData.Data[towerID].NameTexture];
            frameWidth = TDData.Data[towerID].FrameWidth;
            frameHeight = TDData.Data[towerID].FrameHeight;
            if (TDData.Data[towerID].buttonAnimation != TDData.eButtonAnimation.None)
                isFrame = true;
            else isFrame = false;
            scale = 1f;
            this.towerType = towerType;
            this.towerLevel = towerLevel;
            scale = 1;
            BoundingBox = new Rectangle((int)(position.X - TDData.Data[towerID].FrameWidth/2),
                                        (int)(position.Y - TDData.Data[towerID].FrameHeight/2),
                                        TDData.Data[towerID].FrameWidth,
                                        TDData.Data[towerID].FrameHeight);
        }

        public void RotateWeapon(SceneMap pCurrentScene, SpriteTower pCurrentTower)
        {
            pCurrentTower.spriteWeapon.angleSelected += 90;
            if (pCurrentTower.spriteWeapon.angleSelected == 360) pCurrentTower.spriteWeapon.angleSelected = 0;
            pCurrentTower.towerID = "ICONROTATEWEAPON";
        }
        public int OffsetTowerY(SpriteTower pCurrentTower)
        {
            string dataTowerID = "TOWER" + pCurrentTower.towerType + pCurrentTower.towerLevel.ToString();
            offsetCenterY = TDData.Data[dataTowerID].OffsetCenterY;
            return offsetCenterY;
        }
        public int OffsetWeaponY(SpriteTower pCurrentTower)
        {
            string weaponTowerID = "WEAPONTOWER" + pCurrentTower.towerType + "LEVEL" + pCurrentTower.towerLevel.ToString();
            offsetCenterY = TDData.Data[weaponTowerID].OffsetCenterY;
            return offsetCenterY;
        }
    }
}
