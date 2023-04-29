using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Scenes;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;
using tower_Defense.Buttons;

namespace tower_Defense.Animation
{
    public class SpriteTowerFilter
    {
        public SpriteTower spriteTower;
        public List<SpriteTower> liste;
        public SpriteTowerFilter()
        {
            this.liste = new();
        }


        public SpriteTowerFilter AddTower(Game mainGame, Vector2 position, String towerID, string towerType, int towerLevel)
        {
            SpriteTower tower = new SpriteTower(mainGame, position, new Vector2(0, 0), towerID, towerType, towerLevel);
            tower.AddAnimation(
            "Tower",
                TDData.Data[towerID].ArrayFrames,
                TDData.Data[towerID].FramesDuration,
                TDData.Data[towerID].OffsetX,
                TDData.Data[towerID].OffsetY,
                TDData.Data[towerID].IsLoop,
                TDData.Data[towerID].InitOffsetX,
                TDData.Data[towerID].InitOffsetY);
            tower.RunAnimation("Tower");
            liste.Add(tower);
            return this;
        }
        public SpriteTowerFilter TimerBuildUpdate(GameTime gameTime)
        {
            liste.ForEach(sprite => sprite.timerBuild += (float)gameTime.ElapsedGameTime.TotalSeconds);
            return this;
        }

        public SpriteTowerFilter BuildTowerAnimation(MainGame mainGame)
        {
            spriteTower = null;
            liste.ForEach(sprite =>
            {
                if (sprite.timerBuild >= 2f && !sprite.IsBuilded)
                    spriteTower = sprite;
            });
            if (spriteTower != null)
            {
                liste.Remove(spriteTower);
                AddTower(mainGame, spriteTower.position, "TOWERCONSTRUCTION1BIS", spriteTower.towerType, 1);
                liste[liste.Count - 1].IsBuilded = true;
            }
            return this;
        }
        public SpriteTowerFilter BuildTower(MainGame mainGame)
        {
            spriteTower = null;
            liste.ForEach(sprite =>
            {
                if (sprite.currentAnimation.isFinished && sprite.IsBuilded && !sprite.IsActiveTower)
                    spriteTower = sprite;
            });
            if (spriteTower != null)
            {
                liste.Remove(spriteTower);
                AddTower(mainGame, spriteTower.position, "TOWER" + spriteTower.towerType + "1", spriteTower.towerType, 1);
                spriteTower = liste[liste.Count - 1];
                spriteTower.IsBuilded = true;
                spriteTower.IsActiveTower = true;
                spriteTower.offsetTextureX = TDData.Data["TOWER" + spriteTower.towerType + "1"].InitOffsetX;
                spriteTower.offsetTextureY = TDData.Data["TOWER" + spriteTower.towerType + "1"].InitOffsetY;
                spriteTower.widthTexture = (int)(TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameWidth * TDData.Data["TOWER" + spriteTower.towerType + "1"].Scale);
                spriteTower.heightTexture = (int)(TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameHeight * TDData.Data["TOWER" + spriteTower.towerType + "1"].Scale);
                spriteTower.textureBox = new Rectangle(
                            spriteTower.offsetTextureX,
                            spriteTower.offsetTextureY,
                            TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameWidth,
                            TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameHeight);
                spriteTower.towerLevel = 1;
                spriteTower.weaponLevel = 1;
                SceneMap.spriteWeaponFilter.AddWeapon(mainGame,
                    "WEAPONTOWER" + spriteTower.towerType + "LEVEL1",
                   new Vector2(spriteTower.position.X,
                   spriteTower.position.Y + TDData.Data["WEAPONTOWER" + spriteTower.towerType + "LEVEL1"].OffsetCenterY), new Vector2(0, 0), spriteTower);
                SceneMap.spriteWeaponFilter.liste[^1].weaponLevel = 1;
                SceneMap.spriteWeaponFilter.liste[^1].towerLevel = 1;
                spriteTower.spriteWeapon = SceneMap.spriteWeaponFilter.liste[^1];
            }
            return this;
        }
        public SpriteTowerFilter UpgradeTower(MainGame mainGame, SpriteTower currentTower)
        {
            liste.Remove(currentTower);
            string towerToBuild = "TOWER" + spriteTower.towerType + spriteTower.towerLevel.ToString();
            AddTower(mainGame, spriteTower.position, towerToBuild, spriteTower.towerType, spriteTower.towerLevel);
            spriteTower = liste[^1];
            spriteTower.IsBuilded = true;
            spriteTower.IsActiveTower = true;
            spriteTower.offsetTextureX = TDData.Data[towerToBuild].InitOffsetX;
            spriteTower.offsetTextureY = TDData.Data[towerToBuild].InitOffsetY;
            spriteTower.widthTexture = (int)(TDData.Data[towerToBuild].FrameWidth * TDData.Data[towerToBuild].Scale);
            spriteTower.heightTexture = (int)(TDData.Data[towerToBuild].FrameHeight * TDData.Data[towerToBuild].Scale);
            spriteTower.textureBox = new Rectangle(
                        spriteTower.offsetTextureX,
                        spriteTower.offsetTextureY,
                        TDData.Data[towerToBuild].FrameWidth,
                        TDData.Data[towerToBuild].FrameHeight);
            spriteTower.towerLevel = currentTower.towerLevel;
            spriteTower.weaponLevel = currentTower.weaponLevel;
            spriteTower.spriteWeapon = currentTower.spriteWeapon;
            spriteTower.spriteWeapon.towerLevel = spriteTower.towerLevel;

            spriteTower.spriteWeapon.position = new Vector2(spriteTower.position.X,
               spriteTower.position.Y + 
               TDData.Data["WEAPONTOWER" + spriteTower.towerType + "LEVEL" + spriteTower.weaponLevel.ToString()].OffsetCenterY
               + TDData.Data[towerToBuild].OffsetTowerWeaponY);
            return this;
        }

        public SpriteTowerFilter UpgradeWeapon(MainGame mainGame, SpriteTower currentTower)
        {
            SceneMap.spriteWeaponFilter.liste.Remove(currentTower.spriteWeapon);
            SceneMap.spriteWeaponFilter.AddWeapon(mainGame,
                   "WEAPONTOWER" + spriteTower.towerType + "LEVEL" + currentTower.weaponLevel.ToString(),
                  new Vector2(spriteTower.position.X,
                  spriteTower.position.Y + TDData.Data["WEAPONTOWER" + spriteTower.towerType + "LEVEL" + currentTower.weaponLevel.ToString()].OffsetCenterY
                  + TDData.Data[currentTower.ID].OffsetTowerWeaponY), new Vector2(0, 0), spriteTower);
            currentTower.spriteWeapon = SceneMap.spriteWeaponFilter.liste[^1];
            return this;
        }

        public SpriteTower OnHover()
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePos = mouseState.Position;
            spriteTower = liste.FirstOrDefault(sprite => sprite.BoundingBox.Contains(mousePos)
                                                         && sprite.IsMenuUpgradeOpen);
            if (spriteTower != null) return spriteTower;
            return liste.FirstOrDefault(sprite => sprite.BoundingBox.Contains(mousePos)
                                                    && sprite.ID.Substring(0,6) != "TOWERC");
        }

        public SpriteTowerFilter UpdateAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Update(pGametime));
            return this;
        }
        public SpriteTowerFilter DrawAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Draw(pGametime));
            return this;
        }


       

    }
}
