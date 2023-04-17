using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using tower_Defense.Buttons;
using tower_Defense.EnnemyGamePlay;
using tower_Defense.Scenes;
using tower_Defense.Utils;

namespace tower_Defense.Animation
{
    public class SpriteWeaponFilter
    {
        public List<SpriteWeapon> liste;
        public SpriteWeaponFilter()
        {
            this.liste = new();
        }

        public SpriteWeaponFilter AddWeapon(Game mainGame, string weaponID, Vector2 position, Vector2 velocity, Tower tower)
        {
            SpriteWeapon spriteWeapon = new SpriteWeapon(mainGame, position, velocity, weaponID, tower);
            spriteWeapon.AddAnimation(
                "Weapon",
                TDData.Data[weaponID].ArrayFrames,
                TDData.Data[weaponID].FramesDuration,
                TDData.Data[weaponID].FrameWidth,
                TDData.Data[weaponID].OffsetY,
                TDData.Data[weaponID].IsLoop,
                TDData.Data[weaponID].InitOffsetX,
                TDData.Data[weaponID].InitOffsetY);
            spriteWeapon.RunAnimation("Weapon");
            liste.Add(spriteWeapon);
            return this;
        }
        public SpriteWeaponFilter Remove(GameTime pGametime, SpriteWeapon sprite)
        {
            liste.Remove(sprite);
            return this;
        }

        public SpriteWeaponFilter UpdateAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Update(pGametime));
            return this;
        }
        public SpriteWeaponFilter DrawAll(GameTime pGametime)
        {
            liste.ForEach(sprite => sprite.Draw(pGametime));
            return this;
        }
        
        static void AddMissile7X(Game mainGame, SceneMap pCurrentScene, SpriteWeapon spriteWeapon)
        {
            pCurrentScene.spriteMissileFilter.AddMissile(mainGame,
                                 "MISSILETOWER7LEVEL1",
                            new Vector2(spriteWeapon.position.X, spriteWeapon.position.Y - 40),
                            new Vector2(0, -30),
                            spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType);
            if (spriteWeapon.weaponLevel >= 2)
                pCurrentScene.spriteMissileFilter.AddMissile(mainGame,
                        "MISSILETOWER7LEVEL2",
                   new Vector2(spriteWeapon.position.X, spriteWeapon.position.Y + 40),
                   new Vector2(0, 30),
                   spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType);

            if (spriteWeapon.weaponLevel >= 3)
            {
                pCurrentScene.spriteMissileFilter.AddMissile(mainGame,
                        "MISSILETOWER7LEVEL3",
                   new Vector2(spriteWeapon.position.X - 40, spriteWeapon.position.Y),
                   new Vector2(-30, 0),
                   spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType);
                pCurrentScene.spriteMissileFilter.AddMissile(mainGame,
                        "MISSILETOWER7LEVEL3",
                   new Vector2(spriteWeapon.position.X + 40, spriteWeapon.position.Y),
                   new Vector2(30, 0),
                   spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType);
            }
        }
        
            public SpriteWeaponFilter CooldownShootIsUp(Game mainGame, SceneMap pCurrentScene)
        {
            Tools tools = new Tools();
            string missileID;
            liste.ForEach(spriteWeapon => 
            {
                if (spriteWeapon.currentAnimation.isFinished)
                {
                    missileID = "MISSILETOWER" + spriteWeapon.weaponType + "LEVEL" + spriteWeapon.weaponLevel.ToString();
                    Vector2 velocity = tools.VelocityAngleSpeed(spriteWeapon.angle, spriteWeapon.speed);
                    if (spriteWeapon.weaponType == "7")
                    {
                        AddMissile7X(mainGame, pCurrentScene, spriteWeapon);
                    }
                    else if (spriteWeapon.weaponType == "8")
                    {
                        pCurrentScene.spriteMissileFilter.AddMissile(mainGame,
                             missileID,
                             tools.originePositionMissile(spriteWeapon.position, velocity, missileID),
                             new Vector2(0, 0),
                             spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType);
                    }
                    else
                    {
                        pCurrentScene.spriteMissileFilter.AddMissile(mainGame,
                             missileID,
                             tools.originePositionMissile(spriteWeapon.position, velocity, missileID),
                             velocity,
                             spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType);
                    }
                    spriteWeapon.frame = 0;
                    spriteWeapon.currentAnimation.isFinished = false;
                }                
            });
            return this;
        }
    }
}