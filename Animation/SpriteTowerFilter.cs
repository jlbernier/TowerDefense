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

        public SpriteTower IsSelected()
        {
            SpriteTower towerContainsMouse = null;
            MouseState mouseState = Mouse.GetState();
            liste.ForEach(tower =>
            {
                if (tower.BoundingBox.Contains(mouseState.Position)) towerContainsMouse = tower;
            });
            return towerContainsMouse;
        }

        public SpriteTowerFilter AddTower(Game mainGame, Vector2 position, String towerID, string towerType)
        {
            SpriteTower tower = new SpriteTower(mainGame, position, new Vector2(0, 0), towerID, towerType );
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
                AddTower(mainGame, spriteTower.position, "TOWERCONSTRUCTION1BIS", spriteTower.towerType);
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
                AddTower(mainGame, spriteTower.position, "TOWER" + spriteTower.towerType + "1", spriteTower.towerType);
                liste[liste.Count - 1].IsBuilded = true;
                liste[liste.Count - 1].IsActiveTower = true;
                liste[liste.Count - 1].offsetTextureX = TDData.Data["TOWER" + spriteTower.towerType + "1"].InitOffsetX;
                liste[liste.Count - 1].offsetTextureY = TDData.Data["TOWER" + spriteTower.towerType + "1"].InitOffsetY;
                liste[liste.Count - 1].widthTexture = (int)(TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameWidth * TDData.Data["TOWER" + spriteTower.towerType + "1"].Scale);
                liste[liste.Count - 1].heightTexture = (int)(TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameHeight * TDData.Data["TOWER" + spriteTower.towerType + "1"].Scale);
                liste[liste.Count - 1].textureBox = new Rectangle(
                            liste[liste.Count - 1].offsetTextureX,
                            liste[liste.Count - 1].offsetTextureY,
                            TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameWidth,
                            TDData.Data["TOWER" + spriteTower.towerType + "1"].FrameHeight);
            }
            return this;
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


        public SpriteTowerFilter CooldownShootIsUp()
        {
            liste = liste.FindAll(spriteTower => spriteTower.isCooldownShootUp);
            return this;
        }

    }
}
