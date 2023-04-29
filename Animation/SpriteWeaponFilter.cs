using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using tower_Defense.Scenes;
using tower_Defense.Utils;

namespace tower_Defense.Animation
{
    public class SpriteWeaponFilter
    {
        public List<SpriteWeapon> liste;
        public SpriteWeaponFilter() {this.liste = new();}

        public SpriteWeaponFilter AddWeapon(Game mainGame, string weaponID, Vector2 position, Vector2 velocity, SpriteTower tower)
        {
            SpriteWeapon spriteWeapon = new SpriteWeapon(mainGame, position, velocity, weaponID, tower, tower.weaponSelectedAngle);
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

        public SpriteWeaponFilter EnnemyWithinRangeWeapon(Game mainGame)
        {
            SpriteEnnemy missileTarget = null;
            float outOfRange;
            float ennemyInRange;
            float ennemyDistance;            
            liste.ForEach(spriteWeapon =>
            {
                spriteWeapon.spriteEnnemy = null;
                spriteWeapon.angle = 0;
                spriteWeapon.isEnnemyInRange = false;
                outOfRange = Tools.OutOfRange(spriteWeapon);
                ennemyInRange = outOfRange + 1;
                spriteWeapon.angle = 0;
                SceneMap.spriteEnnemyFilter.liste.ForEach(spriteEnnemy =>
                {
                    ennemyDistance = Tools.EnnemyDistanceFromWeapon(spriteWeapon, spriteEnnemy);
                    if (ennemyDistance < outOfRange) 
                    { 
                        ennemyInRange = ennemyDistance;
                        missileTarget = spriteEnnemy;
                    }
                });
                if (ennemyInRange < outOfRange) 
                { 
                    spriteWeapon.isEnnemyInRange = true;
                    spriteWeapon.angle = Tools.AngleWeaponEnnemy(spriteWeapon);
                    spriteWeapon.spriteEnnemy = missileTarget;
                }
                else
                {                   
                    spriteWeapon.frame = 0;
                }
            });
                return this;
        }

        static void AddMissile7X(Game mainGame, SpriteWeapon spriteWeapon)
        {
            SceneMap.spriteMissileFilter.AddMissile(mainGame,
                                 "MISSILETOWER7LEVEL1",
                            new Vector2(spriteWeapon.position.X, spriteWeapon.position.Y - 40),
                            new Vector2(0, -30),
                            spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType, spriteWeapon);
            if (spriteWeapon.weaponLevel >= 2)
                SceneMap.spriteMissileFilter.AddMissile(mainGame,
                        "MISSILETOWER7LEVEL2",
                   new Vector2(spriteWeapon.position.X, spriteWeapon.position.Y + 40),
                   new Vector2(0, 30),
                   spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType, spriteWeapon);

            if (spriteWeapon.weaponLevel >= 3)
            {
                SceneMap.spriteMissileFilter.AddMissile(mainGame,
                        "MISSILETOWER7LEVEL3",
                   new Vector2(spriteWeapon.position.X - 40, spriteWeapon.position.Y),
                   new Vector2(-30, 0),
                   spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType, spriteWeapon);
                SceneMap.spriteMissileFilter.AddMissile(mainGame,
                        "MISSILETOWER7LEVEL3",
                   new Vector2(spriteWeapon.position.X + 40, spriteWeapon.position.Y),
                   new Vector2(30, 0),
                   spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType, spriteWeapon);
            }
        }
        
        public SpriteWeaponFilter CooldownShootIsUp(Game mainGame, SceneMap pCurrentScene)
        {
            string missileID;
            liste.ForEach(spriteWeapon => 
            {
                if (spriteWeapon.currentAnimation.isFinished && spriteWeapon.isEnnemyInRange)
                {
                    missileID = "MISSILETOWER" + spriteWeapon.weaponType + "LEVEL" + spriteWeapon.weaponLevel.ToString();
                    Vector2 velocity = Tools.VelocityAngleSpeed(spriteWeapon.angle, spriteWeapon.speedMissile);
                    if (spriteWeapon.weaponType == "7")
                    {
                        AddMissile7X(mainGame, spriteWeapon);
                    }
                    else if (spriteWeapon.weaponType == "8")
                    {
                        SceneMap.spriteImpactFilter.AddImpact8(mainGame, spriteWeapon);
                    }
                    else
                    {
                        SceneMap.spriteMissileFilter.AddMissile(mainGame,
                             missileID,
                             Tools.originePositionMissile(spriteWeapon.position, velocity, missileID),
                             velocity,
                             spriteWeapon.weaponLevel, spriteWeapon.towerLevel, spriteWeapon.weaponType, spriteWeapon);
                    }
                    spriteWeapon.frame = 0;
                    spriteWeapon.currentAnimation.isFinished = false;
                    spriteWeapon.isEnnemyInRange = false;
                }                
            });
            return this;
        }
    }
}